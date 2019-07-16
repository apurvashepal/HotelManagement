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
using WebService.Models;

namespace WebService.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET api/Employee
        [ResponseType(typeof(IEnumerable<EmployeeDet>))]
        [Route("api/GetEmployeeDets")]
        public IQueryable<EmployeeDet> GetEmployeeDets()
        {
            List <EmployeeDet> emp = new List<EmployeeDet>();

            return db.EmployeeDets;
        }

        // GET api/Employee/5
        [ResponseType(typeof(EmployeeDet))]
        [Route ("api/GetEmployeeDet")]
        public IHttpActionResult GetEmployeeDet(int id)
        {
            EmployeeDet employeedet = db.EmployeeDets.Find(id);
            if (employeedet == null)
            {
                return NotFound();
            }

            return Ok(employeedet);
        }

        // PUT api/Employee/5
        [ResponseType(typeof(EmployeeDet))]
        [Route("api/putEmployeeDet")]
        public IHttpActionResult PutEmployeeDet(int id, EmployeeDet employeedet)
        {
            EmployeeDet employeedet1 = db.EmployeeDets.Find(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeedet1.Id)
            {
                return BadRequest();
            }

            db.Entry(employeedet1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetExists(id))
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

        // POST api/Employee
        [ResponseType(typeof(EmployeeDet))]
       
        [Route("api/PostEmployeeDet")]
        public IHttpActionResult PostEmployeeDet(EmployeeDet employeedet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDets.Add(employeedet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetExists(employeedet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeedet.Id }, employeedet);
        }

        // DELETE api/Employee/5
        [ResponseType(typeof(EmployeeDet))]
      
        [Route("api/DeleteEmployeeDet")]
        public IHttpActionResult DeleteEmployeeDet(int id)
        {
            EmployeeDet employeedet = db.EmployeeDets.Find(id);
            if (employeedet == null)
            {
                return NotFound();
            }

            db.EmployeeDets.Remove(employeedet);
            db.SaveChanges();

            return Ok(employeedet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetExists(int id)
        {
            return db.EmployeeDets.Count(e => e.Id == id) > 0;
        }
    }
}