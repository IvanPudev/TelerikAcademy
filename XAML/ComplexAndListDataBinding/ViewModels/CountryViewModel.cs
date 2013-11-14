using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CountryViewModel
    {
        public string Name { get; set; }

        public string Language { get; set; }

        public string Flag { get; set; }

        public IEnumerable<TownViewModel> Towns { get; set; }
    }
}
