namespace Aurora.Dominio
{
    public class Equipo
    {
        private int aId;
        private string aNumeroSerie;
        private string aEstado;  // Disponible, Reservado, En preparación, Alquilado, En mantenimiento, Fuera de servicio
        private TipoEquipamiento aTipo;
        private Deposito aDeposito;

        public int Id { get { return aId; } set { aId = value; } }
        public string NumeroSerie { get { return aNumeroSerie; } set { aNumeroSerie = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public TipoEquipamiento Tipo { get { return aTipo; } set { aTipo = value; } }
        public Deposito Deposito { get { return aDeposito; } set { aDeposito = value; } }

        public Equipo(int pId, string pNumeroSerie, string pEstado, TipoEquipamiento pTipo, Deposito pDeposito)
        {
            aId = pId;
            aNumeroSerie = pNumeroSerie;
            aEstado = pEstado;
            aTipo = pTipo;
            aDeposito = pDeposito;
        }
    }
}
}
