using aplication;
using Domain.Model.Entities;
using Domain.Model.ObjectValues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.ViewModels;

namespace UI.Desktop.Forms
{
    public partial class InformesFrm : Form
    {
        public InformesFrm()
        {
            InitializeComponent();
        }

        private void InformesFrm_Load(object sender, EventArgs e)
        {
            gridInformes.DataSource = new InformeService().GetInformesAsync();
            cmbEmpleadoConfecciona.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleadoInformado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleadoConfecciona.DataSource = new EmpleadoService().GetEmpleados();
            //cmbEmpleadoConfecciona.DisplayMember = "Nombre";
            cmbEmpleadoInformado.DataSource = new EmpleadoService().GetEmpleados();
            //cmbEmpleadoInformado.DisplayMember = "Nombre";
        }

        public List<EpleadoViewModel> empleadosViewModel()
        {
            var empleados = new EmpleadoService().GetEmpleados();
            List < EpleadoViewModel > empleadosViewModel = new List<EpleadoViewModel>();
            foreach (var item in empleados)
            {
                empleadosViewModel.Add(new EpleadoViewModel
                {
                    Legajo = item.Legajo,
                    Nombre = item.Nombre
                });
            }
            return empleadosViewModel;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var informeAgregar = new Informe
            {
                Fecha = dateTimePicker1.Value,
                EmpleadoConfecciona = cmbEmpleadoConfecciona.SelectedItem as Empleado,
                EmpleadoInformado = cmbEmpleadoInformado.SelectedItem as Empleado,
                Motivo = txtMotivo.Text,
                Descripcion = txtResumen.Text
            };
            var informeService = new InformeService();
            informeService.EstadoEntidad = EntityState.Agregado;
            var resultado = informeService.SaveChanges(informeAgregar);
            MessageBox.Show(resultado);
        }
    }
}
