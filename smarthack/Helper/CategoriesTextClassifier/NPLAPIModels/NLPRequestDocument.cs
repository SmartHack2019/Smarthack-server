using Newtonsoft.Json;

namespace smarthack.Helper.CategoriesTextClassifier.NPLAPIModels
{
    public class NLPRequestDocument
    {
        [JsonProperty(PropertyName = "type")]
        public string Type = "PLAIN_TEXT";

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        public NLPRequestDocument(string Content)
        {
            this.Content = Content;
        }

    }
}
