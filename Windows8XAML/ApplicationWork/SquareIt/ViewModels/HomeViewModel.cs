using SquareIt.Commands;
using SquareIt.Services;
using SquareIt.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace SquareIt.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private ICommand gotoPlayerInfoPage;

        public HomeViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }

        public ICommand GotoPlayerInfoPage
        {
            get
            {
                if (this.gotoPlayerInfoPage == null)
                {
                    this.gotoPlayerInfoPage = new DelegateCommand<object>(this.HandleGotoPlayerInfoPage);
                }
                return gotoPlayerInfoPage;
            }
        }

        public void HandleGotoPlayerInfoPage(object obj)
        {
            navigation.Navigate(SquareIt.Services.Views.PlayerInfo);
        }
    }
}
