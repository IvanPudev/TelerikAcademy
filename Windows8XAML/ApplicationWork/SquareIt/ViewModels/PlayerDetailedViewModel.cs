using Newtonsoft.Json;
using SquareIt.Commands;
using SquareIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;

namespace SquareIt.ViewModels
{
    public class PlayerDetailedViewModel : ViewModelBase
    {
        private readonly INavigationService navigation;
        private readonly IEnumerable<Color> colors = new Color[]
        {
            Windows.UI.Colors.Blue, 
            Windows.UI.Colors.Red, 
            Windows.UI.Colors.Yellow,
            Windows.UI.Colors.Green
        };
        private ICommand startGame;
        private string firstPlayerName;
        private string secondPlayerName;
        private Color secondPlayerColor;
        private Color firstPlayerColor;

        public PlayerDetailedViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
            this.Colors = colors;
            this.OnPropertyChanged("Colors");
        }

        public string FirstPlayerName
        {
            get
            {
                return this.firstPlayerName;
            }
            set
            {
                if (this.firstPlayerName != value)
                {
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    localSettings.Values["FirstPlayerName"] = value;

                    this.firstPlayerName = value;
                    this.OnPropertyChanged("FirstPlayerName");
                }
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return this.secondPlayerName;
            } 
            set
            {
                if (this.secondPlayerName != value)
                {
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    localSettings.Values["SecondPlayerName"] = value;

                    this.secondPlayerName = value;
                    this.OnPropertyChanged("SecondPlayerName");
                }
            }
        }

        public Color SecondPlayerColor
        {
            get
            {
                return this.secondPlayerColor;
            } 
            set
            {
                if (this.secondPlayerColor != value)
                {

                    this.secondPlayerColor = value;
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    localSettings.Values["SecondPlayerColor"] = JsonConvert.SerializeObject(secondPlayerColor);

                    
                }
            }
        }

        public Color FirstPlayerColor
        {
            get
            {
                return this.firstPlayerColor;
            }
            set
            {
                if (this.firstPlayerColor != value)
                {
                    this.firstPlayerColor = value;
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    localSettings.Values["FirstPlayerColor"] = JsonConvert.SerializeObject(firstPlayerColor);

                    
                }
            }
        }

        public IEnumerable<Color> Colors { get; set; }

        public ICommand StartGame
        {
            get
            {
                if (this.startGame == null)
                {
                    this.startGame = new DelegateCommand<object>(this.HandleStartGame);
                }

                return startGame;
            }
        }

        private void HandleStartGame(object parameter)
        {
            navigation.Navigate(SquareIt.Services.Views.GameSizeS);
        }
    }
}
