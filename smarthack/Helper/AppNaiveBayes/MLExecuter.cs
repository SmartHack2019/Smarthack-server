using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.EntityFrameworkCore;
using smarthack.Data;
using smarthack.Helper.Classifier;

namespace smarthack.Helper.AppNaiveBayes
{
    public class MLExecuter
    {
        private static MLExecuter instance;
        //public static SmartHackDbContext _context;

        public static async Task ExecuteAsync(SmartHackDbContext _context)
        {
            var companies = await _context.Companies.Include(x => x.Newses).ToListAsync();
            foreach (var company in companies)
            {
                var news = company.Newses.OrderByDescending(x => x.Time).FirstOrDefault();
                if (news != null)
                {
                    var newsType = ClassifierLearner.Clasify(news.Content);
                    AppNaiveBayes.learnNaiveBayes(company.Percent, newsType, company.Id);
                }
                var result = AppNaiveBayes.getNaiveBayesResult("Positive", companies.FirstOrDefault().Id);
                var result2 = result;
            }

        
        }
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
