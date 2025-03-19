using AlienAdminSystem.Components.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

/*
 * 
 Assignment Title
Design and Implement a Modular “Galactic Alien Administration” in .NET 9.0 Using Multiple Design Patterns and Head First OOP Principles

Scenario Overview
Earth has been designated by the Interplanetary Council to host alien visitors from various galaxies. These visitors may come for research, cultural exchange, or tourism, and your job is to design (and optionally develop) a .NET MAUI Blazor application that manages:

Alien Visitors (individual beings)
Alien Groups/Delegations (multiple beings traveling together)
Planetary Facilities (Embassies, Research Centers, Quarantine Zones)
Arrival & Temporary Settlement processes
Your system should handle accommodation requests, facility usage, alien profile management, scheduling, and special requirements (such as anti-gravity chambers or radiation shielding). The solution must be developed in .NET 9.0 and should follow object-oriented principles and design patterns as introduced in Head First Design Patterns.

Head First OOP Design Principles
Your design should explicitly demonstrate the following principles:

Encapsulate What Varies
Elements likely to change—such as new alien species, facility types, or regulations—should be encapsulated to minimize the impact of changes.

Favor Composition Over Inheritance
Where feasible, compose functionalities from smaller objects rather than building large inheritance hierarchies.

Program to Interfaces, Not Implementations
Use interfaces (or abstract classes) for core subsystems, like facility operations or alien identity management, to decouple implementation details from clients.

Strive for Loosely Coupled Designs
Keep dependencies between modules minimal. Adjusting one part of the system (e.g., notification logic) should not break unrelated components.

Open for Extension, Closed for Modification
Allow adding new alien types or facility types without extensively altering stable components of the system.

Depend Upon Abstractions, Not Concretions
Base your design on abstract classes or interfaces (e.g., ISpeciesBehavior) so you can plug in specialized implementations for each alien species.

Law of Demeter (“Don’t Talk to Strangers”)
Ensure each object only communicates with its immediate collaborators. Avoid unnecessary deep linking into other object structures.

Key Functional Requirements
1. Alien Registration & Management
Individual Aliens: Store personal data, species, and unique requirements, along with visit duration.
Alien Groups/Delegations: Group multiple individuals under a single travel or visitation request.
Verification Procedures: Confirm eligibility for Earth’s atmosphere and other required checks.
2. Facility Listing & Availability
Facility Management: Embassies, research labs, and quarantine zones each have specific features (e.g., capacity, environmental controls).
Status Tracking: Mark facilities as “available,” “under maintenance,” or other relevant statuses.
3. Visitation Scheduling & Booking
Request Handling: Aliens or delegation leaders can request time slots in specific facilities.
Approval Workflow: Some requests may need manual approval by Earth Administrators, while others may be auto-approved if certain conditions (like capacity) are met.
4. Notification & Alerts
Event-Driven Updates: Changes to bookings, facility availability, or new arrivals should trigger notifications.
Extensible Channels: Notifications could be sent via email, in-app messages, or future methods (e.g., galactic telepathy or cosmic mail).
5. Search & Browsing (Optional Extension)
Facility Filters: Aliens can search facilities by capacity, atmosphere type (oxygen, methane, vacuum), or special equipment.
Admin Filtering: Earth Admins can quickly find unassigned alien groups or underutilized facilities.
6. Reports & Monitoring (Optional Extension)
Analytics: Admins may want facility occupancy reports, usage statistics, or species-specific trends.
Scalability: The system design should make it straightforward to add analytics or monitoring features later.
Design & Implementation Requirements in .NET 9.0
Your solution (prototype or full implementation) must be built in .NET 9.0 with a focus on:

Modern C# features (pattern matching, record types, nullable references).
Integration of 5 or 6 design patterns that solve real problems in this scenario.
Application of the Head First OOP principles listed above.
A .NET MAUI Blazor front end, ensuring a cross-platform UI that can run on desktop and mobile devices.
Recommended Design Patterns
While you may choose any patterns that fit, consider these commonly useful ones:

Singleton
Could be used to manage global configurations like universal visitation rules, cosmic event schedules, or logging.

Factory / Abstract Factory
A Factory pattern can help instantiate various facility types (e.g., Embassies, Research Labs, Quarantine Zones) or different alien species objects.

Strategy
Useful for different booking or scheduling procedures (e.g., manual approval vs. auto-approval), or diverse search/filter strategies.

Observer
Ideal for the notification subsystem. Observers (email, push notifications, cosmic signals) subscribe to events such as new bookings or cancellations.

Decorator
Allows you to dynamically add optional features to an alien booking or facility (e.g., specialized environmental controls, VIP protocols) without modifying the base class.

Command
Encapsulate booking actions as commands, enabling undo/redo or scheduling tasks for later (e.g., sending arrival reminders).

Facade
Provide a simple interface for complex operations like scheduling logic, species compliance checks, and notifications.

State
Manage clear transitions between facility or booking states (e.g., Requested, Approved, UnderMaintenance, Closed).
Illustrative Subsystems
Your design should present how the following key subsystems interact within a .NET MAUI Blazor solution:

Alien Management: Handles registration, profile, and species-specific behaviors.
Facility Management: Tracks facility details, availability, and maintenance status.
Booking System: Processes alien visit requests, approvals, and scheduling.
Notification System: Dispatches alerts and updates to relevant parties.

*/

namespace AlienAdminSystem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);
            builder.Services.AddSingleton<AlienDatabaseService>();
            builder.Services.AddSingleton<Alien>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
