using Microsoft.ML;
using smarthack.Helper.SentimentAnalyzer.Models;
using System;
using System.IO;
using System.Linq;
using static Microsoft.ML.DataOperationsCatalog;

namespace smarthack.Helper.Classifier
{
    public class ClassifierLearner
    {
        private static ClassifierLearner instance;
        private static String text;
        private static MLContext mlContext;
        private static ITransformer model;
        private static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data/SentimentAnalyzerData", "yelp_labelled.txt");

        private ClassifierLearner()
        {

        }
        public static ClassifierLearner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClassifierLearner();
                    //mlContext = new MLContext();
                    //TrainTestData splitDataView = LoadData();
                    //model = BuildAndTrainModel(splitDataView.TrainSet);
                }
                return instance;
            }
        }

        public static string Clasify(string _text)
        {
            mlContext = new MLContext();
            TrainTestData splitDataView = LoadData();
            model = BuildAndTrainModel(splitDataView.TrainSet);
            text = _text;
            SentimentPrediction resultPrediction = UseModelWithSingleItem();
            return Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative";
        }
        public static TrainTestData LoadData()
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(ClassifierLearner._dataPath, hasHeader: false);
            TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            return splitDataView;
        }
        public static ITransformer BuildAndTrainModel(IDataView splitTrainSet)
        {
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
            var model = estimator.Fit(splitTrainSet);
            return model;
        }
        private static SentimentPrediction UseModelWithSingleItem()
        {
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = ClassifierLearner.mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(ClassifierLearner.model);
            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = text
            };
            var resultPrediction = predictionFunction.Predict(sampleStatement);
            Console.WriteLine($"Sentiment: {resultPrediction.Sentiment} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");
            //var sentiment = Convert.ToBoolean(resultPrediction.Prediction) ? "Toxic" : "Not Toxic";
            //Console.WriteLine(sentiment);

            return resultPrediction;
        }
     
    }
}
