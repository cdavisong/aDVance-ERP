using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Taller.Interfaces;

using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion {
    public partial class VistaRegistroOrdenProduccion : Form, IVistaRegistroOrdenProduccion {
        private bool _modoEdicion;
        private string _numeroOrden = "-";
        private DateTime _fechaApertura = DateTime.Now;

        public VistaRegistroOrdenProduccion() {
            InitializeComponent();
            Inicializar();
        }

        public bool Habilitada {
            get => Enabled;
            set => Enabled = value;
        }

        public Point Coordenadas {
            get => Location;
            set => Location = value;
        }

        public Size Dimensiones {
            get => Size;
            set => Size = value;
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnAbrirCerrarOrdenProduccion.Text = value ? "Cerrar orden de producción" : "Abrir orden de producción";
                _modoEdicion = value;
            }
        }

        public string NumeroOrden {
            get => _numeroOrden;
            set {
                _numeroOrden = value;
                fieldSubtitulo.Text = $"Registro Nro. {_numeroOrden} del {FechaApertura:dd/MM/yyyy}";
            }
        }

        public DateTime FechaApertura {
            get => _fechaApertura;
            set {
                _fechaApertura = value;
                fieldSubtitulo.Text = $"Registro Nro. {NumeroOrden} del {FechaApertura:dd/MM/yyyy}";
            }
        }

        public string NombreProductoTerminado {
            get => fieldNombreProductoTerminado.Text;
            set => fieldNombreProductoTerminado.Text = value;
        }

        public decimal Cantidad {
            get => decimal.TryParse(fieldCantidadProducir.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) ? cantidad : 0m;
            set => fieldCantidadProducir.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public decimal MargenGanancia {
            get => decimal.TryParse(fieldMargenGananciaDeseado.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var margen) ? margen : 0m;
            set => fieldMargenGananciaDeseado.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public IRepositorioVista? VistasMateriaPrima { get; private set; }
        public List<string[]> MateriasPrimas { get; private set; } = new List<string[]>();

        public IRepositorioVista? VistasActividadProduccion { get; private set; }
        public List<string[]> ActividadesProduccion { get; private set; } = new List<string[]>();

        public IRepositorioVista? VistasGastosIndirectos { get; private set; }
        public List<string[]> GastosIndirectos { get; private set; } = new List<string[]>();

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? MateriaPrimaEliminada;
        public event EventHandler? ActividadProduccionEliminada;
        public event EventHandler? GastoIndirectoEliminado;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Vistas
            VistasMateriaPrima = new RepositorioVistaBase(contenedorVistasMateriaPrima);
            VistasActividadProduccion = new RepositorioVistaBase(contenedorVistasActividadesProduccion);
            VistasGastosIndirectos = new RepositorioVistaBase(contenedorVistasGastosIndirectos);

            // Eventos
            #region Materias primas

            fieldNombreMateriaPrima.TextChanged += delegate (object? sender, EventArgs args) {
                btnAdicionarMateriaPrima.Enabled = !string.IsNullOrWhiteSpace(fieldNombreMateriaPrima.Text) && !string.IsNullOrWhiteSpace(fieldCantidadMateriaPrima.Text);
            };
            fieldNombreMateriaPrima.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    args.SuppressKeyPress = true;
                    fieldCantidadMateriaPrima.Focus();
                }
            };
            fieldCantidadMateriaPrima.TextChanged += delegate (object? sender, EventArgs args) {
                btnAdicionarMateriaPrima.Enabled = !string.IsNullOrWhiteSpace(fieldNombreMateriaPrima.Text) && !string.IsNullOrWhiteSpace(fieldCantidadMateriaPrima.Text);
            };
            fieldCantidadMateriaPrima.KeyPress += delegate (object? sender, KeyPressEventArgs args) {
                if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar) && (args.KeyChar != '.')) {
                    args.Handled = true;
                }
                // Permitir un solo punto decimal
                if ((args.KeyChar == '.') && ((sender as TextBox)?.Text.IndexOf('.') > -1)) {
                    args.Handled = true;
                }
            };
            fieldCantidadMateriaPrima.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    args.SuppressKeyPress = true;
                    AdicionarMateriaPrima();
                }
            };
            btnAdicionarMateriaPrima.Click += delegate (object? sender, EventArgs args) {
                AdicionarMateriaPrima();
            };
            MateriaPrimaEliminada += delegate (object? sender, EventArgs args) {
                ActualizarTuplasMateriaPrima();
            };

            #endregion
            #region Actividades de produccion

            fieldNombreActividadProduccion.TextChanged += delegate (object? sender, EventArgs args) {
                btnAdicionarActividadProduccion.Enabled = !string.IsNullOrWhiteSpace(fieldNombreActividadProduccion.Text) && !string.IsNullOrWhiteSpace(fieldCantidadActividadesProduccion.Text);
            };
            fieldNombreActividadProduccion.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    args.SuppressKeyPress = true;
                    fieldCantidadActividadesProduccion.Focus();
                }
            };
            fieldCantidadActividadesProduccion.TextChanged += delegate (object? sender, EventArgs args) {
                btnAdicionarActividadProduccion.Enabled = !string.IsNullOrWhiteSpace(fieldNombreActividadProduccion.Text) && !string.IsNullOrWhiteSpace(fieldCantidadActividadesProduccion.Text);
            };
            fieldCantidadActividadesProduccion.KeyPress += delegate (object? sender, KeyPressEventArgs args) {
                if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar) && (args.KeyChar != '.')) {
                    args.Handled = true;
                }
                // Permitir un solo punto decimal
                if ((args.KeyChar == '.') && ((sender as TextBox)?.Text.IndexOf('.') > -1)) {
                    args.Handled = true;
                }
            };
            fieldCantidadActividadesProduccion.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    args.SuppressKeyPress = true;
                    AdicionarActividadProduccion();
                }
            };
            btnAdicionarActividadProduccion.Click += delegate (object? sender, EventArgs args) {
                AdicionarActividadProduccion();
            };
            ActividadProduccionEliminada += delegate (object? sender, EventArgs args) {
                ActualizarTuplasActividadesProduccion();
            };

            #endregion
            #region Gastos indirectos

            fieldConceptoGastoIndirecto.TextChanged += delegate (object? sender, EventArgs args) {
                btnAdicionarGastoIndirecto.Enabled = !string.IsNullOrWhiteSpace(fieldConceptoGastoIndirecto.Text) && !string.IsNullOrWhiteSpace(fieldCantidadGastoIndirecto.Text);
            };
            fieldConceptoGastoIndirecto.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    args.SuppressKeyPress = true;
                    fieldCantidadGastoIndirecto.Focus();
                }
            };
            fieldCantidadGastoIndirecto.TextChanged += delegate (object? sender, EventArgs args) {
                btnAdicionarGastoIndirecto.Enabled = !string.IsNullOrWhiteSpace(fieldConceptoGastoIndirecto.Text) && !string.IsNullOrWhiteSpace(fieldCantidadGastoIndirecto.Text);
            };
            fieldCantidadGastoIndirecto.KeyPress += delegate (object? sender, KeyPressEventArgs args) {
                if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar) && (args.KeyChar != '.')) {
                    args.Handled = true;
                }
                // Permitir un solo punto decimal
                if ((args.KeyChar == '.') && ((sender as TextBox)?.Text.IndexOf('.') > -1)) {
                    args.Handled = true;
                }
            };
            fieldCantidadGastoIndirecto.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    args.SuppressKeyPress = true;
                    AdicionarGastoIndirecto();
                }
            };
            btnAdicionarGastoIndirecto.Click += delegate (object? sender, EventArgs args) {
                AdicionarGastoIndirecto();
            };
            GastoIndirectoEliminado += delegate (object? sender, EventArgs args) {
                ActualizarTuplasGastosIndirectos();
            };

            #endregion

            fieldCantidadProducir.KeyPress += delegate (object? sender, KeyPressEventArgs args) {
                if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar) && (args.KeyChar != '.')) {
                    args.Handled = true;
                }
                // Permitir un solo punto decimal
                if ((args.KeyChar == '.') && ((sender as TextBox)?.Text.IndexOf('.') > -1)) {
                    args.Handled = true;
                }
            };
            fieldCantidadProducir.TextChanged += delegate (object? sender, EventArgs args) {
                ActualizarPrecioUnitarioProducto();
            };
            fieldCantidadProducir.KeyDown += delegate (object? sender, KeyEventArgs args) {
                if (args.KeyCode == Keys.Enter) {
                    args.SuppressKeyPress = true;
                    fieldMargenGananciaDeseado.Focus();
                }
            };
            fieldMargenGananciaDeseado.KeyPress += delegate (object? sender, KeyPressEventArgs args) {
                if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar) && (args.KeyChar != '.')) {
                    args.Handled = true;
                }
                // Permitir un solo punto decimal
                if ((args.KeyChar == '.') && ((sender as TextBox)?.Text.IndexOf('.') > -1)) {
                    args.Handled = true;
                }
            };
            fieldMargenGananciaDeseado.TextChanged += delegate (object? sender, EventArgs args) {
                ActualizarPrecioUnitarioProducto();
            };
            btnAbrirCerrarOrdenProduccion.Click += delegate (object? sender, EventArgs args) {
                //if (ModoEdicionDatos)
                //    EditarDatos?.Invoke(sender, args);
                //else
                //    RegistrarDatos?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            contenedorVistasMateriaPrima.Resize += delegate {
                VistasMateriaPrima?.Vistas?.ForEach(vista => {
                    if (vista is IVistaTupla tupla)
                        tupla.Dimensiones = new Size(contenedorVistasMateriaPrima.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada);
                });
            };
        }

        #region Autocompletamiento en campos

        public void CargarNombresProductosTerminados(string[] nombresProductosTerminados) {
            fieldNombreProductoTerminado.AutoCompleteCustomSource.Clear();
            fieldNombreProductoTerminado.AutoCompleteCustomSource.AddRange(nombresProductosTerminados);
            fieldNombreProductoTerminado.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldNombreProductoTerminado.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void CargarNombresMateriasPrimas(string[] nombresMateriasPrimas) {
            fieldNombreMateriaPrima.AutoCompleteCustomSource.Clear();
            fieldNombreMateriaPrima.AutoCompleteCustomSource.AddRange(nombresMateriasPrimas);
            fieldNombreMateriaPrima.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldNombreMateriaPrima.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void CargarNombresActividadesProduccion(string[] nombresActividadesProduccion) {
            fieldNombreActividadProduccion.AutoCompleteCustomSource.Clear();
            fieldNombreActividadProduccion.AutoCompleteCustomSource.AddRange(nombresActividadesProduccion);
            fieldNombreActividadProduccion.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldNombreActividadProduccion.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void CargarConceptosGastosIndirectos(string[] conceptosGastosIndirectos) {
            fieldConceptoGastoIndirecto.AutoCompleteCustomSource.Clear();
            fieldConceptoGastoIndirecto.AutoCompleteCustomSource.AddRange(conceptosGastosIndirectos);
            fieldConceptoGastoIndirecto.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldConceptoGastoIndirecto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        #endregion

        public void AdicionarMateriaPrima(string nombre = "", decimal cantidad = 0) {
            var adNombre = string.IsNullOrEmpty(nombre) ? fieldNombreMateriaPrima.Text : nombre;

            if (!string.IsNullOrEmpty(adNombre)) {
                var idProducto = UtilesProducto.ObtenerIdProducto(adNombre).Result;

                if (idProducto <= 0) {
                    CentroNotificaciones.Mostrar($"No se encontró la materia prima '{adNombre}'.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
                    return;
                }

                var stockProducto = UtilesProducto.ObtenerStockTotalProducto(idProducto).Result;
                var cantidadAcumulada = MateriasPrimas
                    .Where(p => p[0].Equals(adNombre))
                    .Sum(p => decimal.TryParse(p[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cant) ? cant : 0m);
                var adCantidad = cantidad > 0 ? cantidad : decimal.TryParse(fieldCantidadMateriaPrima.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var cant) ? cant : 0m;
                var adCantidadTotal = adCantidad + cantidadAcumulada;

                if (stockProducto < adCantidadTotal) {
                    CentroNotificaciones.Mostrar($"No hay suficiente stock de la materia prima '{adNombre}' para satisfacer la demanda de fabricación especificada. Stock actual: {stockProducto}.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
                    return;
                }

                var adPrecio = UtilesProducto.ObtenerPrecioCompraBase(idProducto).Result;
                var tuplaMateriaPrimaExistente = MateriasPrimas.FirstOrDefault(p => p[0].Equals(adNombre));
                var tuplaMateriaPrima = tuplaMateriaPrimaExistente
                    ?? [adNombre, "0", adPrecio.ToString("N2", CultureInfo.InvariantCulture)];
                tuplaMateriaPrima[1] = adCantidadTotal.ToString("N2", CultureInfo.InvariantCulture);

                if (tuplaMateriaPrimaExistente == null)
                    MateriasPrimas.Add(tuplaMateriaPrima);

                fieldNombreMateriaPrima.Text = string.Empty;
                fieldCantidadMateriaPrima.Text = string.Empty;

                ActualizarTuplasMateriaPrima();

                fieldNombreMateriaPrima.Focus();
            } else
                CentroNotificaciones.Mostrar("Debe ingresar un nombre válido para la materia prima.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
        }

        public void AdicionarActividadProduccion(string nombre = "", decimal cantidad = 0) {
            var adNombre = string.IsNullOrEmpty(nombre) ? fieldNombreActividadProduccion.Text : nombre;

            if (!string.IsNullOrEmpty(adNombre)) {
                var cantidadAcumulada = ActividadesProduccion
                    .Where(p => p[0].Equals(adNombre))
                    .Sum(p => decimal.TryParse(p[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cant) ? cant : 0m);
                var adCantidad = cantidad > 0 ? cantidad : decimal.TryParse(fieldCantidadActividadesProduccion.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var cant) ? cant : 0m;
                var adCantidadTotal = adCantidad + cantidadAcumulada;

                if (adCantidad <= 0) {
                    CentroNotificaciones.Mostrar("La cantidad de la actividades de producción debe ser mayor a cero.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
                    return;
                }

                var tuplaActividadProduccionExistente = ActividadesProduccion.FirstOrDefault(p => p[0].Equals(adNombre));
                var tuplaActividadProduccion = tuplaActividadProduccionExistente
                    ?? [adNombre, "0", "1.00"];
                tuplaActividadProduccion[1] = adCantidadTotal.ToString("N2", CultureInfo.InvariantCulture);

                if (tuplaActividadProduccionExistente == null)
                    ActividadesProduccion.Add(tuplaActividadProduccion);

                fieldNombreActividadProduccion.Text = string.Empty;
                fieldCantidadActividadesProduccion.Text = string.Empty;

                ActualizarTuplasActividadesProduccion();

                fieldNombreActividadProduccion.Focus();
            } else
                CentroNotificaciones.Mostrar("Debe ingresar un nombre válido para la actividad de producción.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
        }

        public void AdicionarGastoIndirecto(string concepto = "", decimal cantidad = 0) {
            var adConcepto = string.IsNullOrEmpty(concepto) ? fieldConceptoGastoIndirecto.Text : concepto;

            if (!string.IsNullOrEmpty(adConcepto)) {
                var cantidadAcumulada = GastosIndirectos
                    .Where(p => p[0].Equals(adConcepto))
                    .Sum(p => decimal.TryParse(p[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cant) ? cant : 0m);
                var adCantidad = cantidad > 0 ? cantidad : decimal.TryParse(fieldCantidadGastoIndirecto.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var cant) ? cant : 0m;
                var adCantidadTotal = adCantidad + cantidadAcumulada;

                if (adCantidad <= 0) {
                    CentroNotificaciones.Mostrar("La cantidad del gasto indirecto debe ser mayor a cero.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
                    return;
                }

                var tuplaGastoIndirectoExistente = GastosIndirectos.FirstOrDefault(p => p[0].Equals(adConcepto));
                var tuplaGastoIndirecto = tuplaGastoIndirectoExistente
                    ?? [adConcepto, "0", "1.00"];
                tuplaGastoIndirecto[1] = adCantidadTotal.ToString("N2", CultureInfo.InvariantCulture);

                if (tuplaGastoIndirectoExistente == null)
                    GastosIndirectos.Add(tuplaGastoIndirecto);

                fieldConceptoGastoIndirecto.Text = string.Empty;
                fieldCantidadGastoIndirecto.Text = string.Empty;

                ActualizarTuplasGastosIndirectos();

                fieldConceptoGastoIndirecto.Focus();
            } else
                CentroNotificaciones.Mostrar("Debe ingresar un concepto válido para el gasto indirecto.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            ModoEdicionDatos = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }

        private void LimpiarTuplasContenedor(Panel contenedorVistas) {
            foreach (var tupla in contenedorVistas.Controls)
                if (tupla is IVistaTupla vistaTupla)
                    vistaTupla.Cerrar();
            contenedorVistas.Controls.Clear();

            // Restablecer útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla = 0;
        }

        private void ActualizarTuplasMateriaPrima() {
            LimpiarTuplasContenedor(contenedorVistasMateriaPrima);

            for (int i = 0; i < MateriasPrimas.Count; i++) {
                var materiaPrima = MateriasPrimas[i];
                var tuplaOrdenMateriaPrima = new VistaTuplaOrdenMateriaPrima();

                tuplaOrdenMateriaPrima.NombreMateriaPrima = materiaPrima[0];
                tuplaOrdenMateriaPrima.Cantidad = materiaPrima[1];
                tuplaOrdenMateriaPrima.PrecioUnitario = materiaPrima[2];
                tuplaOrdenMateriaPrima.Habilitada = !ModoEdicionDatos;
                tuplaOrdenMateriaPrima.Dimensiones = new Size(contenedorVistasMateriaPrima.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada);
                tuplaOrdenMateriaPrima.PrecioUnitarioModificado += delegate (object? sender, EventArgs args) {
                    materiaPrima = sender as string[];

                    if (materiaPrima == null || materiaPrima.Length < 3)
                        return;

                    MateriasPrimas[MateriasPrimas.FindIndex(p => p[0].Equals(materiaPrima?[0]))] = materiaPrima;

                    ActualizarCostoTotalMateriales();
                };
                tuplaOrdenMateriaPrima.EliminarDatosTupla += delegate (object? sender, EventArgs args) {
                    materiaPrima = sender as string[];

                    MateriasPrimas.RemoveAt(MateriasPrimas.FindIndex(p => p[0].Equals(materiaPrima?[0])));
                    MateriaPrimaEliminada?.Invoke(materiaPrima, args);
                };

                // Registro y muestra
                VistasMateriaPrima?.Registrar(
                    $"vistaTupla{tuplaOrdenMateriaPrima.GetType().Name}{i}",
                    tuplaOrdenMateriaPrima,
                    new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                    new Size(contenedorVistasMateriaPrima.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada), "N");
                tuplaOrdenMateriaPrima.Mostrar();

                // Incremento de la útima coordenada Y de la tupla
                VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
            }

            // Actualizar el costo total de los materiales
            ActualizarCostoTotalMateriales();
        }

        private void ActualizarCostoTotalMateriales() {
            var costoTotal = MateriasPrimas
                .Sum(p => decimal.TryParse(p[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) && decimal.TryParse(p[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var precio) ? cantidad * precio : 0m);

            fieldCostoTotalMateriales.Text = costoTotal.ToString("N2", CultureInfo.InvariantCulture);

            ActualizarCostoTotalProduccion();
        }

        private void ActualizarTuplasActividadesProduccion() {
            LimpiarTuplasContenedor(contenedorVistasActividadesProduccion);

            for (int i = 0; i < ActividadesProduccion.Count; i++) {
                var actividadProduccion = ActividadesProduccion[i];
                var tuplaOrdenActividadProduccion = new VistaTuplaOrdenActividadProduccion();

                tuplaOrdenActividadProduccion.NombreActividadProduccion = actividadProduccion[0];
                tuplaOrdenActividadProduccion.Cantidad = actividadProduccion[1];
                tuplaOrdenActividadProduccion.CostoActividad = actividadProduccion[2];
                tuplaOrdenActividadProduccion.Habilitada = !ModoEdicionDatos;
                tuplaOrdenActividadProduccion.Dimensiones = new Size(contenedorVistasActividadesProduccion.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada);
                tuplaOrdenActividadProduccion.CostoActividadModificado += delegate (object? sender, EventArgs args) {
                    actividadProduccion = sender as string[];

                    if (actividadProduccion == null || actividadProduccion.Length < 3)
                        return;

                    ActividadesProduccion[ActividadesProduccion.FindIndex(p => p[0].Equals(actividadProduccion?[0]))] = actividadProduccion;

                    ActualizarCostoTotalActividadesProduccion();
                };
                tuplaOrdenActividadProduccion.EliminarDatosTupla += delegate (object? sender, EventArgs args) {
                    actividadProduccion = sender as string[];

                    ActividadesProduccion.RemoveAt(ActividadesProduccion.FindIndex(p => p[0].Equals(actividadProduccion?[0])));
                    ActividadProduccionEliminada?.Invoke(actividadProduccion, args);
                };

                // Registro y muestra
                VistasActividadProduccion?.Registrar(
                    $"vistaTupla{tuplaOrdenActividadProduccion.GetType().Name}{i}",
                    tuplaOrdenActividadProduccion,
                    new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                    new Size(contenedorVistasActividadesProduccion.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada), "N");

                tuplaOrdenActividadProduccion.Mostrar();

                // Incremento de la útima coordenada Y de la tupla
                VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
            }

            // Actualizar el costo total de las actividades de producción
            ActualizarCostoTotalActividadesProduccion();
        }

        private void ActualizarCostoTotalActividadesProduccion() {
            var costoTotal = ActividadesProduccion
                .Sum(p => decimal.TryParse(p[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) && decimal.TryParse(p[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var costo) ? cantidad * costo : 0m);

            fieldCostoTotalActividadesProduccion.Text = costoTotal.ToString("N2", CultureInfo.InvariantCulture);

            ActualizarCostoTotalProduccion();
        }

        private void ActualizarTuplasGastosIndirectos() {
            LimpiarTuplasContenedor(contenedorVistasGastosIndirectos);

            for (int i = 0; i < GastosIndirectos.Count; i++) {
                var gastoIndirecto = GastosIndirectos[i];
                var tuplaOrdenGastoIndirecto = new VistaTuplaOrdenGastoIndirecto();

                tuplaOrdenGastoIndirecto.ConceptoGasto = gastoIndirecto[0];
                tuplaOrdenGastoIndirecto.Cantidad = gastoIndirecto[1];
                tuplaOrdenGastoIndirecto.Monto = gastoIndirecto[2];
                tuplaOrdenGastoIndirecto.Habilitada = !ModoEdicionDatos;
                tuplaOrdenGastoIndirecto.Dimensiones = new Size(contenedorVistasGastosIndirectos.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada);
                tuplaOrdenGastoIndirecto.MontoGastoModificado += delegate (object? sender, EventArgs args) {
                    gastoIndirecto = sender as string[];

                    if (gastoIndirecto == null || gastoIndirecto.Length < 3)
                        return;

                    GastosIndirectos[GastosIndirectos.FindIndex(p => p[0].Equals(gastoIndirecto?[0]))] = gastoIndirecto;

                    ActualizarCostoTotalGastosIndirectos();
                };
                tuplaOrdenGastoIndirecto.EliminarDatosTupla += delegate (object? sender, EventArgs args) {
                    gastoIndirecto = sender as string[];

                    GastosIndirectos.RemoveAt(GastosIndirectos.FindIndex(p => p[0].Equals(gastoIndirecto?[0])));
                    GastoIndirectoEliminado?.Invoke(gastoIndirecto, args);
                };

                // Registro y muestra
                VistasGastosIndirectos?.Registrar(
                    $"vistaTupla{tuplaOrdenGastoIndirecto.GetType().Name}{i}",
                    tuplaOrdenGastoIndirecto,
                    new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                    new Size(contenedorVistasGastosIndirectos.Width - 20, VariablesGlobales.AlturaTuplaPredeterminada), "N");
                tuplaOrdenGastoIndirecto.Mostrar();

                // Incremento de la útima coordenada Y de la tupla
                VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
            }

            // Actualizar el costo total de los gastos indirectos
            ActualizarCostoTotalGastosIndirectos();
        }

        private void ActualizarCostoTotalGastosIndirectos() {
            var montoTotal = GastosIndirectos
                .Sum(p => decimal.TryParse(p[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) && decimal.TryParse(p[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var monto) ? cantidad * monto : 0m);

            fieldMontoTotalGastosIndirectos.Text = montoTotal.ToString("N2", CultureInfo.InvariantCulture);

            ActualizarCostoTotalProduccion();
        }

        private void ActualizarCostoTotalProduccion() {
            var costoTotalMateriales = decimal.TryParse(fieldCostoTotalMateriales.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var costoMat) ? costoMat : 0m;
            var costoTotalActividades = decimal.TryParse(fieldCostoTotalActividadesProduccion.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var costoAct) ? costoAct : 0m;
            var montoTotalGastosIndirectos = decimal.TryParse(fieldMontoTotalGastosIndirectos.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var montoGast) ? montoGast : 0m;
            
            fieldCostoTotalProduccion.Text = (costoTotalMateriales + costoTotalActividades + montoTotalGastosIndirectos).ToString("N2", CultureInfo.InvariantCulture);

            ActualizarPrecioUnitarioProducto();
        }

        private void ActualizarPrecioUnitarioProducto() {
            var costoTotalProduccion = decimal.TryParse(fieldCostoTotalProduccion.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var costoTotal) ? costoTotal : 0m;
            var cantidadProducir = decimal.TryParse(fieldCantidadProducir.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) ? cantidad : 1m;
            var margenGanancia = decimal.TryParse(fieldMargenGananciaDeseado.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var margen) ? margen : 0m;

            fieldPrecioUnitarioProducto.Text = (cantidad > 0 ? (costoTotal / cantidad) * (1 + margen / 100) : 0m).ToString("N2", CultureInfo.InvariantCulture);
        }
    }
}
