using System;
using System.Collections.Generic;
using System.Linq;

//Define a class that holds information about a mobile phone device: model, manufacturer, 
//price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics
//(size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).


namespace MobilePhoneDeviceData
{
    class GSM
    {

        #region Fields

        private string model;
        private string manufacturer;
        private decimal? price;
        private string ownerName;
        private Battery battery;
        private Display display;
        private readonly List<Call> callHistory = new List<Call>();
        private static readonly GSM iPhone4S;

        #endregion

        #region Preoperties

        public GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        public decimal? Price
        {
            get { return this.price; }
            set 
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException("Invalid price. Must be Possitive number.");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get { return this.ownerName; }
            set { this.ownerName = value; }
        }

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        #endregion

        #region Constructors

        static GSM()
        {
            Battery battery = new Battery("iBattery", 5.4, 2.0);
            Display display = new Display(3.5, 16000000);
            iPhone4S = new GSM("iPhone4S", "Apple", 1500, "John Smith", battery, display);
        }

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price, owner, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }
        #endregion

        #region Methods

        public void AddCall(DateTime date, string dialedNumber, int callDuration)
        {
            this.callHistory.Add(new Call(date, dialedNumber, callDuration));
        }

        public void RemuveCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CallPrice(decimal pricePerMin)
        {
            int secondsTalked = 0;
            decimal minutesTalked = 0;

            foreach (Call call in callHistory)
            {
                secondsTalked += call.CallDuration;
            }

            minutesTalked = secondsTalked / 60M;
            return minutesTalked * pricePerMin;
        }

        public override string ToString()
        {

            return string.Format("Model: {0}\r\n" +
                "Manufacturer: {1}\r\n" +
                "Price: {2}\r\n" +
                "Owner: {3}\r\n" +
                "Battery: {4}\r\n" +
                "Display: {5}", model, manufacturer, price, ownerName, battery, display);
        }

        #endregion

    }
}
