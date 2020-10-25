namespace BodySculptor.Services.Mapping
{
    public static class ObjectMappingExtensions
    {
        public static TDestination MapTo<TDestination>(this object obj)
            => AutoMapperConfig.MapperInstance.Map<TDestination>(obj);

        public static TDestination MapTo<TSource, TDestination>(this object obj, TDestination destination)
            => AutoMapperConfig.MapperInstance.Map(obj, destination);
    }
}
