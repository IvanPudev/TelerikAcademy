using Newtonsoft.Json;
using SquareIt.Commands;
using SquareIt.Models;
using SquareIt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI;

namespace SquareIt.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private int firstPlayerScore;
        private int secondPlayerScore;
        //private Color selectedColor;
        private bool bonus;
        private Player currentPlayer;
        private Player firstPlayer;
        private Player secondPlayer;
        private readonly Box[] boxes = new Box[64];
        private readonly KeyValuePair<int, bool>[,] aboxes = new KeyValuePair<int, bool>[8, 8];
        private ICommand select;

        public GameViewModel()
        {
            this.BoxesObservable = new ObservableCollection<BoxViewModel>();
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            LoadFromSettings(localSettings);
            this.currentPlayer = this.firstPlayer;
            //this.selectedColor = currentPlayer.Color;
            for (int i = 0; i < 64; i++)
            {
                this.boxes[i] = new Box();
                this.BoxesObservable.Add(new BoxViewModel());
            }
        }
  
        private async void LoadFromSettings(ApplicationDataContainer localSettings)
        {
            this.firstPlayer = new Player()
            {
                Name = localSettings.Values["FirstPlayerName"] as string,
            };
            this.firstPlayer.Color = await JsonConvert.DeserializeObjectAsync<Color>(localSettings.Values["FirstPlayerColor"].ToString());

            this.secondPlayer = new Player()
            {
                Name = localSettings.Values["SecondPlayerName"] as string,
            };
            this.secondPlayer.Color = await JsonConvert.DeserializeObjectAsync<Color>(localSettings.Values["SecondPlayerColor"].ToString());
        }

        public ObservableCollection<BoxViewModel> BoxesObservable { get; set; }

        public ICommand Select
        {
            get
            {
                if (this.select == null)
                {
                    this.select = new DelegateCommand<string>(this.SelectHandler);
                }

                return this.select;
            }
        }

        private void SelectHandler(string lineInfoString)
        {
            var lineInfo = lineInfoString.Split(',');
            var position = int.Parse(lineInfo[0]);
            var linePosition = lineInfo[1];

            // Horizontal
            if (linePosition == "l" || linePosition == "r")
            {
                this.CheckVertical(position, linePosition);
            }
            else
            {
                this.CheckHorizontal(position, linePosition);
            }

            if (!this.bonus)
            {
                this.ChangeCurrentPlayer();
            }
            this.bonus = false;
        }

        private void CheckVertical(int position, string linePosition)
        {
            //if alredy selected.
            if (this.boxes[position].IsFilled)
            {
                return;
            }

            switch (linePosition)
            {
                case "l":
                    if (!this.boxes[position].Left)
                    {
                        this.boxes[position].Left = true;
                        this.BoxesObservable[position].Left = this.currentPlayer.Color;
                        var previousPosition = position - 1;
                        if (previousPosition >= 0)
                        {
                            this.boxes[previousPosition].Right = true;
                            this.BoxesObservable[previousPosition].Right = this.currentPlayer.Color;
                        }
                    }
                    break;
                case "r":
                    if (!this.boxes[position].Right)
                    {
                        this.boxes[position].Right = true;
                        this.BoxesObservable[position].Right = this.currentPlayer.Color;
                        var nextPosition = position + 1;
                        if (nextPosition < 64)
                        {
                            this.boxes[nextPosition].Left = true;
                            this.BoxesObservable[nextPosition].Left = this.currentPlayer.Color;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Line is undefined.");
            }

            //check current box
            for (int i = position - 1; i < position + 1; i++)
            {
                if (this.CheckBoxIsFilled(i))
                {
                    this.bonus = true;
                    this.boxes[i].IsFilled = true;
                    this.BoxesObservable[i].PlayerColor = this.currentPlayer.Color;
                }

                if (i != 0 && i % 8 == 0)
                {
                    break;
                }
            }
        }
        

        private bool CheckBoxIsFilled(int position)
        {
            if (position < 0 || position > this.boxes.Length)
            {
                return false;
            }

            var box = this.boxes[position];
            
            return box.Top && box.Bottom && box.Left && box.Right;
        }

        private void ChangeCurrentPlayer()
        {
            if (this.currentPlayer == this.firstPlayer)
            {
                this.currentPlayer = this.secondPlayer;
            }
            else
            {
                this.currentPlayer = this.firstPlayer;
            }
            
        }

        private void CheckHorizontal(int position, string linePosition)
        {
            //if alredy selected.
            if (this.boxes[position].IsFilled)
            {
                return;
            }

            switch (linePosition)
            {
                case "t":
                    if (!this.boxes[position].Top)
                    {
                        this.boxes[position].Top = true;
                        this.BoxesObservable[position].Top = this.currentPlayer.Color;
                        var positionOver = position - 8;
                        if (positionOver >= 0)
                        {
                            this.boxes[positionOver].Bottom = true;
                            this.BoxesObservable[positionOver].Bottom = this.currentPlayer.Color;
                        }
                    }
                    break;
                case "b":
                    if (!this.boxes[position].Bottom)
                    {
                        this.boxes[position].Bottom = true;
                        this.BoxesObservable[position].Bottom = this.currentPlayer.Color;
                        var positionUnder = position + 8;
                        if (positionUnder < 64)
                        {
                            this.boxes[positionUnder].Top = true;
                            this.BoxesObservable[positionUnder].Top = this.currentPlayer.Color;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Line is undefined.");
            }

            //check current box
            var positionForCheck = new int[] { position - 8, position, position + 8 };
            for (int i = 0; i < positionForCheck.Length; i++)
            {
                if (this.CheckBoxIsFilled(positionForCheck[i]))
                {
                    this.bonus = true;
                    this.boxes[positionForCheck[i]].IsFilled = true;
                    this.BoxesObservable[positionForCheck[i]].PlayerColor = this.currentPlayer.Color;
                }
            }
        }
    }
}
