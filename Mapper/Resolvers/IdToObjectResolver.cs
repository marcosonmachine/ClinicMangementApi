// using AutoMapper;

// public class IdToObjectResolver<TSource, TDestination, TService> : IValueResolver<TSource, TDestination, object>
// {
//     private readonly Func<TService, int, object> _getObjectById;

//     public IdToObjectResolver(Func<TService, int, object> getObjectById)
//     {
//         _getObjectById = getObjectById;
//     }

//     public object Resolve(TSource source, TDestination destination, object destMember, ResolutionContext context)
//     {
//         // Assuming source has an ID property
//         Guid id = (Guid)context.SourceValue;

//         // You'll need to inject the service instance into this resolver
//         // for simplicity, let's assume it's injected via constructor

//         // Fetch the object using the service function
//         TService service = context.Mapper.ConfigurationProvider.ResolveService<TService>();
//         return _getObjectById(service, id);
//     }
// }