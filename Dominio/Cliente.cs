namespace Aurora.Dominio
{

        public class Cliente
        {
            private int aId;
            private string aTipo;       // "Particular", "Empresa" u "Organizacion"
            private string aNombre;     // nombre o razón social
            private string aDocumento;  // cédula o RUT
            private string aTelefono;
            private string aEmail;
            private bool aActivo;

            public int Id { get { return aId; } set { aId = value; } }
            public string Tipo { get { return aTipo; } set { aTipo = value; } }
            public string Nombre { get { return aNombre; } set { aNombre = value; } }
            public string Documento { get { return aDocumento; } set { aDocumento = value; } }
            public string Telefono { get { return aTelefono; } set { aTelefono = value; } }
            public string Email { get { return aEmail; } set { aEmail = value; } }
            public bool Activo { get { return aActivo; } set { aActivo = value; } }

            public Cliente(int pId, string pTipo, string pNombre, string pDocumento, string pTelefono, string pEmail)
            {
                aId = pId;
                aTipo = pTipo;
                aNombre = pNombre;
                aDocumento = pDocumento;
                aTelefono = pTelefono;
                aEmail = pEmail;
                aActivo = true;
            }
        }
    }


        