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
        [Column("bookid")]
        public long BookId { get; set; }
        [Column("chapter")]
        public int Chapter { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("releasedate")]
        public long ReleaseDate { get; set; }
        public Book book { get; set; }
    }
}
