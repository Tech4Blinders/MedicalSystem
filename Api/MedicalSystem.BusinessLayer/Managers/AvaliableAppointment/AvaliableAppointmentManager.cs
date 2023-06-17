using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer
{
    public class AvaliableAppointmentManager : IAvaliableAppointmentManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public AvaliableAppointmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Add(AvaliableAppointmentAddDto entity)
        {
            var avaliableAppointment = new AvaliableAppointment
            {
                DoctorId= entity.DoctorId,
                Date= entity.Date,
            };
            _unitOfWork._AvaliableAppointmentRepo.AddAsync(avaliableAppointment);
            _unitOfWork.SaveChanges();
            return avaliableAppointment.Id;
        }

        public  void Delete(int id)
        {
            var avaliableAppointment =  _unitOfWork._AvaliableAppointmentRepo.GetByIdAsync(id).Result;
            if (avaliableAppointment is null)
            {
                return;
            }
            _unitOfWork._AvaliableAppointmentRepo.Delete(avaliableAppointment);
            _unitOfWork.SaveChanges();
        }

        public  List<AvaliableAppointmentReadDto> GetAll()
        {
            var appointment = _unitOfWork._AvaliableAppointmentRepo.GetAllAsyn().Result;
            if(appointment is null)
            {
                return new List<AvaliableAppointmentReadDto>();
            }

            return appointment.Select(a => new AvaliableAppointmentReadDto
            {
                DoctorId = a.DoctorId,
                Date = a.Date
            }).ToList();

        }

        public AvaliableAppointmentReadDto? GetById(int id)
        {
            var appointment = _unitOfWork._AvaliableAppointmentRepo.GetById(id);
            if(appointment is null)
            {
                return new AvaliableAppointmentReadDto();
            }
            return new AvaliableAppointmentReadDto
            {
                DoctorId= appointment.DoctorId,
                Date=appointment.Date
            };
        }

        public List<AvaliableAppointmentReadDto> GetByDoctorId(int doctorId)
        {
            var avaliableAppointments = _unitOfWork._AvaliableAppointmentRepo
                                                                            .GetAllAsyn()
                                                                            .Result
                                                                            .Where(available => available.DoctorId == doctorId);
            
            if(avaliableAppointments is null)
            {
                return new List<AvaliableAppointmentReadDto>();
            }

            return avaliableAppointments.Select(available => new AvaliableAppointmentReadDto
            {
                DoctorId = available.DoctorId,
                Date = available.Date
            }).ToList();
        }

        public bool Update(AvaliableAppointmentUpdateDto entity)
        {
            var appointment = _unitOfWork._AvaliableAppointmentRepo.GetById(entity.Id);
            if (appointment is null)
            {
                return false;
            }
            appointment.DoctorId=entity.DoctorId;
            appointment.Date = entity.Date;
            _unitOfWork._AvaliableAppointmentRepo.Update(appointment);
            _unitOfWork.SaveChanges();
            return true;

        }

        public bool MakeReservation(ReservationDto reservation)
        {
            bool isReserved = false;
            bool isAdded = false;
            bool isDeleted = false;
            
            Appointment appointment = new Appointment
            {
                PatientId = reservation.PatientId,
                DoctorId = reservation.DoctorId,
                BranchId = reservation.BranchId,
                AppointmentDate = reservation.Date,
                Cost = reservation.Cost,
            };

            AvaliableAppointment? avaliableAppointment = _unitOfWork._AvaliableAppointmentRepo
                                                                    .GetAllAsyn()
                                                                    .Result
                                                                    .FirstOrDefault(available =>
                                                                                    available.DoctorId == reservation.DoctorId
                                                                                    &&
                                                                                    available.Date == reservation.Date);
            if (avaliableAppointment == null)
            {
                return false;
            }

            try
            {
                _unitOfWork._AppointmentRepo.AddAsync(appointment);
                isAdded = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (isAdded)
            {
                try
                {
                    _unitOfWork._AvaliableAppointmentRepo.Delete(avaliableAppointment);
                    isDeleted = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            if (isDeleted && isAdded)
            {
                _unitOfWork.SaveChanges();
                isReserved = true;
            }

            return isReserved;
        }
    }
}
