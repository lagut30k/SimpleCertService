using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;

namespace SimpleCertService.Bussiness.ViewModels
{
    [DataContract]
    public class SimpleX509Dto
    {
        public SimpleX509Dto(X509Certificate2 x509)
        {
            Name = x509.GetNameInfo(X509NameType.SimpleName, true); ;
            Thumbprint = x509.Thumbprint;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "thumbprint")]
        public string Thumbprint { get; set; }
    }
}
