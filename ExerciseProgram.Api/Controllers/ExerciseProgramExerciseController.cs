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
    public class ExerciseProgramExerciseController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        // GET: api/ExerciseProgramExercise
        public IQueryable<ExerciseProgramExercise> GetExerciseProgramExercises()
        {
            return db.ExerciseProgramExercises;
        }

        // GET: api/ExerciseProgramExercise/5
        [ResponseType(typeof(ExerciseProgramExercise))]
        public IHttpActionResult GetExerciseProgramExercise(int id)
        {
            ExerciseProgramExercise exerciseProgramExercise = db.ExerciseProgramExercises.Find(id);
            if (exerciseProgramExercise == null)
            {
                return NotFound();
            }

            return Ok(exerciseProgramExercise);
        }

        // PUT: api/ExerciseProgramExercise/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExerciseProgramExercise(int id, ExerciseProgramExercise exerciseProgramExercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseProgramExercise.ExerciseProgramExercise_Pk)
            {
                return BadRequest();
            }

            db.Entry(exerciseProgramExercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseProgramExerciseExists(id))
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

        // POST: api/ExerciseProgramExercise
        [ResponseType(typeof(ExerciseProgramExercise))]
        public IHttpActionResult PostExerciseProgramExercise(ExerciseProgramExercise exerciseProgramExercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseProgramExercises.Add(exerciseProgramExercise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exerciseProgramExercise.ExerciseProgramExercise_Pk }, exerciseProgramExercise);
        }

        // DELETE: api/ExerciseProgramExercise/5
        [ResponseType(typeof(ExerciseProgramExercise))]
        public IHttpActionResult DeleteExerciseProgramExercise(int id)
        {
            ExerciseProgramExercise exerciseProgramExercise = db.ExerciseProgramExercises.Find(id);
            if (exerciseProgramExercise == null)
            {
                return NotFound();
            }

            db.ExerciseProgramExercises.Remove(exerciseProgramExercise);
            db.SaveChanges();

            return Ok(exerciseProgramExercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseProgramExerciseExists(int id)
        {
            return db.ExerciseProgramExercises.Count(e => e.ExerciseProgramExercise_Pk == id) > 0;
        }
    }
}