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
using WpfApp2;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> OrderedPizzas;
        private decimal TotalPrice;

        public string pizzas;
        public string CustomizedPizza { get; private set; }
        public decimal CustomizedPrice { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = Pizza.SelectedItems.Cast<ListBoxItem>();
            OrderedPizzas = new List<string>();
            TotalPrice = 0;

            foreach (var item in selectedItems)
            {
                string pizzaName = item.Content.ToString();
                string priceText = item.Tag.ToString();
                decimal pizzaPrice = decimal.Parse(priceText);

                OrderedPizzas.Add(pizzaName);
                TotalPrice += pizzaPrice;
            }

            Bestiling.Text += string.Join(", ", OrderedPizzas);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Bestiling.Clear();
            Pizza.SelectedItems.Clear();

            CustomizedPrice = 0;

            CustomizedPizza = null;

            OrderedPizzas = null;

            TotalPrice = 0;
        }

         
        private void CustomizePizza_Click(object sender, RoutedEventArgs e)
        {
            CustomizePizza customizePizzaWindow = new CustomizePizza();
            customizePizzaWindow.ShowDialog();

            // Check if customization was confirmed
            if (!string.IsNullOrEmpty(customizePizzaWindow.CustomizedPizza))
            {
                pizzas = "Pizza med ";
                // Update your order or display the customized pizza in the Bestiling TextBox
                string customizedPizza = customizePizzaWindow.CustomizedPizza;
                decimal customizedPrice = customizePizzaWindow.CustomizedPrice;

                // Append or update the Bestiling TextBox with the customized pizza
                Bestiling.Text += $"\nCustomized Pizza: {customizedPizza} ({customizedPrice}kr)";

                customizedPizza = pizzas + customizedPizza;

                CustomizedPrice = customizedPrice;
                CustomizedPizza = customizedPizza;

            }
        }
        private void Bestilb_Click(object sender, RoutedEventArgs e)
        {
            Bestilingw newWindow = new Bestilingw(OrderedPizzas, TotalPrice, CustomizedPizza, CustomizedPrice);
            newWindow.Show();
        }

    }
}