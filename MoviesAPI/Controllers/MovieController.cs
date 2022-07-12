using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            using (TopContext db = new TopContext())
            {
                var movieList = (from m in db.Movies
                                 select m).ToList();

                return movieList;
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            using (TopContext db = new TopContext())
            {
                var movie = (from m in db.Movies
                             where m.Id == id
                             select m).FirstOrDefault();

                return movie;
            }

        }

        [HttpPost]
        public string Post([FromBody] Models.Request.MovieRequest value)
        {
            using (TopContext db = new TopContext())
            {
                
                Movie oMovie = new Movie();
                oMovie.Name = value.Name;
                oMovie.Genre = value.Genre;
                oMovie.Year = value.Year;
                oMovie.Rating = value.Rating;
                db.Movies.Add(oMovie);
                db.SaveChanges();

            }
            return "Movie Saved Successfully";
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Models.Request.MovieEditRequest value)
        {
            using (TopContext db = new TopContext())
            {

                Movie oMovie = db.Movies.Find(id);
                oMovie.Name = value.Name;
                oMovie.Genre = value.Genre;
                oMovie.Year = value.Year;
                oMovie.Rating = value.Rating;
                db.Entry(oMovie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return "Movie Updated Successfully";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            using (TopContext db = new TopContext())
            {

                Movie oMovie = db.Movies.Find(id);
                db.Movies.Remove(oMovie);
                db.SaveChanges();

            }
            return "Movie Deleted Successfully";
        }

    }
}
