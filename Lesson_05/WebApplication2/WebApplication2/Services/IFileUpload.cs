using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Services
{
    public interface IFileUpload
    {
        Task<string> Upload(IFormFile file);
    }
}
