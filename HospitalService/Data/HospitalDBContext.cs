using HospitalService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data
{
    public class HospitalDBContext: DbContext
    {
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options)
     : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
