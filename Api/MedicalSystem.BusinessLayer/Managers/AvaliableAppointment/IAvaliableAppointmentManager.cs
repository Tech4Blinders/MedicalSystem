﻿using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer
{
    public interface IAvaliableAppointmentManager
    {
        public List<AvaliableAppointmentReadDto> GetAll();
        public AvaliableAppointmentReadDto? GetById(int id);

        public int Add(AvaliableAppointmentAddDto entity);

        public bool Update(AvaliableAppointmentUpdateDto entity);

        public void Delete(int id);
    }
}
