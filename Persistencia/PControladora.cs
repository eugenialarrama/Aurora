using Aurora.Dominio;

namespace Aurora.Persistencia
{
    public class PControladora
    {
        #region "Clientes"
        public List<Cliente> ListaClientes()
        {
            return new PCliente().ListaClientes();
        }
        public bool AltaCliente(Cliente mCliente)
        {
            return new PCliente().Alta(mCliente);
        }
        public bool ModificarCliente(Cliente mCliente)
        {
            return new PCliente().Modificar(mCliente);
        }
        public bool DesactivarCliente(int pId)
        {
            return new PCliente().Desactivar(pId);
        }
        #endregion

        #region "Depositos"
        public List<Deposito> ListaDepositos()
        {
            return new PDeposito().ListaDepositos();
        }
        public bool AltaDeposito(Deposito mDeposito)
        {
            return new PDeposito().Alta(mDeposito);
        }
        public bool BajaDeposito(int pId)
        {
            return new PDeposito().Baja(pId);
        }
        public bool ModificarDeposito(Deposito mDeposito)
        {
            return new PDeposito().Modificar(mDeposito);
        }
        #endregion

        #region "TiposEquipamiento"
        public List<TipoEquipamiento> ListaTiposEquipamiento()
        {
            return new PTipoEquipamiento().ListaTipos();
        }
        public bool AltaTipoEquipamiento(TipoEquipamiento mTipo)
        {
            return new PTipoEquipamiento().Alta(mTipo);
        }
        public bool BajaTipoEquipamiento(int pId)
        {
            return new PTipoEquipamiento().Baja(pId);
        }
        public bool ModificarTipoEquipamiento(TipoEquipamiento mTipo)
        {
            return new PTipoEquipamiento().Modificar(mTipo);
        }
        #endregion

        #region "Unidades"
        public List<UnidadEquipamiento> ListaUnidades()
        {
            return new PUnidadEquipamiento().ListaUnidades();
        }
        public bool AltaUnidad(UnidadEquipamiento mUnidad)
        {
            return new PUnidadEquipamiento().Alta(mUnidad);
        }
        public bool BajaUnidad(int pId)
        {
            return new PUnidadEquipamiento().Baja(pId);
        }
        public bool ModificarUnidad(UnidadEquipamiento mUnidad)
        {
            return new PUnidadEquipamiento().Modificar(mUnidad);
        }
        #endregion
    }
}
