using System.ComponentModel.DataAnnotations.Schema;

namespace FairyGodStore.Models
{
    [Table("bookchapter")]
    public class BookChapter : ModelBase
    {
        [Column("bookid")]
        public long BookId { get; set; }
        [Column("chapter")]
        public int Chapter { get; set; }
        [Column("title")]
        public string Title { get; set; }
        public Book book { get; set; }
        public BookContent bookcontent { get; set; }
    }
}
