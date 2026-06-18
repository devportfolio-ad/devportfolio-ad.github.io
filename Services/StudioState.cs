namespace PersonalPage.Services;

/// <summary>
/// Scoped state that persists user selections while they navigate between
/// pages (calculator choice, agreement acceptance). Registered as a singleton
/// in WASM so it lives for the lifetime of the loaded app.
/// </summary>
public class StudioState
{
    public event Action? OnChange;

    private ScopePackage _selectedPackage = Catalogue.Packages[0];
    public ScopePackage SelectedPackage
    {
        get => _selectedPackage;
        set { _selectedPackage = value; NotifyChanged(); }
    }

    private bool _termsAccepted;
    public bool TermsAccepted
    {
        get => _termsAccepted;
        set { _termsAccepted = value; NotifyChanged(); }
    }

    private void NotifyChanged() => OnChange?.Invoke();
}
