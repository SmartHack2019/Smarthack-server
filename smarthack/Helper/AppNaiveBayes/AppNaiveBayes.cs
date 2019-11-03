using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.MachineLearning;
using Accord.Statistics.Filters;
using System;
using System.Data;
using Accord.Statistics.Distributions.Univariate;
using smarthack.Models;

namespace smarthack.Helper.AppNaiveBayes
{
    public class AppNaiveBayes
    {
        private static AppNaiveBayes instance;
        private static NaiveBayesLearning learner;
        //private static NaiveBayes<NormalDistribution> naiveBayes;
        private static NaiveBayes naiveBayes;

        static Codification codebook;
        //static string[] columnNames;
        //static string[] classNames;
        private AppNaiveBayes()
        {

        }
        public static AppNaiveBayes Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppNaiveBayes();
                    learner = new NaiveBayesLearning();

                }
                return instance;
            }
        }
        public static void learnNaiveBayes(double percent, string newsType, Guid companyId)
        {
                try
                {

                var classNames = new string[] { "Percent", "NewsType", "CompanyId" };

                DataTable dt = new DataTable();
                dt.Columns.Add("Percent");
                dt.Columns.Add("NewsType");
                dt.Columns.Add("CompanyId");

                DataRow dr = dt.NewRow();
                dr["Percent"] = percent.ToString();
                dr["NewsType"] = newsType;
                dr["CompanyId"] = companyId.ToString();
                dt.Rows.Add(dr);

                // Creates a matrix from the source data table
                //double[,] table = dt.ToMatrix(out columnNames);

                // Get only the input vector values
                //double[][] inputs = table.GetColumns(0, 1).ToJagged();

                // Get only the label outputs
               // int[] outputs = table.GetColumn(2).ToInt32();
                if (codebook == null)
                    codebook = new Codification(dt, "NewsType", "CompanyId", "Percent");
                DataTable symbols = codebook.Apply(dt);
                int[][] inputs = symbols.ToJagged<int>("NewsType", "CompanyId");
                int[] outputs = symbols.ToArray<int>("Percent");
                //var teacher = new NaiveBayesLearning<NormalDistribution>();
                var teacher = new NaiveBayesLearning();

                naiveBayes = teacher.Learn(inputs, outputs);
                }
                catch (Exception e)
                {

                }
             
        }
        public static string getNaiveBayesResult(string newsType, Guid companyId)
        {
            try
            {
                int[] info = codebook.Translate(new string[] {"NewsType", "CompanyId"}, new string[] { newsType.ToString(), companyId.ToString() });
                //int[] info = codebook.Transform(new string[] { newsType, companyId.ToString() });
                if (naiveBayes == null)
                {
                    instance = AppNaiveBayes.Instance;
                }

                if (naiveBayes != null)
                {
                    int c = naiveBayes.Decide(info);
                    string result = codebook.Translate("Percent", c);
                    return result;
                }
                return "-1";
            }
            catch (Exception e)
            {
                return "-1";
            }
        }
    }

}

