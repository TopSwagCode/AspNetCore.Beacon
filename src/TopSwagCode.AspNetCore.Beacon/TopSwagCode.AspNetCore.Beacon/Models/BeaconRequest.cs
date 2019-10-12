using System;
using System.Text.Json.Serialization;


namespace TopSwagCode.AspNetCore.Beacon.Models
{
    public class BeaconRequest
    {
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("userTime")]
        public DateTimeOffset UserTime { get; set; }
    }
}