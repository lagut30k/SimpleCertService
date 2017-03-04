using System.Runtime.Serialization;

namespace SimpleCertService.Bussiness.ViewModels
{
    [DataContract]
    public class CSPDto
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "type")]
        public string TypeName;
    }
}
