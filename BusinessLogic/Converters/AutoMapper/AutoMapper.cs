using AutoMapper;

namespace BusinessLayer.Converters.AutoMapper
{
    internal static class AutoMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AutoMapperProfiles>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper { get => Lazy.Value; }
    }
}
