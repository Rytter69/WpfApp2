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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Bestilingw.xaml
    /// </summary>
    public partial class Bestilingw : Window
    {
        private List<string> OrderedPizzas;
        private decimal TotalPrice;

        public string CustomizedPizza { get; private set; }
        public decimal CustomizedPrice { get; private set; }


        public Bestilingw(List<string> orderedPizzas, decimal totalPrice, string customizedPizza, decimal customizedPrice)
        {
            InitializeComponent();

            // Initialize the orderedPizzas list if it's null
            OrderedPizzas = orderedPizzas ?? new List<string>();
            TotalPrice = totalPrice;

            CustomizedPizza = customizedPizza;
            CustomizedPrice = customizedPrice;

            totalPrice = totalPrice + CustomizedPrice;

            // Update text boxes with the ordered pizzas and total price
            string orderedPizzaText = string.Join(", ", OrderedPizzas);
            string orderedPizzaText1 = string.Join(", ", CustomizedPizza);
            BestiltePizzaerText.Text = orderedPizzaText + orderedPizzaText1;
            SamletBeløbText.Text = $"Kr. {totalPrice}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
