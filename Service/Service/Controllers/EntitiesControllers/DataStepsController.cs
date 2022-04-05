using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    [RoutePrefix("api/DataSteps")]
    public class DataStepsController : ApiController
    {
        private readonly IDataStepsService dataStepsService;

        public DataStepsController(IDataStepsService dataStepsService)
        {
            this.dataStepsService = dataStepsService;
        }

        // GET: api/DataSteps/GetDataSteps
        [Route("GetDataSteps")]
        [HttpGet]
        public IEnumerable<DataStepsWebModel> Get()
        {
            try
            {
                var dataStepsWebModel =
                    MapperHelperWeb.Mapper.Map<IEnumerable<DataStepsModel>, IEnumerable<DataStepsWebModel>>(
                        dataStepsService.Get());
                return dataStepsWebModel;
            }
            catch (ArgumentNullException ex)
            {
                return new List<DataStepsWebModel>();
            }
            catch (Exception ex)
            {
                return new List<DataStepsWebModel>();
            }
        }

        // GET: api/DataSteps/GetDataStepsById
        [Route("GetDataStepsById")]
        [HttpGet]
        public DataStepsWebModel Get(string id)
        {
            try
            {
                var dataStepsWebModel =
                    MapperHelperWeb.Mapper.Map<DataStepsModel, DataStepsWebModel>(dataStepsService.Get(Convert.ToInt32(id)));
                return dataStepsWebModel;
            }
            catch (ArgumentNullException ex)
            {
                return new DataStepsWebModel();
            }
            catch (Exception ex)
            {
                return new DataStepsWebModel();
            }
        }

        // POST: api/DataSteps/AddDataSteps
        [Route("AddDataSteps")]
        [HttpPost]
        public void Post([FromBody] DataStepsWebModel model)
        {
            try
            {
                dataStepsService.Create(MapperHelperWeb.Mapper.Map<DataStepsWebModel, DataStepsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        // PUT: api/DataSteps/UpdateDataStepsById
        [Route("UpdateDataStepsById")]
        [HttpPut]
        public void Put(int id, [FromBody] DataStepsWebModel model)
        {
            try
            {
                if (id == model.Id)
                {
                    dataStepsService.Update(MapperHelperWeb.Mapper.Map<DataStepsWebModel, DataStepsModel>(model));
                }
                else
                {
                    throw new Exception("uncorrect id");
                }
            }
            catch (ArgumentNullException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        // DELETE: api/DataSteps/DeleteDataSteps
        [Route("DeleteDataSteps")]
        [HttpDelete]
        public void Delete([FromBody] DataStepsWebModel model)
        {
            try
            {
                dataStepsService.Remove(MapperHelperWeb.Mapper.Map<DataStepsWebModel, DataStepsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }
    }
}