// Minimal interop for the CatCompanion component.
// The animation + AI state machine live in C#; this only reports the
// viewport size and forwards pointer input (for Follow mode) to C#.
let dotnetRef = null;
let pointerDown = false;

function onResize() {
    if (dotnetRef) {
        dotnetRef.invokeMethodAsync('OnViewportResized', window.innerWidth, window.innerHeight);
    }
}

function onPointerDown(e) {
    pointerDown = true;
    if (dotnetRef) dotnetRef.invokeMethodAsync('OnPointerDown', e.clientX, e.clientY);
}

function onPointerMove(e) {
    // Only stream coordinates while the button is held — keeps interop quiet.
    if (pointerDown && dotnetRef) dotnetRef.invokeMethodAsync('OnPointerMove', e.clientX, e.clientY);
}

function onPointerUp() {
    pointerDown = false;
    if (dotnetRef) dotnetRef.invokeMethodAsync('OnPointerUp');
}

export function init(ref) {
    dotnetRef = ref;
    window.addEventListener('resize', onResize);
    window.addEventListener('pointerdown', onPointerDown);
    window.addEventListener('pointermove', onPointerMove);
    window.addEventListener('pointerup', onPointerUp);
    window.addEventListener('pointercancel', onPointerUp);
    const reduced = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    return { width: window.innerWidth, height: window.innerHeight, reducedMotion: reduced };
}

export function dispose() {
    window.removeEventListener('resize', onResize);
    window.removeEventListener('pointerdown', onPointerDown);
    window.removeEventListener('pointermove', onPointerMove);
    window.removeEventListener('pointerup', onPointerUp);
    window.removeEventListener('pointercancel', onPointerUp);
    dotnetRef = null;
}
