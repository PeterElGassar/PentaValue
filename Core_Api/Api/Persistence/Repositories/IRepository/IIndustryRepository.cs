using Api.Models.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories.IRepository
{
    public interface IIndustryRepository:IRepository<Industry>
    {
        void Update(Industry industry);
        void Delete(Industry industry);
    }
}
