using System;
using System.Data.Linq;
using System.Linq;

//By inheriting the Employee entity class create a class which allows 
//employees to access their corresponding territories as property of type EntitySet<T>.

namespace Northwind.Data
{
    public partial class Employee
    {
        private EntitySet<Territory> entityTerritories;

        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritory = this.Territories;
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                entityTerritories.AddRange(employeeTerritory);
                return entityTerritories;
            }
        }

    }
}
