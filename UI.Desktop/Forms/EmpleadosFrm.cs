using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aplication;
using UI.Desktop.ViewModels;

namespace UI.Desktop.Forms
{
    public partial class EmpleadosFrm : Form
    {
        public EmpleadosFrm()
        {
            InitializeComponent();
        }

        private void EmpleadosFrm_Load(object sender, EventArgs e)
        {
            GetEmpleados();
        }

        private void GetEmpleados()
        {
            var empleados = new EmpleadoService().GetEmpleados();
            List<EpleadoViewModel> empleadosViewModel = new List<EpleadoViewModel>();
            foreach (var item in empleados)
            {
                empleadosViewModel.Add(new EpleadoViewModel
                {
                    Legajo = item.Legajo,
                    Nombre = item.Nombre,
                    DNI = item.Dni
                });
            }
            gridEmpleados.DataSource=empleadosViewModel;
        }
    }
}
