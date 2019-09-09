using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Areas.Dashboard.ViewModels
{
    public class AccomodationPackagesListingModel
    {
        public IEnumerable<AccomodationType> AccomodationPackages { get; set; }
        public string SearchTerm { get; set; }
    }
    public class AccomodationPackagesActionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; }

        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
    }
}