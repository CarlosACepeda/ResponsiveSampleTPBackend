using ResponsiveSampleTPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveSampleTPBackend.ViewModels
{
    public class NewHobbyForUserViewModel
    {
        public User UserToAttachNewHobbyTo { get; set; }
        public List<Hobby> SelectableHobbies { get; set; }
    }
}
