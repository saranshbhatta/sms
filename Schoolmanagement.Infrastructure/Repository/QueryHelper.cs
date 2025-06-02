using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Infrastructure.Repository;

public static class QueryHelper
{
    public static void GlobalQueryFilter(ModelBuilder builder)
    {
        // Apply global query filters for soft delete
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            // Check if the entity has an IsDeleted property
            var isDeletedProperty = entityType.FindProperty("IsDeleted");
            if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
            {
                // Build the lambda expression: (e) => EF.Property<bool>(e, "IsDeleted") == false
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Call(
                    typeof(EF),
                    nameof(EF.Property),
                    new[] { typeof(bool) },
                    parameter,
                    Expression.Constant("IsDeleted"));
                var filter = Expression.Lambda(
                    Expression.Equal(property, Expression.Constant(false)),
                    parameter);

                // Apply the filter
                builder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
    }
}