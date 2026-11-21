using Aurora.Dominio;
using System.Data;

namespace Aurora.Persistencia
{
    public class PUnidadEquipamiento
    {
        private Conexion Conexion = new Conexion();

        public List<UnidadEquipamiento> ListaUnidades()
        {
            string sql = "SELECT id, identificador, estado, idTipo, idDeposito FROM UnidadEquipamiento";

            DataSet datos = Conexion.Consultar(sql);

            List<UnidadEquipamiento> lista = new List<UnidadEquipamiento>();
            PTipoEquipamiento unaPTipo = new PTipoEquipamiento();
            PDeposito unaPDeposito = new PDeposito();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                UnidadEquipamiento unaUnidad = new UnidadEquipamiento(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    unaPTipo.Buscar(int.Parse(fila[3].ToString())),
                    unaPDeposito.Buscar(int.Parse(fila[4].ToString()))
                    );
                lista.Add(unaUnidad);
            }
            return lista;
        }

        public bool Alta(UnidadEquipamiento unaUnidad)
        {
            string sql = "INSERT INTO UnidadEquipamiento (id, identificador, estado, idTipo, idDeposito) "
                + "VALUES (" + unaUnidad.Id + ",'" + unaUnidad.Identificador + "','" + unaUnidad.Estado + "',"
                + unaUnidad.Tipo.Id + "," + unaUnidad.Deposito.Id + ")";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM UnidadEquipamiento WHERE id = " + pId.ToString();

            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(UnidadEquipamiento unaUnidad)
        {
            string sql = "UPDATE UnidadEquipamiento "
                + "SET identificador = '" + unaUnidad.Identificador + "',"
                + "estado = '" + unaUnidad.Estado + "',"
                + "idTipo = " + unaUnidad.Tipo.Id + ","
                + "idDeposito = " + unaUnidad.Deposito.Id + " "
                + "WHERE id = " + unaUnidad.Id.ToString();

            return Conexion.Ejecutar(sql);
        }
    }
}
