using Npgsql;
using pilotoPharmaVisualStudio.Models.DTOs;

namespace pilotoPharmaVisualStudio.Models.Consultas
{
    public class ConsultasPostgreSQL
    {
        public static List<ProductosDTO> ConsultaSelectPostgreSQL(NpgsqlConnection conexionGenerada)
        {
            List<ProductosDTO> listAlumnos = new List<ProductosDTO>();

            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"dlk_operacional_productos\".\"opr_cat_productos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAlumnos = DTOs.ADTO.ReaderAListDTO.ReaderAListProductoDTO(resultadoConsulta);
                int cont = listAlumnos.Count();


                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " productos");



                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
                //conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listAlumnos;
        }
    }
}
