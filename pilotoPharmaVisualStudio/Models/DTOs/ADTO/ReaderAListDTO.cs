using Npgsql;

namespace pilotoPharmaVisualStudio.Models.DTOs.ADTO
{
    public class ReaderAListDTO
    {

        public static List<ProductosDTO> ReaderAListProductoDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<ProductosDTO> listProductos = new List<ProductosDTO>();
            while (resultadoConsulta.Read())
            {
                listProductos.Add(new ProductosDTO(

                    resultadoConsulta[0].ToString(),
                    resultadoConsulta[1].ToString(),
                    (int)Int64.Parse(resultadoConsulta[2].ToString()),
                    resultadoConsulta[3].ToString(),
                    resultadoConsulta[4].ToString(),
                    resultadoConsulta[5].ToString(),
                    resultadoConsulta[6].ToString(),
                    resultadoConsulta[7].ToString(),
                    resultadoConsulta[8].ToString()

                    )
                    );

            }
            return listProductos;
        }


    }
}
