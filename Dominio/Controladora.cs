namespace Aurora.Dominio
{
    public class Controladora
    {

        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Deposito> aListaDepositos = new List<Deposito>();
        private static List<TipoEquipamiento> aListaTiposEquipamiento = new List<TipoEquipamiento>();

        #region Clientes

        public List<Cliente> ListarClientes()
        {
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
                aListaClientes.Add(pCliente);
                return true;
            }
            return false;
        }

        public bool ModificarCliente(int pId, string pTipo, string pNombre, string pDocumento, string pTelefono, string pEmail,string pDireccion)
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
                return true;
            }
            return false;
        }

        public bool DesactivarCliente(int pId)
        {
            Cliente ClienteADesactivar = BuscarCliente(pId);
            if (ClienteADesactivar != null)
            {
                ClienteADesactivar.Activo = false;
                return true;
            }
            return false;
        }

        #endregion

        #region Depositos
        public List<Deposito> ListarDepositos()
        {
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
                aListaDepositos.Add(pDeposito);
                return true;
            }
            return false;
        }

        public bool BajaDeposito(int pId)
        {
            Deposito DepositoAEliminar = BuscarDeposito(pId);
            if (DepositoAEliminar != null)
            {
                aListaDepositos.Remove(DepositoAEliminar);
                return true;
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
                return true;
            }
            return false;
        }
        #endregion

    }
}
