﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe;
using System.Net.Http.Headers;
using System.Text;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private IZoomMeetingManager _ZoomMeetingManager;
        private IAppointmentManager _AppointmentManager;
        private int appointmentId=1;
        public MeetingController(IZoomMeetingManager zoomMeetingManager,IAppointmentManager appointmentManager)
        {
            
            _ZoomMeetingManager = zoomMeetingManager;
            _AppointmentManager = appointmentManager;
        }
        [HttpGet]
        public async Task<string> Get(string code)
        {
            var username = "75Vsq2TiT8WBkw3Axb7pJA";
            var password = "j8aLbYB18LnBibjKCzJJ7MKvXjMQ4maR";
            using var client = new HttpClient();

            var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ':' + password));
            // Add headers to HttpClient
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);
            var parameters = new Dictionary<string, string>
            {
                { "code", code },
                { "grant_type","authorization_code" },
                { "redirect_uri","https://localhost:4200/meeting/doctor" },
            };

            var content = new FormUrlEncodedContent(parameters);

            var response = await client.PostAsync("https://zoom.us/oauth/token", content);


            var responseBody = await response.Content.ReadAsStringAsync();

            // Parse response as JSON object
            //var responseObject = JsonConvert.DeserializeObject<dynamic>(responseBody);
            var responseObject = JObject.Parse(responseBody);
            var accessToken = responseObject["access_token"]?.Value<string>();
            //return  responseBody;


            // Set the request URL and body
            var url = "https://api.zoom.us/v2/users/me/meetings";
            var settings = new
            {
                host_video = "true",
                participant_video = "true",
                join_before_host = "true",
                mute_upon_entry = "true"

            };
            var body = new
            {
                topic = "first meeting",
                type = "2",
                start_time = "2023-6-11T12:02:33",
                duration = "60",
                timezone = "Africa/Cairo",
                password = "123",
                agenda = "testing",
                settings = settings
            };
            var jsonBody = JsonConvert.SerializeObject(body);


            // Set the request headers
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", "MyHttpClient/1.0");
            client.DefaultRequestHeaders
                .TryAddWithoutValidation("Content-Type", "application/json");

            // Send the POST request
            var response2 = await client.PostAsync(url, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            // Handle the response
            var responseContent = await response2.Content.ReadAsStringAsync();
            var responseObject2 = JObject.Parse(responseContent);
            var zoomMeetingAddDto = new ZoomMeetingAddDto
            {
                MeetingId = responseObject2["id"]?.Value<string>()!,
                Password = responseObject2["password"]?.Value<string>()!,
                Duration = responseObject2["duration"].Value<int>(),
                StartTime = responseObject2["start_time"].Value<DateTime>(),
            };

            var newZoomMeetingId = await _ZoomMeetingManager.Add(zoomMeetingAddDto);

            var appointmentUpdateDto = new AppointmentUpdateDto();

            appointmentUpdateDto.appointmentId = appointmentId;
            appointmentUpdateDto.meetingId = newZoomMeetingId;

            var isUpdated = _AppointmentManager.UpdateAppointment(appointmentUpdateDto);
           
            
            //var responseObject2 = JObject.Parse(responseContent);
            //var meetingId = responseObject2["id"].Value<long>();
            //var meetingPassword = responseObject2["password"].Value<string>();

            return responseContent;
        }
        // 
		[HttpGet("join")]
        public ActionResult<ZoomMeetingReadDto> JoinMeeting(int appointmentId)
        {
            var zoomData = _ZoomMeetingManager.GetMeetingByAppointmentID(appointmentId);

            if (zoomData == null) return NotFound();

			return Ok(zoomData);
        }

	}
}
