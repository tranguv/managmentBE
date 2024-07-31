using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Dtos
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Username { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Date of birth"), DataType(DataType.Date)]
        public DateTime? Dob { get; set; }
        public Role Role { get; set; }
    }
}
