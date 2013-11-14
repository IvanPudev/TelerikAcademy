using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.Commands;

namespace TicTacToe.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private const string userWinsMessage = "Game over! You win!";
        private const string computerWinsMessage = "Game over! Computer wins!";
        private ICommand moveMade;
        private string topLeft;
        private string topMiddle;
        private string topRight;
        private string middleLeft;
        private string middleCenter;
        private string middleRight;
        private string bottomRight;
        private string bottomMiddle;
        private string bottomLeft;
        private string message;

        public GameViewModel()
        {
            this.message = string.Empty;
        }

        public string TopLeft
        {
            get
            {
                return this.topLeft;
            }
            set
            {
                this.topLeft = value;
                this.OnPropertyChanged("TopLeft");
            }
        }

        public string TopMiddle
        {
            get
            {
                return this.topMiddle;
            }
            set
            {
                this.topMiddle = value;
                this.OnPropertyChanged("TopMiddle");
            }
        }

        public string TopRight
        {
            get
            {
                return this.topRight;
            }
            set
            {
                this.topRight = value;
                this.OnPropertyChanged("TopRight");
            }
        }

        public string MiddleLeft
        {
            get
            {
                return this.middleLeft;
            }
            set
            {
                this.middleLeft = value;
                this.OnPropertyChanged("MiddleLeft");
            }
        }

        public string MiddleCenter
        {
            get
            {
                return this.middleCenter;
            }
            set
            {
                this.middleCenter = value;
                this.OnPropertyChanged("MiddleCenter");
            }
        }

        public string MiddleRight
        {
            get
            {
                return this.middleRight;
            }
            set
            {
                this.middleRight = value;
                this.OnPropertyChanged("MiddleRight");
            }
        }

        public string BottomLeft
        {
            get
            {
                return this.bottomLeft;
            }
            set
            {
                this.bottomLeft = value;
                this.OnPropertyChanged("BottomLeft");
            }
        }

        public string BottomMiddle
        {
            get
            {
                return this.bottomMiddle;
            }
            set
            {
                this.bottomMiddle = value;
                this.OnPropertyChanged("BottomMiddle");
            }
        }

        public string BottomRight
        {
            get
            {
                return this.bottomRight;
            }
            set
            {
                this.bottomRight = value;
                this.OnPropertyChanged("BottomRight");
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set 
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public ICommand MoveMade
        {
            get
            {
                if (this.moveMade == null)
                {
                    this.moveMade = new DelegateCommand<string>(this.HandleMakeMove);
                }
                return this.moveMade;
            }
        }

        private async void HandleMakeMove(string parameter)
        {
            switch (parameter)
            {
                case "00": if (CheckCellValue(this.TopLeft))
                    {
                        this.TopLeft = "X";
                    }
                    break;
                case "01": if (CheckCellValue(this.TopMiddle))
                    {
                        this.TopMiddle = "X";
                    }
                    break;
                case "02": if (CheckCellValue(this.TopRight))
                    {
                        this.TopRight = "X";
                    }
                    break;
                case "10": if (CheckCellValue(this.MiddleLeft))
                    {
                        this.MiddleLeft = "X";
                    }
                    break;
                case "11": if (CheckCellValue(this.MiddleCenter))
                    {
                        this.MiddleCenter = "X";
                    }
                    break;
                case "12": if (CheckCellValue(this.MiddleRight))
                    {
                        this.MiddleRight = "X";
                    }
                    break;
                case "20": if (CheckCellValue(this.BottomLeft))
                    {
                        this.BottomLeft = "X";
                    }
                    break;
                case "21": if (CheckCellValue(this.BottomMiddle))
                    {
                        this.BottomMiddle = "X";
                    }
                    break;
                case "22": if (CheckCellValue(this.BottomRight))
                    {
                        this.BottomRight = "X";
                    }
                    break;
                default:
                    break;
            }

            if (CheckGameOver())
            {
                return;
            }
            await Task.Delay(TimeSpan.FromSeconds(1));
            ComputerMoves();
        }

        private bool CheckGameOver()
        {
            bool gameOver = false;

            if( (this.topLeft=="X" && this.topMiddle=="X" && this.TopRight=="X") ||
            (this.MiddleCenter=="X" && this.MiddleLeft=="X" && this.MiddleRight=="X") ||
                (this.BottomLeft=="X" && this.BottomMiddle=="X" && this.BottomRight=="X") ||
                (this.TopLeft=="X" && this.MiddleLeft=="X" && this.BottomLeft=="X")||
                (this.TopMiddle == "X" && this.MiddleCenter == "X" && this.BottomMiddle == "X") ||
                (this.TopRight == "X" && this.MiddleRight == "X" && this.BottomRight == "X") ||
                (this.TopLeft=="X" && this.MiddleCenter=="X" && this.BottomRight=="X")||
                (this.TopRight=="X" && this.MiddleCenter=="X" && this.BottomLeft=="X"))
            {
                this.Message = userWinsMessage;
                gameOver = true;
                return gameOver;
            }

            if ((this.topLeft == "0" && this.topMiddle == "0" && this.TopRight == "0") ||
           (this.MiddleCenter == "0" && this.MiddleLeft == "0" && this.MiddleRight == "0") ||
               (this.BottomLeft == "0" && this.BottomMiddle == "0" && this.BottomRight == "0") ||
                (this.TopLeft == "0" && this.MiddleLeft == "0" && this.BottomLeft == "0") ||
                (this.TopMiddle == "0" && this.MiddleCenter == "0" && this.BottomMiddle == "0") ||
                (this.TopRight == "0" && this.MiddleRight == "0" && this.BottomRight == "0") ||
               (this.TopLeft == "0" && this.MiddleCenter == "0" && this.BottomRight == "0") ||
               (this.TopRight == "0" && this.MiddleCenter == "0" && this.BottomLeft == "0"))
            {
                this.Message = computerWinsMessage;
                gameOver = true;
                return gameOver;
            }

            return gameOver;
        }

        private void ComputerMoves()
        {
            if (CheckCellValue(this.TopLeft))
            {
                this.TopLeft = "0";
                return;
            }
            if (CheckCellValue(this.TopMiddle))
            {
                this.TopMiddle = "0";
                return;
            }
            if (CheckCellValue(this.TopRight))
            {
                this.TopRight = "0";
                return;
            }

            if (CheckCellValue(this.MiddleLeft))
            {
                this.MiddleLeft = "0";
                return;
            }
            if (CheckCellValue(this.MiddleCenter))
            {
                this.MiddleCenter = "0";
                return;
            }
            if (CheckCellValue(this.MiddleRight))
            {
                this.MiddleRight = "0";
                return;
            }

            if (CheckCellValue(this.BottomLeft))
	        {
                this.BottomLeft = "0";
                return;
	        }
            if (CheckCellValue(this.BottomMiddle))
            {
                this.BottomMiddle = "0";
                return;
            }
            if (CheckCellValue(this.BottomRight))
            {
                this.BottomRight = "0";
                return;
            }
        }

        private bool CheckCellValue(string cellValue)
        {
            if (string.IsNullOrEmpty(cellValue))
            {
                return true;
            }

            return false;
        }

    }
}
