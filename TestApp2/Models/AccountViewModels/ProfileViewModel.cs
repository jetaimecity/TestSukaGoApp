using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp2.Models.AccountViewModels
{
    public class ProfileViewModel
    {
        // add an id
        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public IList<string> Interests { get; set; }

        public IList<string> Skills { get; set; }

        public string Experience { get; set; }
    }
}
