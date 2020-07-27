using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;
using WebAPI.Repositorio;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private UsersRepositorio _repositorio;
        private static List<Users> users = new List<Users>();

        /*[HttpGet]
        public List<Users> Get()
        {
              return users;
        }*/

        /*
        public void Post(string name, string cpf, string rg, DateTime birthday, string motherName, string fatherName, DateTime checkinDate)
        {
            
            //if (!string.IsNullOrEmpty(name, cpf, rg, birthday, motherName, fatherName, checkinDate))
            users.Add(new Users(name, cpf, rg, birthday, motherName, fatherName, checkinDate));
        }
        */

        public IHttpActionResult Delete(string cpf, string rg)
        {
            try
            {
                _repositorio = new UsersRepositorio();
                if (_repositorio.DeleteUser(cpf, rg))
                {
                    
                }

                
            }
            catch(Exception)
            {
                
            }
            return Ok();
            //Remove the first with name indicated
            //users.RemoveAt(users.IndexOf(users.First(x => x.uName.Equals(name))));

        }


        //GET: api/Users/321
        [HttpGet]
        public IHttpActionResult SearchUser(string name)
        {
            _repositorio = new UsersRepositorio();

            ModelState.Clear();  

            
            try
            {
                return Ok(_repositorio.SearchUser(name));
            }
            catch (Exception)
            {
                /*List<Users> u = _repositorio.SearchUser(name);
            if (u.Count == 0)
            {
                u = null;                
                return NotFound();
            }*/
                throw;
            }
            
        }

        
        //GET: api/Users/5
       public string Get()
        {
            return "Euclides";
        }


        //public IHttpActionResult InsertUser([FromBody] Users u)
        [HttpPost]
        public IHttpActionResult InsertUser(string name, string cpf, string rg, DateTime birthday, string motherName, string fatherName, DateTime checkinDate)
        {
            Users u = new Users(name, cpf, rg, birthday, motherName, fatherName, checkinDate);
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new UsersRepositorio();
                    

                    if (_repositorio.InsertUser(u))
                    {
                        
                    }
                }
                
            }
            catch(Exception)
            {
            
            }
            return Ok();
        }
        
    }
}
