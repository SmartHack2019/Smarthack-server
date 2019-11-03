using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentScheduler;

namespace smarthack.Helper.NaiveBayes
{
    public class MLExecuter
    {
        private static MLExecuter instance;
        private MLExecuter()
        {
           
        }
        public static MLExecuter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MLExecuter();
                }
                return instance;
            }
        }
    }
}
