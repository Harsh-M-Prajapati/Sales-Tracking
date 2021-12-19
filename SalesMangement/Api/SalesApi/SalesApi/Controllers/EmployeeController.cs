using BusinessLayer;
using DataAccessLayer.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SalesApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private UserBL db = new UserBL();

        [HttpPost]
        [Route("api/employee/register")]
        public IHttpActionResult PostUser(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMessage response = new RespMessage();
                response.Message = db.AddEmployee(emp);
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("api/employee/login/{email}/{password}")]
        public IHttpActionResult login(string email, string password)
        {
            RespLogin response = new RespLogin();

            Employee emp = db.login(email, password);
            if (emp != null)
            {
                response.UserID = emp.EmployeeID.ToString();
                response.EmailID = emp.EmailID;
                response.Message = "Login successful";
                response.Token = generateToken();
            }
            else
            {
                response.UserID = "0";
                response.EmailID = "";
                response.Message = "Invalid email id or password";
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("api/employee/GetProducts")]
        public List<Product> GetProducts()
        {
            return db.GetProducts();
        }

        [Authorize]
        [HttpPost]
        [Route("api/employee/addOrder")]
        public IHttpActionResult addOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMessage response = new RespMessage();
                response.Message = db.AddOrder(order);
                return Ok(response);
            }
        }

        public string generateToken()
        {
            string securityKey = "0948129dsajsbdiqdbp";

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signInCred = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    issuer: "abcd@domain.in",
                    audience: "Users",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signInCred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
