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
using ExerciseProgram.Api.Data;

namespace ExerciseProgram.Api.Controllers
{
    public class ExerciseTypeController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        // GET: api/ExerciseType
        public IQueryable<ExerciseType> GetExerciseTypes()
        {
            return db.ExerciseTypes;
        }

        // GET: api/ExerciseType/5
        [ResponseType(typeof(ExerciseType))]
        public IHttpActionResult GetExerciseType(int id)
        {
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            return Ok(exerciseType);
        }

        // PUT: api/ExerciseType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExerciseType(int id, ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseType.ExerciseType_Pk)
            {
                return BadRequest();
            }

            db.Entry(exerciseType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseTypeExists(id))
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

        // POST: api/ExerciseType
        [ResponseType(typeof(ExerciseType))]
        public IHttpActionResult PostExerciseType(ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseTypes.Add(exerciseType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exerciseType.ExerciseType_Pk }, exerciseType);
        }

        // DELETE: api/ExerciseType/5
        [ResponseType(typeof(ExerciseType))]
        public IHttpActionResult DeleteExerciseType(int id)
        {
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            db.ExerciseTypes.Remove(exerciseType);
            db.SaveChanges();

            return Ok(exerciseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseTypeExists(int id)
        {
            return db.ExerciseTypes.Count(e => e.ExerciseType_Pk == id) > 0;
        }
    }
}