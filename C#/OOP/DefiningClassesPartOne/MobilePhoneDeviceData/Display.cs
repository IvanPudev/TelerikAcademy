using System;
using System.Linq;


namespace MobilePhoneDeviceData
{
    class Display
    {

        #region Fields

        private double? size;
        private double? colors;

        #endregion

        #region Properties

        public double? Size
        {
            get { return this.size ; }
            set 
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException("Invalid Input. The Size must be possitive number.");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public double? Colors
        {
            get { return this.colors; }
            set 
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException("Invalid Input. The Color must be possitive number.");
                }
                else
                {
                    this.colors = value;
                } 
            }
        }

        #endregion

        #region Constructors

        public Display(double? size, double? colorsNum)
        {
            this.Size = size;
            this.Colors = colorsNum;
        }

        #endregion

    }
}
