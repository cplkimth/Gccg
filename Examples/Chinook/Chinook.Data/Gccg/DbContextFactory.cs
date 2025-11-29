#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
#endregion

namespace Chinook.Data;

public partial class DbContextFactory
{
    public static string ConnectionString =>
        "Data Source=.\\SQL2025;Initial Catalog=ChinookMP;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

    private static PooledDbContextFactory<ChinookContext> _factory;

    public static ChinookContext Create()
    {
        if (_factory == null)
            InitializeFactory();
    
        var context = _factory!.CreateDbContext();
        return context;
    }

    private static void InitializeFactory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();

        // 콘솔에 로그 출력
#if DEBUG
        optionsBuilder.UseLoggerFactory(ChinookContextLoggerFactory.GetInstance(
            nameof(LogPath.Console),
            nameof(LogPath.Debug)
            // "ChinookContext.log"
        ));
#endif

        // 엔터티 상태를 트랙킹하지 않음
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        // QuerySplittingBehavior
        var querySplittingBehavior = QuerySplittingBehavior.SplitQuery;

        var options = optionsBuilder
            .UseSqlServer(
                ConnectionString,
                x => x.UseQuerySplittingBehavior(querySplittingBehavior)
                    .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                    .UseCompatibilityLevel(160)
                    .UseParameterizedCollectionMode(ParameterTranslationMode.Parameter)
            )
            .Options;

        _factory = new PooledDbContextFactory<ChinookContext>(options);
    }
}