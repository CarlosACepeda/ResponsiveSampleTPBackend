using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveSampleTPBackend.Models
{
    public class Hobby
    {
        [Key]
        public int ID { get; set; }
        public List<User> Users { get; set; }
        public string Name { get; set; }
    }
}
