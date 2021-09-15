using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
