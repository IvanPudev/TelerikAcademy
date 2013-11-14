using CalculateAndConcatenatePrimes.Helpers;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CalculateAndConcatenatePrimes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        public async void ConcatenateNumbersClick(object sender, RoutedEventArgs e)
        {
            int firstNumber = int.Parse(FirstNumber.Text);
            int lasttNumber = int.Parse(LastNumber.Text);

            if (this.NumbersSwitch.IsOn)
            {
                var primes = await PrimesCalculator.GetPrimesInRangeAsync(firstNumber, lasttNumber);
                var concatenatedPrimes = await PrimesCalculator.ConcatenateNumberssAsync(primes);
                Content.Text = await concatenatedPrimes.JoinAsStringAsync<int>(", ");
            }
            else
            {
                var complexNumbers = await PrimesCalculator.GetComplexNumbersAsync(firstNumber, lasttNumber);
                var concatenatedComplexNumbers = await PrimesCalculator.ConcatenateNumberssAsync(complexNumbers);
                Content.Text = await concatenatedComplexNumbers.JoinAsStringAsync<int>(", ");
            }
            
        }

        public async void ConcatenateNumbersClick1(object sender, RoutedEventArgs e)
        {
            int firstNumber = int.Parse(FirstNumber1.Text);
            int lasttNumber = int.Parse(LastNumber1.Text);

            if (this.NumbersSwitch.IsOn)
            {
                var primes = await PrimesCalculator.GetPrimesInRangeAsync(firstNumber, lasttNumber);
                var concatenatedPrimes = await PrimesCalculator.ConcatenateNumberssAsync(primes);
                Content1.Text = await concatenatedPrimes.JoinAsStringAsync<int>(", ");
            }
            else
            {
                var complexNumbers = await PrimesCalculator.GetComplexNumbersAsync(firstNumber, lasttNumber);
                var concatenatedComplexNumbers = await PrimesCalculator.ConcatenateNumberssAsync(complexNumbers);
                Content1.Text = await concatenatedComplexNumbers.JoinAsStringAsync<int>(", ");
            }

        }

        public async void ConcatenateNumbersClick2(object sender, RoutedEventArgs e)
        {
            int firstNumber = int.Parse(FirstNumber2.Text);
            int lasttNumber = int.Parse(LastNumber2.Text);

            if (this.NumbersSwitch.IsOn)
            {
                var primes = await PrimesCalculator.GetPrimesInRangeAsync(firstNumber, lasttNumber);
                var concatenatedPrimes = await PrimesCalculator.ConcatenateNumberssAsync(primes);
                Content2.Text = await concatenatedPrimes.JoinAsStringAsync<int>(", ");
            }
            else
            {
                var complexNumbers = await PrimesCalculator.GetComplexNumbersAsync(firstNumber, lasttNumber);
                var concatenatedComplexNumbers = await PrimesCalculator.ConcatenateNumberssAsync(complexNumbers);
                Content2.Text = await concatenatedComplexNumbers.JoinAsStringAsync<int>(", ");
            }

        }

        public async void ConcatenateNumbersClick3(object sender, RoutedEventArgs e)
        {
            int firstNumber = int.Parse(FirstNumber3.Text);
            int lasttNumber = int.Parse(LastNumber3.Text);

            if (this.NumbersSwitch.IsOn)
            {
                var primes = await PrimesCalculator.GetPrimesInRangeAsync(firstNumber, lasttNumber);
                var concatenatedPrimes = await PrimesCalculator.ConcatenateNumberssAsync(primes);
                Content3.Text = await concatenatedPrimes.JoinAsStringAsync<int>(", ");
            }
            else
            {
                var complexNumbers = await PrimesCalculator.GetComplexNumbersAsync(firstNumber, lasttNumber);
                var concatenatedComplexNumbers = await PrimesCalculator.ConcatenateNumberssAsync(complexNumbers);
                Content3.Text = await concatenatedComplexNumbers.JoinAsStringAsync<int>(", ");
            }

        }

        
    }
}
