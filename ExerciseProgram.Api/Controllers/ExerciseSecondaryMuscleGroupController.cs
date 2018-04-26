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
    public class ExerciseSecondaryMuscleGroupController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        // GET: api/ExerciseSecondaryMuscleGroup
        public IQueryable<ExerciseSecondaryMuscleGroup> GetExerciseSecondaryMuscleGroups()
        {
            return db.ExerciseSecondaryMuscleGroups;
        }

        // GET: api/ExerciseSecondaryMuscleGroup/5
        [ResponseType(typeof(ExerciseSecondaryMuscleGroup))]
        public IHttpActionResult GetExerciseSecondaryMuscleGroup(int id)
        {
            ExerciseSecondaryMuscleGroup exerciseSecondaryMuscleGroup = db.ExerciseSecondaryMuscleGroups.Find(id);
            if (exerciseSecondaryMuscleGroup == null)
            {
                return NotFound();
            }

            return Ok(exerciseSecondaryMuscleGroup);
        }

        // PUT: api/ExerciseSecondaryMuscleGroup/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExerciseSecondaryMuscleGroup(int id, ExerciseSecondaryMuscleGroup exerciseSecondaryMuscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseSecondaryMuscleGroup.ExerciseSecondaryMuscleGroup_Pk)
            {
                return BadRequest();
            }

            db.Entry(exerciseSecondaryMuscleGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseSecondaryMuscleGroupExists(id))
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

        // POST: api/ExerciseSecondaryMuscleGroup
        [ResponseType(typeof(ExerciseSecondaryMuscleGroup))]
        public IHttpActionResult PostExerciseSecondaryMuscleGroup(ExerciseSecondaryMuscleGroup exerciseSecondaryMuscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseSecondaryMuscleGroups.Add(exerciseSecondaryMuscleGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exerciseSecondaryMuscleGroup.ExerciseSecondaryMuscleGroup_Pk }, exerciseSecondaryMuscleGroup);
        }

        // DELETE: api/ExerciseSecondaryMuscleGroup/5
        [ResponseType(typeof(ExerciseSecondaryMuscleGroup))]
        public IHttpActionResult DeleteExerciseSecondaryMuscleGroup(int id)
        {
            ExerciseSecondaryMuscleGroup exerciseSecondaryMuscleGroup = db.ExerciseSecondaryMuscleGroups.Find(id);
            if (exerciseSecondaryMuscleGroup == null)
            {
                return NotFound();
            }

            db.ExerciseSecondaryMuscleGroups.Remove(exerciseSecondaryMuscleGroup);
            db.SaveChanges();

            return Ok(exerciseSecondaryMuscleGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseSecondaryMuscleGroupExists(int id)
        {
            return db.ExerciseSecondaryMuscleGroups.Count(e => e.ExerciseSecondaryMuscleGroup_Pk == id) > 0;
        }
    }
}