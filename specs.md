# Technical Specifications: Cozy Code Studio Portfolio
Project Specification Sheet: Freelance Web Dev Offering1. Project OverviewPurpose: A single-page application (SPA) showcasing custom freelance website creation services.Target Audience: Entrepreneurs, creatives, and businesses seeking a high-quality, custom web presence.Host Platform: GitHub Pages (Static Hosting).Architecture: Blazor WebAssembly (WASM) targeting .NET 10.2. Visual & UI Design ThemeAesthetic: Cyberpunk-inspired minimalism with dark backgrounds, neon glows, and glassmorphism elements.Interactive Background: A subtle, performance-optimized CSS or HTML5 Canvas particle network (e.g., slowly drifting nodes connecting with faint lines) to represent data connectivity without hurting text readability.Framework Suggestion: MudBlazor or a custom utility-first Tailwind CSS integration for lightweight, highly customizable layouts.3. Site Architecture & Page BreakdownPage 1: Home (The Pitch)Hero Section: Company/Service name with high-impact neon typography.The "Why": A brief, compelling origin story detailing your passion for engineering interactive web spaces.Service Overview: High-level value proposition of what you build.Interactive Price Calculator:Input field or slider for Hourly Rate.Dynamic display showcasing the corresponding Typical Total Price Range based on project scope parameters.Page 2: Use Cases & DeliverablesGrid Layout: Cards representing different website variations you offer.Card Components: Each item features a description, primary use case, and an estimated price tag.Suggested Use Cases:Interactive Portfolios: Multi-dimensional timelines or gamified resumes.Independent Web Shops: Simple, fast landing pages for boutique services.Custom Web Applications: Local tool dashboards or unique client utilities.Page 3: Service Agreement & WorkflowTransaction Rules: Transparent breakdown of how project milestones, payment schedules, and revisions operate.Legal/Contract Content: Clear terms of service regarding code ownership, deployment support, and communication policies.Mandatory Acknowledgment: An interactive checkbox ("I understand and agree to these terms") that unlocks a custom contact form or direct link to your communication handles.4. Technical Constraints & Architecture[GitHub Pages CDN]
       │
       ▼ (Serves Static Files)
[Blazor WASM (.NET 10 App)] ──► [App.razor (Routing)]
                                      │
                         ┌────────────┼────────────┐
                         ▼            ▼            ▼
                    [Home.razor] [Uses.razor] [Terms.razor]
                         │            │            │
                         └────────────┴────────────┘
                                      │
                                      ▼
                       [Shared Layout / Canvas BG Component]
Routing: Standard Blazor client-side routing.GitHub Pages Compatibility:Include a custom 404.html script trick to safely redirect deep-linked SPA routes back to the main index.Ensure a .nojekyll file is present in the output root folder to prevent GitHub from ignoring folders starting with underscores (critical for Blazor framework files).State Management: Use a simple scoped dependency injection (DI) service if user selections or calculation inputs need to persist while jumping between tabs.
#Revisions
1. Updated Background Component: The Cozy Cat CompanionThe background will feature a custom, low-overhead Razor component (<CatCompanion />) running a state machine in C# via a lightweight standard HTML5 Canvas loop.The AI Behaviors: The cat switches randomly between states: Walking, Sitting, Grooming, and Sleeping.Movement Pathing: A simple Random Walk algorithm keeps the cat wandering slowly behind your content layer. It avoids text blocks by utilizing bounding boxes or restricted margin pathways.Performance Optimization: Built using a small, transparent pixel art sprite sheet. Because it updates on a low-frame-rate canvas loop, it will not drain the user's mobile battery or cause page lag.2. Page 1: Home Page & Dynamic Price ArchitectureYou will handle pricing via a centralized app configuration file (AppConfig.cs), making it incredibly easy to change your hourly rate globally in one line of code.csharp// AppConfig.cs - Change your rate here anytime!
public static class AppConfig
{
    public const decimal HourlyRate = 50.00m; 
}
Use code with caution.The User Calculator Layout:Input: The user inputs or selects their project scope category (e.g., Simple Landing Page, Complex Web App).Logic: The Blazor backend pulls your fixed HourlyRate from configuration and multiplies it by predefined hours.Display: Instantly updates a clean visual element showing the estimated cost layout:\(\text{Project\ Cost}=\text{Fixed\ Hourly\ Rate}\times \text{Package\ Hours}\)3. Page 2: Organic Workflow & Use CasesInstead of a rigid, boring text list, your process layout will use an asymmetrical, staggered timeline design that guides the eye naturally down the screen. [ Phase 1: Blueprint ] ──(Cat footprint trail)──► [ Phase 2: Design Sync ]
                                                           │
                                                (Soft vertical line)
                                                           │
 [ Phase 4: Launch Day ] ◄──(Cat footprint trail)─── [ Phase 3: Development ]
