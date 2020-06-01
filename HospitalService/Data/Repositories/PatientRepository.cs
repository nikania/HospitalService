using HospitalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public Task<Patient> GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Card> GetPatientCard(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Doctor>> GetPatientDoctors(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetPatients()
        {
            throw new NotImplementedException();
        }
    }
}
