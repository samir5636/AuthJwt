using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Stocks
    {
        [Key]  // Define Id as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Symbole { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }

        public long MarketCap { get; set; }

        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}