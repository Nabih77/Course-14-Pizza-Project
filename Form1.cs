using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_14_Pizza_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float GetSelectedSizePrice()
        {
            if(rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }
                

            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);

            else
                return Convert.ToSingle(rbLarge.Tag);
        }

        float GetSelectedCrustPrice()
        {
            if (rbThin.Checked)
                return Convert.ToSingle(rbThin.Tag); 
            else
                return Convert.ToSingle(rbThink.Tag);
        }

        float CalculateToppingsPrice()
        {
            float TotalPrice = 0;

            if(chkExstraChees.Checked)
            {
                TotalPrice += Convert.ToSingle(chkExstraChees.Tag);
            }
            if(chkGreenPeppers.Checked)
            {
                TotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }
            if(chkMushrooms.Checked)
            {
                TotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }
            if(chkOlives.Checked)
            {
                TotalPrice += Convert.ToSingle(chkOlives.Tag);
            }
            if(chkOnion.Checked)
            {
                TotalPrice += Convert.ToSingle(chkOnion.Tag);
            }
            if(chkTomatoes.Checked)
            {
                TotalPrice += Convert.ToSingle(chkTomatoes.Tag);
            }
            return TotalPrice;
        }

        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + GetSelectedCrustPrice() + CalculateToppingsPrice();
        }

        void UpdateTotalPrice()
        {
            lblPrice.Text = "$" + CalculateTotalPrice().ToString();
        } 

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }

        }

        void UpdateCrust()
        {
            UpdateTotalPrice(); 

            if (rbThin.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }

            if (rbThink.Checked)
            {
                lblCrustType.Text = "Think Crust";
                return;
            }
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";

            if(chkExstraChees.Checked)
            {
                sToppings += "Exstra Chees";
            }

            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }

            if (chkGreenPeppers.Checked)
            {
                sToppings += ", Green Peppers";
            }

            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (chkOnion.Checked)
            {
                sToppings += ", Onion";
            }

            if (chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }
            if(sToppings == "")
            {
                sToppings = "No Toppings";
            }
            lblToppings.Text = sToppings;
        }

        void UpdateTotalSummary()
        {
            UpdateTotalPrice();
            UpdateSize();
            UpdateCrust();
            UpdateToppings();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThink_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = "Eat In";
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = "Take Out";
        }

        private void btnPizzaOrder_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Order","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully","Seccess",MessageBoxButtons.OK,MessageBoxIcon.Information);

                btnPizzaOrder.Enabled = false;
                gbSize.Enabled = false;
                gbCrust.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;

            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            btnPizzaOrder.Enabled = true;
            gbSize.Enabled = true;
            gbCrust.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
        }

        private void chkExstraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTotalSummary();
        }
    }
}
