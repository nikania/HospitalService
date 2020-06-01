using HospitalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class PatientService : IPatientService
    {
        public async Task<Patient> GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Card> GetPatientCard(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Doctor>> GetPatientDoctors(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Patient>> GetPatients()
        {
            throw new NotImplementedException();
        }
    }
}
