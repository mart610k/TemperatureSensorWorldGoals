﻿using System.Collections.Generic;

namespace BackEndServices
{
    public interface IDatabaseAccess
    {
        List<T> LoadData<T>(string sql);

        bool UpdateData<T>(string sql);

        bool SaveData<T>(string sql);
    }
}
