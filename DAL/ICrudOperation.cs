using static DAL.Enum;

namespace MyMarket.Interface
{
    public interface ICrudOperation<T>
    {
        IEnumerable<T> GetAll(string sql);
        EnumResult Add(string sql);
        EnumResult Update(string sql);
        EnumResult Delete( string sql);
        int AddHeader(string sql);
        T GetById(string sql);

    }
}
