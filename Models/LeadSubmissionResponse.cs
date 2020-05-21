using Newtonsoft.Json;

namespace RentDynamics.DotNet.Models
{
    public class LeadSubmissionResponse : LeadSubmission
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "amenitites")]
        public int[] Amenitites { get; set; }

        [JsonProperty(PropertyName = "community")]
        public int Community { get; set; }

        [JsonProperty(PropertyName = "preferredCommunicationTypeId")]
        public int? PreferredCommunicationTypeId { get; set; }

        [JsonProperty(PropertyName = "secondaryPreferredCommunicationTypeId")]
        public int? SecondaryPreferredCommunicationTypeId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "endFollowUpReasonTypeId")]
        public int? EndFollowUpReasonTypeId { get; set; }

        [JsonProperty(PropertyName = "followUpDate")]
        public string FollowUpDate { get; set; }

        [JsonProperty(PropertyName = "leadId")]
        public int? LeadId { get; set; }

        [JsonProperty(PropertyName = "leaseTerm")]
        public int? LeaseTerm { get; set; }

        [JsonProperty(PropertyName = "moveReasonTypeId")]
        public int? MoveReasonTypeId { get; set; }

        [JsonProperty(PropertyName = "noAppointmentReasonTypeId")]
        public int? NoAppointmentReasonTypeId { get; set; }

        [JsonProperty(PropertyName = "occupants")]
        public Occupant[] Occupants { get; set; }

        [JsonProperty(PropertyName = "pets")]
        public Pet[] Pets { get; set; }

        [JsonProperty(PropertyName = "secondaryAdSourceId")]
        public int? SecondaryAdSourceId { get; set; }

        [JsonProperty(PropertyName = "trySms")]
        public bool? TrySms { get; set; }

        [JsonProperty(PropertyName = "unqualifiedReasonTypeId")]
        public int? UnqualifiedReasonTypeId { get; set; }

        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        [JsonProperty(PropertyName = "referrerSourceId")]
        public int? ReferrerSourceId { get; set; }
    }
}
