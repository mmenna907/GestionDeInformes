using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Forms
{
    public partial class PrincipalFrm : Form
    {
        public PrincipalFrm()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirEnPanel<EmpleadosFrm>();
        }
        private void btnInformes_Click(object sender, EventArgs e)
        {
            AbrirEnPanel<InformesFrm>();
        }
        private void AbrirEnPanel<Forms>() where Forms : Form, new()
        {
            //-----------ABRO O MUESTRO EL FORMULARIO EN EL PANEL CENTRAL----------- 
            Form formAbrir = panelContenedor.Controls.OfType<Forms>().FirstOrDefault();

            //si el formulario/instancia no existe, creamos nueva instancia y mostramos
            if (formAbrir == null)
            {
                formAbrir = new Forms
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelContenedor.Controls.Add(formAbrir);
                panelContenedor.Tag = formAbrir;
                formAbrir.Show();
                formAbrir.BringToFront();
            }
            else
            {
                //si la Formulario/instancia existe, lo traemos a frente
                formAbrir.BringToFront();
                //Si la instancia esta minimizada mostramos
                if (formAbrir.WindowState == FormWindowState.Minimized)
                    formAbrir.WindowState = FormWindowState.Normal;
            }
        }
    }
}
