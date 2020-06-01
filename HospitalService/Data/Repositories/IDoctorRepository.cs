using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> CreateDoctor(Doctor doctor);
        Task<Doctor> ChangeDoctor(Doctor doctor);
        Task<Doctor> DeleteDoctor(int id);
        Task<List<Patient>> GetDoctorPatients(int id);
    }
}
