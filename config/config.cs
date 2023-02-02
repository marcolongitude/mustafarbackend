namespace mustafarbackend.config
{
    static public class MyRateLimitOptions
    {
        static public readonly string MyRateLimit = "MyRateLimit";
        static public int PermitLimit { get; } = 5;
        static public int Window { get; } = 10;
        static public int ReplenishmentPeriod { get; } = 2;
        static public int QueueLimit { get; } = 1;
        static public int SegmentsPerWindow { get; } = 10;
        static public int TokenLimit { get; } = 10;
        static public int TokenLimit2 { get; } = 20;
        static public int TokensPerPeriod { get; } = 4;
        static public bool AutoReplenishment { get; } = false;
    }
}