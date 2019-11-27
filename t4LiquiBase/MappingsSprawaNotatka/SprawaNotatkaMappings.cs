
using EZDRP.Sprawy.DS.Data.Entities;
using ICE.DataEf.Core;
using Microsoft.EntityFrameworkCore;

namespace EZDRP.Sprawy.DS.DataEF.Mappings
{
    public class SprawaNotatkaMappings : IDomainModelEfMapping<SprawaNotatka>
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<SprawaNotatka>();
            entityTypeBuilder.ToTable("SprawaNotatka");
        }
    }
}
