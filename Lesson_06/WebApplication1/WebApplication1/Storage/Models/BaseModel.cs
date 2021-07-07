using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Storage.Models
{
    public abstract class BaseModel<T> where T : struct
    {
        public T Id { get; set; }
    }
}
