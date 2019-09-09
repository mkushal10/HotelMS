using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationPackagesService
    {
        public IEnumerable<AccommodationPackage> GetAllAccomodationPackages()
        {
            var context = new HMSContext();

            return context.AccommodationPackages.ToList();
        }
        public IEnumerable<AccommodationPackage> SearchAllAccomodationPackages(string searchTerm)
        {
            var context = new HMSContext();

            var accomodationPackages = context.AccommodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationPackages = accomodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return accomodationPackages.ToList();
        }

        public AccommodationPackage GetAllAccomodationPackageByID(int ID)
        {
            var context = new HMSContext();

            return context.AccommodationPackages.Find(ID);
        }

        public bool SaveAccomodationPackage(AccommodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.AccommodationPackages.Add(accomodationPackage);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccomodationPackage(AccommodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodationPackage(AccommodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}