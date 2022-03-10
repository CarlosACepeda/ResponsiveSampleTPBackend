using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveSampleTPBackend.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Username { get; set; }
        public string Password { get; set; } //Passwords should never be in plain text, for the sake of simplicity we are ommitting this.
        
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public long Phonenumber { get; set; }
        public ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();
    }
}
