using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace SquareIt.ViewModels
{
    public class BoxViewModel : ViewModelBase
    {
        private Color top;
        private Color left;
        private Color bottom;
        private Color right;
        private Color playerColor;

        public BoxViewModel()
        {
            this.Top = Windows.UI.Colors.DarkGray;
            this.Left = Windows.UI.Colors.DarkGray;
            this.Bottom = Windows.UI.Colors.DarkGray;
            this.Right = Windows.UI.Colors.DarkGray;
            this.PlayerColor = Windows.UI.Colors.DarkGray;
        }

        public Color Top
        {
            get
            {
                return this.top;
            }

            set
            {
                if (this.top != value)
                {
                    this.top = value;
                    this.OnPropertyChanged("Top");
                }
            }
        }

        public Color Left
        {
            get
            {
                return this.left;
            }
            set
            {
                if (this.left != value)
                {
                    this.left = value;
                    this.OnPropertyChanged("Left");
                }
            }

        }
        public Color Bottom
        {
            get
            {
                return this.bottom;
            }
            set
            {
                if (this.bottom != value)
                {
                    this.bottom = value;
                    this.OnPropertyChanged("Bottom");
                }
            }
        }
        public Color Right
        {
            get
            {
                return this.right;
            }
            set
            {
                if (this.right != value)
                {
                    this.right = value;
                    this.OnPropertyChanged("Right");
                }
            }
        }

        public Color PlayerColor
        {
            get
            {
                return this.playerColor;
            }
            set
            {
                if (this.playerColor != value)
                {
                    this.playerColor = value;
                    this.OnPropertyChanged("PlayerColor");
                }
            }
        }
    }
}
