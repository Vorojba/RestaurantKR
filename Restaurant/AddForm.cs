using System;
using System.Drawing;
using System.Windows.Forms;
using Restaurant.ModelData;

namespace Restaurant
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxName.Text) ||
                String.IsNullOrWhiteSpace(textBoxCost.Text)) 
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            Menus menu = new Menus();
            menu.Name = textBoxName.Text;
            menu.Cost = 0;
            menu.Weight = 0; 
            menu.Unit = textBoxUnit.Text;
            menu.Ingredients = textBoxIngredients.Text;
            try
            {
                model.Menu.Add(menu);
                model.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Данные добавлены!");
                Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фото продукции";
            ofd.Filter = "Файл JPG, PNG|*.jpg;*.png|Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }
}
