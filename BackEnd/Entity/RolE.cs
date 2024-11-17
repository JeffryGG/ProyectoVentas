using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RolE
    {
        public int IdRol { get; set; }
        public string Rol_Dsc { get; set; }
        public bool Estado {  get; set; }

        public RolE() { }
        public RolE(int _idrol, string rol_dsc, bool estado)
        { 
            IdRol = _idrol;
            Rol_Dsc = rol_dsc;
            Estado = estado;
        }
    }
}
