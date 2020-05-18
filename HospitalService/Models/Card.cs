using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Models
{
    // medical health card
    public class Card
    {
        public int CardId { get; set; }
        public DateTime OpenDate { get; set; }


        public List<Record> Records { get; set; }

        public Patient Patient { get; set; }
    }
}
