using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CountriesSystemViewModel
    {
        private IEnumerable<CountryViewModel> countriesViewModel;

        public string CountriesDocumentPath { get; set; }

        public CountriesSystemViewModel()
        {
            this.CountriesDocumentPath = "..\\..\\..\\ViewModels\\countries.xml";
        }

        public IEnumerable<CountryViewModel> Towns
        {
            get
            {
                if (this.countriesViewModel == null)
                {
                    this.countriesViewModel = DataPersister.GetAll(CountriesDocumentPath);
                }
                return countriesViewModel;
            }
        }
    }
}
