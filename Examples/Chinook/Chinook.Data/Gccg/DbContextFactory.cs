#region

using Microsoft.EntityFrameworkCore;

#endregion

namespace Chinook.Data;

public partial class DbContextFactory
{
    public static string ConnectionString =>
        "Data Source=lovanpis.com,3433;Initial Catalog=Chinook;uid=Chinook;password=1;Trust Server Certificate=true";

    public static ChinookContext Create()
    {
        var builder = new DbContextOptionsBuilder<ChinookContext>();

        OnConfigure(builder);

        // 콘솔에 로그 출력
        builder.UseLoggerFactory(ChinookContextLoggerFactory.GetInstance(LogPath.Console, LogPath.Debug));

        // 엔터티 상태를 트랙킹하지 않음
        builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        builder.UseSqlServer(ConnectionString);

        return new ChinookContext(builder.Options);
    }

    static partial void OnConfigure(DbContextOptionsBuilder<ChinookContext> builder);
}