using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace RentDynamics.DotNet.Common
{
    public class ApiService
    {
        protected string _url = "https://api-dev.rentdynamics.com";
        protected string _apiKey = "490efa56-d";
        protected string _apiSecretKey = "1478aff2-977f-4831-8";
        protected bool _isProd = false;

        public ApiService() 
        { 
        }

        public ApiService(string url, string apiKey, string apiSecretKey, bool isProd)
        {
            _url = url;
            _apiKey = apiKey;
            _apiSecretKey = apiSecretKey;
            _isProd = isProd;
        }

        public T Get<T>(string endpoint) where T : new()
        {

            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };

            GetAuthHeaders(request, endpoint);

            var client = new RestClient { BaseUrl = GetFullUrl(endpoint) };

            var response = client.Execute<T>(request);


            if (response.ErrorException != null)
            {

                // todo: some error happened log it?

                return default(T);

            }

            return response.Data;

        }


        public T Post<T>(string endpoint, object payload) where T : new()
        {
            var request = new RestRequest
            {

                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };

            request.AddParameter("application/json", ToJSON(payload), ParameterType.RequestBody);
            GetAuthHeaders(request, endpoint, payload);

            var client = new RestClient { BaseUrl = GetFullUrl(endpoint) };
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                // todo: some error happened log it?
                return default(T);

            }

            return response.Data;
        }

        public T PostObject<T>(string endpoint, object payload) where T : new()
        {
            var request = new RestRequest
            {

                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };

            request.AddParameter("application/json", ToJSON(payload), ParameterType.RequestBody);
            GetAuthHeaders(request, endpoint, payload);

            var client = new RestClient { BaseUrl = GetFullUrl(endpoint) };
            var response = client.Execute<Dictionary<string, object>>(request);

            if (response.ErrorException != null)
            {
                // todo: some error happened log it?
                return default(T);
            }

            var obj = JObject.FromObject(response.Data);

            return obj.ToObject<T>();
        }

        public T Put<T>(string endpoint, object payload) where T : new()
        {

            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                Method = Method.PUT,
            };

            request.AddParameter("application/json", ToJSON(payload), ParameterType.RequestBody);
            GetAuthHeaders(request, endpoint, payload);

            var client = new RestClient { BaseUrl = GetFullUrl(endpoint) };
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                // todo: some error happened log it?
                return default(T);
            }

            return response.Data;
        }

        private void GetAuthHeaders(RestRequest request, string endpoint, object payload = null)
        {
            var timestamp = ((Int64)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();

            var json = ToJSON(payload);
            var nonce = GetNonce(timestamp, endpoint, json);

            request.AddHeader("x-rd-api-key", _apiKey);
            request.AddHeader("x-rd-timestamp", timestamp);
            request.AddHeader("x-rd-api-nonce", nonce.ToLower());
        }


        private string ToJSON(Object payload)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() };
            return payload != null ? JsonConvert.SerializeObject(payload, settings) : string.Empty;
        }

        private Uri GetFullUrl(string relativeUrl)
        {
            var baseUrl = new Uri(_url);
            return new Uri(baseUrl, relativeUrl);
        }

        private string GetNonce(string timestamp, string url, string data = "")
        {
            var nonceString = timestamp + url + data.Replace(" ", string.Empty);
            var enc = Encoding.UTF8;

            HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(_apiSecretKey));

            byte[] buffer = hmac.ComputeHash(enc.GetBytes(nonceString));

            return ByteToString(buffer);
        }

        private string ByteToString(byte[] buffer)
        {
            return buffer.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));
        }
    }
}