using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter),
                    BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
            entityData.AddIndex(entityData.FindProperty(nameof(BaseEntity.DeletedAt)));
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : BaseEntity
        {
            Expression<Func<TEntity, bool>> filter = x => x.DeletedAt == null;
            return filter;
        }
    }
}
