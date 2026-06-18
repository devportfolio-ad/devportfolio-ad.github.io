namespace PersonalPage;

/// <summary>
/// Central app configuration. Change your hourly rate here once and it
/// propagates across the whole site (price calculator, use-case cards, etc.).
/// </summary>
public static class AppConfig
{
    // Change your rate here anytime!
    public const decimal HourlyRate = 50.00m;

    public const string CurrencySymbol = "$";

    // Studio identity / contact details surfaced across the site.
    public const string StudioName = "Cozy Code Studio";
    public const string Tagline = "Custom websites, handcrafted in code.";
    public const string ContactEmail = "linnracious@gmail.com";

    // Deposit / revision policy reused on the Terms page.
    public const int DepositPercent = 50;
    public const int IncludedRevisionRounds = 3;
}

/// <summary>
/// A project scope package: a named tier with a representative hour band.
/// Prices are derived from <see cref="AppConfig.HourlyRate"/> at runtime.
/// </summary>
public record ScopePackage(
    string Name,
    string Description,
    string PrimaryUseCase,
    int MinHours,
    int MaxHours)
{
    public decimal MinPrice => AppConfig.HourlyRate * MinHours;
    public decimal MaxPrice => AppConfig.HourlyRate * MaxHours;

    /// <summary>Midpoint estimate, handy for slider readouts.</summary>
    public decimal TypicalPrice => AppConfig.HourlyRate * ((MinHours + MaxHours) / 2m);
}

/// <summary>
/// The catalogue of offerings. Single source of truth shared by the Home
/// calculator and the Use Cases grid.
/// </summary>
public static class Catalogue
{
    public static readonly IReadOnlyList<ScopePackage> Packages = new List<ScopePackage>
    {
        new("Simple Landing Page",
            "A fast, single-screen landing page for a boutique service or product launch.",
            "Independent web shops & promo pages",
            6, 12),
        new("Interactive Portfolio",
            "A multi-dimensional timeline or gamified resume that makes your work memorable.",
            "Creatives, freelancers & personal brands",
            16, 32),
        new("Custom Web Application",
            "A bespoke local-tool dashboard or unique client utility built to your spec.",
            "Businesses needing a tailored web tool",
            40, 90),
    };
}
