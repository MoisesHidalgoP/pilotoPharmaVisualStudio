using Microsoft.AspNetCore.Mvc;
using Npgsql;
using pilotoPharmaVisualStudio.Models;
using pilotoPharmaVisualStudio.Models.Conexiones;
using pilotoPharmaVisualStudio.Models.Consultas;
using pilotoPharmaVisualStudio.Models.DTOs;
using pilotoPharmaVisualStudio.Models.Util;
using System.Diagnostics;

namespace pilotoPharmaVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

            //CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;



            //Se genera una conexión a PostgreSQL y validamos que esté abierta fuera del método
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            List<ProductosDTO> listProductoDTO = new List<ProductosDTO>();
            //NpgsqlCommand consulta = new NpgsqlCommand();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);
            //Se realiza la consulta y se guarda una lista de alumnosDTO
            listProductoDTO = ConsultasPostgreSQL.ConsultaSelectPostgreSQL(conexionGenerada);
            int cont = listProductoDTO.Count();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista compuesta por: " + cont + " productos");
            foreach (ProductosDTO producto in listProductoDTO)
                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista productos: {0} {1} {2} {3} {4} {5} {6} {7} {8}", producto.md_uuid, producto.md_fch, producto.id_producto, producto.cod_producto, producto.nombre_producto, producto.tipo_producto_origen, producto.tipo_producto_clase, producto.des_producto, producto.fch_alta_producto, producto.fch_baja_producto);



            conexionGenerada.Close();

            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}