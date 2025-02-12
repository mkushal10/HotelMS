﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class Booking
    {
        public int ID { get; set; }

        public int AccommodationID { get; set; }
        public Accommodation Accommodation { get; set; }

        public DateTime FromDate { get; set; }

        /// <summary>
        /// No Of Stay Nights
        /// </summary>
        public int Duration { get; set; }
    }
}
