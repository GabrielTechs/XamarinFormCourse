using Fusillade;
using LoginPage.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.Services
{
    public interface IApiService
    {
        Task<List<PhonesDirectory>> GetDirectories();
    }
}
