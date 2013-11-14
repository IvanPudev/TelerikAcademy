using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels
{
    class DataPersister
    {
        public static IEnumerable<CountryViewModel> GetAll(string countryDocumentPath)
        {
            var countryDocumentRoot = XDocument.Load(countryDocumentPath).Root;

            var countriesMVs = from country in countryDocumentRoot.Elements("country")
                               select new CountryViewModel
                               {
                                   Name = country.Element("name").Value,
                                   Language = country.Element("language").Value,
                                   Towns = (from town in country.Element("towns").Elements("town")
                                            select new TownViewModel()
                                            {
                                                Name = town.Element("name").Value,
                                                Population = int.Parse(town.Element("population").Value)
                                            }).ToList()

                               };

            return countriesMVs;
        }
    }
}
