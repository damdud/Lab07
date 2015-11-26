using Newtonsoft.Json;
using UamTTA.Model;

namespace UamTTA.Api.Models
{
    public class TemplateModel
    {
        [JsonProperty("template_name")]
        public string Name { get; set; }

        public Duration Duration { get; set; }
    }
}