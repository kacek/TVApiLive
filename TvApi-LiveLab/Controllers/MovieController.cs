using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TvApi_LiveLab.Models;

namespace TvApi_LiveLab.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            return Ok(getMovies());
        }

        [HttpPost, Route("movies")]
        public IHttpActionResult AddMovie([FromBody]Movie movie)
        {
            //add to db
            return Ok(movie);
        }

        public List<Movie> getMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Author = "Jasio stasio",
                    Title = "Super film",
                    Comments = new List<string> { "Super", "Cool" }
                },
                new Movie
                {
                    Id = 2,
                    Author = "xxx yyy",
                    Title = "XXX YYY",
                    Comments = new List<string>()
                }
            };
            return movies;
        }
        [HttpGet, Route("movies/{id:int}")]
        public IHttpActionResult GetMovieByID(int id)
        {
            List<Movie> movies = getMovies();
            Movie movie = movies.Where(m => m.Id == id).SingleOrDefault();
            if(movie == null)
            {
                return NotFound();
            }else
            {
                return Ok(movie);
            }
        }

        [HttpDelete, Route("movies/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            List<Movie> movies = getMovies();
            var movie = movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return BadRequest();
            }else
            {
                movies.Remove(movie);
                return Ok();
            }
        }
    }
}
