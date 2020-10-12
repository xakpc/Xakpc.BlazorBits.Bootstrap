using System.Collections.ObjectModel;

namespace Xakpc.BlazorBits.Bootstrap.Pages
{
    /// <summary>
    /// No view model here which is wrong
    /// </summary>
    public partial class Buttons
    {
        public Buttons()
        {
            // b
            AddCommand = new Command<int>(DoAdd);

            // bg
            Items = new ObservableCollection<string>()
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };
            Items.CollectionChanged += (sender, args) => StateHasChanged();

            EditItemCommand = new Command<string>(s =>
            {
                if (Items.Contains(s))
                    Items[Items.IndexOf(s)] = "Edited Item";
            });
            DeleteItemCommand = new Command<string>(s => Items.Remove(s));
        }

        private int Value { get; set; } = 10;

        private System.Windows.Input.ICommand AddCommand { get; set; }

        private void DoAdd(int p)
        {
            Value += p;
            StateHasChanged(); // <--- nog gonna work without it
        }

        #region ButtonsGroup
        private ObservableCollection<string> Items;

        private System.Windows.Input.ICommand EditItemCommand { get; set; }

        private System.Windows.Input.ICommand DeleteItemCommand { get; set; }
        #endregion
    }
}
