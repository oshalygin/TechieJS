using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Twitter.BLL.JsonTypes
{

    public class UserEntities
    {

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

}
