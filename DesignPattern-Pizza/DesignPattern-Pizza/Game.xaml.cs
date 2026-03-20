using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using DesignPattern_Pizza.Topping;

namespace DesignPattern_Pizza
{
    public partial class Game : Window
    {
        IPizza _currentPizza;
        private decimal _earnings = 0;
        private bool _baseChosen = false;

        public Game()
        {
            InitializeComponent();
            _currentPizza = new Base();
        }

        private void PlaySound()
        {
            var sound = new MediaPlayer();
            sound.Open(new Uri("Sounds/balloon.mp3", UriKind.Relative));
            sound.Play();
        }

        private void LockBases()
        {
            BtnMargherita.IsEnabled = false;
            BtnBianca.IsEnabled = false;
        }

        private void ResetPizza()
        {
            _currentPizza = new Base();
            _baseChosen = false;

            var toRemove = new List<UIElement>();
            foreach (UIElement child in PizzaCanvas.Children)
                if (child is Image) toRemove.Add(child);
            foreach (var child in toRemove)
                PizzaCanvas.Children.Remove(child);

            BtnMargherita.IsEnabled = true;
            BtnBianca.IsEnabled = true;
            FlameLabel.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            PizzaStatusBlock.Text = "Your Pizza: Empty";
            PriceStatusBlock.Text = "Current Price: ";
        }

        // Bases
        private void Margherita_Click(object sender, RoutedEventArgs e)
        {
            if (_baseChosen) return;
            _baseChosen = true;
            LockBases();

            _currentPizza = new MargheritaBase(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Margarita base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PlaySound();
            PizzaCanvas.Children.Add(img);
            PizzaStatusBlock.Text = _currentPizza.GetDescription();
            PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Bianca_Click(object sender, RoutedEventArgs e)
        {
            if (_baseChosen) return;
            _baseChosen = true;
            LockBases();

            _currentPizza = new BiancaBase(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Bianca base.png")),
                Width = 500,
                Height = 500,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PlaySound();
            PizzaCanvas.Children.Add(img);
            PizzaStatusBlock.Text = _currentPizza.GetDescription();
            PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        // Toppings
        private void Kebab_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new KebabDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Kebab_Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PlaySound();
            PizzaCanvas.Children.Add(img);
            PizzaStatusBlock.Text = _currentPizza.GetDescription();
            PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Mozza_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new MozzarellaDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Mozzarella Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PlaySound();
            PizzaCanvas.Children.Add(img);
            PizzaStatusBlock.Text = _currentPizza.GetDescription();
            PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Parma_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new ParmaDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Parma Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PlaySound();
            PizzaCanvas.Children.Add(img);
            PizzaStatusBlock.Text = _currentPizza.GetDescription();
            PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        private void Gorgon_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }
            _currentPizza = new GorgonzolaDecorator(_currentPizza);
            var img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images_png/Gorgonzola Topping.png")),
                Width = 650,
                Height = 650,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            PlaySound();
            PizzaCanvas.Children.Add(img);
            PizzaStatusBlock.Text = _currentPizza.GetDescription();
            PriceStatusBlock.Text = $"Current Price: {_currentPizza.GetPrice()} kr.";
        }

        // Bake
        private async void Bake_Click(object sender, RoutedEventArgs e)
        {
            if (!_baseChosen) { MessageBox.Show("Choose a base first!"); return; }

            BakeButton.IsEnabled = false;
            KebabButton.IsEnabled = false;
            MozzaButton.IsEnabled = false;
            ParmaButton.IsEnabled = false;
            GorgonButton.IsEnabled = false;
            MenuButton.IsEnabled = false;

            PizzaCanvas.Visibility = Visibility.Hidden;
            PizzaStatusBlock.Visibility = Visibility.Hidden;
            PriceStatusBlock.Visibility = Visibility.Hidden;

            FlameLabel.Foreground = Brushes.OrangeRed;
            await Task.Delay(2000);
            FlameLabel.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            await Task.Delay(300);

            // Replace this condition with your CustomerOrder logic
            bool correct = _currentPizza.GetDescription().Contains("Margherita")
                        && _currentPizza.GetDescription().Contains("Mozzarella")
                        && _currentPizza.GetDescription().Contains("Kebab");

            if (correct)
            {
                decimal earned = _currentPizza.GetPrice();
                _earnings += earned;
                EarningsLabel.Text = $"DKK {_earnings:0.00}";
                MessageBox.Show($"✅ Perfect! The customer loved it!\n+DKK {earned:0.00}", "Great job!");
            }
            else
            {
                MessageBox.Show("❌ Wrong pizza! The customer is unhappy.\n+DKK 0.00", "Oops!");
            }

            PizzaCanvas.Visibility = Visibility.Visible;
            PizzaStatusBlock.Visibility = Visibility.Visible;
            PriceStatusBlock.Visibility = Visibility.Visible;

            ResetPizza();

            BakeButton.IsEnabled = true;
            KebabButton.IsEnabled = true;
            MozzaButton.IsEnabled = true;
            ParmaButton.IsEnabled = true;
            GorgonButton.IsEnabled = true;
            MenuButton.IsEnabled = true;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ResetPizza();
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }
    }
}