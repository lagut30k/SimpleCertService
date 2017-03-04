using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

using SimpleCertService.Bussiness.ViewModels;

namespace SimpleCertService.Bussiness.Helpers
{
    public static class X509Helper
    {
        public static IEnumerable<SimpleX509Dto> GetCertificates()
        {
            return ReadCertificates()
                .Cast<X509Certificate2>()
                .Select(x509Certificate2 => new SimpleX509Dto(x509Certificate2));
        }

        public static X509Certificate2 FindCertificate(string thumbprint)
        {
            var x509 = GetCertificateByThumbprint(thumbprint);
            if (x509 != null)
            {
                LastedCertificateThumbprint = x509.Thumbprint;
            }
            return x509;
        }

        public static bool ShowStoredCertificate()
        {
            X509Certificate2 x509;
            if (LastedCertificateThumbprint == null || (x509 = GetCertificateByThumbprint(LastedCertificateThumbprint)) == null)
            {
                return false;
            }
            X509Certificate2UI.DisplayCertificate(x509);
            return true;
        }

        private static X509Certificate2 GetCertificateByThumbprint(string thumbprint)
        {
            return ReadCertificates()
                    .Find(X509FindType.FindByThumbprint, thumbprint, false)
                    .Cast<X509Certificate2>()
                    .FirstOrDefault();
        }

        private static X509Certificate2Collection ReadCertificates()
        {
            var store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            return store.Certificates;
        }

        private static string LastedCertificateThumbprint { get; set; }
    }
}
