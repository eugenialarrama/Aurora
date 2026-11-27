namespace Aurora.Dominio
{
    public class Evento
    {
        private int aId;
        private string aNombre;
        private DateTime aFecha;
        private string aUbicacion;
        private TimeSpan aHoraInicio; //TimeSpan para representar la hora de inicio
        private TimeSpan aHoraFin; //TimeSpan para representar la hora de fin
        private int aCantAsistentes;

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public DateTime Fecha { get { return aFecha; } set { aFecha = value; } }
        public string Ubicacion { get { return aUbicacion; } set { aUbicacion = value; } }
        public TimeSpan HoraInicio { get { return aHoraInicio; } set { aHoraInicio = value; } }
        public TimeSpan HoraFin { get { return aHoraFin; } set { aHoraFin = value; } }
        public int CantAsistentes { get { return aCantAsistentes; } set { aCantAsistentes = value; } }

        public Evento(int pId, string pNombre, DateTime pFecha, string pUbicacion, TimeSpan pHoraInicio, TimeSpan pHoraFin, int pCantAsistentes)
        {
            aId = pId;
            aNombre = pNombre;
            aFecha = pFecha;
            aUbicacion = pUbicacion;
            aHoraInicio = pHoraInicio;
            aHoraFin = pHoraFin;
            aCantAsistentes = pCantAsistentes;
        }
    }
}

