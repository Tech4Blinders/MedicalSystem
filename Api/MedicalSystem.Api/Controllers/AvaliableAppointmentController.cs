using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliableAppointmentController : ControllerBase
    {
        private readonly IAvaliableAppointmentManager _avaliableAppointmentManager;

        public AvaliableAppointmentController(IAvaliableAppointmentManager avaliableAppointmentManager)
        {
            _avaliableAppointmentManager = avaliableAppointmentManager;
        }
        [HttpGet]
        public ActionResult<List<AvaliableAppointmentReadDto>> GetAll()
        {
            var avaliableAppointment = _avaliableAppointmentManager.GetAll();
            if (avaliableAppointment.Count == 0)
            {
                return NoContent();
            }
            return Ok(avaliableAppointment);
        }

        [HttpGet("{id}")]
        public ActionResult<AvaliableAppointmentReadDto> Get(int id)
        {
            var patient = _avaliableAppointmentManager.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet]
        [Route("DoctorAvailableAppointments/{id}")]
        public ActionResult<List<AvaliableAppointmentReadDto>> GetAllByDoctorId(int id)
        {
            List<AvaliableAppointmentReadDto> availableAppointments = _avaliableAppointmentManager.GetByDoctorId(id);
            if (availableAppointments is null)
            {
                return NoContent();
            }
            return Ok(availableAppointments);
        }

        [HttpPost]
        public ActionResult Add(AvaliableAppointmentAddDto patientDto)
        {
            var newId = _avaliableAppointmentManager.Add(patientDto);
            return CreatedAtAction("Get", new { id = newId }, new { m = "AvaliableAppointment has been added successfully" });

        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public ActionResult Update(AvaliableAppointmentUpdateDto appDto)
        {
            var isFound = _avaliableAppointmentManager.Update(appDto);
            if (!isFound)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _avaliableAppointmentManager.Delete(id);
            return NoContent();
        }

        [HttpPost]
        [Route("MakeReservation")]
        public ActionResult<bool> MakeReservation(ReservationDto reservation)
        {
            bool isReserved = _avaliableAppointmentManager.MakeReservation(reservation);
            if (!isReserved)
            {
                return BadRequest();
            }
            return Ok(isReserved);
        }
    }
}
