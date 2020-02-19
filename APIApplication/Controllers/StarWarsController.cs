using APIApplication.BAL;
using APIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIApplication.Controllers
{
    public class StarWarsController : ApiController
    {        

        [HttpGet]
        public IHttpActionResult GetLongestOpeningCrawlMovie()
        {
            try
            {
                var filmcharacters = StarWarService.GetLongestOpeningCrawlMovie();
                return Ok(filmcharacters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetMostCharacterInFilms()
        {
            try
            {
                var filmcharacters = StarWarService.GetMostCharacterInFilms();
                return Ok(filmcharacters);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        public IHttpActionResult GetMostSpeciesInFilms()
        {
            try
            {
                var filmcharacters = StarWarService.GetMostSpeciesInFilms();
                return Ok(filmcharacters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpGet]
        public IHttpActionResult GetLargestVehiclePiolots()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