Visual Elements: Steps alternate from left to right, connected by a faint dotted vector line or a whimsical trail of fading cat paw prints.The Workflow Breakdown:Discovery & Scope: Aligning on features, goals, and layout ideas.Interactive Prototype: Reviewing a mock design before any code is written.Active Development: Building the application in Blazor WASM with live staging access.Final Polish & Launch: Deploying the stable build directly to your GitHub Pages or custom domain.4. Page 3: The Integrated Agreement & GatekeeperTo maximize transparency, the contract terms and acceptance interface sit neatly directly below your workflow steps on the final screen.┌────────────────────────────────────────────────────────┐
│               SERVICE AGREEMENT TERMS                  │
│                                                        │
│ • Milestones: 50% deposit upfront, 50% upon delivery.  │
│ • Ownership: Code ownership transfers upon final pay.  │
│ • Revisions: Includes up to 3 rounds of minor tweaks.   │
└────────────────────────────────────────────────────────┘
    [ ] I have read, understood, and agree to these terms.
 
┌────────────────────────────────────────────────────────┐
│              [ CONTACT ME / GET STARTED ]              │
│         (This form unlocks after checking above)       │
└────────────────────────────────────────────────────────┘
The Acknowledgment Lock: The contact panel remains grayed out and disabled.The Unlock Trigger: Once the client checks the agreement box, the panel beautifully fades in using a soft CSS transition, allowing them to fill out their request or reveal your direct email link.

