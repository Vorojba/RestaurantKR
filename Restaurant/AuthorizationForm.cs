using System;
using System.Linq;
using System.Windows.Forms;
using Restaurant.ModelData;

namespace Restaurant
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }
        public static Workers Enter_workers;

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            Enter_workers = null;
            Model1 model = new Model1();
            Enter_workers = model.Workers.FirstOrDefault(x => x.Login == textBoxLogin.Text && x.Password == textBoxPassword.Text);
            if(Enter_workers != null )
            {
                switch (Enter_workers.RoleID)
                {
                    case 2:
                        MForm menu = new MForm();
                        menu.ShowDialog();
                        break;
                    case 4:
                        MForm menuForm = new MForm();
                        menuForm.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("Роль не найдена!");
                        break;
                }
            }
        }

    }
}
