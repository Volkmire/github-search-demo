using System;
using System.Collections.Generic;
using System.Text;
using GSD.Domain;
using GSD.Domain.Models;

namespace GSD.App
{
    public interface IRepository
    {
        public bool SaveRequest(List<RepositoryModel> repositories);
        public List<RepositoryModel> LoadRequest(int id);
        public List<RepositoryModel> LoadLastRequest();
    }
}
