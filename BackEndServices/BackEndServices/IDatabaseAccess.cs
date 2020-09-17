using System.Collections.Generic;

namespace BackEndServices
{
    public interface IDatabaseAccess
    {
        List<T> LoadData<T>(string sql);

        bool UpdateData(string sql);

        bool SaveData(string sql);
    }
}
