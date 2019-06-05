using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1
{
    public class ToDoesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ToDoes
        public IQueryable<ToDo> GetToDo()
        {
            return db.ToDo;
        }

        // GET: api/ToDoes/5
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult GetToDo(int id)
        {
            ToDo toDo = db.ToDo.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        // PUT: api/ToDoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToDo(int id, ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDo.Id)
            {
                return BadRequest();
            }

            db.Entry(toDo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ToDoes
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult PostToDo(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDo.Add(toDo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toDo.Id }, toDo);
        }

        // DELETE: api/ToDoes/5
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult DeleteToDo(int id)
        {
            ToDo toDo = db.ToDo.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }

            db.ToDo.Remove(toDo);
            db.SaveChanges();

            return Ok(toDo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoExists(int id)
        {
            return db.ToDo.Count(e => e.Id == id) > 0;
        }
    }
}