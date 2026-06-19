// Scroll-into-view reveal. Any element with class "reveal" fades + slides up
// the first time it enters the viewport. Self-contained and easy to remove:
// delete this file, the .reveal CSS, the reveal classes, and the init call in
// MainLayout.razor.
let observer = null;

export function init() {
    // Re-runs on SPA navigation; start clean each time.
    if (observer) observer.disconnect();

    const targets = document.querySelectorAll('.reveal:not(.is-visible)');

    // No IntersectionObserver (or reduced motion) → just show everything.
    const reduced = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    if (reduced || !('IntersectionObserver' in window)) {
        targets.forEach(el => el.classList.add('is-visible'));
        return;
    }

    observer = new IntersectionObserver((entries, obs) => {
        for (const entry of entries) {
            if (entry.isIntersecting) {
                entry.target.classList.add('is-visible');
                obs.unobserve(entry.target);
            }
        }
    }, { threshold: 0.15, rootMargin: '0px 0px -8% 0px' });

    targets.forEach(el => observer.observe(el));
}
