using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.ExtensionMethods
{
    public static class HandlingExceptionExtensions
    {
        public static void CheckIfNull<T>(this int id, T entity)
        {
            if (entity == null)
                throw new Exception($"{typeof(T).Name} of {id} is not found");
        }
    }
}
