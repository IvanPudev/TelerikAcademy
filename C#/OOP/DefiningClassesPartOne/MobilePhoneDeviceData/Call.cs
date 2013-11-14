using System;
using System.Linq;

namespace MobilePhoneDeviceData
{
    class Call
    {
        #region Fields

        private DateTime date;
        private string dialedNumber;
        private int callDuration;

        #endregion

        #region Properties

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
            set { this.dialedNumber = value; }
        }

        public int CallDuration
        {
            get { return this.callDuration; }
            set { this.callDuration = value; }
        }

        #endregion

        #region Constructors

        public Call(DateTime date, string dialedNumber, int callDuration)
        {
            this.Date = date;
            this.DialedNumber = dialedNumber;
            this.CallDuration = callDuration;
        }

        #endregion

    }
}
