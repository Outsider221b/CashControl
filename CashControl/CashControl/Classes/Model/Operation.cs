using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControl
{
    [Table("operation")]
    public class Operation
    {
        [Required]
        [MaxLength(36)]
        [Key]
        public string OperationId { get; set; }

        public decimal MoneyCount { get; set; }

        public bool IsProfit { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public DateTime Creation { get; set; }

        public DateTime LastUpdate { get; set; }

        public string SourceId { get; set; }

        [ForeignKey(nameof(SourceId))]
        public virtual Source Source { get; set; }
    }
}
