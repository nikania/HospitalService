using HospitalService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDBContext _context;

        public DoctorRepository(HospitalDBContext context)
        {
            _context = context;
        }
        public async Task<Doctor> ChangeDoctor(Doctor doctor)
        {
            var changedDoctor = await _context.Doctors.FirstOrDefaultAsync(x=> x.DoctorId==doctor.DoctorId);
            changedDoctor.FirstName = doctor.FirstName;
            changedDoctor.LastName = doctor.LastName;
            await _context.SaveChangesAsync();
            return changedDoctor;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            var doctorCreated = await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctorCreated.Entity;
        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.SingleAsync(x => x.DoctorId == id);
            var deletedDoctor = _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return deletedDoctor.Entity;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);
        }

        public async Task<List<Patient>> GetDoctorPatients(int id)
        {
            return await _context.Patients
                                            .Where(x => x.Card.Records.Where(x => x.DoctorId == id) != null).ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }
    }
}
