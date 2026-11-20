namespace Aurora.Dominio
{
    public class UnidadEquipamiento
    {
        private int aId;
        private string aIdentificador;  
        private string aEstado; 
        private TipoEquipamiento aTipo;
        private Deposito aDeposito;

        public int Id { get { return aId; } set { aId = value; } }
        public string Identificador { get { return aIdentificador; } set { aIdentificador = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public TipoEquipamiento Tipo { get { return aTipo; } set { aTipo = value; } }
        public Deposito Deposito { get { return aDeposito; } set { aDeposito = value; } }

        public UnidadEquipamiento(int pId, string pIdentificador, string pEstado, TipoEquipamiento pTipo, Deposito pDeposito)
        {
            aId = pId;
            aIdentificador = pIdentificador;
            aEstado = pEstado;
            aTipo = pTipo;
            aDeposito = pDeposito;
        }
    }
}
