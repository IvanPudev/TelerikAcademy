using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Paint
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        RotateTransform canvasRotation = new RotateTransform();
        TranslateTransform stackPanelTranslation = new TranslateTransform();

        private Color currentColor = Windows.UI.Color.FromArgb(255, 255, 0, 0);
        private Shape currentElement = new Windows.UI.Xaml.Shapes.Rectangle();


        public MainPage()
        {
            this.InitializeComponent();

            ElementMenu.RenderTransform = stackPanelTranslation;
            Palette.RenderTransform = canvasRotation;
        }

        

        public void DrawElement(object sender, TappedRoutedEventArgs e)
        {
            var position = e.GetPosition(DrawingSheet);
            
            if (currentElement is Rectangle)
            {
                var rect = new Rectangle();
                rect.Fill = new Windows.UI.Xaml.Media.SolidColorBrush(currentColor);
                rect.Width = 40;
                rect.Height = 40;
                rect.SetValue(Canvas.TopProperty, position.Y);
                rect.SetValue(Canvas.LeftProperty, position.X);
                DrawingSheet.Children.Add(rect);
            }
            else if (currentElement is Ellipse)
            {
                var ellipse = new Ellipse();
                ellipse.Fill = new Windows.UI.Xaml.Media.SolidColorBrush(currentColor);
                ellipse.Width = 40;
                ellipse.Height = 40;
                ellipse.SetValue(Canvas.TopProperty, position.Y);
                ellipse.SetValue(Canvas.LeftProperty, position.X);
                DrawingSheet.Children.Add(ellipse);
            }
            else if (currentElement is Line)
            {
                var line = new Line();
                line.Fill = new Windows.UI.Xaml.Media.SolidColorBrush(currentColor);
                line.SetValue(Canvas.TopProperty, position.Y);
                line.SetValue(Canvas.LeftProperty, position.X);
                line.X1 = position.X;
                line.Y1 = position.Y;
                line.Y2 = position.Y;
                line.X2 = position.X + 40;
                line.Width = 10;
                
                DrawingSheet.Children.Add(line);
            }
        }

        public void PalettePositionCheck(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (canvasRotation.Angle > 360)
            {
                canvasRotation.Angle = canvasRotation.Angle - 360;
            }
            if (315 <= canvasRotation.Angle || canvasRotation.Angle <= 45)
            {
                canvasRotation.Angle = 0;
                currentColor = Windows.UI.Color.FromArgb(255, 255, 0, 0);
            }
            else if (45 < canvasRotation.Angle && canvasRotation.Angle <= 135 )
            {
                canvasRotation.Angle = 90;
                currentColor = Windows.UI.Color.FromArgb(255, 0, 255, 0);
            }
            else if (135 < canvasRotation.Angle && canvasRotation.Angle <= 255)
            {
                canvasRotation.Angle = 180;
                currentColor = Windows.UI.Color.FromArgb(255, 255, 255, 0);
            }
            else if (225 < canvasRotation.Angle && canvasRotation.Angle <= 314)
            {
                canvasRotation.Angle = 270;
                currentColor = Windows.UI.Color.FromArgb(255, 0, 0, 255);
            }
        }

        public void ElementMenuPositionCheck(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (stackPanelTranslation.X <= 45)
            {
                currentElement = new Windows.UI.Xaml.Shapes.Rectangle();
                stackPanelTranslation.X = 0;
                
            }
            else if (45 >= stackPanelTranslation.X || stackPanelTranslation.X <= 135)
            {
                currentElement = new Windows.UI.Xaml.Shapes.Ellipse();
                stackPanelTranslation.X = 90;
                
            }
            else if (stackPanelTranslation.X >= 135)
            {
                currentElement = new Windows.UI.Xaml.Shapes.Line();
                stackPanelTranslation.X = 180;
                
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void MovingElementMenu(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var xOffset = e.Delta.Translation.X;

            stackPanelTranslation.X += xOffset;
        }

        private void RotatePalette(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var canvas = sender as Canvas;
            
            canvasRotation.Angle += e.Delta.Rotation;
            canvasRotation.CenterX = canvas.Width / 2;
            canvasRotation.CenterY = canvas.Height / 2;
        }


    }
}
