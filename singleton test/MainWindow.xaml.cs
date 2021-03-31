using Microsoft.Azure.Amqp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace singleton_test
{
    public partial class MainWindow : Window
    {
        private bool Refresh = false;
        private bool edited = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddItem()
        {
            ItemsList.Items.Add(new ItemPop(ItemBox.Text, PriceBox.Text));

            ItemsList.SelectedIndex = ItemsList.Items.Count - 1;

            Singleton.Instance.Add(ItemBox.Text, PriceBox.Text);

            ItemBox.Focus();
        }

        private void dataEdited(bool value)
        {
            edited = value;

        }
        private void RefreshListView(string value1, string value2)
        {
            ItemPop lvc = (ItemPop)ItemsList.SelectedItem;
            if (lvc != null && !Refresh)
            {
                dataEdited(true);

                lvc.Items = value1;
                lvc.Price = value2;

                ItemsList.Items.Refresh();
            }
        }
        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            dataEdited(true);
            AddItem();
        }
        private void deleteItem_Click(object sender, RoutedEventArgs e)
        {
            dataEdited(true);
            int itemIndex = ItemsList.SelectedIndex;

            ItemsList.Items.Remove(ItemsList.SelectedItem);

            Singleton.Instance.Delete(ItemBox.Text);

            if (ItemsList.Items.Count == 0)
            {
                AddItem();
            }
            else if (itemIndex <= ItemsList.Items.Count - 1)
            {
                ItemsList.SelectedIndex = itemIndex;
            }
            else
            {
                ItemsList.SelectedIndex = ItemsList.Items.Count - 1;
            }
        }
        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemPop lvc = (ItemPop)ItemsList.SelectedItem;
            if (lvc != null)
            {
                Refresh = true;
                ItemBox.Text = lvc.Items;
                PriceBox.Text = lvc.Price;
                Refresh = false;
            }
        }


    }
}
