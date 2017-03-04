using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using SimpleCertService.Bussiness.ViewModels;
using SimpleCertService.Bussiness.Helpers;

namespace SimpleCertService.Service
{
    public class CertificateService : ICertificateService
    {
        public IEnumerable<SimpleX509Dto> Certificates()
        {
            SetHeaders();
            try
            {
                return X509Helper.GetCertificates();
            }
            catch (Exception e)
            {

                throw new WebFaultException<Exception>(new Exception(e.Message), HttpStatusCode.InternalServerError);
            }
        }

        public X509Dto CertificateDetails(string hash)
        {
            SetHeaders();
            try
            {
                var x509 = X509Helper.FindCertificate(hash);
                if (x509 == null)
                {
                    throw new WebFaultException<NullReferenceException>(new NullReferenceException("Certificate was not found."),
                        HttpStatusCode.NotFound);
                }
                return new X509Dto(x509);
            }
            catch (WebFaultException<NullReferenceException>)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new WebFaultException<Exception>(new Exception(e.Message), HttpStatusCode.InternalServerError);
            }
        }

        public IEnumerable<CSPDto> SystemCryptoProviders()
        {
            SetHeaders();
            try
            {
                return CSPHelper.ReadAllProviders();
            }
            catch (Exception e)
            {

                throw new WebFaultException<Exception>(new Exception(e.Message), HttpStatusCode.InternalServerError);
            }
        }

        private static void SetHeaders()
        {
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
