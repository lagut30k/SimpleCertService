using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;

namespace SimpleCertService.Bussiness.ViewModels
{
    [DataContract]
    public class X509Dto
    {
        public X509Dto(X509Certificate2 x509)
        {
            ContentType = X509Certificate2.GetCertContentType(x509.RawData).ToString();
            PublicKey = x509.GetPublicKeyString();
            IsVerified = x509.Verify();
            SimpleName = x509.GetNameInfo(X509NameType.SimpleName, true);
            SignatureAlgorithm = x509.SignatureAlgorithm.FriendlyName;
            IsArchived = x509.Archived;
            Thumbprint = x509.Thumbprint;
            RawData = x509.GetRawCertDataString();
        }

        [DataMember(Name = "contentType")]
        public string ContentType { get; set; }

        [DataMember(Name = "publicKey")]
        public string PublicKey { get; set; }

        [DataMember(Name = "isVerified")]
        public bool IsVerified { get; set; }

        [DataMember(Name = "simpleName")]
        public string SimpleName { get; set; }

        [DataMember(Name = "signatureAlgorithm")]
        public string SignatureAlgorithm { get; set; }

        [DataMember(Name = "isArchived")]
        public bool IsArchived { get; set; }

        [DataMember(Name = "rawData")]
        public string RawData { get; set; }

        [DataMember(Name = "thumbprint")]
        public string Thumbprint { get; set; }

    }
}
