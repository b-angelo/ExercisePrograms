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
    public class ExerciseProgramController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        // GET: api/ExerciseProgram
        public IQueryable<Data.ExerciseProgram> GetExercisePrograms()
        {
            return db.ExercisePrograms;
        }

        // GET: api/ExerciseProgram/5
        [ResponseType(typeof(Data.ExerciseProgram))]
        public IHttpActionResult GetExerciseProgram(int id)
        {
            Data.ExerciseProgram exerciseProgram = db.ExercisePrograms.Find(id);
            if (exerciseProgram == null)
            {
                return NotFound();
            }

            return Ok(exerciseProgram);
        }

        // PUT: api/ExerciseProgram/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExerciseProgram(int id, Data.ExerciseProgram exerciseProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseProgram.ExerciseProgram_Pk)
            {
                return BadRequest();
            }

            db.Entry(exerciseProgram).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseProgramExists(id))
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

        // POST: api/ExerciseProgram
        [ResponseType(typeof(Data.ExerciseProgram))]
        public IHttpActionResult PostExerciseProgram(Data.ExerciseProgram exerciseProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExercisePrograms.Add(exerciseProgram);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exerciseProgram.ExerciseProgram_Pk }, exerciseProgram);
        }

        // DELETE: api/ExerciseProgram/5
        [ResponseType(typeof(Data.ExerciseProgram))]
        public IHttpActionResult DeleteExerciseProgram(int id)
        {
            Data.ExerciseProgram exerciseProgram = db.ExercisePrograms.Find(id);
            if (exerciseProgram == null)
            {
                return NotFound();
            }

            db.ExercisePrograms.Remove(exerciseProgram);
            db.SaveChanges();

            return Ok(exerciseProgram);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseProgramExists(int id)
        {
            return db.ExercisePrograms.Count(e => e.ExerciseProgram_Pk == id) > 0;
        }
    }
}