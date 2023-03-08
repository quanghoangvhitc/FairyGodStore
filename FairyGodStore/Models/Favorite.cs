using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("favorite")]
    public class Favorite : ModelBase
    {
        [Column("bookid")]
        public long BookId { get; set; }
        public Book book { get; set; }
    }
}
