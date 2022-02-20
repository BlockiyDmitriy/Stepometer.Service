using Service.BLL.Models;
using Service.BLL.Services.Contract;
using Service.Extensions;
using Service.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers.EntitiesControllers
{
    public class FriendsController : ApiController
    {
        private readonly IFriendsService friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            this.friendsService = friendsService;
        }


        // GET: api/Friends
        public IEnumerable<FriendsWebModel> Get()
        {
            try
            {
                var friendsWebModel =
                    MapperHelperWeb.Mapper.Map<IEnumerable<FriendsModel>, IEnumerable<FriendsWebModel>>(
                        friendsService.Get());
                return friendsWebModel;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // GET: api/Friends/5
        public FriendsWebModel Get(int id)
        {
            try
            {
                var friendsWebModel = MapperHelperWeb.Mapper.Map<FriendsModel, FriendsWebModel>(friendsService.Get(id));
                return friendsWebModel;
            }
            catch (ArgumentNullException)
            {
                return new FriendsWebModel();
            }
        }

        // POST: api/Friends
        public void Post([FromBody] FriendsWebModel model)
        {
            try
            {
                friendsService.Create(MapperHelperWeb.Mapper.Map<FriendsWebModel, FriendsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        // PUT: api/Friends/5
        public void Put(int id, [FromBody] FriendsWebModel model)
        {
            try
            {
                if (id == model.Acc1.Id || id == model.Acc2.Id)
                {
                    friendsService.Update(MapperHelperWeb.Mapper.Map<FriendsWebModel, FriendsModel>(model));
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

        // DELETE: api/Friends/5
        public void Delete(FriendsWebModel model)
        {
            try
            {
                friendsService.Remove(MapperHelperWeb.Mapper.Map<FriendsWebModel, FriendsModel>(model));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }
    }
}