using Aurora.Dominio;
using System.Data;

namespace Aurora.Persistencia
{
    public class PTipoEquipamiento
    {
        private Conexion Conexion = new Conexion();

        public List<TipoEquipamiento> ListaTipos()
        {
            string sql = "SELECT id, nombre, descripcion, caracteristicas, precioAlquiler, idDeposito FROM TipoEquipamiento";

            DataSet datos = Conexion.Consultar(sql);

            List<TipoEquipamiento> lista = new List<TipoEquipamiento>();
            PDeposito unaPDeposito = new PDeposito();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                TipoEquipamiento unTipo = new TipoEquipamiento(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    decimal.Parse(fila[4].ToString()),
                    unaPDeposito.Buscar(int.Parse(fila[5].ToString()))
                    );
                lista.Add(unTipo);
            }
            return lista;
        }

        public TipoEquipamiento Buscar(int pId)
        {
            string sql = "SELECT id, nombre, descripcion, caracteristicas, precioAlquiler, idDeposito FROM TipoEquipamiento WHERE id = " + pId.ToString();

            DataSet datos = Conexion.Consultar(sql);
            PDeposito unaPDeposito = new PDeposito();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                return new TipoEquipamiento(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    decimal.Parse(fila[4].ToString()),
                    unaPDeposito.Buscar(int.Parse(fila[5].ToString()))
                    );
            }
            return null;
        }

        public bool Alta(TipoEquipamiento unTipo)
        {
            string sql = "INSERT INTO TipoEquipamiento (id, nombre, descripcion, caracteristicas, precioAlquiler, idDeposito) "
                + "VALUES (" + unTipo.Id + ",'" + unTipo.Nombre + "','" + unTipo.Descripcion + "','"
                + unTipo.Caracteristicas + "'," + unTipo.PrecioAlquiler.ToString().Replace(",", ".") + "," //SQL Server entiende los decimales con punto
                + unTipo.Deposito.Id + ")";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM TipoEquipamiento WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(TipoEquipamiento unTipo)
        {
            string sql = "UPDATE TipoEquipamiento "
                + "SET nombre = '" + unTipo.Nombre + "',"
                + "descripcion = '" + unTipo.Descripcion + "',"
                + "caracteristicas = '" + unTipo.Caracteristicas + "',"
                + "precioAlquiler = " + unTipo.PrecioAlquiler.ToString().Replace(",", ".") + ","
                + "idDeposito = " + unTipo.Deposito.Id + " "
                + "WHERE id = " + unTipo.Id.ToString();

            return Conexion.Ejecutar(sql);
        }
    }
}

