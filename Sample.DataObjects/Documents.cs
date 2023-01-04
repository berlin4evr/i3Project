using Newtonsoft.Json;

namespace Sample.DataObjects
{
    public class Documents
    {
        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("address")]
        public string Address;

        [JsonProperty("area")]
        public int Area;

        [JsonProperty("attachedbaths")]
        public int Attachedbaths;

        [JsonProperty("bedrooms")]
        public int Bedrooms;

        [JsonProperty("bhk")]
        public string Bhk;

        [JsonProperty("city")]
        public string City;

        [JsonProperty("filenumber")]
        public string Filenumber;

        [JsonProperty("furnish")]
        public string Furnish;

        [JsonProperty("halls")]
        public int Halls;

        [JsonProperty("iselectricity")]
        public bool Iselectricity;

        [JsonProperty("isfloodarea")]
        public bool Isfloodarea;

        [JsonProperty("isgas")]
        public bool Isgas;

        [JsonProperty("isother")]
        public bool Isother;

        [JsonProperty("isplayarea")]
        public bool Isplayarea;

        [JsonProperty("ispool")]
        public bool Ispool;

        [JsonProperty("ispurchase")]
        public bool Ispurchase;

        [JsonProperty("isrefinance")]
        public bool Isrefinance;

        [JsonProperty("kitchen")]
        public int Kitchen;

        [JsonProperty("seperatebaths")]
        public int Seperatebaths;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("year")]
        public int Year;
    }
}
