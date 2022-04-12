using AutoMapper;
using System;
using gadgets.Application.Interfaces;
using gadgets.Application.Common.Mapping;
using gadgets.Persistance;
using Xunit;


namespace gadgets.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public gadgetsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = gadgetsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IgadgetsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            gadgetsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

