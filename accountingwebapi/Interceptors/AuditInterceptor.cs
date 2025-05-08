﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using accountingwebapi.Models.App;

namespace POSIMSWebApi.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public AuditInterceptor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result
        )
        {
            if (eventData.Context == null) return result;
            foreach(var entry in eventData.Context.ChangeTracker.Entries())
            {
                //var claimuserId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var claimuserId = Guid.NewGuid().ToString();
                if (Guid.TryParse(claimuserId, out Guid userId))
                {
                    if (entry.Entity is AuditedEntity auditableEntity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            auditableEntity.CreationTime = DateTime.UtcNow;
                            //TODO: change it once auth is implemented
                            auditableEntity.CreatedBy = userId;
                        }
                        if (entry.State == EntityState.Modified)
                        {
                            auditableEntity.ModifiedBy = userId;
                            auditableEntity.ModifiedTime = DateTime.UtcNow;
                        }
                        if (entry.State == EntityState.Deleted )
                        {
                            entry.State = EntityState.Modified;
                            auditableEntity.DeletedBy = userId;
                            auditableEntity.IsDeleted = true;
                            auditableEntity.DeletionTime = DateTime.UtcNow;
                        }
                    }
                }
                else
                {
                    throw new Exception("Error! Interceptor can't find UserId");
                }
                
            }
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
        {
            if (eventData.Context == null) return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                //var claimUserId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var claimUserId = Guid.NewGuid().ToString();
                if (Guid.TryParse(claimUserId, out Guid userId))
                {
                    if (entry.Entity is AuditedEntity auditableEntity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            auditableEntity.CreationTime = DateTime.UtcNow;
                            auditableEntity.CreatedBy = userId;
                        }
                        if (entry.State == EntityState.Modified)
                        {
                            auditableEntity.ModifiedBy = userId;
                            auditableEntity.ModifiedTime = DateTime.UtcNow;
                        }

                        if (entry.State == EntityState.Deleted)
                        {
                            entry.State = EntityState.Modified;
                            auditableEntity.DeletedBy = userId;
                            auditableEntity.IsDeleted = true;
                            auditableEntity.DeletionTime = DateTime.UtcNow;
                        }
                    }
                }
                else
                {
                    throw new Exception("Error! Interceptor can't find UserId");
                }
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }


    }
}
