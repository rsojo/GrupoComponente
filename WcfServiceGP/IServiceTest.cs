using GrupoComponente.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceGP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceTest" in both code and config file together.
    [ServiceContract]
    public interface IServiceTest
    {
        [OperationContract]
        Response<User> GetUsers(Int64? id);
        //Response<User> GetUser();

        [OperationContract]
        Response<User> SetUser(User user);

        [OperationContract]
        Response<User> DelUser(Int64 id);
    }
}
