using GrupoComponente.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoComponente.Web.Controllers
{
    public class UsersController : Controller
    {
        List<SelectListItem> lstSex;
        public UsersController() {
            lstSex = new List<SelectListItem>();

            lstSex.Add(new SelectListItem() { Text = "Femenino", Value = "f" });
            lstSex.Add(new SelectListItem() { Text = "Masculino", Value = "m" });
            lstSex.Add(new SelectListItem() { Text = "Otro", Value = "o" });
        } 
        // GET: Users
        public ActionResult UsuarioConsulta()
        {
            var response = new ServiceReferenceTestGP.ServiceTestClient().GetUsers(0);
            if (response.Error)
            {
                return RedirectToAction("Error");
            }
            return View(response.Lst);
        }
        // GET: Users
        public ActionResult Error()
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //var response = new ServiceReferenceTestGP.ServiceTestClient().GetUsers();
                //if (response.Error)
                //{
                //    return RedirectToAction("Error");
                //}

                return RedirectToAction("UsuarioConsulta");

            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            var response = new ServiceReferenceTestGP.ServiceTestClient().GetUsers(id);
            if (response.Error)
            {
                return RedirectToAction("Error");
            }

            Web.Models.User user = new Web.Models.User() { Id = response.UnitResp.Id, BirthDay = response.UnitResp.BirthDay, Name = response.UnitResp.Name, Sex = response.UnitResp.Sex };
            foreach (var item in lstSex)
            {
                if (item.Value[0] == user.Sex)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.Sexes = lstSex;
            user.BirthDay.ToString("MM/dd/YYYY");


            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var user = new GrupoComponente.Data.Entidades.User();
                user.Id = Int64.Parse(collection.GetValue("Id").AttemptedValue);
                user.Name = collection.GetValue("Name").AttemptedValue;
                user.Sex = collection.GetValue("Sex").AttemptedValue[0];
                if (collection.GetValue("BirthDay").AttemptedValue != "")
                {
                    user.BirthDay = DateTime.ParseExact(collection.GetValue("BirthDay").AttemptedValue, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                }
                var response = new ServiceReferenceTestGP.ServiceTestClient().SetUser(user);
                if (response.Error)
                {
                    return RedirectToAction("Error");
                }

                return RedirectToAction("UsuarioConsulta");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            var response = new ServiceReferenceTestGP.ServiceTestClient().GetUsers(id);
            if (response.Error)
            {
                return RedirectToAction("Error");
            }

            Web.Models.User user = new Web.Models.User() { Id = response.UnitResp.Id, BirthDay = response.UnitResp.BirthDay, Name = response.UnitResp.Name, Sex = response.UnitResp.Sex };
            foreach (var item in lstSex)
            {
                if (item.Value[0] == user.Sex)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.Sexes = lstSex;
            user.BirthDay.ToString("MM/dd/YYYY");


            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                var response = new ServiceReferenceTestGP.ServiceTestClient().DelUser(id);
                if (response.Error)
                {
                    return RedirectToAction("Error");
                }

                return RedirectToAction("UsuarioConsulta");
            }
            catch
            {
                return View();
            }
        }
    }
}
