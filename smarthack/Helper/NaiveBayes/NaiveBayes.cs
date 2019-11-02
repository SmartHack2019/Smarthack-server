using Accord.MachineLearning.Bayes;
using Accord.Statistics.Filters;

namespace smarthack.Helper.NaiveBayes
{
    public class NaiveBayes
    {
        private static NaiveBayes instance;
        private static NaiveBayesLearning lerner;
        private static NaiveBayes naiveBayes;
        static Codification codebook;
        private NaiveBayes()
        {

        }
        public static NaiveBayes Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NaiveBayes();
                    lerner = new NaiveBayesLearning();
                }
                return instance;
            }
        }
        public void learnNaiveBayes()
        {

        }

    }
}

