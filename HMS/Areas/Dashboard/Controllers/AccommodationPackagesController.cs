using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccommodationPackagesController : Controller
    {
        AccomodationPackagesService accomodationPackagesService = new AccomodationPackagesService();
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        public ActionResult Index(string searchTerm)
        {
            AccomodationPackagesListingModel model = new AccomodationPackagesListingModel();
            model.SearchTerm = searchTerm;
            //model.AccomodationPackages = accomodationPackagesService.SearchAllAccomodationPackages(searchTerm);
            return View(model);
        }
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationPackagesActionModel model = new AccomodationPackagesActionModel();
            if (ID.HasValue)
            {
                var accomodationPackage = accomodationPackagesService.GetAllAccomodationPackageByID(ID.Value);

                model.ID = accomodationPackage.ID;
                model.Name = accomodationPackage.Name;
                model.NoOfRoom = accomodationPackage.NoOfRoom;
                model.FeePerNight = accomodationPackage.FeePerNight;
            }
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationPackagesActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var accomodationPackage = accomodationPackagesService.GetAllAccomodationPackageByID(model.ID);
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRoom = model.NoOfRoom;
                accomodationPackage.FeePerNight = model.FeePerNight;
                result = accomodationPackagesService.UpdateAccomodationPackage(accomodationPackage);
            }
            else
            {
                AccommodationPackage accomodationPackage = new AccommodationPackage();
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRoom = model.NoOfRoom;
                accomodationPackage.FeePerNight = model.FeePerNight;
                result = accomodationPackagesService.SaveAccomodationPackage(accomodationPackage);
            }

            if (result)
            {
                json.Data = new { Sucess = true };
            }
            else
            {
                json.Data = new { Sucess = false, Message = "Unable to perform action on Accomodation type" };
            }
            return json;
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationPackagesActionModel model = new AccomodationPackagesActionModel();
            var accomodationPackage = accomodationPackagesService.GetAllAccomodationPackageByID(ID);
            model.ID = accomodationPackage.ID;
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationPackagesActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var accomodationPackage = accomodationPackagesService.GetAllAccomodationPackageByID(model.ID);
            accomodationPackage.Name = model.Name;
            accomodationPackage.NoOfRoom = model.NoOfRoom;
            accomodationPackage.FeePerNight = model.FeePerNight;
            result = accomodationPackagesService.DeleteAccomodationPackage(accomodationPackage);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation type" };
            }
            return json;
        }
    }
}