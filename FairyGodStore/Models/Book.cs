using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("book")]
    public class Book : ModelBase
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("releasedate")]
        public long ReleaseDate { get; set; }
        [Column("thumbnail")]
        public string Thumbnail { get; set; }
        [Column("sortdescription")]
        public string SortDescription { get; set; }
        [Column("views")]
        public long Views { get; set; }
        [Column("point")]
        public long Point { get; set; }
    }
}
