using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("bookcontent")]
    public class BookContent : ModelBase
    {
        [Column("bookchapterid")]
        public long BookChapterId { get; set; }
        [Column("content")]
        public string Content { get; set; }
        public BookChapter bookchapter { get; set; }
    }
}
