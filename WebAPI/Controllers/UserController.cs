using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        [HttpPost]
        [Route("create")]
        public ActionResult Create(User user) { 
            try
            {
                var um = new UserManager();
                um.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500,  ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var um = new UserManager();
                var listResult = um.RetrieveAll();
                return Ok(listResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        [Route("Update")]
        public ActionResult Update(User user)
        {
            try 
            {
                var um = new UserManager();
                um.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                var um = new UserManager();
                um.Delete(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }



}
