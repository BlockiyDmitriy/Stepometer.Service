using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Service.BLL.Services.Abstruct
{
    public interface IServiceGetFunction<TDTO> where TDTO : class
    {
        IEnumerable<TDTO> Get();
        TDTO Get(int id);
        IEnumerable<TDTO> Get(Expression<Func<TDTO, bool>> predicate);
        TDTO SingleOrDefault(Expression<Func<TDTO, bool>> predicate);
    }
}