namespace Aurora.Dominio
{
    public class TipoEquipamiento
    {
        private int aId;
        private string aNombre;
        private string aDescripcion;
        private string aCaracteristicas;
        private decimal aPrecioAlquiler;
        private Deposito aDeposito;

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Descripcion { get { return aDescripcion; } set { aDescripcion = value; } }
        public string Caracteristicas { get { return aCaracteristicas; } set { aCaracteristicas = value; } }
        public decimal PrecioAlquiler { get { return aPrecioAlquiler; } set { aPrecioAlquiler = value; } }
        public Deposito Deposito { get { return aDeposito; } set { aDeposito = value; } }

        public TipoEquipamiento(int pId, string pNombre, string pDescripcion, string pCaracteristicas, decimal pPrecioAlquiler, Deposito pDeposito)
        {
            aId = pId;
            aNombre = pNombre;
            aDescripcion = pDescripcion;
            aCaracteristicas = pCaracteristicas;
            aPrecioAlquiler = pPrecioAlquiler;
            aDeposito = pDeposito;
        }
    }
}
