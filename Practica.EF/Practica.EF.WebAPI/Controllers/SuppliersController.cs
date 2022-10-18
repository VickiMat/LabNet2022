using Common.Exceptions;
using Practica.EF.Entities;
using Practica.EF.Service;
using Practica.EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Practica.EF.WebAPI.Controllers
{
    public class SuppliersController : ApiController
    {
        private SuppliersService _supService;

        public SuppliersService SupService
        {
            get
            {
                if(_supService == null)
                {
                    _supService = new SuppliersService();
                }
                return _supService;
            }
        }

        // GET: api/Suppliers
        public IHttpActionResult GetSuppliers()
        {
            try
            {
                var supList = SupService.GetSuppliers();

                List<SuppliersResponse> respSup = supList.Select(s => new SuppliersResponse
                {
                    Id = s.SupplierID,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    City = s.City,
                    Country = s.Country
                }).ToList();

                return Ok(respSup);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Something went wrong, contact with technical support.");
            }
        }

        //GET: api/Suppliers/{id}
        public IHttpActionResult GetSupplierById(int id)
        {
            try
            {
                var sup = SupService.GetSuppliersById(id);

                var respSup = new SuppliersResponse
                {
                    Id = sup.SupplierID,
                    CompanyName = sup.CompanyName,
                    ContactName = sup.ContactName,
                    City = sup.City,
                    Country = sup.Country
                };
                return Ok(respSup);
            }
            catch (NotFoundIDException)
            {
                return Content(HttpStatusCode.NotFound, "The id doesn´t exists");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, "Something went wrong, contact with technical support.");
            }
        }

        //GET: api/Suppliers/{city}
        public IHttpActionResult GetSuppliersByCity(string city)
        {
            try
            {
                var sup = SupService.GetSuppliersByCity(city);

                List<SuppliersResponse> respSup = sup.Select(s => new SuppliersResponse
                {
                    Id = s.SupplierID,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    City = s.City,
                    Country = s.Country
                }).ToList();

                return Ok(respSup);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Something went wrong, contact with technical support.");
            }
        }

        //POST: api/Suppliers
        public IHttpActionResult AddSupplier([FromBody] SuppliersRequest reqSup)
        {
            try
            {
                Suppliers sup = new Suppliers
                {
                    CompanyName = reqSup.CompanyName,
                    ContactName = reqSup.ContactName,
                    City = reqSup.City,
                    Country = reqSup.Country
                };

                SupService.AddSupplier(sup);
                return Content(HttpStatusCode.Created, $"Supplier: {sup.CompanyName}, was added with id {sup.SupplierID}");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Something went wrong, contact with technical support.");
            }
        }

        //PUT: api/Suppliers
        [HttpPut]
        public IHttpActionResult UpdateSupplier([FromBody] SuppliersRequest reqSup)
        {
            try
            {
                Suppliers sup = new Suppliers
                {
                    SupplierID = reqSup.Id,
                    CompanyName = reqSup.CompanyName,
                    ContactName = reqSup.ContactName,
                    City = reqSup.City,
                    Country = reqSup.Country
                };

                SupService.UpdateSupplier(sup);
                return Content(HttpStatusCode.OK, $"Supplier: {sup.CompanyName}, with id {sup.SupplierID} was succesfully updated");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Something went wrong, contact with technical support.");
            }
        }

        //DELETE: api/Suppliers/{id}
        public IHttpActionResult DeleteSupplier(int id)
        {
            try
            {
                SupService.DeleteSupplier(id);
                return Content(HttpStatusCode.OK, $"Supplier with id {id} was succesfully deleted");
            }
            catch(NotFoundIDException nex)
            {
                return Content(HttpStatusCode.NotFound, nex.Message);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Something went wrong, contact with technical support.");
            }
        }
    }
}