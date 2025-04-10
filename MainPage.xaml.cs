using System.Collections.ObjectModel;
using Windows.ApplicationModel.DataTransfer;
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

        private void ListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            // Store both the item and source list view
            e.Data.Properties.Add("DraggedItem", e.Items[0]);
            e.Data.Properties.Add("SourceListView", sender);
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Move;
            e.DragUIOverride.IsCaptionVisible = false;
            e.DragUIOverride.IsGlyphVisible = false;
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Properties.TryGetValue("DraggedItem", out object draggedItemObj) &&
                e.DataView.Properties.TryGetValue("SourceListView", out object sourceListViewObj) &&
                sourceListViewObj is ListView sourceListView &&
                sender is ListView targetListView)
            {
                if (sourceListView == targetListView) return;

                if (draggedItemObj is CardItem draggedItem)
                {
                    // Remove from source collection
                    if (sourceListView.ItemsSource is ObservableCollection<CardItem> sourceCollection)
                    {
                        sourceCollection.Remove(draggedItem);
                    }

                    // Add to target collection
                    if (targetListView.ItemsSource is ObservableCollection<CardItem> targetCollection)
                    {
                        targetCollection.Add(draggedItem);
                    }
                }
            }
        }
    }

    public class CardItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}