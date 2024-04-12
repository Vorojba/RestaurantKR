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
using Restaurant.UserElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Restaurant
{
    public partial class MForm : Form
    {
        private enum SwipeType
        {
            Left, Right
        }
        private Model1 model = new Model1();
        private List<Menus> menu = new List<Menus>();
        private int SwipeID;
       
        private void Loadproducts()
        {
            menu.Clear();
            SwipeID = 0;
            menu = model.Menu.ToList();
        }

        private void Sort()
        {
            if (checkBoxMax.Checked == false)
            {
                if (comboBoxFiltr.SelectedIndex == 0)
                    menu = menu.OrderByDescending(x => x.Name).ToList();
                else if (comboBoxFiltr.SelectedIndex == 1)
                    menu = menu.OrderByDescending(x => x.Cost).ToList();
            }
            else
            {
                if (comboBoxFiltr.SelectedIndex == 0)
                    menu = menu.OrderBy(x => x.Name).ToList();
                else if (comboBoxFiltr.SelectedIndex == 1)
                    menu = menu.OrderBy(x => x.Cost).ToList();
            }
            CreateTile();
        }
        private void Sort2()
        {
            if (checkBoxMin.Checked == false)
            {
                if (comboBoxFiltr.SelectedIndex == 0)
                    menu = menu.OrderBy(x => x.Name).ToList();
                else if (comboBoxFiltr.SelectedIndex == 1)
                    menu = menu.OrderBy(x => x.Cost).ToList();
            }
            else
            {
                if (comboBoxFiltr.SelectedIndex == 0)
                    menu = menu.OrderByDescending(x => x.Name).ToList();
                else if (comboBoxFiltr.SelectedIndex == 1)
                    menu = menu.OrderByDescending(x => x.Cost).ToList();
            }
            CreateTile();
        }


        private void SetTextlabel()
        {
            if (menu.Count != 0)
            {
                labelCount.Text = menu.Count >= 4 ?
                    $"с {SwipeID + 1} по {SwipeID + 4} из {menu.Count} товаров" :
                    $"с 1 по {menu.Count} товаров";
            }
            else
                labelCount.Text = $"с 0 из {menu.Count} товаров";
        }

        private void CreateTile()
        {
            FLPTile.Controls.Clear();
            SetTextlabel();
            for (int i = 0; i < 4; i++)
            {
                if (menu.Count > i)
                {
                    int count = i + SwipeID;
                    UserTile tile = new UserTile(menu[count]);
                    FLPTile.Controls.Add(tile);
                }
            }
        }

        private void Search()
        {
            menu.Clear();
            SwipeID = 0;
            menu = model.Menu.Where(
                x => x.Name.Contains(textBoxSearch.Text)).ToList();
            labelNothing.Visible = menu.Count == 0 ? true : false;
            CreateTile();
        }

        private void Swipe(SwipeType swipeType)
        {
            if (swipeType == SwipeType.Left && SwipeID != 0)
            {
                SwipeID--;
                CreateTile();
            }
            if (swipeType == SwipeType.Right && SwipeID + 5 < menu.Count - 1)
            {
                SwipeID++;
                CreateTile();
            }
        }

        public MForm()
        {
            InitializeComponent();
            Loadproducts();
            CreateTile();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            Swipe(SwipeType.Left);
        }

        private void buttonLeft2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                Swipe(SwipeType.Left);
        }

        private void buttonRight2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                Swipe(SwipeType.Right);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            Swipe(SwipeType.Right);
        }

        private void comboBoxFiltr_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sort();
            Sort2();
        }

        private void checkBoxMax_CheckedChanged(object sender, EventArgs e)
        {
            Sort();
        }

        private void checkBoxMin_CheckedChanged(object sender, EventArgs e)
        {
            Sort2();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
        }

        private void labelNothing_Click(object sender, EventArgs e)
        {

        }
    }
}
