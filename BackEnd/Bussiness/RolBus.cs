using Dto;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class RolBus
    {
        public async Task<ResultadoTransaccionE<string>> Registrar_Rol(RolE objRol) 
        {
            ResultadoTransaccionE<string> transaccionE = new ResultadoTransaccionE<string>();
            try {
                transaccionE = await new RolDto().Registrar_Rol(objRol);
            }
            catch (Exception ex) {
                transaccionE.IdRegistro = -1;
                transaccionE.Mensaje = ex.Message;
            }
            return transaccionE;
        }

        public async Task<ResultadoTransaccionE<string>> Actualizar_Rol(RolE objRol) {
            ResultadoTransaccionE<string> transaccionE = new ResultadoTransaccionE<string>();
            try
            {
                transaccionE = await new RolDto().Actualizar_Rol(objRol);
            }
            catch (Exception ex)
            {
                transaccionE.IdRegistro = -1;
                transaccionE.Mensaje = ex.Message;
            }
            return transaccionE;
        }

        public async Task<ResultadoTransaccionE<string>> Eliminar_Rol(RolE objRol) 
        {
            ResultadoTransaccionE<string> transaccionE = new ResultadoTransaccionE<string>();
            try
            {
                transaccionE = await new RolDto().Eliminar_Rol(objRol);
            }
            catch (Exception ex)
            {
                transaccionE.IdRegistro = -1;
                transaccionE.Mensaje = ex.Message;
            }
            return transaccionE;
        }
        public async Task<ResultadoTransaccionE<RolE>> Listar_X_ID(int orden, string buscar, int Idrol) {
            ResultadoTransaccionE<RolE> transaccionE = new ResultadoTransaccionE<RolE>();
            try
            {
                transaccionE = await new RolDto().Listar_X_ID( orden,  buscar,  Idrol);
            }
            catch (Exception ex)
            {
                transaccionE.IdRegistro = -1;
                transaccionE.Mensaje = ex.Message;
            }
            return transaccionE;
        }

        public async Task<ResultadoTransaccionE<RolE>> Listar_All(int orden, string buscar, int Idrol) {
            ResultadoTransaccionE<RolE> transaccionE = new ResultadoTransaccionE<RolE>();
            try
            {
                transaccionE = await new RolDto().Listar_All(orden, buscar, Idrol);
            }
            catch (Exception ex)
            {
                transaccionE.IdRegistro = -1;
                transaccionE.Mensaje = ex.Message;
            }
            return transaccionE;
        }
    }
}
