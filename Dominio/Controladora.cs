using Aurora.Persistencia;

namespace Aurora.Dominio
{
    public class Controladora
    {
        private PControladora Persistencia;
        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Deposito> aListaDepositos = new List<Deposito>();
        private static List<TipoEquipamiento> aListaTiposEquipamiento = new List<TipoEquipamiento>();
        private static List<UnidadEquipamiento> aListaUnidades = new List<UnidadEquipamiento>();
        private static List<SolicitudAlquiler> aListaSolicitudes = new List<SolicitudAlquiler>();
        private static List<LineaSolicitud> aListaLineasSolicitud = new List<LineaSolicitud>();

        public Controladora()
        {
            Persistencia = new PControladora();
        }
        public void CargarListas()
        {
            ListarClientes();
            ListarDepositos();
            ListarTiposEquipamiento();
            ListarUnidades();
            ListarSolicitudes();
        }

        #region Clientes

        public List<Cliente> ListarClientes()
        {
            aListaClientes = Persistencia.ListaClientes();
            return aListaClientes;
        }

        public Cliente BuscarCliente(int pId)
        {
            foreach (Cliente unCliente in aListaClientes)
            {
                if (unCliente.Id == pId)
                {
                    return unCliente;
                }
            }
            return null;
        }

        public bool AltaCliente(Cliente pCliente)
        {
            Cliente ComparoCliente = BuscarCliente(pCliente.Id);
            if (ComparoCliente == null)
            {
                if (Persistencia.AltaCliente(pCliente))
                {
                    aListaClientes.Add(pCliente);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarCliente(int pId, string pTipo, string pNombre, string pDocumento, string pTelefono, string pEmail, string pDireccion)
        {
            Cliente ClienteAModificar = BuscarCliente(pId);
            if (ClienteAModificar != null)
            {
                ClienteAModificar.Tipo = pTipo;
                ClienteAModificar.Nombre = pNombre;
                ClienteAModificar.Documento = pDocumento;
                ClienteAModificar.Telefono = pTelefono;
                ClienteAModificar.Email = pEmail;
                ClienteAModificar.Direccion = pDireccion;
                return Persistencia.ModificarCliente(ClienteAModificar);
            }
            return false;
        }

        public bool DesactivarCliente(int pId)
        {
            Cliente ClienteADesactivar = BuscarCliente(pId);
            if (ClienteADesactivar != null)
            {
                if (Persistencia.DesactivarCliente(pId))
                {
                    ClienteADesactivar.Activo = false;
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Depositos

        public List<Deposito> ListarDepositos()
        {
            aListaDepositos = Persistencia.ListaDepositos();
            return aListaDepositos;
        }

        public Deposito BuscarDeposito(int pId)
        {
            foreach (Deposito unDeposito in aListaDepositos)
            {
                if (unDeposito.Id == pId)
                {
                    return unDeposito;
                }
            }
            return null;
        }

        public bool AltaDeposito(Deposito pDeposito)
        {
            Deposito ComparoDeposito = BuscarDeposito(pDeposito.Id);
            if (ComparoDeposito == null)
            {
                if (Persistencia.AltaDeposito(pDeposito))
                {
                    aListaDepositos.Add(pDeposito);
                    return true;
                }
            }
            return false;
        }

        public bool BajaDeposito(int pId)
        {
            Deposito DepositoAEliminar = BuscarDeposito(pId);
            if (DepositoAEliminar != null)
            {
                foreach (TipoEquipamiento unTipo in ListarTiposEquipamiento())
                {
                    if (unTipo.Deposito.Id == pId)
                    {
                        return false;
                    }
                }
                foreach (UnidadEquipamiento unaUnidad in ListarUnidades())
                {
                    if (unaUnidad.Deposito.Id == pId)
                    {
                        return false;
                    }
                }
                if (Persistencia.BajaDeposito(pId))
                {
                    aListaDepositos.Remove(DepositoAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarDeposito(int pId, string pNombre, string pDireccion)
        {
            Deposito DepositoAModificar = BuscarDeposito(pId);
            if (DepositoAModificar != null)
            {
                DepositoAModificar.Nombre = pNombre;
                DepositoAModificar.Direccion = pDireccion;
                return Persistencia.ModificarDeposito(DepositoAModificar);
            }
            return false;
        }

        #endregion

        #region TiposEquipamiento

        public List<TipoEquipamiento> ListarTiposEquipamiento()
        {
            aListaTiposEquipamiento = Persistencia.ListaTiposEquipamiento();
            return aListaTiposEquipamiento;
        }

        public TipoEquipamiento BuscarTipoEquipamiento(int pId)
        {
            foreach (TipoEquipamiento unTipo in aListaTiposEquipamiento)
            {
                if (unTipo.Id == pId)
                {
                    return unTipo;
                }
            }
            return null;
        }

        public bool AltaTipoEquipamiento(TipoEquipamiento pTipo)
        {
            TipoEquipamiento ComparoTipo = BuscarTipoEquipamiento(pTipo.Id);
            if (ComparoTipo == null)
            {
                if (Persistencia.AltaTipoEquipamiento(pTipo))
                {
                    aListaTiposEquipamiento.Add(pTipo);
                    return true;
                }
            }
            return false;
        }

        public bool BajaTipoEquipamiento(int pId)
        {
            TipoEquipamiento TipoAEliminar = BuscarTipoEquipamiento(pId);
            if (TipoAEliminar != null)
            {
                foreach (UnidadEquipamiento unaUnidad in ListarUnidades())
                {
                    if (unaUnidad.Tipo.Id == pId)
                    {
                        return false;
                    }
                }
                if (Persistencia.BajaTipoEquipamiento(pId))
                {
                    aListaTiposEquipamiento.Remove(TipoAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarTipoEquipamiento(int pId, string pNombre, string pDescripcion, string pCaracteristicas, decimal pPrecioAlquiler, Deposito pDeposito)
        {
            TipoEquipamiento TipoAModificar = BuscarTipoEquipamiento(pId);
            if (TipoAModificar != null)
            {
                TipoAModificar.Nombre = pNombre;
                TipoAModificar.Descripcion = pDescripcion;
                TipoAModificar.Caracteristicas = pCaracteristicas;
                TipoAModificar.PrecioAlquiler = pPrecioAlquiler;
                TipoAModificar.Deposito = pDeposito;
                return Persistencia.ModificarTipoEquipamiento(TipoAModificar);
            }
            return false;
        }

        #endregion

        #region Unidades

        public List<string> ListarEstados()
        {
            List<string> Estados = new List<string>();
            Estados.Add("Disponible");
            Estados.Add("Reservado");
            Estados.Add("En preparación");
            Estados.Add("Alquilado");
            Estados.Add("En mantenimiento");
            Estados.Add("Fuera de servicio");
            return Estados;
        }

        public List<UnidadEquipamiento> ListarUnidades()
        {
            aListaUnidades = Persistencia.ListaUnidades();
            return aListaUnidades;
        }

        public UnidadEquipamiento BuscarUnidad(int pId)
        {
            foreach (UnidadEquipamiento unaUnidad in aListaUnidades)
            {
                if (unaUnidad.Id == pId)
                {
                    return unaUnidad;
                }
            }
            return null;
        }

        public UnidadEquipamiento BuscarUnidadPorIdentificador(string pIdentificador)
        {
            foreach (UnidadEquipamiento unaUnidad in aListaUnidades)
            {
                if (unaUnidad.Identificador == pIdentificador)
                {
                    return unaUnidad;
                }
            }
            return null;
        }

        public bool AltaUnidad(UnidadEquipamiento pUnidad)
        {
            UnidadEquipamiento ComparoUnidad = BuscarUnidad(pUnidad.Id);
            if (ComparoUnidad == null)
            {
                if (Persistencia.AltaUnidad(pUnidad))
                {
                    aListaUnidades.Add(pUnidad);
                    return true;
                }
            }
            return false;
        }

        public bool BajaUnidad(int pId)
        {
            UnidadEquipamiento UnidadAEliminar = BuscarUnidad(pId);
            if (UnidadAEliminar != null)
            {
                if (Persistencia.BajaUnidad(pId))
                {
                    aListaUnidades.Remove(UnidadAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarUnidad(int pId, string pIdentificador, string pEstado, TipoEquipamiento pTipo, Deposito pDeposito)
        {
            UnidadEquipamiento UnidadAModificar = BuscarUnidad(pId);
            if (UnidadAModificar != null)
            {
                UnidadAModificar.Identificador = pIdentificador;
                UnidadAModificar.Estado = pEstado;
                UnidadAModificar.Tipo = pTipo;
                UnidadAModificar.Deposito = pDeposito;
                return Persistencia.ModificarUnidad(UnidadAModificar);
            }
            return false;
        }

        #endregion

        #region Solicitudes

        public int ProximoIdEvento()
        {
            return Persistencia.ProximoEventoId();
        }

        public int ProximoIdSolicitud()
        {
            return Persistencia.ProximoSolicitudId();
        }

        public List<SolicitudAlquiler> ListarSolicitudes()
        {
            aListaSolicitudes = Persistencia.ListaSolicitudes();
            return aListaSolicitudes;
        }

        public SolicitudAlquiler BuscarSolicitud(int pId)
        {
            foreach (SolicitudAlquiler unaSolicitud in aListaSolicitudes)
            {
                if (unaSolicitud.Id == pId)
                {
                    return unaSolicitud;
                }
            }
            return null;
        }

        public bool AltaSolicitud(SolicitudAlquiler pSolicitud)

        {
            SolicitudAlquiler ComparoSolicitud = BuscarSolicitud(pSolicitud.Id);
            if (ComparoSolicitud == null)
            {
                if (Persistencia.AltaEvento(pSolicitud.Evento))
                {
                    if (Persistencia.AltaSolicitud(pSolicitud))
                    {
                        aListaSolicitudes.Add(pSolicitud);
                        LimpiarLineasSolicitud();
                        return true;
                    }
                }
            }
            return false;
        }
        public int ProximoIdLinea()
        {
            return Persistencia.ProximoLineaSolicitudId();
        }

        public List<LineaSolicitud> ListarLineasSolicitud()
        {
            return aListaLineasSolicitud;
        }

        public bool AltaLineaSolicitud(LineaSolicitud pLinea)
        {
            aListaLineasSolicitud.Add(pLinea);
            return true;
        }

        public bool QuitarLineaSolicitud(int pId)
        {
            foreach (LineaSolicitud unaLinea in aListaLineasSolicitud)
            {
                if (unaLinea.Id == pId)
                {
                    aListaLineasSolicitud.Remove(unaLinea);
                    return true;
                }
            }
            return false;
        }

        public void LimpiarLineasSolicitud()
        {
            aListaLineasSolicitud.Clear();
        }
        public bool CambiarEstadoSolicitud(int pId, string pEstado)
        {
            SolicitudAlquiler unaSolicitud = BuscarSolicitud(pId);
            if (unaSolicitud != null)
            {
                bool Permitido = false;

                if (unaSolicitud.Estado == "Pendiente")
                {
                    if (pEstado == "Aceptada" || pEstado == "Rechazada" || pEstado == "Cancelada")
                    {
                        Permitido = true;
                    }
                }
                if (unaSolicitud.Estado == "Aceptada")
                {
                    if (pEstado == "Cancelada")
                    {
                        Permitido = true;
                    }
                }

                if (Permitido)
                {
                    if (Persistencia.CambiarEstadoSolicitud(pId, pEstado))
                    {
                        unaSolicitud.Estado = pEstado;
                        return true;
                    }
                }
            }
            return false;
        }
        public int CantidadDisponible(int pIdTipo)
        {
            int Cantidad = 0;
            foreach (UnidadEquipamiento unaUnidad in ListarUnidades())
            {
                if (unaUnidad.Tipo.Id == pIdTipo && unaUnidad.Estado == "Disponible")
                {
                    Cantidad += 1;
                }
            }
            return Cantidad;
        }

        public int CantidadComprometida(int pIdTipo, SolicitudAlquiler pSolicitud)
        {
            int Cantidad = 0;
            foreach (SolicitudAlquiler otraSolicitud in aListaSolicitudes)
            {
                if (otraSolicitud.Id != pSolicitud.Id && otraSolicitud.Estado == "Aceptada")
                {
                    if (otraSolicitud.Evento.Fecha.Date == pSolicitud.Evento.Fecha.Date)
                    {
                        if (pSolicitud.Evento.HoraInicio < otraSolicitud.Evento.HoraFin
                            && otraSolicitud.Evento.HoraInicio < pSolicitud.Evento.HoraFin)
                        {
                            foreach (LineaSolicitud unaLinea in otraSolicitud.Lineas)
                            {
                                if (unaLinea.Tipo.Id == pIdTipo)
                                {
                                    Cantidad += unaLinea.Cantidad;
                                }
                            }
                        }
                    }
                }
            }
            return Cantidad;
        }

        public string VerificarDisponibilidad(SolicitudAlquiler pSolicitud)
        {
            foreach (LineaSolicitud unaLinea in pSolicitud.Lineas)
            {
                int Libres = CantidadDisponible(unaLinea.Tipo.Id) - CantidadComprometida(unaLinea.Tipo.Id, pSolicitud);
                if (Libres < unaLinea.Cantidad)
                {
                    if (Libres < 0)
                    {
                        Libres = 0;
                    }
                    return "No hay disponibilidad de " + unaLinea.Tipo.Nombre + ": se piden " + unaLinea.Cantidad + " y hay " + Libres + " para esa fecha y horario.";
                }
            }
            return "";
        }

        #endregion
    }
}
