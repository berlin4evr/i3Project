using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace i3Project
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Post>(myJsonResponse);
    public class Post
    {
        [JsonProperty("one")]
        public string One;

        [JsonProperty("key")]
        public string Key;
    }


}
