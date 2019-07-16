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
using WebApp.Models;

namespace WebService.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET api/Employee
        [ResponseType(typeof(IEnumerable<EmployeeDetail>))]
        [Route("api/GetEmployeeDets")]
        public IQueryable<EmployeeDetail> GetEmployeeDets()
        {
            List<EmployeeDetail> emp = new List<EmployeeDetail>();

            return db.EmployeeDetails;
        }

        // GET api/Employee/5
        [ResponseType(typeof(EmployeeDetail))]
        [Route("api/GetEmployeeDet")]
        public IHttpActionResult GetEmployeeDet(int id)
        {
            EmployeeDetail EmployeeDetail = db.EmployeeDetails.Find(id);
            if (EmployeeDetail == null)
            {
                return NotFound();
            }

            return Ok(EmployeeDetail);
        }

        // PUT api/Employee/5
        [ResponseType(typeof(EmployeeDetail))]
        [Route("api/PutEmployeeDet")]
        public IHttpActionResult PutEmployeeDet(int id, EmployeeDetail EmployeeDetail)
        {
            EmployeeDetail employeedet1 = db.EmployeeDetails.Find(id);
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
        [ResponseType(typeof(EmployeeDetail))]

        [Route("api/PostEmployeeDet")]
        public IHttpActionResult PostEmployeeDet(EmployeeDetail EmployeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDetails.Add(EmployeeDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetExists(EmployeeDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = EmployeeDetail.Id }, EmployeeDetail);
        }

        // DELETE api/Employee/5
        [ResponseType(typeof(EmployeeDetail))]

        [Route("api/DeleteEmployeeDet")]
        public IHttpActionResult DeleteEmployeeDet(int id)
        {
            EmployeeDetail EmployeeDetail = db.EmployeeDetails.Find(id);
            if (EmployeeDetail == null)
            {
                return NotFound();
            }

            db.EmployeeDetails.Remove(EmployeeDetail);
            db.SaveChanges();

            return Ok(EmployeeDetail);
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
            return db.EmployeeDetails.Count(e => e.Id == id) > 0;
        }
    }
}