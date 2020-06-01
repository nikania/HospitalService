using HospitalService.Data.Repositories;
using HospitalService.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Doctor> ChangeDoctor(Doctor doctor)
        {
            doctor.FirstName.Any(c => char.IsLetter(c));
            doctor.LastName.Any(c => char.IsLetter(c));

            return await _repository.ChangeDoctor(doctor);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            doctor.FirstName.Any(c => char.IsLetter(c));
            doctor.LastName.Any(c => char.IsLetter(c));

            return await _repository.CreateDoctor(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            return await _repository.DeleteDoctor(id);
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _repository.GetDoctor(id);
        }

        public async Task<List<Patient>> GetDoctorPatients(int id)
        {
            return await _repository.GetDoctorPatients(id);
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _repository.GetDoctors();
        }
    }
}
