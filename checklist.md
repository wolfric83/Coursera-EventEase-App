# EventEase Registration Form Manual Test Checklist

## 1. Empty name
- Input or action: Open the registration page and leave the attendee name field blank. Enter a valid email and submit the form.
- Expected result: The form shows a validation message for the attendee name field and does not submit.
- Requirement being verified: Registration requires a non-empty attendee name.

## 2. Empty email
- Input or action: Open the registration page and leave the email field blank. Enter a valid attendee name and submit the form.
- Expected result: The form shows a validation message for the email field and does not submit.
- Requirement being verified: Registration requires a non-empty email address.

## 3. Invalid email format
- Input or action: Open the registration page, enter a valid attendee name, and enter an invalid email such as `user@` or `user.com`. Submit the form.
- Expected result: The form shows a validation message indicating the email format is invalid and does not submit.
- Requirement being verified: Registration requires a valid email format.

## 4. Excessively long name
- Input or action: Open the registration page, enter a name longer than the allowed limit (e.g. 201+ characters), enter a valid email, and submit.
- Expected result: The form shows a validation message for the attendee name length and does not submit.
- Requirement being verified: Registration enforces maximum length for the attendee name.

## 5. Valid registration
- Input or action: Open the registration page, enter a valid attendee name, a valid email address, select an event, and submit the form.
- Expected result: The form submits successfully, a success message appears, and registration data is saved in session state.
- Requirement being verified: Registration completes successfully with valid input.

## 6. Repeated submission
- Input or action: After a successful registration, submit the registration form again with the same valid data or make no changes and submit again.
- Expected result: The app either displays a repeated registration success confirmation or prevents duplicate submission based on current behavior; no invalid state is introduced.
- Requirement being verified: The registration form handles repeated submissions safely.

## 7. Validation messages disappearing after correction
- Input or action: Trigger validation errors by submitting invalid data, then correct the invalid fields and resubmit.
- Expected result: Validation messages disappear for corrected fields and the form proceeds with submission if all inputs are valid.
- Requirement being verified: Validation state updates correctly after user corrections.

## 8. Registration being saved only after valid submission
- Input or action: Attempt to submit the form with invalid data, then navigate to the Attendance or Event Details page.
- Expected result: No registration data should be present in session state if the submission was invalid.
- Requirement being verified: Registration is not saved until a valid submission is completed.

## 9. Navigation after successful registration
- Input or action: Complete a valid registration and then navigate to the Attendance page or Event Details page using the available links.
- Expected result: The user can navigate to the Attendance page and see registration details, and to Event Details without losing the selected event.
- Requirement being verified: Successful registration preserves session state and supports navigation to related pages.

## 10. Events edits reflected in registration list
- Input or action: On the `Events` page, edit an existing saved event (use the Edit button) and modify its name or date. Navigate to the `Registration` page and open the event selector.
- Expected result: The `Registration` page shows the updated event information in its event selector (it uses the session-scoped events list).
- Requirement being verified: The available events shown on the registration form come from the session events list and reflect edits made in the `Events` page.

## Notes
- Session state is stored in memory for the current browser tab (scoped service). It survives client-side navigation between pages but does not survive a full browser refresh.
- The registration form's available events are drawn from the session event list (`SessionState.Events`), so edits in `Events.razor` should be visible in the `Registration` selector as long as the page is not refreshed.
