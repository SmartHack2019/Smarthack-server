using Newtonsoft.Json;

namespace smarthack.Helper.CategoriesTextClassifier.NPLAPIModels
{
    public class NLPRequestModel
    {
        [JsonProperty(PropertyName = "document")]
        public NLPRequestDocument Document { get; set; }

        public NLPRequestModel(string content)
        {
            this.Document = new NLPRequestDocument(content);
        }
    }
}
