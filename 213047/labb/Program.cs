using System;
using System.Windows.Forms;

namespace _213047_Q1
{
    public partial class RestaurantMenuForm : Form
    {
        public RestaurantMenuForm()
        {
            InitializeComponent();
        }
        private void CalculateTotalButton_Click(object sender, EventArgs e)
        {
            double totalBill = 0.0;

            totalBill += CalculateGroupTotal(StarterGroupBox);

            totalBill += CalculateGroupTotal(MainCourseGroupBox);

            totalBill += CalculateGroupTotal(SweetDishGroupBox);

            TotalAmountTextBox.Text = totalBill.ToString("C");

        }

        private double CalculateGroupTotal(GroupBox group)
        {
            double groupTotal = 0.0;

            foreach (Control control in group.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    string itemName= checkBox.Text;
                    double itemPrice = Convert.ToDouble(control.Tag);

                    int itemQuantity = Convert.ToInt32(control.Controls.Find(itemName + "QuantityTextBox", false)[0].Text);
                    groupTotal += itemPrice * itemQuantity;
                }
            }
            return groupTotal;
        }
    }
}