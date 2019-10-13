

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopSwagCode.AspNetCore.Beacon.Data
{
    public class Analytic
    {
        public string State { get; set; }
        public DateTimeOffset UserTime { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}