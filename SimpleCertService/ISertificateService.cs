using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Security.Cryptography.X509Certificates;
using SimpleCertService.Bussiness.ViewModels;

namespace SimpleCertService
{
    [ServiceContract]
    interface ISertificateService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<SimpleX509Dto> List(/*string s*/);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        X509Dto Details(string s);
    }
}
