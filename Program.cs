using System;
using System.Linq;
using System.Collections.Generic;
using RentDynamics.DotNet.Common;
using RentDynamics.DotNet.Models;

namespace RentDynamics.DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            int communityGroupId = 6079;
            int communityId = 6507;
            int adSourceId = 4085;
            // This represents the maximum number of days available for available dates
            int numberOfAvailableDays = 90-1;
            string url = "https://api-dev.rentdynamics.com";
            string apiKey = "myapikey";
            string apiSecretKey = "myapisecretkey";
            bool isProd = false;

            DateTime dateOfInterest = DateTime.Parse("05/21/2020").Date;
            DateTime moveDate = DateTime.Parse("2020-07-01").Date;
            double bathrooms = 1.5;
            double bedrooms = 2;
            // (optional) 3 is chat, 2 is e - mail, 13 is text, defaults to 14 which is web lead
            int communicationTypeId = 14;
            string email = "testlead@somedomain.com";
            string firstName = "Skyler";
            string lastName = "Cain";
            string phoneNumber = "7145958867";
            string note = "Note text";

            var api = new ApiService(url, apiKey, apiSecretKey, isProd);

            var start = DateTime.Now.Date;
            var end = (start.AddDays(numberOfAvailableDays)).Date;

            var availableDays = api.Get<List<string>>($"/appointmentDays/{communityGroupId}?start={start:MM/dd/yyyy}&end={end:MM/dd/yyyy}");

            Console.WriteLine("Available Days:");
            foreach (var ds in availableDays)
            {
                var dt = DateTimeOffset.Parse(ds).Date;
                Console.WriteLine(dt.ToString("MM/dd/yyyy"));
            }
            Console.WriteLine(Environment.NewLine);

            var availableTimes = api.Get<List<string>>($"/appointmentTimes/{communityGroupId}?utc=true&appointmentDate={dateOfInterest:MM/dd/yyyy}");

            Console.WriteLine("Available Times:");
            foreach (var ds in availableTimes)
            {
                var dt = DateTimeOffset.Parse(ds);
                Console.WriteLine(dt.ToString("hh:mm tt"));
            }
            Console.WriteLine(Environment.NewLine);

            var appointmentDate = DateTime.Parse(availableTimes.First());
            var request = new LeadSubmissionRequest { 
                AdSourceId = adSourceId,
                AppointmentDate = appointmentDate.ToString("o"),
                Bathrooms = bathrooms,
                Bedrooms = bedrooms,
                CommunicationTypeId = communicationTypeId,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                MoveDate = moveDate.ToString("yyyy-MM-dd"),
                PhoneNumber = phoneNumber,
                Note = note
            };
            var response = api.PostObject<LeadSubmissionResponse>($"/communities/{communityId}/leadCards", request);

            Console.WriteLine("Lead Submission Post:");
            Console.WriteLine($"LeadId: {response.LeadId}");
        }
    }
}
