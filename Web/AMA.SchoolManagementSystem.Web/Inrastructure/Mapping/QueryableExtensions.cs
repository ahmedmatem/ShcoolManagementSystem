namespace AMA.SchoolManagementSystem.Web.Inrastructure.Mapping
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using AMA.SchoolManagementSystem.Web.App_Start;
    using AutoMapper.QueryableExtensions;

    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}