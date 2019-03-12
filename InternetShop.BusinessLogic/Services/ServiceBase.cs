using InternetShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.BusinessLogic.Services
{
    public abstract class ServiceBase
    {
        public int GetMaxId(List<IIdentifiable> enteties)
        {
            if (enteties == null || !enteties.Any())
                return 0;
            return enteties.Max(e => e.Id);
        }
        protected string GetStoragePath(string filename)
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}\{filename}";
        }

    }
}
