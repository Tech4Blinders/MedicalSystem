using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpGet]
        public ActionResult<List<AppointmentReadDto>> GetAllAppointments()
        {
            var appointments = _appointmentManager.GetAllAppointments();
            if (appointments == null)
            {
                return NoContent();
            }
            return Ok(appointments);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<AppointmentReadDto> GetAppointmentById(int id)
        {
            var appointment = _appointmentManager.GetAppointmentById(id);
            if (appointment == null)
            {
                return NoContent();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public ActionResult AddAppointment(AppointmentAddDto newAppointment)
        {
            int newAppointmentId = _appointmentManager.AddAppointment(newAppointment);
            return CreatedAtAction("GetAppointmentById", new { id = newAppointmentId }, new { m = "Appointment has been added successfully" });
        }

        [HttpDelete]
        public ActionResult DeleteAppointment(int id)
        {
            _appointmentManager?.DeleteAppointment(id);
            return NoContent();
        }

        //[HttpPut]
        //public ActionResult UpdateAppointment(AppointmentUpdateDto appointmentToUpdate)
        //{
        //    bool isFound = _appointmentManager.UpdateAppointment(appointmentToUpdate);
        //    if (isFound)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}
    }
}
