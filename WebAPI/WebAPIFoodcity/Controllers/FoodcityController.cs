using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIFoodcity.Models;

namespace WebAPIFoodcity.Controllers
{
    public class FoodcityController : ApiController
    {
        [Route("api/FoodcityController/Restaurant")]
        [HttpGet]
        public IHttpActionResult getRestaurant()
        {
            try
            {
                DataTable tb = Database.getRestaurant();
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/Restaurant/id")]
        [HttpGet]
        public IHttpActionResult getRestaurant(string id)
        {
            try
            {
                Restaurant tb = Database.getRestaurant(id);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/Advertisement")]
        [HttpGet]
        public IHttpActionResult getAdvertisement()
        {
            try
            {
                DataTable tb = Database.getAdvertisement();
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/Food")]
        [HttpGet]
        public IHttpActionResult getFood()
        {
            try
            {
                DataTable tb = Database.getFood();
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/Food/ResId")]
        [HttpGet]
        public IHttpActionResult getFoodId(string id)
        {
            try
            {
                DataTable tb = Database.getFoodByResId(id);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/Food/type")]
        [HttpGet]
        public IHttpActionResult getFoodtype(int id)
        {
            try
            {
                DataTable tb = Database.getFoodtype(id);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/Food/text")]
        [HttpGet]
        public IHttpActionResult getFoodText(string text)
        {
            try
            {
                DataTable tb = Database.getFoodText(text);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/Review/ResId")]
        [HttpGet]
        public IHttpActionResult getReviewId(string id)
        {
            try
            {
                DataTable tb = Database.getReviewByResId(id);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/DangNhap")]
        [HttpGet]
        public IHttpActionResult getUser(string id, string code)
        {
            try
            {
                User user = Database.getUser(id, code);
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodcityController/AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            try
            {
                User kq = Database.AddUser(user);
                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}