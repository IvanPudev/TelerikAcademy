using SquareIt.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SquareIt.Services
{
    public class NavigationService : INavigationService
    {
        public void Navigate(Views sourcePageType)
        {
            var pageType = this.GetViewType(sourcePageType);

            if(pageType != null)
            {
                ((Frame)Window.Current.Content).Navigate(pageType);
            }
        }

        public void Navigate(Views sourcePageType, object parameter)
        {
            var pageType = this.GetViewType(sourcePageType);

            if (pageType != null)
            {
                ((Frame)Window.Current.Content).Navigate(pageType, parameter);
            }
        }

        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }

        private Type GetViewType(Views view)
        {
            switch(view)
            {
                case Views.Main:
                    return typeof(MainPage);
                case Views.PlayerInfo:
                    return typeof(PlayerInfoPage);
                case Views.GameSizeS:
                    return typeof(GameSizeSPage);
                default:
                    break;
            }
            return null;
        }
    }
}
