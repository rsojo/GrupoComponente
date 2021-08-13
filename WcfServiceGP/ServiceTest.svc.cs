using GrupoComponente.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceGP.Model;

namespace WcfServiceGP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceTest" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceTest.svc or ServiceTest.svc.cs at the Solution Explorer and start debugging.
    public class ServiceTest : IServiceTest
    {
        //public Response<User> GetUser(long id)
        //{
        //    var response = new Response<User>();
        //    try
        //    {
        //        using (DatabaseEntities1 context = new DatabaseEntities1())
        //        {
        //            var resp = context.SPGetUser(id).ToList().FirstOrDefault();
        //            if (resp != null)
        //            {
        //                response.UnitResp = new User() { Id = resp.id, BirthDay = resp.birthDay??new DateTime(), Name = resp.name, Sex = resp.sex[0] };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        response.Error = true;
        //        response.Msg = "Error en capa de Datos";
        //    }

        //    return response;
        //}
        public Response<User> GetUsers(long? id)
        {
            var response = new Response<User>();
            try
            {
                using (DatabaseEntities1 context = new DatabaseEntities1())
                {
                    if (id>0)
                    {

                        var resp = context.SPGetUser(id).ToList().FirstOrDefault();
                        if (resp != null)
                        {
                            response.UnitResp = new User() { Id = resp.id, BirthDay = resp.birthDay ?? new DateTime(), Name = resp.name, Sex = resp.sex[0] };
                        }
                    }
                    else
                    {
                        var resp = context.SPGetUser(id).ToList();
                        if (resp.Count > 0)
                        {

                            response.Lst = new List<User>();
                            foreach (var item in resp)
                            {
                                var itemx = new User() { Id = item.id, BirthDay = item.birthDay ?? new DateTime(), Name = item.name, Sex = item.sex[0] };
                                response.Lst.Add(itemx);

                            }
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {

                response.Error = true;
                response.Msg = "Error en capa de Datos";
            }

            return response;
        }
        public Response<User> DelUser(long id)
        {
            var response = new Response<User>();
            try
            {
                using (DatabaseEntities1 context = new DatabaseEntities1())
                {
                    var resp = context.SPDelUser(id).ToList().FirstOrDefault();
                    if (resp.Value > 0)
                    {
                        response.Msg = "Eliminado Completo";
                    }
                    else
                    {
                        response.Error = true;
                        response.Msg = "Error en capa de Datos SQL";
                    }
                }
            }
            catch (Exception ex)
            {

                response.Error = true;
                response.Msg = "Error en capa de Datos";
            }

            return response;
        }

        public Response<User> SetUser(User user)
        {
            var response = new Response<User>();
            try
            {
                using (DatabaseEntities1 context = new DatabaseEntities1())
                {
                    var resp = context.SPSetUser(user.Id, user.Name, user.BirthDay, user.Sex.ToString()).ToList().FirstOrDefault();
                    if (resp.Value > 0)
                    {
                        response.Msg = "Proceso Completo";
                    }
                    else
                    {
                        response.Error = true;
                        response.Msg = "Error en capa de Datos SQL";
                    }
                }
            }
            catch (Exception ex)
            {

                response.Error = true;
                response.Msg = "Error en capa de Datos";
            }

            return response;
        }
    }
}
