using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Models
{
    [Table("user")]
    public class User : ModelBase
    {
        [Column("phonenumber")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("fullname")]
        public string FullName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("identitycard")]
        public string IdentityCard { get; set; }
        [Column("avatar")]
        public string Avatar { get; set; }
        [Column("status")]
        public int Status { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
