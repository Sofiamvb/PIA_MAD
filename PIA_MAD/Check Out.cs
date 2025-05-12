using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PIA_MAD.Clases;

namespace PIA_MAD
{
    public partial class Check_Out : Form
    {
        private string patronNumeros = @"^\d+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronPrecio = @"^\$\d{1,3}(,\d{3})*(\.\d{2})?$";
        private int idReservacion;
        private int idCliente;
        private int idHotel;
        private int cantPersonas;
        private decimal anticipo;
        private Guid codigoReserva;
        private DateTime fechaEnt;
        private DateTime fechaCheckin;
        private DateTime fechaSal;
        private DateTime fechareserva;
        private string formadepago = "";
        private string metododepago = "";
        private int diasExtra = 0;
        private decimal descuento = 0.00m;
        private decimal descuentoAplicable = 0.00m;
        private decimal montoTotal;
        private decimal montoDescuento;
        private decimal montosindesc;
        private Guid codigoreserva;
        Empleado empleado = Empleado.ObtenerInstancia();
        private List<ServicioAdicionalHotel> servicioAdicionalHotel = new List<ServicioAdicionalHotel>();
        private List<ServicioAdicionalHotel> servicioAdicionalesSeleccionados = new List<ServicioAdicionalHotel>();
        private List<ConceptoFactura> conceptoFacturas = new List<ConceptoFactura>();
        public Check_Out()
        {
            InitializeComponent();
            DTP_CheckOut.ShowUpDown = true;
            DTP_CheckOut.Enabled = false;
            RB_DescuentoSi.Enabled = false;
            RB_DescuentoNo.Enabled = false;
            TB_CantDescuento.Enabled = false;
            TB_MontoTotal.Enabled = false;
            TB_AnticipoCO.Enabled = false;
            BTN_CheckOut.Enabled = false;
            BTN_AgregarServicio.Enabled = false;
            BTN_EliminarServicio.Enabled = false;


            LV_ServiciosAdicionales.View = View.Details;
            LV_ServiciosAdicionales.FullRowSelect = true;
            LV_ServiciosAdicionales.GridLines = true;
            LV_ServiciosAdicionales.Columns.Clear();
            LV_ServiciosAdicionales.Columns.Add("Nombre", 220);
            LV_ServiciosAdicionales.Columns.Add("Precio", 80);

            LV_ServiciosAgregados.View = View.Details;
            LV_ServiciosAgregados.FullRowSelect = true;
            LV_ServiciosAgregados.GridLines = true;
            LV_ServiciosAgregados.Columns.Clear();
            LV_ServiciosAgregados.Columns.Add("Nombre", 220);
            LV_ServiciosAgregados.Columns.Add("Precio", 80);

            CB_FormaDePago.Items.AddRange(new object[] {
               "01 - Efectivo",
               "02 - Cheque nominativo",
               "03 - Transferencia electrónica de fondos",
               "04 - Tarjeta de crédito",
               "05 - Monedero electrónico",
               "06 - Dinero electrónico",
               "08 - Vales de despensa",
               "12 - Dación en pago",
               "13 - Pago por subrogación",
               "14 - Pago por consignación",
               "15 - Condonación",
               "17 - Compensación",
               "23 - Novación",
               "24 - Confusión",
               "25 - Remisión de deuda",
               "26 - Prescripción o caducidad",
               "27 - A satisfacción del acreedor",
               "28 - Tarjeta de débito",
               "29 - Tarjeta de servicios",
               "30 - Aplicación de anticipos",
               "31 - Intermediario pagos",
               "99 - Por definir"
            });
            if (CB_FormaDePago.Items.Count > 0)
                CB_FormaDePago.SelectedIndex = 0;
            CB_MetodoDePago.Items.AddRange(new object[] {
                "PUE - Pago en una sola exhibición",
                "PPD - Pago en parcialidades o diferido"
            });
            if (CB_MetodoDePago.Items.Count > 0)
                CB_MetodoDePago.SelectedIndex = 0;
            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuSuperior());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanas.VentanaClientes = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Check_Out_Load(object sender, EventArgs e)
        {

        }

        private void EliminarConceptoFacturaPorDescripcion(string descripcion)
        {
            var concepto = conceptoFacturas.FirstOrDefault(c => c.Descripcion == descripcion);
            if (concepto != null)
            {
                conceptoFacturas.Remove(concepto);
            }
        }

