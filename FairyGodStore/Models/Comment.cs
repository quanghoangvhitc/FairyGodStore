using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("comment")]
    public class Comment : ModelBase
    {
        [Column("content")]
        public string Content { get; set; }
        [Column("likecount")]
        public long LikeCount { get; set; }
        [Column("dislikecount")]
        public long DisLikeCount { get; set; }
        [Column("userid")]
        public long UserId { get; set; }
        [Column("parentid")]
        public long ParentId { get; set; }
    }
}
