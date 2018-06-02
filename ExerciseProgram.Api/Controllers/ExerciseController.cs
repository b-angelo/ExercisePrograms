using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.ViewModels;

namespace ExerciseProgram.Api.Controllers
{
    public class ExerciseController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();
        private ExerciseService _exerciseService = new ExerciseService();

        [HttpGet]
        [Route("api/Exercise/")]
        public List<ExerciseViewModel> GetAllExercises()
        {
            return _exerciseService.GetExercises();
        }

        [HttpGet]
        [Route("api/Exercise/{muscleGroupName}")]
        public List<ExerciseViewModel> GetAllExercisesByMuscleGroup([FromUri] string muscleGroupName)
        {
            return _exerciseService.GetExercises(muscleGroupName);
        }

        // GET: api/Exercise/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult GetExercise(int id)
        {
            var exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercise/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise(int id, Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.Exercise_Pk)
            {
                return BadRequest();
            }

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercise
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult PostExercise(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercises.Add(exercise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercise.Exercise_Pk }, exercise);
        }

        // DELETE: api/Exercise/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult DeleteExercise(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercise);
            db.SaveChanges();

            return Ok(exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseExists(int id)
        {
            return db.Exercises.Count(e => e.Exercise_Pk == id) > 0;
        }
    }
}