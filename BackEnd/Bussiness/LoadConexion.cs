using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public static class LoadConexion
    {
        public static void LoadCadenaConexion(string conexion) {
            ConexionDto.Cnx = conexion;
        }
    }
}
