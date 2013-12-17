using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Data.Interfaces
{
    //[ServiceContract]
    interface IPersistence<T>
    {
        //[OperationContract]
        bool Create(T Entity);
        List<T> Read(short by, object value);
        bool Update(T Entity);
        List<T> GetList();

    }
}
