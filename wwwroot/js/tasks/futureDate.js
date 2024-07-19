jQuery.validator.addMethod("futuredate", function(value, element) {
    const today = new Date();
    today.setHours(0, 0, 0, 0);
    const inputDate = new Date(value);
    inputDate.setHours(0, 0, 0, 0); 
    return this.optional(element) || inputDate >= today;
}, "Date isn't in the future so like change it.");

jQuery.validator.unobtrusive.adapters.addSingleVal("futuredate", "param");