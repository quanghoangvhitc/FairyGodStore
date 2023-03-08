using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("role")]
    public class Role : ModelBase
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
