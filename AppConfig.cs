namespace PersonalPage;

/// <summary>
/// Central app configuration. Change your hourly rate here once and it
/// propagates across the whole site (price calculator, use-case cards, etc.).
/// </summary>
public static class AppConfig
{
    // Change your rate here anytime!
    public const decimal HourlyRate = 25.00m;

    public const string CurrencySymbol = "$";

    // Studio identity / contact details surfaced across the site.
    public const string StudioName = "Cozy Code Crib";
    public const string Tagline = "Personalized websites, cozy and cheap";
    public const string ContactEmail = "linnracious@gmail.com";

    // Deposit is a flat fee charged upfront to begin (not a percentage).
    public const decimal DepositAmount = 10.00m;

    // Google Form embed URLs. In Google Forms: Send → < > (embed HTML) and copy
    // the src that ends in "?embedded=true". Leave blank to show a fallback note.
    public const string IntakeFormUrl = "https://docs.google.com/forms/d/e/1FAIpQLSe7YBJ1Ks3nQovZqLNQBnBL-W8yOPaw2t1Id9-08_laAqUcog/viewform?usp=dialog";    // shown on the Agreement page once the client accepts the terms
    public const string DetailsFormUrl = "https://docs.google.com/forms/d/e/1FAIpQLSe7YBJ1Ks3nQovZqLNQBnBL-W8yOPaw2t1Id9-08_laAqUcog/viewform?usp=dialog";   // hosted at the hidden "/brief" route for deeper website details
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
        new("My Cozy Blog",
            "A fast, single-screen landing page for a boutique service or product launch.",
            "Independent web shops & promo pages",
            3, 7),
        new("My Creative Portfolio",
            "A multi-dimensional timeline or gamified resume that makes your work memorable.",
            "Creatives, freelancers & personal brands",
            5, 7),
        new("My Consensual Wedding",
            "A bespoke local-tool dashboard or unique client utility built to your spec.",
            "Businesses needing a tailored web tool",
            7, 9),
        new("My Classy Advert",
            "A bespoke local-tool dashboard or unique client utility built to your spec.",
            "Businesses needing a tailored web tool",
            5, 7),
        new("My Contemporary Store/Restaurant",
            "A bespoke local-tool dashboard or unique client utility built to your spec.",
            "Businesses needing a tailored web tool",
            7, 9),                           
    };
}
