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

namespace Restaurant.UserElement
{
    public partial class UserTile : UserControl
    {
        private Menus _menu;
        private Model1 model = new Model1();
        public UserTile(Menus menu)
        {
            InitializeComponent();
            Fill(menu);
        }
        public void Fill(Menus menu)
        {
            _menu = menu;
            labelName.Text = _menu.Name;
            labelCost.Text = $"{_menu.Cost} руб.";
            pictureBox1.Image = Restaurant.Properties.Resources.placeholder;
        }
        private void Delete()
        {
            DialogResult result = MessageBox.Show(
                $"Вы действительно хотите удалить продукцию с ID {_menu.ID}",
                "Сообщение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    model.Menu.Remove(
                        model.Menu.First((x => x.ID == _menu.ID)));
                    model.SaveChanges();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Clicking(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                InfoForm info = new InfoForm(_menu);
                info.ShowDialog();
            }
            else if (e.Button == MouseButtons.Right)
            {
                Delete();
            }
        }

        private void Controls_Click(object sender, MouseEventArgs e)
        {
            Clicking(e);
        }
    }
}
