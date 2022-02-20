using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    public class AccController : ApiController
    {
        private readonly IAccService accService;

        public AccController(IAccService accService)
        {
            this.accService = accService;
        }

        // GET: api/Acc
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

        // GET: api/Acc/5
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

        // POST: api/Acc
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

        // PUT: api/Acc/5
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

        // DELETE: api/Acc/5
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