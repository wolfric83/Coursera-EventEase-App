# EventEase

EventEase is a small Blazor WebAssembly demo app that demonstrates event listing, editing, registration with validation, and a simple attendance tracker. The app uses an in-memory, scoped `SessionStateService` to share selected event and registration data across pages in the same browser tab.

## Quick start

From the project root run:

```bash
cd EventEase
dotnet build
dotnet run
```

Open the app in your browser (the run output will show the URL, or open `https://localhost:5001` if running locally with HTTPS).

## Important runtime notes

- Session state is stored in memory via a scoped service. It survives navigation between pages in the same tab but is cleared on a full browser refresh.
- The `Events` collection is kept in `SessionStateService.Events` so edits made on the `Events` page are reflected across `Event Details`, `Registration`, and `Attendance` pages while the tab remains active.

## Files of interest

- `EventEase/Components/EventCard.razor` — event display component, now supports two-way binding via `@bind-EventItem` and an `EventItemChanged` callback.
- `EventEase/Pages/Events.razor` — create/edit events; includes an editable demo using `@bind-EventItem` and saves new events into `SessionStateService.Events`.
- `EventEase/Pages/Registration.razor` — registration form with data-annotation validation; uses session state to save registrations.
- `EventEase/Pages/Attendance.razor` — shows registration and allows toggling attendance status stored in session.
- `EventEase/Services/SessionStateService.cs` — scoped session state implementation (in-memory list of events, selected event, registration info).
- `checklist.md`, `testplan.md` — manual test checklist and session-state test plan (kept in sync with app behavior).

## Copilot assistance

I used Copilot to help generate and refine component implementations and to explain Blazor concepts during development. Copilot-assisted work focused on component scaffolding (`EventCard`), form handling (`Registration`), session state patterns, and navigation fixes. 

## Testing notes

- Run through `checklist.md` for manual registration tests.
- Run through `testplan.md` to verify session-state behavior and navigation.


*** End of README ***
