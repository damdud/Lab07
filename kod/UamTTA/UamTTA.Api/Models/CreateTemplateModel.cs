using UamTTA.Model;

namespace UamTTA.Api.Models
{
    public class CreateTemplateModel
    {
        public string Name { get; set; }

        public Duration Duration { get; set; }
    }
}