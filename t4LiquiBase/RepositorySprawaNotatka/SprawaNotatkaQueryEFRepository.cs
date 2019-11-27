
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EZDRP.Sprawy.Common;
using EZDRP.Sprawy.DS.Data.Entities;
using EZDRP.Sprawy.DS.Data.Repositories;
using EZDRP.Sprawy.SharedDto;
using ICE.DataEf.Core;
using Microsoft.EntityFrameworkCore;

namespace EZDRP.Sprawy.DS.DataEF.Repositories
{
    public class SprawaNotatkaQueryEFRepository : EfQueryRepositoryDomainBase<SprawaNotatka>, ISprawaNotatkaQueryRepository
    {
        public override string ContainerKey => "EZDRP";

       
    }
}
