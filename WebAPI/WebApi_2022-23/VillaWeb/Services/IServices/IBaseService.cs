using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaWeb.Models;

namespace VillaWeb.Services.IServices
{
    public interface IBaseService
    {
        ApiResponse ResponseModel { get; set; }

        //za pozive prema API-ju
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
