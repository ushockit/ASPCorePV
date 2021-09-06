using System;
namespace CQRSProject.Domain.Entities
{
    public abstract class BaseEntity<T>
        where T : struct
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
