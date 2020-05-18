using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Models
{
    //record in health card during visit to doctor
    public class Record
    {
        public int RecordId { get; set; }
        public DateTime Date { get; set; }
        public string Entry { get; set; }


        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
       
    }
}
