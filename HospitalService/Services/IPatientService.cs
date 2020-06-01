using HospitalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<Card> GetPatientCard(int id);
        Task<List<Doctor>> GetPatientDoctors(int id);
    }
}
