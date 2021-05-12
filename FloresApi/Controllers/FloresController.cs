using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FloresApi.Models;

namespace FloresApi.Controllers
{
    public class FloresController : ApiController
    {
        //GET - obtener datos
        public IHttpActionResult GetAllFlores()
        {
            IList<FloresViewModel> flores = null;
            using (var x = new ApifloresEntities())
            {
                flores = x.datosflores
                .Select(c => new FloresViewModel()
                {
                    Nombre = c.nombre,
                    Color = c.color,
                    Relleno = c.relleno,
                    Paqueteagranel = c.paqueteagranel,
                    Longituddeltallo = c.longituddeltallo,
                    Talloracimo = c.talloracimo,
                    Comentarios = c.comentarios

                }).ToList<FloresViewModel>();
            }

            if (flores.Count == 0)
                return NotFound();
            return Ok(flores);
        }

        //POST -  insertar

        public IHttpActionResult PostNewFlores(FloresViewModel flor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos invalidos");

            using (var x = new ApifloresEntities())
            {
                //asignamos lo del modelo a la base de datos
                x.datosflores.Add(new datosflores()
                { 
                    nombre = flor.Nombre,
                    color = flor.Color,
                    relleno = flor.Relleno,
                    paqueteagranel = flor.Paqueteagranel,
                    longituddeltallo = flor.Longituddeltallo,
                    talloracimo = flor.Talloracimo,
                    comentarios = flor.Comentarios

                });

                x.SaveChanges();
            }

            return Ok();
        }

        //PUT - actualizar datos

        public IHttpActionResult PutFlores(FloresViewModel flor)
        {
            if (!ModelState.IsValid)
                return BadRequest("modelo invalido revise ");

            using (var x = new ApifloresEntities())
            {
                var checkExistingFlor = x.datosflores.Where(c => c.id == flor.Id)
                    .FirstOrDefault<datosflores>();
                if (checkExistingFlor != null)
                {
                    checkExistingFlor.nombre = flor.Nombre;
                    checkExistingFlor.color = flor.Color;
                    checkExistingFlor.relleno = flor.Relleno;
                    checkExistingFlor.paqueteagranel = flor.Paqueteagranel;
                    checkExistingFlor.longituddeltallo = flor.Longituddeltallo;
                    checkExistingFlor.talloracimo = flor.Talloracimo;
                    checkExistingFlor.comentarios = flor.Comentarios;

                    x.SaveChanges();
                }
                else
                    return NotFound();
            }

            return Ok();
        }
        //DELETE - eliminar 

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("por favor entre un Id de flor valido");
            using(var x = new ApifloresEntities())
            {
                var flor = x.datosflores
                    .Where(c => c.id == id)
                    .FirstOrDefault();

                x.Entry(flor).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }

            return Ok();
        }
    }
}