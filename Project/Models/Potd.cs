using Newtonsoft.Json;

namespace Project.Models
{
    public class Potd
    {
        [JsonProperty("copyright")]
        public string CopyRight { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        [JsonProperty("hdurl")]
        public string HDPicUrl { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("title")]
        public string PicTitle { get; set; }

        [JsonProperty("url")]
        public string NoramlPicUrl { get; set; }
    }
}
