﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorApp.Datos;
using GestorApp.Entidades;
using GestorApp.Presentacion.Reportes;

namespace GestorApp.Presentacion
{
    public partial class FormEmpleados : Form
    {
        public FormEmpleados()
        {
            InitializeComponent();
        }

        #region "Variables"
        int iCodigoEmpleado = 0;
        bool bEstadoGuardar = true;
        #endregion


        #region"Metodos"

        private void CargarEmpleados(string cBusqueda)
        {
            D_Empleados Datos = new D_Empleados();
            dgvLista.DataSource = Datos.Listar_Empleados(cBusqueda);

            FormatoListaEmpleados();
        }

        private void FormatoListaEmpleados()
        {
            dgvLista.Columns[0].Width = 45;
            dgvLista.Columns[1].Width = 160;
            dgvLista.Columns[2].Width = 160;
            dgvLista.Columns[4].Width = 250;
            dgvLista.Columns[5].Width = 160;
            dgvLista.Columns[6].Width = 160;
        }

        private void CargarDepartamentos()
        {
            D_Departamentos Datos = new D_Departamentos();
            cmbDepartamento.DataSource = Datos.Listar_Departamentos();
            cmbDepartamento.ValueMember = "id_departamento";
            cmbDepartamento.DisplayMember = "nombre_departamento";
            cmbDepartamento.SelectedIndex = -1;
        }

        private void CargarCargos()
        {
            D_Cargos Datos = new D_Cargos();
            cmbCargo.DataSource = Datos.Listar_Cargos();
            cmbCargo.ValueMember = "id_cargo";
            cmbCargo.DisplayMember = "nombre_cargo";
            cmbCargo.SelectedIndex = -1;
        }

        private void ActivarTextos(bool bEstado)
        {
            txtNombre.Enabled = bEstado;
            txtDireccion.Enabled = bEstado;
            txtTelefono.Enabled = bEstado;
            txtSalario.Enabled = bEstado;
            cmbDepartamento.Enabled = bEstado;
            cmbCargo.Enabled = bEstado;
            dtpFechaNacimiento.Enabled = bEstado;

            txtBuscar.Enabled = !bEstado;
        }

        private void ActivarBotones(bool bEstado)
        {
            btnNuevo.Enabled = bEstado;
            btnActualizar.Enabled = bEstado;
            btnEliminar.Enabled = bEstado;
            btnReporte.Enabled = bEstado;

            btnGuardar.Visible = !bEstado;
            btnCancelar.Visible = !bEstado;
        }

        private void SeleccionarEmpleado()
        {
            iCodigoEmpleado = Convert.ToInt32(dgvLista.CurrentRow.Cells["ID"].Value);

            txtNombre.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Nombre"].Value);
            txtDireccion.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Dirección"].Value);
            txtTelefono.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Teléfono"].Value);
            txtSalario.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Salario"].Value);
            cmbDepartamento.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Departamento"].Value);
            cmbCargo.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Cargo"].Value);
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvLista.CurrentRow.Cells["Fecha Nacimiento"].Value);
        }

        private void Limpiar() 
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtSalario.Clear();
            txtBuscar.Clear();

            cmbDepartamento.SelectedIndex = -1;
            cmbCargo.SelectedIndex = -1;

            dtpFechaNacimiento.Value = DateTime.Now;

            iCodigoEmpleado = 0;
        }

        private void GuardarEmpleado()
        {
            E_Empleado Empleado = new E_Empleado();

            Empleado.Nombre_Empleado = txtNombre.Text;
            Empleado.Direccion_Empleado = txtDireccion.Text;
            Empleado.Telefono_Empleado = txtTelefono.Text;
            Empleado.Salario_Empleado = Convert.ToDecimal(txtSalario.Text);
            Empleado.Fecha_Nacimiento = dtpFechaNacimiento.Value;
            Empleado.ID_Departamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
            Empleado.ID_Cargo = Convert.ToInt32(cmbCargo.SelectedValue);

            D_Empleados Datos = new D_Empleados();
            string respuesta = Datos.Guardar_Empleado(Empleado);

            if (respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Guardados Correctamente!", "Sistema Gestion de Empleados", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema Gestion de Empleados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool validarTextos()
        {
            bool hayTextosVacios = false;

            if (string.IsNullOrEmpty(txtNombre.Text)) hayTextosVacios = true;
            if (string.IsNullOrEmpty(txtTelefono.Text)) hayTextosVacios = true;
            if (string.IsNullOrEmpty(txtSalario.Text)) hayTextosVacios = true;

            return hayTextosVacios;
        }

        private void ActualizarEmpleado()
        {
            E_Empleado Empleado = new E_Empleado();

            Empleado.ID_Empleado = iCodigoEmpleado;
            Empleado.Nombre_Empleado = txtNombre.Text;
            Empleado.Direccion_Empleado = txtDireccion.Text;
            Empleado.Telefono_Empleado = txtTelefono.Text;
            Empleado.Salario_Empleado = Convert.ToDecimal(txtSalario.Text);
            Empleado.Fecha_Nacimiento = dtpFechaNacimiento.Value;
            Empleado.ID_Departamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
            Empleado.ID_Cargo = Convert.ToInt32(cmbCargo.SelectedValue);

            D_Empleados Datos = new D_Empleados();
            string respuesta = Datos.Actualizar_Empleado(Empleado);

            if (respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Actualizados Correctamente!", "Sistema Gestion de Empleados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema Gestion de Empleados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DesactivarEmpleado(int iCodigoEmpleado)
        {
            E_Empleado Empleado = new E_Empleado();

            D_Empleados Datos = new D_Empleados();
            string respuesta = Datos.Desactivar_Empleado(iCodigoEmpleado);

            if (respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Registro Eliminado Correctamente!", "Sistema Gestion de Empleados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema Gestion de Empleados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados("%");
            CargarDepartamentos();
            CargarCargos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEmpleados(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bEstadoGuardar = true;
            iCodigoEmpleado = 0;

            ActivarTextos(true);
            ActivarBotones(false);
            Limpiar();

            txtNombre.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bEstadoGuardar=true;
            iCodigoEmpleado= 0;

            ActivarTextos(false);
            ActivarBotones(true);

            Limpiar();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarEmpleado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(iCodigoEmpleado == 0)
            {
                MessageBox.Show("Selecciona un Registro", "Sistema de Gestion de Empleado", MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
            }
            else
            {
                bEstadoGuardar = false;

                ActivarTextos(true);
                ActivarBotones(false);

                txtNombre.Select();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextos())
            {
                MessageBox.Show("Hay campos vacios, debes llenar todos los campos (*) obligatorios", 
                    "Sistema Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(bEstadoGuardar)
                { 
                    GuardarEmpleado(); 
                }
                else
                {
                    ActualizarEmpleado();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Selecciona un Registro", "Sistema de Gestion de Empleado", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar este registro?", "Sistema de Gestion de Empleado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (resultado == DialogResult.Yes)
                {
                    DesactivarEmpleado(iCodigoEmpleado);
                }

            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FormReporteEmpleados formReporteEmpleados = new FormReporteEmpleados();
            formReporteEmpleados.textFiltrar.Text = txtBuscar.Text;
            formReporteEmpleados.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