Here is some reference code for the cat that can be leveraged:
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Geometric Wanderer | Interactive SVG Cat</title>
    <style>
        :root {
            --bg-main: #ffffff;
            --bg-alt: #f6f8fa;
            --text-primary: #1f2328;
            --text-secondary: #656d76;
            --accent: #0969da;
            --cat-body: #2d3436;
            --cat-ear: #636e72;
            --cat-eye: #55efc4;
            --cat-heart: #ff7675;
            --border-color: #d0d7de;
        }

        * { box-sizing: border-box; }

        body {
            margin: 0;
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", "Noto Sans", Helvetica, Arial, sans-serif;
            color: var(--text-primary);
            background-color: var(--bg-main);
            line-height: 1.5;
            overflow-x: hidden;
        }

        /* GitHub-style Header */
        header {
            background-color: var(--bg-alt);
            border-bottom: 1px solid var(--border-color);
            padding: 24px 16px;
            text-align: center;
        }

        .container {
            max-width: 900px;
            margin: 0 auto;
            padding: 0 20px;
        }

        h1 { margin: 0; font-size: 32px; font-weight: 600; }
        .subtitle { color: var(--text-secondary); margin-top: 8px; font-size: 18px; }

        /* Playground Section */
        #playground {
            position: relative;
            width: 100%;
            height: 500px;
            background: linear-gradient(180deg, #f6f8fa 0%, #ffffff 100%);
            border: 1px solid var(--border-color);
            border-radius: 12px;
            margin: 40px 0;
            overflow: hidden;
            cursor: crosshair;
        }

        .controls-overlay {
            position: absolute;
            bottom: 16px;
            left: 16px;
            display: flex;
            gap: 12px;
            z-index: 10;
        }

        .badge {
            background: rgba(255, 255, 255, 0.8);
            border: 1px solid var(--border-color);
            padding: 6px 12px;
            border-radius: 20px;
            font-size: 12px;
            font-weight: 600;
            backdrop-filter: blur(4px);
        }

        button {
            background-color: var(--accent);
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 6px;
            font-size: 14px;
            font-weight: 500;
            cursor: pointer;
            transition: background 0.2s;
        }

        button:hover { background-color: #085cc1; }
        button.active { background-color: var(--cat-heart); }

        /* Cat Component */
        #cat {
            position: absolute;
            width: 80px;
            height: 80px;
            will-change: transform;
            pointer-events: auto;
            cursor: pointer;
        }

        .cat-svg {
            width: 100%;
            height: 100%;
            filter: drop-shadow(0 4px 8px rgba(0,0,0,0.1));
        }

        .heart {
            position: absolute;
            top: -20px;
            left: 50%;
            transform: translateX(-50%);
            font-size: 20px;
            color: var(--cat-heart);
            opacity: 0;
            transition: all 0.4s ease-out;
        }

        .show-heart { opacity: 1; transform: translate(-50%, -25px) scale(1.3); }

        /* Documentation Section */
        .docs {
            padding-bottom: 80px;
        }

        .docs h2 { border-bottom: 1px solid var(--border-color); padding-bottom: 8px; margin-top: 40px; }
        .docs code { background: var(--bg-alt); padding: 2px 4px; border-radius: 4px; font-family: monospace; }
        
        .grid { display: grid; grid-template-columns: 1fr 1fr; gap: 24px; margin-top: 20px; }
        @media (max-width: 600px) { .grid { grid-template-columns: 1fr; } }
    </style>
