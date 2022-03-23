using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    [RoutePrefix("api/Acc")]
    public class AccController : ApiController
    {
        private readonly IAccService accService;

        public AccController(IAccService accService)
        {
            this.accService = accService;
        }

        // GET: api/Acc/GetAcc
        [Route("GetAcc")]
        [HttpGet]
        public IEnumerable<AccWebModel> Get()
        {
            try
            {
                var accWebModel =
                    MapperHelperWeb.Mapper.Map<IEnumerable<AccModel>, IEnumerable<AccWebModel>>(accService.Get());
                return accWebModel;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // GET: api/Acc/GetAccById
        [Route("GetAccById")]
        [HttpGet]
        public AccWebModel Get(int id)
        {
            try
            {
                var accWebModel = MapperHelperWeb.Mapper.Map<AccModel, AccWebModel>(accService.Get(id));
                return accWebModel;
            }
            catch (ArgumentNullException ex)
            {
                return new AccWebModel();
            }
        }

        // POST: api/Acc/AddAcc
        [Route("AddAcc")]
        [HttpPost]
        public void Post([FromBody] AccWebModel model)
        {
            try
            {
                accService.Create(MapperHelperWeb.Mapper.Map<AccWebModel, AccModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // PUT: api/Acc/UpdateAccById
        [Route("UpdateAccById")]
        [HttpPut]
        public void Put(int id, [FromBody] AccWebModel model)
        {
            try
            {
                if (id == model.Id)
                {
                    accService.Update(MapperHelperWeb.Mapper.Map<AccWebModel, AccModel>(model));
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("uncorrect id");
            }
        }

        // DELETE: api/Acc/DeleteAcc
        [Route("DeleteAcc")]
        [HttpDelete]
        public void Delete(AccWebModel model)
        {
            try
            {
                accService.Remove(MapperHelperWeb.Mapper.Map<AccWebModel, AccModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }
    }
}