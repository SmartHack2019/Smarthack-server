using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace smarthack.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public double Increase { get; set; }
        public double Percent { get; set; }

        public ICollection<News> Newses { get; set; }
    }
}
