using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    public class DataStepsController : ApiController
    {
        private readonly IDataStepsService dataStepsService;

        public DataStepsController(IDataStepsService dataStepsService)
        {
            this.dataStepsService = dataStepsService;
        }

        // GET: api/DataSteps
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
                throw ex;
            }
        }

        // GET: api/DataSteps/5
        public DataStepsWebModel Get(int id)
        {
            try
            {
                var dataStepsWebModel =
                    MapperHelperWeb.Mapper.Map<DataStepsModel, DataStepsWebModel>(dataStepsService.Get(id));
                return dataStepsWebModel;
            }
            catch (ArgumentNullException ex)
            {
                return new DataStepsWebModel();
            }
        }

        // POST: api/DataSteps
        public void Post([FromBody] DataStepsWebModel model)
        {
            try
            {
                dataStepsService.Create(MapperHelperWeb.Mapper.Map<DataStepsWebModel, DataStepsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // PUT: api/DataSteps/5
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
                throw ex;
            }
        }

        // DELETE: api/DataSteps/5
        public void Delete(DataStepsWebModel model)
        {
            try
            {
                dataStepsService.Remove(MapperHelperWeb.Mapper.Map<DataStepsWebModel, DataStepsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }
    }
}