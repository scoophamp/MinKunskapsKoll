using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KunskapskollMVCLabb.Models;

namespace KunskapskollMVCLabb.Controllers
{
    public class AdressBokController : Controller
    {
        static List<AdressBok> adressBok = new List<AdressBok>();
        public ActionResult Index()
        {
            AdressBok newAdressBok = new AdressBok();
            return View(newAdressBok);
        }
        [HttpPost]
        public ActionResult Create(AdressBok adressbok)
        {
            adressbok.ID = Guid.NewGuid();
            adressbok.UpdatedDate = DateTime.Now;
            adressBok.Add(adressbok);
            return PartialView("List",adressBok);
        }
        public ActionResult ListaAlla()
        {
            return PartialView("List", adressBok);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var delete = adressBok.First(x => x.ID == id);
            adressBok.Remove(delete);
            return PartialView("List", adressBok);
        }
        public ActionResult Edit(AdressBok adressbok)
        {
            var edit = adressBok.Find(x => x.ID == adressbok.ID);
            return PartialView("Edit", edit);
        }
        [HttpPost]
        public ActionResult Edit(AdressBok adressbok,FormCollection formcollection)
        {
            var edit = adressBok.Find(x => x.ID == adressbok.ID);
            edit.Name = adressbok.Name;
            edit.Adress = adressbok.Adress;
            edit.PhoneNumber = adressbok.PhoneNumber;
            return PartialView("List", adressBok);
        }
    }
}