using Newtonsoft.Json;

namespace smarthack.Helper.CategoriesTextClassifier.NPLAPIModels
{
    public class NLPResponseCategory
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
    }
}
