using Entity;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class RolDto
    {
        static string SP_Registrar_ROl = "usp_Registrar_Rol";
        static string SP_Actualizar_ROL = "";
        static string SP_Eliminar_ROL = "usp_Delete_Rol";
        static string SP_Listar_ROL = "usp_venta_Lista";

        public async Task<ResultadoTransaccionE<string>> Registrar_Rol(RolE objRol) 
        {
            ResultadoTransaccionE<string> resultado = new ResultadoTransaccionE<string>();
            using (SqlConnection cnn = new SqlConnection(ConexionDto.Cnx)) {
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(SP_Registrar_ROl, cnn, transaction)) 
                {
                    try 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RolDsc", objRol.Rol_Dsc);
                        cmd.Parameters.AddWithValue("@Estado", 1);
                        await cmd.ExecuteNonQueryAsync();

                        resultado.IdRegistro = 0;
                        resultado.Mensaje = "Se ha registrado correctamente el Rol: " + objRol.Rol_Dsc;
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex) 
                    { 
                        transaction.Rollback();
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message; 
                    }
                }
            }
            return resultado;
        }

        public async Task<ResultadoTransaccionE<string>> Actualizar_Rol(RolE objRol)
        {
            ResultadoTransaccionE<string> resultado = new ResultadoTransaccionE<string>();
            using (SqlConnection cnn = new SqlConnection(ConexionDto.Cnx))
            {
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(SP_Actualizar_ROL, cnn, transaction))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdRol", objRol.IdRol);
                        cmd.Parameters.AddWithValue("@RolDsc", objRol.Rol_Dsc);
                        cmd.Parameters.AddWithValue("@Estado", objRol.Estado);
                        await cmd.ExecuteNonQueryAsync();

                        resultado.IdRegistro = 0;
                        resultado.Mensaje = "Se ha Actualizado correctamente el Rol: " + objRol.Rol_Dsc;
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message;
                    }
                }
            }
            return resultado;
        }

        public async Task<ResultadoTransaccionE<string>> Eliminar_Rol(RolE objRol)
        {
            ResultadoTransaccionE<string> resultado = new ResultadoTransaccionE<string>();
            using (SqlConnection cnn = new SqlConnection(ConexionDto.Cnx))
            {
                cnn.Open();
                SqlTransaction transaction = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(SP_Eliminar_ROL, cnn, transaction))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdRol", objRol.IdRol); 
                        await cmd.ExecuteNonQueryAsync();

                        resultado.IdRegistro = 0;
                        resultado.Mensaje = "Se ha Eliminado correctamente el Rol: " + objRol.Rol_Dsc;
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message;
                    }
                }
            }
            return resultado;
        }

        //Listar x ID
        public async Task<ResultadoTransaccionE<RolE>> Listar_X_ID(int orden, string buscar, int Idrol) 
        {
            ResultadoTransaccionE<RolE> resultado = new ResultadoTransaccionE<RolE>();
            using (SqlConnection cnn = new SqlConnection(ConexionDto.Cnx)) 
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(SP_Listar_ROL, cnn)) 
                {
                    try { 
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@orden", orden);
                        cmd.Parameters.AddWithValue("@buscar", buscar);
                        cmd.Parameters.AddWithValue("@IdRol", Idrol);
                        RolE objrol = new RolE(); 
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) 
                        {
                            if (reader.Read()) 
                            {
                                objrol.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                                objrol.Rol_Dsc = reader["Rol_Dsc"].ToString();
                                objrol.Estado = Convert.ToBoolean(reader["Estado"].ToString());
                            }
                        }
                        resultado.IdRegistro = 0;
                        resultado.Mensaje = "Ok";
                        resultado.Data = objrol;
                    }
                    catch (Exception ex)
                    {
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message;
                        resultado.Data = new RolE();
                    }
                }
            }
            return resultado;
        }

        public async Task<ResultadoTransaccionE<RolE>> Listar_All(int orden, string buscar, int Idrol)
        {
            ResultadoTransaccionE<RolE> resultado = new ResultadoTransaccionE<RolE>();
            using (SqlConnection cnn = new SqlConnection(ConexionDto.Cnx))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(SP_Listar_ROL, cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@orden", orden);
                        cmd.Parameters.AddWithValue("@buscar", buscar);
                        cmd.Parameters.AddWithValue("@IdRol", Idrol);
                        List<RolE> Lista = new List<RolE>();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                RolE objrol = new RolE();
                                objrol.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                                objrol.Rol_Dsc = reader["Rol_Dsc"].ToString();
                                objrol.Estado = Convert.ToBoolean(reader["Estado"].ToString());
                                Lista.Add(objrol);
                            }
                        }
                        resultado.IdRegistro = 0;
                        resultado.Mensaje = "Ok";
                        resultado.DataList = Lista;
                    }
                    catch (Exception ex)
                    {
                        resultado.IdRegistro = -1;
                        resultado.Mensaje = ex.Message;
                        resultado.DataList = new List<RolE>();
                    }
                }
            }
            return resultado;
        }

    }
}
