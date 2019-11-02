using Microsoft.ML;
using Microsoft.ML.Data;
using smarthack.Helper.SentimentAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.ML.DataOperationsCatalog;

namespace smarthack.Helper.Clasifier
{
    public static class Clasifier
    {

        private static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data/SentimentAnalyzerData", "yelp_labelled.txt");
        public static void Clasify()
        {
            MLContext mlContext = new MLContext();
            TrainTestData splitDataView = LoadData(mlContext);
            ITransformer model = BuildAndTrainModel(mlContext, splitDataView.TrainSet);
            //Evaluate(mlContext, model, splitDataView.TestSet);
            var resultPrediction = UseModelWithSingleItem(mlContext, model);
        }

        private static SentimentPrediction UseModelWithSingleItem(MLContext mlContext, ITransformer model)
        {
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = "3i Group plc (the 'Company') announces that Jonathan Asquith, a Director and person discharging managerial responsibilities, has been appointed as a Director of Standard Life Aberdeen plc with effect from 1 September 2019."
            };
            var resultPrediction = predictionFunction.Predict(sampleStatement);
            Console.WriteLine($"Sentiment: {resultPrediction.Sentiment} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");
            var sentiment = Convert.ToBoolean(resultPrediction.Prediction) ? "Toxic" : "Not Toxic";
            Console.WriteLine(sentiment);
            return resultPrediction;
        }
        public static void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
        {
            Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
            IDataView predictions = model.Transform(splitTestSet);
            CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");
            Console.WriteLine();
            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.WriteLine("=============== End of model evaluation ===============");
        }

        public static ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
        {
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
            var model = estimator.Fit(splitTrainSet);
            return model;
        }

        public static TrainTestData LoadData(MLContext mlContext)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(Clasifier._dataPath, hasHeader: false);
            TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            return splitDataView;
        }
    }
}
