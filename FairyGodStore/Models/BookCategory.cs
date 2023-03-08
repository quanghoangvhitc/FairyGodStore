using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("bookcategory")]
    public class BookCategory : ModelBase
    {
        [Column("title")]
        public string Title { get; set; }
    }
}
