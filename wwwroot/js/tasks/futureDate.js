// jQuery.validator.addMethod("futuredate", function (value, element) {
//     if (value === '') return true; // Allow empty values, use "required" for mandatory fields

//     var dateToCheck = new Date(value);
//     if (isNaN(dateToCheck.getTime())) return false; // Correct way to check for Invalid Date

//     var today = new Date();
//     today.setHours(0, 0, 0, 0); // Reset time part to compare only dates
//     return this.optional(element) || dateToCheck >= today; 
// }, "The date must be in the future.");

// Define the custom validation method
jQuery.validator.addMethod("futuredate", function(value, element) {
    const today = new Date();
    today.setHours(0, 0, 0, 0); // Remove time component
    const inputDate = new Date(value);
    inputDate.setHours(0, 0, 0, 0); // Remove time component
    // Ensure the input date is strictly after today's date
    return this.optional(element) || inputDate > today;
}, "Date isn't in the future so like change it.");

jQuery.validator.unobtrusive.adapters.addSingleVal("futuredate", "param");