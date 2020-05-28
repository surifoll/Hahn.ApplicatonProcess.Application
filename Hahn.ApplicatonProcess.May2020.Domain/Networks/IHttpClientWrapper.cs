using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Networks
{
    public interface IHttpClientWrapper
    {
        Task<string> HttpGetAsync(string url);
    }
}
