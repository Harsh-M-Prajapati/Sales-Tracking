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
    public class AdminController : ApiController
    {
        private AdminBL db = new AdminBL();

        [HttpGet]
        [Route("api/admin/login/{username}/{password}")]
        public IHttpActionResult login(string username, string password)
        {
            RespLogin response = new RespLogin();

            Admin a = db.login(username, password);
            if (a != null)
            {
                response.UserID = a.AdminID.ToString();
                response.EmailID = a.EmailID;
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
        [Route("api/admin/GetOrderDetails")]
        public List<OrderDetails> GetOrderDetails()
        {
            return db.GetOrders();
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
