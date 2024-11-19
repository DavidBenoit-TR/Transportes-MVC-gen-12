using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transportes_MVC_gen_12.Models;

namespace Transportes_MVC_gen_12.Controllers
{
    public class CamionesController : Controller
    {
        // GET: Camiones
        //Listado de Camiones
        public ActionResult Index()
        {
            //creo una lista de camiones del modelo Original
            List<Camiones> lista_camiones = new List<Camiones>();
            //lleno la lista con elemtnos existentes dentro del contexto(DB) utilizando EF y LinQ
            using (TransportesEntities context = new TransportesEntities())
            {
                //llenos mi lista directamente usando LinQ
                lista_camiones = (from camion in context.Camiones select camion).ToList();
                ////otra forma de hacer lo miso es
                //lista_camiones = context.Camiones.ToList();
                ////otra forma de hacer lo mismo
                //foreach (Camiones cam in context.Camiones)
                //{
                //    lista_camiones.Add(cam);
                //}
            }

            //ViewBag (forma parte de Razor) se caracteriza por hacer uso de una propiedad arbitraria que sirve para pasar información desde el controlador a la vista
            ViewBag.Titulo = "Lista de Camiones";
            ViewBag.Subtitulo = "Utilizando ASP.NET MVC";

            //ViewData se caracterizaz por hacer uso de un atributo arbitrario y tiene el mismo funcionamiento que el ViewBag
            ViewData["Titulo2"] = "Segundo Título";

            //TempData se cracteriza por permitir crear variables temporales que existen durante la ejecución del Runtime de ASP
            //además, los temdata me permite compartir información nos solo del controlodaor a la vista, sino también entre otras vistas y otros controladores
            //TempData.Add("Clave", "Valor");

            //retorno la vista con los datos del modelo
            return View(lista_camiones);
        }

        //GET: Nuevo_Camion
        public ActionResult Nuevo_Camion()
        {
            ViewBag.Titulo = "Nuevo Camión";
            //cargar DLL con las opciones del tipo de camión
            cargarDDL();
            return View();
        }

        //POST: Nuevo_Camion
        [HttpPost]
        public ActionResult Nuevo_Camion(Camiones_DTO model, HttpPostedFileBase imagen)
        {
            try
            {
                if (ModelState.IsValid) //Verificar si los campos y los tipos de datos corresponden al Modelo (DTO)
                {
                    using (TransportesEntities context = new TransportesEntities()) //creo una unstancia de un solo uso de mi contexto
                    {
                        //creo un objeto basado en el contexto (Modelo Original)
                        var camion = new Camiones();

                        //asigno todos los valores del modelo de entrada (DTO) el objeto que será insertado en la BD (modelo original)
                        camion.Matricula = model.Matricula;
                        camion.Marca = model.Marca;
                        camion.Modelo = model.Modelo;
                        camion.Capacidad = model.Capacidad;
                        camion.Kilometraje = model.Kilometraje;
                        camion.Disponibilidad = model.Disponibilidad;
                        camion.Tipo_Camion = model.Tipo_Camion;

                        //valido si existe una IMG o no
                        if (imagen != null && imagen.ContentLength > 0)
                        {
                            string filename = Path.GetFileName(imagen.FileName); //recupero el nombre de mi archivo
                            string pathdir = Server.MapPath("~/Assets/Imagenes/Camiones/"); //mapeo la ruta donde guardaré mis imágenes en el servidor
                            if (!Directory.Exists(pathdir)) //si no existe el directorio, lo creo
                            {
                                Directory.CreateDirectory(pathdir);
                            }
                            imagen.SaveAs(pathdir + filename); //guardo la imagen en el servidor
                            camion.UrlFoto = "/Assets/Imagenes/Camiones/" + filename; //guardo la ruta y el nombre del archivo en el camión que voy a insertar

                            //Impacto sobre la BD usando EF
                            context.Camiones.Add(camion); //Agrego un nuevo caión al contexto
                            context.SaveChanges(); //impactar la base de datos (enviár los cambios entre el contexto y la BD)
                            //Sweet Alert
                            return RedirectToAction("Index"); //finalmente, regreso al listado si es que todo salió bien
                        }
                        else
                        {
                            //sweet alert
                            cargarDDL();
                            return View(model);
                        }
                    }
                }
                else
                {
                    //En caso de que ocurra alguna exepción, voy a mostrar un msj con el error, voy a volver a cargar la lista de opciones del tipo_camion (cargarDDL) par que no marque error el formulario, y devulveré la misma vista con los mismos datos que me han sido enviado (vas pa' tras)
                    //Sweet Alert
                    cargarDDL();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                //En caso de que ocurra alguna exepción, voy a mostrar un msj con el error, voy a volver a cargar la lista de opciones del tipo_camion (cargarDDL) par que no marque error el formulario, y devulveré la misma vista con los mismos datos que me han sido enviado (vas pa' tras)
                //Sweet Alert
                cargarDDL();
                return View(model);
            }
        }

        #region Auxiliares
        private class Opciones
        {
            public string Numero { get; set; }
            public string Descripcion { get; set; }
        }

        public void cargarDDL()
        {
            List<Opciones> lista_opciones = new List<Opciones>() {
                new Opciones() {Numero = "0", Descripcion="Seleccione una opción"},
                new Opciones() {Numero = "1", Descripcion="Volteo"},
                new Opciones() {Numero = "2", Descripcion="Redilas"},
                new Opciones() {Numero = "3", Descripcion="Transporte"}
            };

            ViewBag.ListaTipos = lista_opciones;
        }
        #endregion
    }
}