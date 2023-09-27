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
    /// Interaction logic for CustomizePizza.xaml
    /// </summary>
    /// 


    public partial class CustomizePizza : Window
    {


        private decimal toppingPrice = 5.0M;

        private decimal basePizzaPrice = 50.0M;
        public string CustomizedPizza { get; private set; }
        public decimal CustomizedPrice { get; private set; }

        public CustomizePizza()
        {
            InitializeComponent();
        }


        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // Build the customized pizza based on user choices
            StringBuilder customizedPizzaBuilder = new StringBuilder();
            decimal customizedPrice = basePizzaPrice;

            // Process selected toppings
            foreach (CheckBox toppingCheckBox in ToppingsPanel.Children.OfType<CheckBox>())
            {
                if (toppingCheckBox.IsChecked == true)
                {
                    string topping = toppingCheckBox.Content.ToString();
                    customizedPizzaBuilder.Append(topping + ", ");
                    customizedPrice += toppingPrice;
                }
            }
            string additionalInstructions = InstructionsTextBox.Text;
            if (!string.IsNullOrEmpty(additionalInstructions))
            {
                customizedPizzaBuilder.Append("Customized Pizza: " + additionalInstructions + ", ");
            }

 
            CustomizedPizza = customizedPizzaBuilder.ToString().TrimEnd(',', ' ');
            CustomizedPrice = customizedPrice;


            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
