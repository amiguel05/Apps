using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO = AgenciaEF_BO;

namespace OpeAgencia2.Operaciones
{
    public partial class frmRecepcion : Form
    {
        int consulta = 0;
        int _Id = -1;
        int iNumeroEPS = -1;
        int iSucursalId = -1;
        BO.DAL.dsDatos.BultosValoresCargosDataTable oCargos = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        public frmRecepcion()
        {
            InitializeComponent();
        }

        public frmRecepcion(int piBltNumero)
        {
            InitializeComponent();
            _Id = piBltNumero;
            grbNavegacion.Visible = false;
            txtCodigoBarra.Enabled = true;
            txtCodigoBarra.KeyDown -= txtCodigoBarra_KeyDown;
            txtCodigoBarra.Leave -= txtCodigoBarra_Leave;
            consulta = 1;
        }
        //using BO = AgenciaEF_BO;
    
        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            CombosProductos();
            CombosEstados();
            this.txtCodigoBarra.Focus();
            if (_Id != -1)
            {
                var Bultos = unitOfWork.BultosRepository.GetByID(_Id);
                txtCodigoBarra.Text = Bultos.BLT_CODIGO_BARRA;
                BuscarDatosPorCodigoBarra();
            }
        }

        #region "Combos"

        void CombosProductos()
        {
            var Productos = from p in unitOfWork.ProductosRepository.Get(filter:xy=>xy.Tipos.TIPO_CODIGO=="R")
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + "-->" + p.PRO_DESCRIPCION };
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            this.cmbProducto.DataSource = Productos.ToList();
        }

        void CombosEstados()
        {
            var Estados = from p in unitOfWork.EstadosRepository.GetByGroupCode("CP")
                            select new { Id = p.ESTADO_ID, Nombre = p.ESTADO_NOMBRE + "-->" + p.ESTADO_DESCR };
            cmbCondicion.DisplayMember = "Nombre";
            cmbCondicion.ValueMember = "Id";
            this.cmbCondicion.DataSource = Estados.ToList();
        }

        void ComboCargos(int iProductoId)
        {
            var cargosExits = from p in unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 29 && s.Cargos.CAR_ESTADO == true ) /*tipo cargos*/
                              select new { Id = p.CARGO_PROD_ID, Nombre = p.Cargos.CAR_CODIGO +"-->" + p.Cargos.CAR_DESCRIPCION + "("+p.TasaCambio.TASA_CODIGO + ")"};
            this.cmbCargos.ValueMember = "Id";
            cmbCargos.DisplayMember = "Nombre";
            cmbCargos.DataSource = cargosExits.ToList();
            cmbCargos.SelectedValue = -1;
        }

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Realizar validaciones
            if (txtCodigoBarra.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe indicar un código de barras", "Código de barras",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CarcularUnidades();
            InsertarBulto();
        }

        void InsertarBulto()
        {
            BO.Models.Bultos oBulto = new BO.Models.Bultos();
            if (_Id !=-1)
            {
                oBulto = unitOfWork.BultosRepository.GetByID(_Id);
            }
            oBulto.BLT_ABIERTO_ADUANA = chkAbiertoAduanas.Checked;
            oBulto.ALM_CODIGO = 1;
            oBulto.BLT_ADUANA = false;
            oBulto.BLT_ALTO = -1;
            oBulto.BLT_ANCHO = -1;
            oBulto.BLT_BOLSA_SUCURSAL = "NA";
            oBulto.BLT_BOLSA_SUPLIDOR = "NA";
            oBulto.BLT_CODIGO_BARRA = txtCodigoBarra.Text;
            oBulto.BLT_DESPA_SUPLIDOR = DateTime.Now;
            oBulto.BLT_ENTREGAR = false;
            oBulto.BLT_ESTADO_ID = 2;
            oBulto.BLT_FECHA_ENTREGADO = DateTime.Now;
            oBulto.BLT_FECHA_RECEPCION = DateTime.Now;
            oBulto.BLT_GUIA_HIJA = txtCodigoBarra.Text;
            oBulto.BLT_HORA_ENTREGADO = "";
            oBulto.BLT_HORA_RECIBIDO = DateTime.Now.Hour.ToString();
            oBulto.BLT_LARGO = -1;
            oBulto.BLT_LIQUIDADOR = "NA";
            oBulto.BLT_MANIFIESTO_SUCURSAL = "NA";
            oBulto.BLT_MONTO_SELLOS = 0;
            oBulto.BLT_OBSERVACION = "NA";
            oBulto.BLT_PESO = Convert.ToDecimal(txtPeso.Text);
            oBulto.BLT_PESO_REAL = Convert.ToDecimal(txtPeso.Text);
            oBulto.BLT_PESO_SUPLIDOR = Convert.ToDecimal(txtPeso.Text);
            oBulto.BLT_PIEZAS = Convert.ToInt32(txtPiezas.Value);
            oBulto.BLT_PIEZAS_SUPLIDOR = Convert.ToInt32(txtPiezas.Value);
            oBulto.BLT_PONUMBER = "NA";
            oBulto.BLT_PORCIENTO_SELLO = 0;
            oBulto.BLT_RECEP_SUPLIDOR = DateTime.Now;
            oBulto.BLT_TRACKING_NUMBER = "NA";
            oBulto.BLT_UBICACION = "NA";
            oBulto.BLT_VALOR_FOB = Convert.ToDecimal(txtValorFOB.Text);
            oBulto.BLT_VENTANILLA = -1;
            oBulto.BLT_VOLUMEN = 0;
            oBulto.BLT_WAREHOUSE = "NA";
            oBulto.CON_CODIGO_ID = Convert.ToInt32(cmbCondicion.SelectedValue);
            oBulto.CONTENIDO = txtContenido.Text;
            oBulto.CTE_ID = iNumeroEPS;
            oBulto.SUC_ID = iSucursalId;
            oBulto.DEST_ID = 168;  /*SDQ*/
            oBulto.DESTINATARIO = txtConsignatario.Text;
            oBulto.FECHA_MODIF = DateTime.Now;
            oBulto.MAN_GUIA = "NA";
            oBulto.MAN_MANIFIESTO = "NA";
            oBulto.ORI_ID = 130;
            oBulto.PROD_ID = Convert.ToInt32(cmbProducto.SelectedValue);
            oBulto.REMITENTE = txtRemitente.Text;
            oBulto.UBI_CODIGO = "NA";
            oBulto.USUARIO_ID = Parametros.Parametros.UsuarioId;
            try
            {
                if (_Id < 0)
                {
                    unitOfWork.BultosRepository.Insert(oBulto);
                }
                else
                {
                    unitOfWork.BultosRepository.Update(oBulto);
                }
                SalvarDetalle(oBulto.BLT_NUMERO);
                unitOfWork.Save();
               // ActualizarItbis(oBulto.BLT_NUMERO);

                AgenciaEF_BO.DAL.ADO.BultosDal Bultos = new BO.DAL.ADO.BultosDal();

                Bultos.RecalcularUnidades(oBulto.BLT_NUMERO);
                //Bultos.RecalcularItebis(oBulto.BLT_NUMERO);
               
                unitOfWork.Save();

                BO.BO.Facturar oFact = new BO.BO.Facturar();
                oFact.ActualizarItbis(oBulto.BLT_NUMERO);


                MessageBox.Show("Datos salvados satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                txtCodigoBarra.Text = "";
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
                    unitOfWork.Dispose();
                }
                //throw;
            }
            catch (Exception ex)
            {
                unitOfWork.Dispose();
                throw ex;
            }
        }

       
        private void SalvarDetalle(int bltNumero)
        {
            var oBultosValores = unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == bltNumero);
            foreach(var oReg in oBultosValores)
            {
                unitOfWork.BultosValoresRepository.Delete(oReg.BVA_ID);
            }
            foreach(DataRow dr in oUnidades)
            {
                BO.Models.BultosValores oNewValores = new BO.Models.BultosValores();
                oNewValores.BLT_NUMERO = bltNumero;
                oNewValores.BVA_MONTO = Convert.ToDecimal(dr["Monto"]);
                oNewValores.BVA_MONTO_APLICAR = Convert.ToDecimal(dr["MontoAplicar"]);
                oNewValores.BVA_MONTO_LOCAL = Convert.ToDecimal(dr["MontoLocal"]);
                oNewValores.BVA_TASA = Convert.ToDecimal(dr["Tasa"]);
                oNewValores.CARGO_PROD_ID = Convert.ToInt32(dr["CARGO_PROD_ID"]);
                unitOfWork.BultosValoresRepository.Insert(oNewValores);
            }
            foreach (DataRow dr in oCargos)
            {
                BO.Models.BultosValores oNewValores = new BO.Models.BultosValores();
                oNewValores.BLT_NUMERO = bltNumero;
                oNewValores.BVA_MONTO = Convert.ToDecimal(dr["Monto"]);
                oNewValores.BVA_MONTO_APLICAR = Convert.ToDecimal(dr["MontoAplicar"]);
                oNewValores.BVA_MONTO_LOCAL = Convert.ToDecimal(dr["MontoLocal"]);
                oNewValores.BVA_TASA = Convert.ToDecimal(dr["Tasa"]);
                oNewValores.CARGO_PROD_ID = Convert.ToInt32(dr["CARGO_PROD_ID"]);
                unitOfWork.BultosValoresRepository.Insert(oNewValores);
            }
        }

        private void txtNumeroEPS_Leave(object sender, EventArgs e)
        {
            var Eps = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtNumeroEPS.Text).FirstOrDefault();
            if (Eps != null)
            {
                lblEps.Text = Eps.CTE_NOMBRE + " " + Eps.CTE_APELLIDO;
                iNumeroEPS = Eps.CTE_ID;
                iSucursalId = Eps.CTE_SUC_ID;
            }
            else
            {
                lblEps.Text = "";
                iNumeroEPS = -1;
                iSucursalId = -1;
            }
        }

        private void txtCodigoBarra_Leave(object sender, EventArgs e)
        {
            BuscarDatosPorCodigoBarra();
        }

        void BuscarDatosPorCodigoBarra()
        {
            if (txtCodigoBarra.Text == "")
                txtCodigoBarra.Focus();
            else
            {
                var sqlBultos = unitOfWork.BultosRepository.Get(filter: s => s.BLT_CODIGO_BARRA == txtCodigoBarra.Text).FirstOrDefault();
                if (sqlBultos != null)
                {
                    if (sqlBultos.BLT_ESTADO_ID == 5 || sqlBultos.BLT_ESTADO_ID ==6)
                    {
                        MessageBox.Show("Este paquete ya fue entregado, o está fuera de inventario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        LimpiarCampos();
                        btnSalvar.Enabled = false;
                        return;
                    }
                    if (sqlBultos.SUC_ID != Parametros.ParametrosSucursal.IdSucursal)
                    {
                        MessageBox.Show("Este paquete pertenece a otra sucursal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnSalvar.Enabled = false;
                        LimpiarCampos();
                        return;
                    }
                    else
                    { btnSalvar.Enabled = true; }

                    _Id = sqlBultos.BLT_NUMERO;
                    BuscarDatos(sqlBultos);
                }
                else
                {
                    LimpiarCampos();
                }
                this.txtCodigoBarra.Enabled = consulta == 1;
                BuscarCargos();
                BuscarUnidades();
            }
        }

        void BuscarDatos(BO.Models.Bultos pBultos)
        {
            BO.Models.Bultos oBulto = new BO.Models.Bultos();
            if (_Id != -1)
            {
                oBulto = unitOfWork.BultosRepository.GetByID(_Id);
            }
            chkAbiertoAduanas.Checked = oBulto.BLT_ABIERTO_ADUANA;
            //oBulto.ALM_CODIGO = 1;
            //oBulto.BLT_ADUANA = false;
            //oBulto.BLT_ALTO = -1;
            //oBulto.BLT_ANCHO = -1;
            //oBulto.BLT_BOLSA_SUCURSAL = "NA";
            //oBulto.BLT_BOLSA_SUPLIDOR = "NA";
            //txtCodigoBarra.Text =oBulto.BLT_CODIGO_BARRA;
            //oBulto.BLT_DESPA_SUPLIDOR = DateTime.Now;
            //oBulto.BLT_ENTREGAR = false;
            //oBulto.BLT_ESTADO_ID = 1;
            //oBulto.BLT_FECHA_ENTREGADO = DateTime.Now;
            //oBulto.BLT_FECHA_RECEPCION = DateTime.Now;
            //oBulto.BLT_GUIA_HIJA = txtCodigoBarra.Text;
            //oBulto.BLT_HORA_ENTREGADO = "";
            //oBulto.BLT_HORA_RECIBIDO = DateTime.Now.Hour.ToString();
            //oBulto.BLT_LARGO = -1;
            //oBulto.BLT_LIQUIDADOR = "NA";
            //oBulto.BLT_MANIFIESTO_SUCURSAL = "NA";
            //oBulto.BLT_MONTO_SELLOS = 0;
            //oBulto.BLT_OBSERVACION = "NA";
            txtPeso.Text = oBulto.BLT_PESO_REAL.ToString();
            //txtPeso.Text  oBulto.BLT_PESO_REAL.ToString();
            //oBulto.BLT_PESO_SUPLIDOR = Convert.ToDecimal(txtPeso.Text);
            txtPiezas.Value = oBulto.BLT_PIEZAS;
            //oBulto.BLT_PIEZAS_SUPLIDOR = Convert.ToInt32(txtPiezas.Value);
            //oBulto.BLT_PONUMBER = "NA";
            //oBulto.BLT_PORCIENTO_SELLO = 0;
            //oBulto.BLT_RECEP_SUPLIDOR = DateTime.Now;
            //oBulto.BLT_TRACKING_NUMBER = "NA";
            //oBulto.BLT_UBICACION = "NA";
            txtValorFOB.Text = oBulto.BLT_VALOR_FOB.ToString();
            //oBulto.BLT_VENTANILLA = -1;
            //oBulto.BLT_VOLUMEN = 0;
            //oBulto.BLT_WAREHOUSE = "NA";
            cmbCondicion.SelectedValue = oBulto.CON_CODIGO_ID;
            txtContenido.Text = oBulto.CONTENIDO;
            //oBulto.DEST_ID = 168;  /*SDQ*/
            txtConsignatario.Text = oBulto.DESTINATARIO;
            //oBulto.FECHA_MODIF = DateTime.Now;
            //oBulto.MAN_GUIA = "NA";
            //oBulto.MAN_MANIFIESTO = "NA";
            //oBulto.ORI_ID = 130;
            //oBulto.PRO_ID = Convert.ToInt32(cmbProducto.SelectedValue);
            cmbProducto.SelectedValue = Convert.ToInt32(oBulto.PROD_ID);

            txtRemitente.Text = oBulto.REMITENTE;
            //oBulto.UBI_CODIGO = "NA";
            //Bulto.USUARIO_ID = 1; /* Usuarios */
            iNumeroEPS = oBulto.CTE_ID;
            iSucursalId = oBulto.SUC_ID;
            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);
            txtNumeroEPS.Text = Clientes.CTE_NUMERO_EPS.ToString();
            lblEps.Text = Clientes.CTE_NOMBRE + " " + Clientes.CTE_APELLIDO;
        }

        void BuscarCargos()
        {
            var qryCargos = from p in unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == _Id && s.CargosProducto.Cargos.CAR_BASE_ID == 29)
                            select new { p.BVA_ID, p.CARGO_PROD_ID, Desc = p.CargosProducto.Cargos.CAR_CODIGO + "-->" + p.CargosProducto.Cargos.CAR_DESCRIPCION + "(" + p.CargosProducto.TasaCambio.TASA_CODIGO + ")",
                                         Monto = p.BVA_MONTO,
                                         Tasa = p.BVA_TASA,
                                         MontoLocal = p.BVA_MONTO_LOCAL,
                                         MontoAplicar = p.BVA_MONTO_APLICAR
                            };
            oCargos.Rows.Clear();
            foreach (var cargo in qryCargos)
            {
                DataRow dr = oCargos.NewRow();
                dr["ID"] = cargo.BVA_ID;
                dr["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                dr["Desc"] = cargo.Desc;
                dr["Tasa"] = cargo.Tasa;
                dr["Monto"] = cargo.Monto;
                dr["MontoLocal"] = cargo.MontoLocal;
                dr["MontoAplicar"] = cargo.MontoAplicar;
                oCargos.Rows.Add(dr);
            }
            dgCargos.DataSource = oCargos;
            dgCargos.Columns[0].Visible = false;
            dgCargos.Columns[1].Visible = false;
            dgCargos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        void BuscarUnidades()
        {
            var qryCargos = from p in unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == _Id && (s.CargosProducto.Cargos.CAR_BASE_ID == 25 || s.CargosProducto.Cargos.CAR_BASE_ID == 52 ))
                            select new
                            {
                                p.BVA_ID,
                                p.CARGO_PROD_ID,
                                Desc = p.CargosProducto.Cargos.CAR_CODIGO + "-->" + p.CargosProducto.Cargos.CAR_DESCRIPCION + "(" + p.CargosProducto.TasaCambio.TASA_CODIGO + ")",
                                Monto = p.BVA_MONTO,
                                Tasa = p.BVA_TASA,
                                MontoLocal = p.BVA_MONTO_LOCAL,
                                MontoAplicar = p.BVA_MONTO_APLICAR
                            };
            oUnidades.Rows.Clear();
            foreach (var cargo in qryCargos)
            {
                DataRow dr = oUnidades.NewRow();
                dr["ID"] = cargo.BVA_ID;
                dr["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                dr["Desc"] = cargo.Desc;
                dr["Tasa"] = cargo.Tasa;
                dr["Monto"] = cargo.Monto;
                dr["MontoLocal"] = cargo.MontoLocal;
                dr["MontoAplicar"] = cargo.MontoAplicar;
                oUnidades.Rows.Add(dr);
            }
            dgUnidades.DataSource = oUnidades;
            dgUnidades.Columns[0].Visible = false;
            dgUnidades.Columns[1].Visible = false;
            dgUnidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        void LimpiarCampos()
        {
            chkAbiertoAduanas.Checked = false;
            txtPeso.Text = "";
            txtPiezas.Value = 0;
            txtValorFOB.Text = "0";
            cmbCondicion.SelectedValue = -1;
            txtContenido.Text = "";
            //oBulto.DEST_ID = 168;  /*SDQ*/
            txtConsignatario.Text = "";
            txtRemitente.Text = "";
            iNumeroEPS = -1;
            txtNumeroEPS.Text = "";
            txtCodigoBarra.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.txtCodigoBarra.Enabled = true;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iProductoId = Convert.ToInt32(cmbProducto.SelectedValue);
            ComboCargos(iProductoId);
        }

        private void cmbCargos_TextChanged(object sender, EventArgs e)
        {
            cmbCargos.FindString(cmbCargos.Text);
        }

        //private void cmbCargos_Enter(object sender, EventArgs e)
        //{
        //    cmbCargos.DroppedDown = true;
        //}

        //Agregar cargos
        private void btnCargoAdd_Click(object sender, EventArgs e)
        {
            if (iNumeroEPS == -1)
            {
                MessageBox.Show("Es necesario especificar un número de eps", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int iCargoProd = -1;
            /* select new { p.ID, p.CARGO_PROD_ID, Desc = p.CargosProducto.Cargos.CAR_CODIGO + "-->" + p.CargosProducto.Cargos.CAR_DESCRIPCION + "(" + p.CargosProducto.TasaCambio.TASA_CODIGO + ")",
                            Monto = p.BVA_MONTO, Tasa= p.BVA_TASA, MontoLocal = p.BVA_MONTO_LOCAL };*/
            iCargoProd = Convert.ToInt32(cmbCargos.SelectedValue);
            var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);
            if (iCargoProd == null || cargosProd == null)
            {
                MessageBox.Show("Debe seleccionar un cargo para agregar", "Seleccionar cargos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (oCargos.Any(xy => xy.CARGO_PROD_ID == iCargoProd))
            {
                MessageBox.Show("Este paquete ya tiene este cargo ", "Cargo duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            decimal monto;
            if (Decimal.TryParse(txtMonto.Text, out monto) == false)
            {
                MessageBox.Show("Debe especificar un monto válido a aplicar", "Especificar monto",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataRow dr = oCargos.NewRow();
            dr["ID"] = -1;
            dr["CARGO_PROD_ID"] = iCargoProd;
            dr["Desc"] = cmbCargos.Text;
            dr["Tasa"] = cargosProd.TasaCambio.FACTOR_CONV;
            dr["Monto"] = monto;
            if (cargosProd.Cargos.CAR_DIRECTO_TABLA == "D")
                dr["MontoAplicar"] = Convert.ToDecimal(txtMonto.Text);
            else
            {
                dr["MontoAplicar"] = BuscarMontoAplicar(iCargoProd,Convert.ToDecimal(txtMonto.Text));
            }
            if (Convert.ToDecimal(dr["MontoAplicar"]) < Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR))
            {
                Convert.ToDecimal(dr["MontoAplicar"] = Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR));
            }

            if (cargosProd.Cargos.CAR_SUMAR == true)
            {
                dr["MontoAplicar"]  = (Convert.ToDecimal(txtMonto.Text) + Convert.ToDecimal(dr["MontoAplicar"]));
            }

            if (cargosProd.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                dr["MontoLocal"] = Convert.ToDecimal(dr["MontoAplicar"]) * cargosProd.TasaCambio.FACTOR_CONV;
            else 
                dr["MontoLocal"] = Convert.ToDecimal(txtMonto.Text) * Convert.ToDecimal(dr["MontoAplicar"]) * cargosProd.TasaCambio.FACTOR_CONV;

            oCargos.Rows.Add(dr);
            cmbCargos.SelectedValue = -1;
            txtMonto.Text = "";
            //cmbCargos.Focus();
        }

        decimal  BuscarMontoAplicar(int piCargoId, decimal Monto)
        {
            decimal dRetorno = 1;
            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);
            var cargosProd = from p in unitOfWork.CargosValoresRepository.Get(filter: s => s.COD_TAR_ID == 
                Clientes.COD_TARIFA && s.SUC_ID == Clientes.CTE_SUC_ID && s.CARGO_PROD_ID == piCargoId)
                orderby p.VAL_HASTA select new { p.VAL_HASTA, p.VAL_PORCENTAJE, p.VAL_VALOR, p.VAL_ADICIONAL };
            foreach (var valor in cargosProd)
            {
                if(Monto <= valor.VAL_HASTA)
                {
                    dRetorno = valor.VAL_VALOR;
                    break;
                }
            }
            return dRetorno;
        }

        void CarcularUnidades()
        {
            int iProductoId = Convert.ToInt32(cmbProducto.SelectedValue);
            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && 
                s.Cargos.CAR_BASE_ID == 25 && s.Cargos.CAR_ESTADO == true && s.FIJO == true); /*tipo cargos*/
            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);
            decimal dPeso = Convert.ToDecimal(txtPeso.Text);
            oUnidades.Rows.Clear();
            foreach(var cargo in cargosExits)
            {
                DataRow oRow = oUnidades.NewRow();
                oRow["ID"] = -1;
                oRow["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                oRow["Desc"] = cargo.Cargos.CAR_DESCRIPCION;
                oRow["Tasa"] = cargo.TasaCambio.FACTOR_CONV;
                oRow["Monto"] = dPeso.ToString();
                oRow["MontoAplicar"]  = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso);
                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    if (Convert.ToDecimal(oRow["MontoAplicar"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                    {
                        oRow["MontoAplicar"] = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR);
                    }
                    oRow["MontoLocal"] = Math.Round(Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV, 2, MidpointRounding.ToEven);
                }
                else
                {
                    if (Convert.ToDecimal(oRow["Monto"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                    {
                        oRow["Monto"] = Math.Round(Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR),2, MidpointRounding.ToEven);
                    }
                    oRow["MontoLocal"] = Convert.ToDecimal(oRow["Monto"]) * Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV;
                    oRow["MontoLocal"] = Math.Round(Convert.ToDecimal(oRow["MontoLocal"]),2, MidpointRounding.ToEven);
                }
                oUnidades.Rows.Add(oRow);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarCargo();
        }

        public void EliminarCargo()
        {
            int iCargoProductoId = -1;
            try
            {
               // iCargoProductoId = Convert.ToInt32(dgCargos[0, dgCargos.CurrentCell.RowIndex].Value);
                iCargoProductoId =dgCargos.CurrentCell.RowIndex;
            }
            catch(Exception ex)
            {
                iCargoProductoId = -1;
            }
            if (iCargoProductoId != -1)
            {
                oCargos.Rows.RemoveAt(iCargoProductoId);
                //oCargos.Rows.Remove(dr);
                oCargos.AcceptChanges();
            }
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                BuscarDatosPorCodigoBarra();
        }

        private void dgCargos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewColumn column in dgCargos.Columns)
                column.ReadOnly = (column.HeaderText.Equals("Monto") == false);
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            btnCargoAdd.PerformClick();
        }

        private void dgCargos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal monto;
            if (dgCargos.CurrentRow.Cells["Monto"].Value == null || 
                Decimal.TryParse(dgCargos.CurrentRow.Cells["Monto"].Value.ToString(), out monto) == false ||
                monto <= 0)
            {
                MessageBox.Show("Debe especificar un monto válido a aplicar", "Especificar monto",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int iCargoProd = Convert.ToInt16(dgCargos.CurrentRow.Cells["CARGO_PROD_ID"].Value);
            var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);
            if (cargosProd.Cargos.CAR_DIRECTO_TABLA == "D")
                dgCargos.CurrentRow.Cells["MontoAplicar"].Value = Convert.ToDecimal(monto);
            else
                dgCargos.CurrentRow.Cells["MontoAplicar"].Value = 
                    BuscarMontoAplicar(iCargoProd, Convert.ToDecimal(monto));
            if (Convert.ToDecimal(dgCargos.CurrentRow.Cells["MontoAplicar"].Value) < 
                Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR))
            {
                Convert.ToDecimal(dgCargos.CurrentRow.Cells["MontoAplicar"].Value = 
                    Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR));
            }
            if (cargosProd.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                dgCargos.CurrentRow.Cells["MontoLocal"].Value = 
                    Convert.ToDecimal(dgCargos.CurrentRow.Cells["MontoAplicar"].Value) * cargosProd.TasaCambio.FACTOR_CONV;
            else
                dgCargos.CurrentRow.Cells["MontoLocal"].Value = 
                    Convert.ToDecimal(monto) * Convert.ToDecimal(dgCargos.CurrentRow.Cells["MontoAplicar"].Value) * 
                    cargosProd.TasaCambio.FACTOR_CONV;
        }
    }
}
