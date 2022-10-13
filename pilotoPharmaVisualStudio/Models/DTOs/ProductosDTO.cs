namespace pilotoPharmaVisualStudio.Models.DTOs
{
    public class ProductosDTO
    {
        public string md_uuid { get; private set; }
        public string md_fch { get; private set; }
        public int id_producto { get; private set; }
        public string cod_producto { get; private set; }
        public string nombre_producto { get; private set; }
        public string tipo_producto_origen { get; private set; }
        public string tipo_producto_clase { get; private set; }
        public string des_producto { get; private set; }
        public string fch_alta_producto { get; private set; }
        public string fch_baja_producto { get; private set; }


        //Constructor ProductoDTO completo
        public ProductosDTO(string md, string mdf, int id, string codP, string nomP, string tipoP, string desP, string fecAltaP, string fecBajaP)
        {
            md_uuid = md;
            md_fch = mdf;
            id_producto = id;
            cod_producto = codP;
            nombre_producto = nomP;
            tipo_producto_origen = tipoP;
            des_producto = desP;
            fch_alta_producto = fecAltaP;
            fch_baja_producto = fecBajaP;





        }
    }
}

