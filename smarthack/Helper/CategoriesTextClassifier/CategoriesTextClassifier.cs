using Newtonsoft.Json;
using smarthack.Helper.CategoriesTextClassifier.NPLAPIModels;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace smarthack.Helper.CategoriesTextClassifier
{
    public static class CategoriesTextClassifier
    {
        public static void ClasifyText(string text)
        {
            // Google NLP Api Implementation
            const string googleAPIKey = "";
            const string googleNLPUrl = "https://language.googleapis.com/v1/documents:classifyText?key=" + googleAPIKey;
            HttpClient googleClient = new HttpClient
            {
                BaseAddress = new Uri(googleNLPUrl)
            };

            var data = new NLPRequestModel(text);
            var stringPayload = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = googleClient.PostAsync(googleNLPUrl, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result
                                       .Replace("\\", "")
                                       .Trim(new char[1] { '"' });

                NLPResponse result = JsonConvert.DeserializeObject<NLPResponse>(responseContent);

                // Find the best confidence category
                double bigestConfidence = 0.0;
                NLPResponseCategory bestCategory = result.Categories.FirstOrDefault();

                foreach (NLPResponseCategory category in result.Categories)
                {
                    if(bigestConfidence< category.Confidence)
                    {
                        bestCategory = category;
                    }
                }

                // Set up in the database the category
                // 
            }
        }
    }
}