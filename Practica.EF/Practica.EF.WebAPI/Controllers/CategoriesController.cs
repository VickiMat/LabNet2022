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
    public class CategoriesController : ApiController
    {
        private CategoriesService _categoriesService;

        public CategoriesService CategoriesService
        {
            get 
            {
                if(_categoriesService == null)
                {
                    _categoriesService = new CategoriesService();
                }
                return _categoriesService;
            }
            set
            {
                _categoriesService = value;
            }
        }

        // GET: api/Categories
        public IHttpActionResult GetCategories()
        {
            try
            {
                var categoriesList = CategoriesService.GetCategories();
                List<CategoriesResponse> responseCat = categoriesList.Select(c => new CategoriesResponse
                {
                    ID = c.CategoryID,
                    Name = c.CategoryName,
                    Description = c.Description
                }).ToList();

                return Ok(responseCat);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //GET: api/Categories/{id}
        public IHttpActionResult GetCategoryById(int id)
        {
            try
            {
                var category = CategoriesService.GetCategoryById(id);

                var responseCat = new CategoriesResponse
                {
                    ID = category.CategoryID,
                    Name = category.CategoryName,
                    Description = category.Description
                };

                return Ok(responseCat);
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        //POST: api/Categories
        public IHttpActionResult AddCategory([FromBody]CategoriesRequest reqCat)
        {
            try
            {
                Categories category = new Categories()
                {
                    CategoryName = reqCat.Name,
                    Description = reqCat.Description
                };
                CategoriesService.AddCategory(category);
                return Content(HttpStatusCode.Created, category);
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //PUT: api/Categories
        [HttpPut]
        public IHttpActionResult UpdateCategory([FromBody] CategoriesRequest reqCat)
        {
            try
            {
                Categories category = new Categories()
                {
                    CategoryID = reqCat.ID,
                    CategoryName = reqCat.Name,
                    Description = reqCat.Description
                };
                CategoriesService.UpdateCategory(category);
                return Content(HttpStatusCode.OK, category);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //DELETE: api/Categories/{id}
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                CategoriesService.DeleteCategory(id);
                return Content(HttpStatusCode.OK,id);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}