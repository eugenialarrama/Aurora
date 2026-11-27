using Aurora.Dominio;
using System.Data;

namespace Aurora.Persistencia
{
    public class PSolicitud
    {
        private Conexion Conexion = new Conexion();

        public List<SolicitudAlquiler> ListaSolicitudes()
        {
            string sql = "SELECT id, fecha, estado, idCliente, idEvento FROM SolicitudAlquiler";

            DataSet datos = Conexion.Consultar(sql);

            List<SolicitudAlquiler> lista = new List<SolicitudAlquiler>();
            PCliente unaPCliente = new PCliente();
            PEvento unaPEvento = new PEvento();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                int Id = int.Parse(fila[0].ToString());
                SolicitudAlquiler unaSolicitud = new SolicitudAlquiler(
                    Id,
                    DateTime.Parse(fila[1].ToString()),
                    fila[2].ToString(),
                    unaPCliente.Buscar(int.Parse(fila[3].ToString())),
                    unaPEvento.Buscar(int.Parse(fila[4].ToString()))
                    );
                unaSolicitud.Lineas = ListaLineas(Id);
                lista.Add(unaSolicitud);
            }
            return lista;
        }

        public List<LineaSolicitud> ListaLineas(int pIdSolicitud)
        {
            string sql = "SELECT id, idTipo, cantidad FROM LineaSolicitud WHERE idSolicitud = " + pIdSolicitud.ToString();

            DataSet datos = Conexion.Consultar(sql);

            List<LineaSolicitud> lista = new List<LineaSolicitud>();
            PTipoEquipamiento unaPTipo = new PTipoEquipamiento();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                LineaSolicitud unaLinea = new LineaSolicitud(
                    int.Parse(fila[0].ToString()),
                    unaPTipo.Buscar(int.Parse(fila[1].ToString())),
                    int.Parse(fila[2].ToString())
                    );
                lista.Add(unaLinea);
            }
            return lista;
        }

            public bool Alta(SolicitudAlquiler unaSolicitud)
        {
            string sql = "INSERT INTO SolicitudAlquiler (id, fecha, estado, idCliente, idEvento) "
                + "VALUES (" + unaSolicitud.Id + ",'" + unaSolicitud.Fecha.ToString("yyyy-MM-dd") + "','"
                + unaSolicitud.Estado + "'," + unaSolicitud.Cliente.Id + "," + unaSolicitud.Evento.Id + ")";

            if (Conexion.Ejecutar(sql))
            {
                return AltaLineas(unaSolicitud.Lineas, unaSolicitud.Id);
            }
            return false;
        }

        public bool AltaLineas(List<LineaSolicitud> pLineas, int pIdSolicitud)
        {
            string sql = "";
            foreach (LineaSolicitud unaLinea in pLineas)
            {
                sql += " INSERT INTO LineaSolicitud (id, idSolicitud, idTipo, cantidad) "
                    + "VALUES (" + unaLinea.Id + "," + pIdSolicitud + "," + unaLinea.Tipo.Id + "," + unaLinea.Cantidad + "); ";
            }
            return Conexion.Ejecutar(sql);
        }

        public int ProximoIdLinea()
        {
            string sql = "SELECT (ISNULL(MAX(id),0)+1) FROM LineaSolicitud";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(id),0)+1) FROM SolicitudAlquiler";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
        public bool CambiarEstado(int pId, string pEstado)
        {
            string sql = "UPDATE SolicitudAlquiler "
                + "SET estado = '" + pEstado + "' "
                + "WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }
    }
}
