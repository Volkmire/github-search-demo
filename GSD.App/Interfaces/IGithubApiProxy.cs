using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GSD.Domain.Models;

namespace GSD.App.Interfaces
{
    public interface IGithubApiProxy
    {
        public Task<List<RepositoryModel>> GetRepositoriesAsync(string searchText);
    }
}
