namespace Aurora.Dominio
{
    public class SolicitudAlquiler
    {
        private int aId;
        private DateTime aFecha;
        private string aEstado;  
        private Cliente aCliente;
        private Evento aEvento;
        private List<LineaSolicitud> aLineas;

        public int Id { get { return aId; } set { aId = value; } }
        public DateTime Fecha { get { return aFecha; } set { aFecha = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public Cliente Cliente { get { return aCliente; } set { aCliente = value; } }
        public Evento Evento { get { return aEvento; } set { aEvento = value; } }
        public List<LineaSolicitud> Lineas { get { return aLineas; } set { aLineas = value; } }

        public SolicitudAlquiler(int pId, DateTime pFecha, string pEstado, Cliente pCliente, Evento pEvento)
        {
            aId = pId;
            aFecha = pFecha;
            aEstado = pEstado;
            aCliente = pCliente;
            aEvento = pEvento;
            aLineas = new List<LineaSolicitud>();
        }
    }
}