        private ConceptoFactura GeneradorConceptoFacturas(
            int cantidad, 
            string Unidad, 
            string ClaveUnidadSAT, 
            string ClaveProductoServicio,
            string Descripcion,
            decimal ValorUnitario,
            decimal Descuentos,
            decimal Impuestos,
            decimal Importe
        )
        {
            var factura = new ConceptoFactura
            {
                Cantidad = cantidad,
                Unidad = Unidad,
                ClaveUnidadSAT = ClaveUnidadSAT,
                ClaveProductoServicio = ClaveProductoServicio,
                Descripcion = Descripcion,
                ValorUnitario = ValorUnitario,
                Descuentos = Descuentos,
                Impuestos = Impuestos,
                Importe = Importe
            };

            conceptoFacturas.Add(factura);

            return factura;
        }

        private void TB_NumReserva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                string checkin_code = TB_NumReserva.Text;
                using (var DB = new ApplicationDbContext())
                {
                    if (Guid.TryParse(checkin_code, out codigoreserva))
                    {
                        var resultado = DB.Reservaciones
                            .Where(r => r.CodigoReserva == codigoreserva)
                            .SelectMany(r => r.HabitacionReservada.Select(hr => new
                            {
                                HotelId = hr.Habitacion.HotelId,
                                Anticipo = r.Anticipo,
                                ServiciosAdicionales = hr.Habitacion.Hotel.ServiciosAdicionales,
                                PrecioNoche = hr.Habitacion.PrecioNoche,
                                FechaEnt = r.FechaEnt,
                                FechaSal = r.FechaSal,
                                FechaCheckIn = r.FechaCheckIn,
                                FechaReserva = r.FechaReserva,
                                ReservacionId = r.id,
                                ClienteId = r.ClienteId,
                                CantPersonas = r.CantPersonas,
                                HabitacionNivelHab = hr.Habitacion.nivelHab,
                                HabitacionTipoCama = hr.Habitacion.tipoCama,
                            }))
                            .ToList(); // Si hay varias habitaciones, obtendrás una lista


                        if (resultado.Count == 0)
                        {
                            MessageBox.Show("Codigo no valido, intenta de nuevo.");
                            return;
                        }

                        var reserva = resultado.First(); // Ya validaste que Count > 0
                        int noches = (reserva.FechaSal.Date - reserva.FechaEnt.Date).Days;
                        DateTime horaLimite = reserva.FechaSal.Date;
                        DateTime ahora = DateTime.Now;

                        if (ahora > horaLimite)
                        {
                            TimeSpan diferencia = ahora - horaLimite;
                            diasExtra = (int)Math.Ceiling(diferencia.TotalDays);
                            MessageBox.Show($"El huésped se ha pasado {diasExtra} día(s).");
                        }
                        else
                        {
                            MessageBox.Show("El huésped aún está dentro del horario de salida.");
                        }

                        noches = noches + diasExtra;

                        idReservacion = resultado[0].ReservacionId;
                        idCliente = resultado[0].ClienteId;
                        idHotel = resultado[0].HotelId;
                        cantPersonas = resultado[0].CantPersonas;
                        anticipo = resultado[0].Anticipo;
                        fechaEnt = resultado[0].FechaEnt;
                        fechaSal = resultado[0].FechaSal;
                        fechaCheckin = resultado[0].FechaCheckIn.Value;
                        fechareserva = resultado[0].FechaReserva;
                        codigoReserva = codigoreserva;

                        var hotelId = resultado[0].HotelId;
                        var servicios = resultado[0].ServiciosAdicionales;
                        decimal totalPorNoche = resultado.Sum(x => x.PrecioNoche);
                        montoTotal = totalPorNoche * noches;
                        montosindesc = montoTotal;
                        montoTotal = montoTotal - anticipo;
                        TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoTotal);

                        RB_DescuentoSi.Enabled = true;
                        RB_DescuentoNo.Enabled = true;

                        BTN_CheckOut.Enabled = true;

                        TB_AnticipoCO.Text = Utilidades.FormatearComoMoneda(anticipo);

                        foreach (var item in resultado)
                        {
                            string nivel = item.HabitacionNivelHab;
                            string cama = item.HabitacionTipoCama;
                            string descripcion = $"Habitación {nivel.ToLower()} con cama {cama.ToLower()}";

                            decimal valorUnitario = item.PrecioNoche;
                            decimal importe = valorUnitario * noches;
                            decimal descuentos = 0m;
                            decimal impuestos = importe * 0.16m;
                            var factura = GeneradorConceptoFacturas(
                                noches,
                                "Servicio",        
                                "E48",                   
                                "90111503",              
                                descripcion,
                                valorUnitario,
                                descuentos,
                                impuestos,
                                importe
                            );
                        }

                        var serviciosadicionales = servicios;

                        servicioAdicionalHotel = serviciosadicionales;

                        LV_ServiciosAdicionales.Items.Clear();

                        foreach (var servicio in servicioAdicionalHotel)
                        {
                            var item = new ListViewItem(servicio.Nombre); // Columna 0

                            item.SubItems.Add(Utilidades.FormatearComoMoneda(servicio.Precio));

                            item.Tag = servicio.id;

                            LV_ServiciosAdicionales.Items.Add(item);
                        }

                        MessageBox.Show("Codigo Valido");
                    }
                    else
                    {
                        MessageBox.Show("El código ingresado no es válido.");
                        return;
                    }
                }
            }
        }

        private void BTN_CheckOut_Click(object sender, EventArgs e)
        {

            try
            {
                using (var DB = new ApplicationDbContext())
                {
                    var reservacion = DB.Reservaciones
                        .Include(r => r.HabitacionReservada)
                        .FirstOrDefault(r => r.id == idReservacion);

                    var ultimoFolio = DB.CheckOut
                        .OrderByDescending(c => c.FolioFactura)
                        .Select(c => c.FolioFactura)
                        .FirstOrDefault();


                    var cliente = DB.Usuarios
                        .FirstOrDefault(u => u.id == idCliente);

                    string nombrecliente = $"{cliente.Nombre} {cliente.AP} {cliente.AM}";

                    var partesFormadepago = formadepago.Split(" - ");
                    string formadepagocod = partesFormadepago[0];
                    string formadepagodesc = partesFormadepago[1];

                    var partesMetodopago =  metododepago.Split(" - ");
                    string metodopagocod = partesMetodopago[0];
                    string metodopagodesc = partesMetodopago[1];

                    var partescfdi = cliente.Cfdi.Split(" - ");
                    string usoCFDICod = partescfdi[0];   
                    string usoCFDIDesc = partescfdi[1];

                    var partesreg = cliente.RegimenFiscal.Split(" - ");
                    string regimenCod = partesreg[0];
                    string regimenDesc = partesreg[1];

                    int siguienteFolio = ultimoFolio + 1;

                    DateTime enestemomento = DateTime.Now;

                    decimal iva = montosindesc * 0.16m;
                    decimal subtotal = montosindesc - iva;

                    decimal montoAPagar;

                    if (descuentoAplicable > 0 && descuento > 0)
                    {
                        montoAPagar = montoDescuento;
                    }
                    else
                    {
                        montoAPagar = montoTotal;
                    }


                    var facturagenerada = Utilidades.GenerarFactura(
                        formadepagocod,
                        formadepagodesc,
                        metodopagocod,
                        metodopagodesc,
                        "PIA_MAD",
                        siguienteFolio.ToString(),
                        enestemomento.ToString("yyyy-MM-dd"),
                        enestemomento.ToString("HH:mm:ss"),
                        nombrecliente,
                        cliente.RFC,
                        usoCFDICod,
                        usoCFDIDesc,
                        regimenCod,
                        regimenDesc,
                        cliente.Domicilio,
                        cliente.Codigopostal,
                        cliente.Estado,
                        cliente.Pais,
                        conceptoFacturas,
                        Utilidades.NumeroALetras(montoAPagar),
                        Utilidades.FormatearComoMoneda(subtotal),
                        Utilidades.FormatearComoMoneda(anticipo),
                        Utilidades.FormatearComoMoneda(descuentoAplicable),
                        Utilidades.FormatearComoMoneda(iva),
                        "$0.00",
                        "$0.00",
                        Utilidades.FormatearComoMoneda(montoAPagar),
                        Utilidades.GenerarSerieCertificadoEmisor(),
                        Utilidades.GenerarUUID(),
                        Utilidades.GenerarSerieCertificadoSAT(),
                        Utilidades.GenerarFechaCertificacion(),
                        Utilidades.GenerarSelloDigital()
                    );
                    if (reservacion != null)
                    {
                        var checkout = new CheckOut
                        {
                            OperativoId = empleado.GetId(),
                            ClienteId = idCliente,
                            HotelId = idHotel,
                            CantPersonas = cantPersonas,
                            Anticipo = anticipo,
                            PorcentajeDescuento = descuento,
                            CantidadDescuento = descuentoAplicable,
                            MontoTotal = montoAPagar,
                            CodigoReserva = codigoReserva,
                            FechaEntReserva = fechaEnt,
                            FechaSalReserva = fechaSal,
                            FechaCheckIn = fechaCheckin,
                            FechaSalReal = DateTime.Now,
                            FechaReserva = fechareserva,
                            SerieFactura = "PIA_MAD",
                            FolioFactura = siguienteFolio,
                            RutaPdfFactura = facturagenerada,
                            HabitacionCheckout = new List<HabitacionCheckout>(),
                            ServiciosAdicionales = servicioAdicionalesSeleccionados
                                .Select(s => new CheckOutServicioAdicional
                                {
                                    ServicioAdicionalHotelId = s.id,
                                    Cantidad = 1
                                }).ToList()
                        };


                        foreach (var habitacionReservada in reservacion.HabitacionReservada)
                        {
                            checkout.HabitacionCheckout.Add(new HabitacionCheckout
                            {
                                HabitacionId = habitacionReservada.HabitacionId,
                                CantidadPersonas = habitacionReservada.CantidadPersonas
                            });
                        }

                        DB.CheckOut.Add(checkout);

                        DB.Reservaciones.Remove(reservacion);

                        foreach (var hr in reservacion.HabitacionReservada)
                        {
                            var habitacion = DB.Habitaciones.FirstOrDefault(h => h.id == hr.HabitacionId);
                            if (habitacion != null)
                                habitacion.Disponible = true;
                        }

                        DB.SaveChanges();

                        MessageBox.Show("Check-Out realizado correctamente. Las habitaciones están disponibles.");

                        this.Hide();
                        var nuevoFormulario = new Check_Out();
                        nuevoFormulario.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la reservación.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al hacer el checkout, intente más tarde.{ex}");
            }
        }


        private void RB_DescuentoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_DescuentoSi.Checked)
            {
                TB_CantDescuento.Enabled = true;
                TB_CantDescuento.Text = "0";
                MessageBox.Show("Se aplicará el descuento.");
            }
            else if (RB_DescuentoNo.Checked)
            {
                TB_CantDescuento.Enabled = false;
                TB_CantDescuento.Text = "0";
                descuento = 0;
                descuentoAplicable = 0;
                TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoTotal);
                MessageBox.Show("No se aplicará el descuento.");
            }
        }

        private void LV_ServiciosAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_ServiciosAdicionales.SelectedItems.Count > 0)
            {
                BTN_AgregarServicio.Enabled = true;
            }
        }

        private void BTN_AgregarServicio_Click(object sender, EventArgs e)
        {
            if (LV_ServiciosAdicionales.SelectedItems.Count > 0)
            {
                var itemsToRemove = new List<ListViewItem>();

                foreach (ListViewItem item in LV_ServiciosAdicionales.SelectedItems)
                {
                    int servicioId = (int)item.Tag;
                    var servicio = servicioAdicionalHotel.FirstOrDefault(s => s.id == servicioId);

                    if (servicio != null)
                    {
                        servicioAdicionalHotel.Remove(servicio);
                        servicioAdicionalesSeleccionados.Add(servicio);

                        montoTotal = montoTotal + servicio.Precio;
                        montosindesc = montosindesc + servicio.Precio;
                        if (descuentoAplicable > 0 && descuento > 0)
                        {
                            descuentoAplicable = montoTotal * (descuento / 100m);
                            montoDescuento = montoTotal - descuentoAplicable;
                            TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoDescuento);
                        }
                        else
                        {
                            TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoTotal);
                        }
                        // Agregar a la lista de agregados
                        var nuevoItem = new ListViewItem(servicio.Nombre);
                        nuevoItem.SubItems.Add(Utilidades.FormatearComoMoneda(servicio.Precio));
                        nuevoItem.Tag = servicio.id;
                        LV_ServiciosAgregados.Items.Add(nuevoItem);
                        var conceptoServicio = GeneradorConceptoFacturas(
                            1,                                     // cantidad (servicio único)
                            "Servicio",                            // Unidad
                            "E48",                                 // ClaveUnidadSAT (puedes validar si aplica otro)
                            "90101800",                            // ClaveProductoServicio (ejemplo: servicios de hotel)
                            $"Servicio adicional: {servicio.Nombre}", // Descripción
                            servicio.Precio,
                            0m,                                    // Descuentos (ajustar si aplicas)
                            servicio.Precio * 0.16m,               // Impuestos (asumiendo 16%)
                            servicio.Precio                        // Importe (sin impuestos si ya está incluido)
                        );
                        // Marcar para quitar del original
                        itemsToRemove.Add(item);
                    }
                }

                // Quitar los seleccionados del listview original
                foreach (var item in itemsToRemove)
                {
                    LV_ServiciosAdicionales.Items.Remove(item);
                }

                BTN_AgregarServicio.Enabled = false;
                BTN_EliminarServicio.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debes seleccionar al menos un servicio adicional para agregarlo.");
                return;
            }
        }


        private void LV_ServiciosAgregados_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTN_EliminarServicio.Enabled = LV_ServiciosAgregados.SelectedItems.Count > 0;
        }

        private void BTN_EliminarServicio_Click(object sender, EventArgs e)
        {
            if (LV_ServiciosAgregados.SelectedItems.Count > 0)
            {
                var itemsToRemove = new List<ListViewItem>();

                foreach (ListViewItem item in LV_ServiciosAgregados.SelectedItems)
                {
                    int servicioId = (int)item.Tag;
                    var servicio = servicioAdicionalesSeleccionados.FirstOrDefault(s => s.id == servicioId);

                    if (servicio != null)
                    {
                        servicioAdicionalesSeleccionados.Remove(servicio);
                        servicioAdicionalHotel.Add(servicio);
                        montoTotal = montoTotal - servicio.Precio;
                        montosindesc = montosindesc - servicio.Precio;
                        if (descuentoAplicable > 0 && descuento > 0)
                        {
                            descuentoAplicable = montoTotal * (descuento / 100m);
                            montoDescuento = montoTotal - descuentoAplicable;
                            TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoDescuento);
                        }
                        else
                        {
                            TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoTotal);
                        }
                        // Regresar al listview original
                        var nuevoItem = new ListViewItem(servicio.Nombre);
                        nuevoItem.SubItems.Add(Utilidades.FormatearComoMoneda(servicio.Precio));
                        nuevoItem.Tag = servicio.id;
                        LV_ServiciosAdicionales.Items.Add(nuevoItem);
                        EliminarConceptoFacturaPorDescripcion($"Servicio adicional: {servicio.Nombre}");

                        // Marcar para quitar
                        itemsToRemove.Add(item);
                    }
                }

                // Quitar de la lista agregada
                foreach (var item in itemsToRemove)
                {
                    LV_ServiciosAgregados.Items.Remove(item);
                }

                BTN_EliminarServicio.Enabled = false;
                BTN_AgregarServicio.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecciona al menos un servicio para eliminarlo.");
            }
        }

        private void TB_CantDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                try
                {
                    descuento = Int32.Parse(TB_CantDescuento.Text);
                    if (descuento < 0)
                    {
                        MessageBox.Show("El descuento tiene que ser mayor a 0%");
                        TB_CantDescuento.Text = "0";
                        TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoTotal);
                        return;
                    }
                    if (descuento > 100)
                    {
                        MessageBox.Show("El descuento no puede ser mayor a 100%");
                        TB_CantDescuento.Text = "0";
                        TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoTotal);
                        return;
                    }
                    descuentoAplicable = montoTotal * (descuento / 100m);
                    montoDescuento = montoTotal - descuentoAplicable;
                    TB_MontoTotal.Text = Utilidades.FormatearComoMoneda(montoDescuento);
                }
                catch (FormatException err)
                {
                    MessageBox.Show("El descuento tiene que ser un porcentaje");
                    TB_CantDescuento.Text = "0";
                    return;
                }

            }
        }

        private void CB_FormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            formadepago = CB_FormaDePago.SelectedItem.ToString();
        }

        private void CB_MetodoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            metododepago = CB_MetodoDePago.SelectedItem.ToString();
        }
    }
}
