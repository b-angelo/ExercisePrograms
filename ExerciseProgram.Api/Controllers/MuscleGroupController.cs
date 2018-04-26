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
    public class MuscleGroupController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        // GET: api/MuscleGroup
        public IQueryable<MuscleGroup> GetMuscleGroups()
        {
            return db.MuscleGroups;
        }

        // GET: api/MuscleGroup/5
        [ResponseType(typeof(MuscleGroup))]
        public IHttpActionResult GetMuscleGroup(int id)
        {
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            return Ok(muscleGroup);
        }

        // PUT: api/MuscleGroup/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMuscleGroup(int id, MuscleGroup muscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muscleGroup.MuscleGroup_Pk)
            {
                return BadRequest();
            }

            db.Entry(muscleGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuscleGroupExists(id))
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

        // POST: api/MuscleGroup
        [ResponseType(typeof(MuscleGroup))]
        public IHttpActionResult PostMuscleGroup(MuscleGroup muscleGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MuscleGroups.Add(muscleGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = muscleGroup.MuscleGroup_Pk }, muscleGroup);
        }

        // DELETE: api/MuscleGroup/5
        [ResponseType(typeof(MuscleGroup))]
        public IHttpActionResult DeleteMuscleGroup(int id)
        {
            MuscleGroup muscleGroup = db.MuscleGroups.Find(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            db.MuscleGroups.Remove(muscleGroup);
            db.SaveChanges();

            return Ok(muscleGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MuscleGroupExists(int id)
        {
            return db.MuscleGroups.Count(e => e.MuscleGroup_Pk == id) > 0;
        }
    }
}