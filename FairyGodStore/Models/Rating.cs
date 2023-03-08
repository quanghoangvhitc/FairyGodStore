using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("rating")]
    public class Rating : ModelBase
    {
        [Column("bookid")]
        public long BookId { get; set; }
        [Column("point")]
        public double Point { get; set; }
    }
}
