using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("report")]
    public class Report : ModelBase
    {
        [Column("bookid")]
        public long BookId { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("email")]
        public string Email { get; set; }
        public Book book { get; set; }
    }
}
