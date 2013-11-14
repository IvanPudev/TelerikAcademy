using System;

namespace High_QualityMethods
{
    public class PersonalInfo
    {
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Hobby { get; set; }

        public PersonalInfo(string birthDate, string city = null, string hobby = null)
        {
            DateTime outParamBirthDate;
            if (!DateTime.TryParse(birthDate, out outParamBirthDate))
            {
                throw new FormatException("Incorrect Date format! Suggest to (15.04.1999)");
            }

            this.BirthDate = outParamBirthDate;
            this.City = city;
            this.Hobby = hobby;
        }
    }
}
