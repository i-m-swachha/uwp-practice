using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpCards
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<CardItem> FirstCards { get; } = new ObservableCollection<CardItem>();
        public ObservableCollection<CardItem> SecondCards { get; } = new ObservableCollection<CardItem>();

        public MainPage()
        {
            this.InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Sample data loading
            for (int i = 1; i <= 15; i++)
            {
                FirstCards.Add(new CardItem
                {
                    Title = $"Card {i}",
                    Description = $"Description for card {i} in first list",
                    ImageUrl = "Assets/coffee.jpg"
                });

               SecondCards.Add(new CardItem
                {
                    Title = $"Card {i}",
                    Description = $"Description for card {i} in second list",
                    ImageUrl = "Assets/coffee.jpg"
                });
            }
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle button clicks
            // Example: var button = sender as Button;
            //          var card = button.DataContext as CardItem;
            //          // Do something with card
        }
    }

    public class CardItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
