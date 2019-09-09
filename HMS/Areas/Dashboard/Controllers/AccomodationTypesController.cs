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
    public class AccomodationTypesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            model.SearchTerm = searchTerm;
            model.AccomodationTypes = accomodationTypesService.SearchAllAccomodationTypes(searchTerm);
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();
            if (ID.HasValue)
            {
                var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(ID.Value);

                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypesActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(model.ID);
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesService.UpdateAccomodationType(accomodationType);
            }
            else
            {
                AccomodationType accomodationType = new AccomodationType();
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesService.SaveAccomodationType(accomodationType);
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
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();
            var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(ID);
            model.ID = accomodationType.ID;
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationTypesActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var accomodationType = accomodationTypesService.GetAllAccomodationTypeByID(model.ID);
            accomodationType.Name = model.Name;
            accomodationType.Description = model.Description;
            result = accomodationTypesService.DeleteAccomodationType(accomodationType);
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