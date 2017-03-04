using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SimpleCertService.Bussiness.ViewModels;

namespace SimpleCertService.Service
{
    [ServiceContract]
    public interface ICertificateService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<SimpleX509Dto> Certificates();

        [OperationContract]
        [FaultContract(typeof(ServiceFaultDto))]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/certificatedetails/{s}")]
        X509Dto CertificateDetails(string s);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<CSPDto> SystemCryptoProviders();
    }
}
