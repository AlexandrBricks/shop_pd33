using System;
using System.Collections.Generic;

namespace Shop.DataAccess.Interfaces
{
    public interface IDataSet<TModel> 
        where TModel : class, IUnique
    {
        public IEnumerable<TModel> GetAll();
        public IEnumerable<TModel> GetAllByCondition(Func<TModel, bool> condition); 
        public TModel Get(int id);
        public TModel GetByCondition(Func<TModel, bool> condition);
        public void Add(TModel model);
        public void Delete(int id);
        public void Edit(TModel model);
        public bool IsContains(TModel model);
        public bool IsContains(int idl);
        public void Save();
        public void Refresh();
    }
}
