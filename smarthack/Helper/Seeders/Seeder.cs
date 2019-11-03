using smarthack.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace smarthack.Helper.Seeders
{
    public class Seeder
    {
        private SmartHackDbContext _context;
        public Seeder(SmartHackDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Seed()
        {
            var rand = new Random();
            var companies = _context.Companies.ToList();
            for (int i = 0; i < companies.Count; i++)
            {
                var x = (double)rand.Next(1, 1500) / 10;
                companies[i].Price = x;
                x = (double)(rand.Next(-5, 6) / 10);
                companies[i].Increase = rand.Next(-5, 5);
                companies[i].Percent = x / 5;
            }

            _context.Companies.UpdateRange(companies);
            _context.SaveChanges();
        }

        public void SeedCorrect()
        {
            double[] percentages =
            {
                0.09, 1.08, -0.05, 3.12, 2.65, 1.36, -0.48, -3.2, 0.81, 1.08, 0.9, -0.37, 0.44, 1.64, 2.36, 1.59, 1.46, -1.45, -0.66, 0.2,
                -0.44, 1.16, -1.76, 0.21, -0.92, 1.28, 0.5, 1.02, -0.33, 3.38, -0.33, -0.27, 3.17, 1.41, -0.43, 3.57, 1.31, -1.98, 0, -0.94,

                0.99, 0.3, 0.65, 1.11, 0.11, 2.15, -0.52, 0.21, 3.32, 0.92, -0.83, 0.83, 0.9, 1.21, 1.5, -0.48, 2.3, 2.28, -0.15, -0.1,

                0.73, 1.92, 0.75, 0.41, 0.53, 1.83, 0.55, 0.7, 1.23, 1.6, -0.72, 0.05, 0.29, -1.7, 3.84, 2.20, 0.94, 0.96, 0.47, 0.54,

                0.32, 0, -0.5, -0.22, 0.7, 1.48, 1.64, 2.49, 1.96, 0.55, -0.24, 0.71, 0.59, 1.51, 1.15, 2.08, -0.23, -0.21, 0.7, 1.55,

                0.23
            };

            double[] prices =
            {
                1129, 2250, 2021, 2043.5, 890.2, 2380, 7465, 544.2, 4216, 419.7, 581.4, 167.18, 634, 4473, 1673, 497.1, 2741.5, 611.6, 203.35, 2012,
                2035, 3128, 71.28, 2355, 2037, 2852, 4840, 7310, 3154, 379.60, 2420, 6568, 8210, 720, 1761, 240.95, 1898, 1737, 2010, 1475,
                588.8, 1697.4, 780, 4711.5, 5358, 542.6, 133.05, 770, 3172, 2019.1, 932.2, 265.9, 57.31, 7038.00, 217.00, 621.4, 218, 1634, 198.55, 900.4,
                6630, 2225, 1393, 685, 2289, 717.1, 1272, 1358, 2260.5, 2253.5, 5921, 1859, 453.2, 588.4, 4168, 724.6, 214.7, 527.20, 723.2, 204.6,
                3105, 505.5, 840, 2250, 1664, 362.9, 1640, 2636, 8080, 1290.5, 1038.5, 706, 305.3, 168, 237.9, 1031, 4612, 868.4, 158.5, 4214, 965.4
            };

            double[] increases =
            {
                1, 24, -1, 61.9, 23.0, 32, -36, -18, 34, 4.5, 5.2, -0.62, 2.8, 72, 38.6, 7.80, 39.5, -9, -1.35, 4,
                -9, 36, -1.28, 5, -19, 36, 24, 74, -10.5, 12.4, -8, -18, 252, 10, -7.6, 8.3, 24.5, -35, 0, -14,
                5.8, 5, 5, 52.5, 6, 11.4, -0.7, 1.6, 102, 1.9, -7.8, 2.2, 0.51, 84, 3.2, -3, 4.9, 36.5, -0.3, -0.9,
                48, 42, 10, 2.8, 12, 12.9, 7, 9.5, 27.5, 35.5, -43, 1, -1.3, -10.2, 154, 15.6, 2, 5, 3.4, 1.1,
                10, 0, -4.2, -5, 11.5, 5.3, 26.5, 64, 155, 7, -2.5, 5, 1.8, 2.5, 2.7, 21, -10.5, -1.8, 1.1, 63, 2.2
            };
            string[] codes = {"III", "ABF", "ADM", "AAL", "ANTO", "AHT", "AZN", "AUTO", "AVV", "AV.",
            "BA.", "BARC", "BDEV", "BKG", "BHP", "BP.", "BATS", "BLND", "BT.A", "BNZL",
            "BRBY", "CCL", "CNA", "CCH", "CPG", "CRH", "CRDA", "DCC", "DGE", "EVR",
            "EXPN", "FERG", "FLTR", "FRES", "GSK", "GLEN", "HLMA", "HL.", "HIK", "HSX",
            "HSBA", "IMB", "INF", "IHG", "ITRK", "IAG", "ITV", "JD.", "JMAT", "KGF",
            "LAND", "LGEN", "LLOY", "LSE", "MNG", "MGGT", "MRO", "MNDI", "MRW", "NG.",
            "NXT", "NMC", "OCDO", "PSON", "PSN", "PHNX", "POLY", "PRU", "RDSA", "RDSB",
            "RB.", "REL", "RTO", "RMV", "RIO", "RR.", "RBS", "RSA", "SGE", "SBRY",
            "SDR", "SMT", "SGRO", "SVT", "SN.", "SMDS", "SMIN", "SKG", "SPX", "SSE",
            "STJ", "STAN", "SLA", "TW.", "TSCO", "TUI", "ULVR", "UU.", "VOD", "WTB", "WPP"};

            var companies = _context.Companies.ToList();
            var pricesDictionary = new Dictionary<string, double>();
            var increaseDictionary = new Dictionary<string, double>();
            var percentagesDic = new Dictionary<string, double>();

            for (int i = 0; i < 101; i++)
            {
                pricesDictionary[codes[i]] = prices[i];
                increaseDictionary[codes[i]] = increases[i];
                percentagesDic[codes[i]] = percentages[i];
            }

            for (int i = 0; i < 101; i++)
            {
                companies[i].Increase = increaseDictionary[companies[i].Code];
                companies[i].Percent = percentagesDic[companies[i].Code];
                companies[i].Price = percentagesDic[companies[i].Code];
            }

            _context.Companies.UpdateRange(companies);
            _context.SaveChanges();
        }

        public void SeedTime()
        {
            var news = _context.Newses.ToList();
            var rand = new Random();
            for (int i = 0; i < news.Count; i++)
            {
                news[i].Time = DateTime.Now.AddDays(-rand.Next(10));
            }
            _context.Newses.UpdateRange(news);
            _context.SaveChanges();
        }
    }
}
