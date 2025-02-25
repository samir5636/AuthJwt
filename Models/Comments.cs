using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreatOn { get; set; } = DateTime.Now;

        [ForeignKey("Stocks")]
        public int StockId { get; set; }
        
        public Stocks? Stock { get; set; }
    }
}