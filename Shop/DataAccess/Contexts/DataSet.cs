using Shop.DataAccess.Interfaces;

namespace Shop.DataAccess.Contexts
{
    internal class DataSet<TModel> : DataSetBase<TModel>
        where TModel : class, IUnique
    {
        public DataSet() : base() { }
    }
}
