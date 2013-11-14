using SquareIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIt.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private INavigationService navigation;

        public AppViewModel()
            : base()
        {
            this.navigation = new NavigationService();
            this.HomeVM = new HomeViewModel(this.navigation);
            this.PlayerVM = new PlayerDetailedViewModel(this.navigation);
            this.GameVM = new GameViewModel();
        }

        public HomeViewModel HomeVM { get; set; }
        public PlayerDetailedViewModel PlayerVM { get; set; }
        public GameViewModel GameVM { get; set; }

    }
}
