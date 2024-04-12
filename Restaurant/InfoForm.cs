using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.ModelData;

namespace Restaurant
{
    public partial class InfoForm : Form
    {
        private Menus _menu;
        public InfoForm(Menus menu)
        {
            InitializeComponent();
            _menu = menu;
            LoadData();
        }
        private void LoadData()
        {
            textBoxName.Text = _menu.Name;
            textBoxWeight.Text = _menu.Weight.ToString();
            textBoxUnit.Text = _menu.Unit.ToString();
            textBoxCost.Text = _menu.Cost.ToString();
            textBoxIngredients.Text = _menu.Ingredients;
            pictureBox1.Image = Restaurant.Properties.Resources.placeholder;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
