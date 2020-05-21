using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentDynamics.DotNet.Models
{
    public class Pet
    {
        [JsonProperty(PropertyName = "leadId")]
        public int LeadId { get; set; }

        [JsonProperty(PropertyName = "petTypeId")]
        public int PetTypeId { get; set; }

        [JsonProperty(PropertyName = "breed")]
        public string Breed { get; set; }

        [JsonProperty(PropertyName = "petName")]
        public string PetName { get; set; }

        [JsonProperty(PropertyName = "isServiceAnimal")]
        public bool IsServiceAnimal { get; set; }
    }
}
