using Aurora.Dominio;
using System.Data;

namespace Aurora.Persistencia
{
    public class PCliente
    {
            private Conexion Conexion = new Conexion();

            public List<Cliente> ListaClientes()
            {
                string sql = "SELECT id, tipo, nombre, documento, telefono, email, direccion, activo FROM Cliente";

                DataSet datos = Conexion.Consultar(sql);

                List<Cliente> lista = new List<Cliente>();

                foreach (DataRow fila in datos.Tables[0].Rows)
                {
                    Cliente unCliente = new Cliente(
                        int.Parse(fila[0].ToString()),
                        fila[1].ToString(),
                        fila[2].ToString(),
                        fila[3].ToString(),
                        fila[4].ToString(),
                        fila[5].ToString(),
                        fila[6].ToString()
                        );
                    unCliente.Activo = bool.Parse(fila[7].ToString());
                    lista.Add(unCliente);
                }
                return lista;
            }

            public bool Alta(Cliente unCliente)
            {
                string sql = "INSERT INTO Cliente (id, tipo, nombre, documento, telefono, email, direccion, activo) "
                    + "VALUES (" + unCliente.Id + ",'" + unCliente.Tipo + "','" + unCliente.Nombre + "','"
                    + unCliente.Documento + "','" + unCliente.Telefono + "','" + unCliente.Email + "','"
                    + unCliente.Direccion + "','" + unCliente.Activo + "')";

                return Conexion.Ejecutar(sql);
            }

            public bool Modificar(Cliente unCliente)
            {
                string sql = "UPDATE Cliente "
                    + "SET tipo = '" + unCliente.Tipo + "',"
                    + "nombre = '" + unCliente.Nombre + "',"
                    + "documento = '" + unCliente.Documento + "',"
                    + "telefono = '" + unCliente.Telefono + "',"
                    + "email = '" + unCliente.Email + "',"
                    + "direccion = '" + unCliente.Direccion + "' "
                    + "WHERE id = " + unCliente.Id.ToString();

                return Conexion.Ejecutar(sql);
            }

            public bool Desactivar(int pId)
            {
                string sql = "UPDATE Cliente SET activo = 0 WHERE id = " + pId.ToString();

                return Conexion.Ejecutar(sql);
            }
        }
    }


