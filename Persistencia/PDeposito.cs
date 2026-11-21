using Aurora.Dominio;
using System.Data;

namespace Aurora.Persistencia
{
    public class PDeposito
    {
        private Conexion Conexion = new Conexion();

        public List<Deposito> ListaDepositos()
        {
            string sql = "SELECT id, nombre, direccion FROM Deposito";

            DataSet datos = Conexion.Consultar(sql);

            List<Deposito> lista = new List<Deposito>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Deposito unDeposito = new Deposito(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString()
                    );
                lista.Add(unDeposito);
            }
            return lista;
        }

        public Deposito Buscar(int pId)
        {
            string sql = "SELECT id, nombre, direccion FROM Deposito WHERE id = " + pId.ToString();

            DataSet datos = Conexion.Consultar(sql);

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                return new Deposito(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString()
                    );
            }
            return null;
        }

        public bool Alta(Deposito unDeposito)
        {
            string sql = "INSERT INTO Deposito (id, nombre, direccion) "
                + "VALUES (" + unDeposito.Id + ",'" + unDeposito.Nombre + "','" + unDeposito.Direccion + "')";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Deposito WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(Deposito unDeposito)
        {
            string sql = "UPDATE Deposito "
                + "SET nombre = '" + unDeposito.Nombre + "',"
                + "direccion = '" + unDeposito.Direccion + "' "
                + "WHERE id = " + unDeposito.Id.ToString();

            return Conexion.Ejecutar(sql);
        }
    }
}

