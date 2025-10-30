using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace NLayeredArthitecture.Repositories
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {

            foreach(var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:

                        if(entityEntry.Entity is IAuditEntity auditEntity)
                        {
                            auditEntity.Created = DateTime.Now;
                            eventData.Context.Entry(auditEntity).Property(X => X.Updated).IsModified = false;
                        }


                        break;

                    case EntityState.Modified:
                        if(entityEntry.Entity is IAuditEntity auditUpdateEntity)
                        {
                            auditUpdateEntity.Created = DateTime.Now;
                            eventData.Context.Entry(auditUpdateEntity).Property(X => X.Updated).IsModified = false;
                        }


                        break;
                    
                }

                
                
            }
            














            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}