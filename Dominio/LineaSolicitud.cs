namespace Aurora.Dominio
{
    public class LineaSolicitud
    {
        private int aId;
        private TipoEquipamiento aTipo;
        private int aCantidad;

        public int Id { get { return aId; } set { aId = value; } }
        public TipoEquipamiento Tipo { get { return aTipo; } set { aTipo = value; } }
        public int Cantidad { get { return aCantidad; } set { aCantidad = value; } }

        public LineaSolicitud(int pId, TipoEquipamiento pTipo, int pCantidad)
        {
            aId = pId;
            aTipo = pTipo;
            aCantidad = pCantidad;
        }
    }
}
