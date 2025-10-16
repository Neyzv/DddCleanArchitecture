using DddCleanArchitecture.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DddCleanArchitecture.Infrastructure.Database.Configurations;

public abstract class DbEntityConfiguration<TDbEntity>
    : IEntityTypeConfiguration<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    public virtual void Configure(EntityTypeBuilder<TDbEntity> builder)
    {
        builder.HasKey(e => e.Id);
        
        InternalConfigure(builder);
    }
    
    protected abstract void InternalConfigure(EntityTypeBuilder<TDbEntity> builder);
}