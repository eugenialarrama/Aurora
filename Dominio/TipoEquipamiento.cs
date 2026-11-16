namespace Aurora.Dominio
{
    public class TipoEquipamiento
    {
            private int aId;
            private string aNombre;            // Proyector, Micrófono, Cable...
            private string aDescripcion;       // características

            public int Id { get { return aId; } set { aId = value; } }
            public string Nombre { get { return aNombre; } set { aNombre = value; } }
            public string Descripcion { get { return aDescripcion; } set { aDescripcion = value; } }

            public TipoEquipamiento(int pId, string pNombre, string pDescripcion)
            {
                aId = pId;
                aNombre = pNombre;
                aDescripcion = pDescripcion;
                
            }
        }
    }

