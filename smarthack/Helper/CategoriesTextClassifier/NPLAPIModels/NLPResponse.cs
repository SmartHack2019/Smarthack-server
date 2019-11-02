using Newtonsoft.Json;
using System.Collections.Generic;

namespace smarthack.Helper.CategoriesTextClassifier.NPLAPIModels
{
    public class NLPResponse
    {
        [JsonProperty(PropertyName = "categories")]
         public ICollection<NLPResponseCategory> Categories { get; set; }
    }
}
