﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Agencia2.BO;
using BO = AgenciaEF_BO;


namespace OpeAgencia2.Parametros
{
    public partial class frmGrupoEstados : Form
    {
        public frmGrupoEstados()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmGrupoEstados_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            CargarDatosIniciales();

            ManejarEstado(false);

        }

          //
        protected void CargarDatosIniciales()
        {

            var grupoTipos = from p in unitOfWork.GruposEstadosRepository.Get()
                             select new { Id = p.GRUPO_EST_ID, Nombre = p.NOMBRE, Descripción = p.DESCR };

            //sucursales = sucursales.Where(s => s.Id == piEmpresa);

            //sSucursales.returnView(piEmpresa, ref sMensaje);

            dg.DataSource = grupoTipos.ToList();
            tabMant.SelectedIndex = 0;
        }


        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textGRUPO_ESTADO_ID.Text = "";
            LimpiarCampos();
            ManejarEstado(true);

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            CargarDatosIniciales();
        }
        private void btnMod_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Modificar");
            Modificar();
            ManejarEstado(true);
        }
        private void btnSal_Click(object sender, EventArgs e)
        {
            this.Close();
            /// MessageBox.Show("Salir");
        }
        private void btnSav_Click(object sender, EventArgs e)
        {

            usrbntMant1.bExito = false;

            if (SalvarDatos())
            {
                usrbntMant1.bExito = true;
                ManejarEstado(false);
                CargarDatosIniciales();
            }
        }
        private void btnUn_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Deshacer");
            ManejarEstado(false);
            tabMant.SelectedIndex = 0;
        }

        #endregion


        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.GetType().Name == "TextBox")
                {
                    if (ctr.Name.Substring(0, 3) == "txt")
                        ctr.Enabled = bEstado;

                }
            }

        }

        void LimpiarCampos()
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.GetType().Name == "TextBox")
                {
                    if (ctr.Name.Substring(0, 3) == "txt")
                        ctr.Text = "";

                }
            }
        }


        #region "CRUD"
        

        void DeleteData()
        {

            int iId = Convert.ToInt32(this.textGRUPO_ESTADO_ID.Text);

            var gruposTipos = unitOfWork.GruposEstadosRepository.GetByID(iId);

            try
            {
                unitOfWork.GruposEstadosRepository.Delete(gruposTipos);
                unitOfWork.Save();
                MessageBox.Show("Datos Actualizados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usrbntMant1.bExito = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        bool SalvarDatos()
        {
            int iId = -1;
            bool bRetorno = false;

            //CompaniasRecord oCom = new CompaniasRecord();


            BO.Models.GruposEstados oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textGRUPO_ESTADO_ID.Text);
                oCom = unitOfWork.GruposEstadosRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.GruposEstados();
            }

            oCom.CODIGO = this.txtCodigo.Text.ToString();
            oCom.NOMBRE = this.txtNombre.Text.ToString();
            oCom.DESCR = this.txtDESCR.Text.ToString().TrimEnd();



            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.GruposEstadosRepository.Update(oCom);
                else
                    unitOfWork.GruposEstadosRepository.Insert(oCom);

                unitOfWork.Save();
                bRetorno = true;
                usrbntMant1.bExito = true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";
                    /*
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    */


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";
                        /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);*/
                    }
                    MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //throw;
            }
            catch (DataException ex)
            {

                throw ex;
            }


            return bRetorno;


        }



        public void Modificar()
        {

            try
            {
                _Id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);

            }
            catch
            {
                _Id = -1;
            }
            if (_Id != -1)
            {
                tabMant.SelectedTab = tabPage2;

            }
            ConsultarDatos(_Id);

        }

        void ConsultarDatos(int Id)
        {
            var grupoEstados = unitOfWork.GruposEstadosRepository.GetByID(Id);

            MoverDatos(grupoEstados);

        }

        void MoverDatos(BO.Models.GruposEstados MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "GRUPO_EST_ID":
                        ctr.Text = MyComp.GRUPO_EST_ID.ToString();
                        break;
                    case "CODIGO":
                        ctr.Text = MyComp.CODIGO.ToString();
                        break;
                    case "NOMBRE":
                        ctr.Text = MyComp.NOMBRE.ToString();
                        break;
                  
                    case "DESCR":
                        ctr.Text = MyComp.DESCR.ToString();
                        break;
                  

                }


            }
        }

        #endregion

        private void tabMant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMant.SelectedIndex == 1)
            {
                try
                {
                    _Id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
                    ConsultarDatos(_Id);

                }
                catch
                {
                    _Id = -1;
                }
                if (_Id != -1)
                {
                    tabMant.SelectedTab = tabPage2;

                }
            }

        }

    }



    }

