using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace smarthack.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Headline { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public DateTime? Time { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
