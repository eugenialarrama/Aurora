using Aurora.Dominio;
using System.Data;

namespace Aurora.Persistencia
{
    public class PEvento
    {
        private Conexion Conexion = new Conexion();

        public Evento Buscar(int pId)
        {
            string sql = "SELECT id, nombre, fecha, ubicacion, horaInicio, horaFin, cantAsistentes FROM Evento WHERE id = " + pId.ToString();

            DataSet datos = Conexion.Consultar(sql);

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                return new Evento(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    DateTime.Parse(fila[2].ToString()),
                    fila[3].ToString(),
                    TimeSpan.Parse(fila[4].ToString()),
                    TimeSpan.Parse(fila[5].ToString()),
                    int.Parse(fila[6].ToString())
                    );
            }
            return null;
        }

        public bool Alta(Evento unEvento)
        {
            string sql = "INSERT INTO Evento (id, nombre, fecha, ubicacion, horaInicio, horaFin, cantAsistentes) "
                + "VALUES (" + unEvento.Id + ",'" + unEvento.Nombre + "','" + unEvento.Fecha.ToString("yyyy-MM-dd") + "','"
                + unEvento.Ubicacion + "','" + unEvento.HoraInicio + "','" + unEvento.HoraFin + "',"
                + unEvento.CantAsistentes + ")";

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(id),0)+1) FROM Evento";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}
