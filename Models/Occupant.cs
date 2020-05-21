using Newtonsoft.Json;

namespace RentDynamics.DotNet.Models
{
    public class Occupant
    {
        [JsonProperty(PropertyName = "personId")]
        public int PersonId { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "primaryLeadId")]
        public int? PrimaryLeadId { get; set; }

        [JsonProperty(PropertyName = "relatedPersonId")]
        public int? RelatedPersonId { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "relationshipId")]
        public int? RelationshipId { get; set; }

        [JsonProperty(PropertyName = "isLessee")]
        public bool IsLessee { get; set; }
    }
}
