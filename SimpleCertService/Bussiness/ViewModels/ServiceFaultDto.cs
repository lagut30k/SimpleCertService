using System.Runtime.Serialization;

namespace SimpleCertService.Bussiness.ViewModels
{
    [DataContract]
    public class ServiceFaultDto
    {
        public ServiceFaultDto(string message)
        {
            Message = message;
        }

        [DataMember]
        public string Message { get; set; }
    }
}
