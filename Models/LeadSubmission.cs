using Newtonsoft.Json;

namespace RentDynamics.DotNet.Models
{
    public class LeadSubmission
    {
        [JsonProperty(PropertyName = "adSourceId")]
        public int AdSourceId { get; set; }

        [JsonProperty(PropertyName = "appointmentDate")]
        public string AppointmentDate { get; set; }

        [JsonProperty(PropertyName = "bedrooms")]
        public double Bedrooms { get; set; }

        [JsonProperty(PropertyName = "bathrooms")]
        public double Bathrooms { get; set; }

        [JsonProperty(PropertyName = "communicationTypeId")]
        public int CommunicationTypeId { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "moveDate")]
        public string MoveDate { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }

}
