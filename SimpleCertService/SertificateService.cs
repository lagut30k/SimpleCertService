using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using SimpleCertService.Bussiness.ViewModels;

namespace SimpleCertService
{
    class SertificateService : ISertificateService
    {
        public IEnumerable<SimpleX509Dto> List(/*string s*/)
        {
            SimpleX509Dto first = new SimpleX509Dto() { Name = "1", PublicKey = "2" };
            var list = new List<SimpleX509Dto> { first };
            return list;
        }

        public X509Dto Details(string s)
        {
            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection;//.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
            var t = fcollection[0];
            return new X509Dto(fcollection[0]);
        }
    }
}
