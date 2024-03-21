using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class UsuarioEntity
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public char TipoUsuario { get; set; }

        public bool Vigente { get; set; }
    }
    /*
     CREATE TABLE Usuario (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Nombre VARCHAR(45) NULL,
	Contraseña VARCHAR(45) NOT NULL,
	TipoUsuario CHAR(1) NOT NULL,
	Vigente BIT NOT NULL Default 1
);
GO
     */
}
