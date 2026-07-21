# EventEase Session State Manual Test Plan

## Overview
This test plan verifies how the EventEase session state behaves during client-side navigation, attendance updates, and browser refreshes. The app currently uses in-memory session state in the browser, so session data should survive navigation between pages in the same browser tab but not survive a full browser refresh.

## 1. Verify registration remains available across pages

### Test 1.1: Registration → Events → Registration
- Input or action: Complete a valid registration on the `Registration` page. Then navigate to the `Events` page and return to the `Registration` page.
- Expected result: Registration fields or saved state remain available in session state during navigation and the registered event is still selectable.
- Requirement being verified: Session state persists across internal page navigation.

### Test 1.2: Registration → Event Details → Registration
- Input or action: Complete a valid registration, then navigate to the `Event Details` page and return to the `Registration` page.
- Expected result: The selected event and registration state remain available during the navigation.
- Requirement being verified: Selected event state is preserved across page transitions.

### Test 1.3: Registration → Attendance → Registration
- Input or action: Complete a valid registration, navigate to the `Attendance` page, then return to the `Registration` page.
- Expected result: Registration state remains intact and the registered event remains available.
- Requirement being verified: Session state is shared between registration and attendance pages.

## 2. Verify event data remains available across non-registration pages

### Test 2.1: Events → Event Details → Attendance
- Input or action: Select an event from the `Events` page to view its details, then go to the `Attendance` page.
- Expected result: The selected event remains available and attendance page shows the selected event when registration is complete.
- Requirement being verified: Navigation preserves selected event information.

### Test 2.2: Event Details → Events → Attendance
- Input or action: Navigate from `Event Details` to `Events`, then to `Attendance`.
- Expected result: If registration was previously completed, the registered event and attendee data remain available.
- Requirement being verified: Session state remains present across backward/forward navigation.

### Test 2.3: Edit event in Events → Registration shows update
- Input or action: On the `Events` page, edit a saved event using the Edit button and change its `Name` and `Date`. Then navigate to the `Registration` page.
- Expected result: The `Registration` page's event selector lists the updated event data (the registration page reads available events from the session-scoped `Events` list).
- Requirement being verified: The session event list (`SessionState.Events`) is the authoritative source for available events and is reflected across pages during client-side navigation.

## 3. Verify attendance updates and page behavior

### Test 3.1: Update attendance status
- Input or action: Complete a registration, navigate to the `Attendance` page, toggle the attendance checkbox to mark as attending or not attending.
- Expected result: The attendance state updates immediately and the page reflects the new attending status.
- Requirement being verified: Attendance updates are stored in session state.

### Test 3.2: Return to Attendance page after change
- Input or action: Change the attendance status, navigate away to another page, then return to the `Attendance` page.
- Expected result: The updated attendance status remains visible.
- Requirement being verified: Attendance changes persist across internal navigation.

## 4. Verify session clearing behavior

### Test 4.1: Clear session manually if any UI action exists
- Input or action: If the app includes a clear or reset action, perform it and then navigate to `Registration`, `Events`, `Event Details`, and `Attendance`.
- Expected result: No registration or selected event data should remain after the session is cleared.
- Requirement being verified: Clear session resets in-memory state across all pages.

### Test 4.2: Implicit clear by navigation after failed registration
- Input or action: Attempt invalid registration submission and then navigate to other pages.
- Expected result: Invalid registration is not saved; the app should not show registered state on other pages.
- Requirement being verified: Invalid registration does not create session state.

## 5. Verify browser refresh behavior

### Test 5.1: Refresh after registration
- Input or action: Complete a valid registration and then refresh the browser page.
- Expected result: Session state is lost after refresh because the current implementation stores state only in memory for the active browser session. The app should behave as if no registration has occurred after refresh.
- Requirement being verified: Browser refresh clears in-memory session state.

Note: Because `Events` are stored in the same in-memory session list (`SessionState.Events`), edits to events will also be lost on a full browser refresh. This test plan assumes an in-memory scoped service; if persistent storage is implemented later, refresh behavior will change accordingly.

### Test 5.2: Refresh after navigation
- Input or action: Navigate to any page (Registration, Events, Event Details, Attendance), then refresh the browser.
- Expected result: The current in-memory session state is reset, and previously selected or registered data is not retained.
- Requirement being verified: Page refresh does not preserve client-side in-memory state.

## Notes
- Do not interpret session state as persistent storage. It survives only client-side navigation in the same browser tab until the page is refreshed.
- If the app is upgraded later to use browser storage or a server backend, the refresh behavior may change; this test plan reflects the current in-memory implementation.