</head>
<body>

    <header>
        <div class="container">
            <h1>Geometric Wanderer</h1>
            <p class="subtitle">An interactive random walk simulation for GitHub Pages</p>
        </div>
    </header>

    <main class="container">
        <section id="playground">
            <div class="controls-overlay">
                <div class="badge" id="modeStatus">Mode: Wandering</div>
                <button id="speedToggle">Toggle Sprint</button>
            </div>

            <div id="cat">
                <div id="heart" class="heart">❤</div>
                <svg class="cat-svg" viewBox="0 0 100 100">
                    <path d="M20 70 Q 5 60 15 45" stroke="#2d3436" stroke-width="4" fill="none" />
                    <rect fill="var(--cat-body)" x="25" y="45" width="50" height="30" rx="5" />
                    <path fill="var(--cat-body)" d="M60 25 L90 25 L90 55 L60 55 Z" />
                    <path fill="var(--cat-ear)" d="M60 25 L65 10 L75 25 Z" />
                    <path fill="var(--cat-ear)" d="M75 25 L85 10 L90 25 Z" />
                    <circle id="eyeL" fill="var(--cat-eye)" cx="70" cy="35" r="3" />
                    <circle id="eyeR" fill="var(--cat-eye)" cx="82" cy="35" r="3" />
                    <path fill="var(--cat-heart)" d="M74 42 L78 42 L76 45 Z" />
                    <rect fill="var(--cat-body)" x="35" y="75" width="5" height="8" />
                    <rect fill="var(--cat-body)" x="60" y="75" width="5" height="8" />
                </svg>
            </div>
        </section>

        <section class="docs">
            <h2>Features & Specs</h2>
            <div class="grid">
                <div>
                    <h3>Autonomous Motion</h3>
                    <p>Uses a steering-based random walk algorithm. The cat calculates a new heading every few frames, resulting in smooth, non-jittery exploration of the playground.</p>
                </div>
                <div>
                    <h3>Interactive Input</h3>
                    <p>Click and hold anywhere in the box to override the wander loop. The cat will calculate the shortest angular path to turn and follow your pointer.</p>
                </div>
            </div>

            <h2>How to Deploy</h2>
            <ol>
                <li>Create a new repository on GitHub named <code>cat-wanderer</code>.</li>
                <li>Upload this file as <code>index.html</code>.</li>
                <li>Go to <b>Settings > Pages</b>.</li>
                <li>Select <b>Deploy from a branch</b> and choose <code>main</code>.</li>
            </ol>
        </section>
    </main>

    <script>
        const cat = document.getElementById('cat');
        const playground = document.getElementById('playground');
        const speedToggle = document.getElementById('speedToggle');
        const modeStatus = document.getElementById('modeStatus');
        const heart = document.getElementById('heart');
        const eyes = [document.getElementById('eyeL'), document.getElementById('eyeR')];

        let state = {
            x: 200,
            y: 200,
            theta: Math.random() * Math.PI * 2,
            targetTheta: 0,
            speed: 2,
            isSprinting: false,
            isFollowing: false,
            mouseX: 0,
            mouseY: 0,
            happy: false
        };

        // UI Logic
        speedToggle.onclick = (e) => {
            e.stopPropagation();
            state.isSprinting = !state.isSprinting;
            state.speed = state.isSprinting ? 5 : 2;
            speedToggle.classList.toggle('active');
        };

        // Interaction Logic
        playground.onmousedown = (e) => {
            if(e.target.closest('#cat')) return; // Handle pet separate
            state.isFollowing = true;
            modeStatus.textContent = "Mode: Following";
            updateMouse(e);
        };

        window.onmouseup = () => {
            state.isFollowing = false;
            modeStatus.textContent = "Mode: Wandering";
        };

        playground.onmousemove = (e) => {
            if (state.isFollowing) updateMouse(e);
        };

        function updateMouse(e) {
            const rect = playground.getBoundingClientRect();
            state.mouseX = e.clientX - rect.left;
            state.mouseY = e.clientY - rect.top;
        }

        cat.onclick = (e) => {
            e.stopPropagation();
            if (state.happy) return;
            state.happy = true;
            heart.classList.add('show-heart');
            eyes.forEach(eye => eye.style.fill = '#ff7675');
            setTimeout(() => {
                state.happy = false;
                heart.classList.remove('show-heart');
                eyes.forEach(eye => eye.style.fill = '#55efc4');
            }, 1000);
        };

        // Core Loop
        function loop() {
            const rect = playground.getBoundingClientRect();
            
            if (state.isFollowing) {
                const dx = state.mouseX - state.x;
                const dy = state.mouseY - state.y;
                const dist = Math.sqrt(dx*dx + dy*dy);
                
                if (dist > 15) {
                    state.targetTheta = Math.atan2(dy, dx);
                    let moveSpeed = state.speed;
                    if (dist < 40) moveSpeed *= (dist/40);
                    state.x += Math.cos(state.theta) * moveSpeed;
                    state.y += Math.sin(state.theta) * moveSpeed;
                }
            } else {
                // Random Walk
                state.targetTheta += (Math.random() - 0.5) * 0.4;
                
                // Bounds Check
                const margin = 40;
                if (state.x < margin) state.targetTheta = 0;
                if (state.x > rect.width - margin) state.targetTheta = Math.PI;
                if (state.y < margin) state.targetTheta = Math.PI/2;
                if (state.y > rect.height - margin) state.targetTheta = -Math.PI/2;

                state.x += Math.cos(state.theta) * state.speed;
                state.y += Math.sin(state.theta) * state.speed;
            }

            // Smooth Angular Interpolation
            let diff = state.targetTheta - state.theta;
            while (diff < -Math.PI) diff += Math.PI * 2;
            while (diff > Math.PI) diff -= Math.PI * 2;
            state.theta += diff * 0.1;

            // Render
            cat.style.transform = `translate(${state.x - 40}px, ${state.y - 40}px) rotate(${state.theta * 180/Math.PI}deg)`;
            
            requestAnimationFrame(loop);
        }

        loop();
    </script>
</body>
</html>
