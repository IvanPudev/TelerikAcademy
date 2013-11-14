using System;
using System.Linq;
using MobilePhoneDeviceData.Enum;


namespace MobilePhoneDeviceData
{
    class Battery
    {

        #region Fields

        private string bateryModel;
        private double? hoursIdle;
        private double? hoursTalk;
        private BatteryType type; 

        #endregion

        #region Properties

        public string Model
        {
            get { return this.bateryModel; }
            set { this.bateryModel = value; }
        }

        public double? HoursIdle
        {
            get { return this.hoursIdle; }
            set 
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException("Invalid Input. Must be Possitive number.");
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        public double? HoursTalk
        {
            get { return this.hoursTalk; }
            set 
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException("Invalid Input. Must be Possitive number.");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
        }

        public BatteryType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        #endregion

        #region Constructors

        public Battery()
            : this(null)
        { 
        }

        public Battery(string model)
            : this(model, null)
        { 
        }

        public Battery(string model, double? idle)
            : this(model, idle, null)
        {
        }

        public Battery(string model, double? idle, double? talk)
        {
            this.Model = model;
            this.HoursIdle = idle;
            this.HoursTalk = talk;
        }

        #endregion

    }
}
