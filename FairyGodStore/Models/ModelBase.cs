using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    public class ModelBase
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("createdby")]
        public long? CreatedBy { get; set; }
        [Column("modifiedby")]
        public long? ModifiedBy { get; set; }
        [Column("created")]
        public long? Created { get; set; }
        [Column("modified")]
        public long? modified { get; set; }
    }
}
