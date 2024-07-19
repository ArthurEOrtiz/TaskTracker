$(document).ready(function () {
  // Listen for when the modal is fully shown
  $('#createTaskModal').on('shown.bs.modal', function () {
    // Initialize or reinitialize the form validation
    //initializeFormValidation();
     $.validator.addMethod("futuredate", function(value, element) {
         const today = new Date();
         today.setHours(0, 0, 0, 0);
         const inputDate = new Date(value);
         inputDate.setHours(0, 0, 0, 0); 
         return this.optional(element) || inputDate >= today;
     }, "Date isn't in the future so like change it.");

    $.validator.unobtrusive.adapters.addSingleVal("futuredate", "param");

    $.validator.unobtrusive.parse('#createForm'); 

    $('#createForm').validate();
    

    console.log("Modal is fully shown");
  });
});


function initializeFormValidation() {
    console.log("Initializing form validation for:", $('#createForm').length ? "Form found" : "Form NOT found");
    // $('#createForm').validate({
    //     rules: {
    //         'UserTask.DueDate': { 
    //             futuredate: true 
    //         }
    //     },
    //     submitHandler: function (form, event) {
    //         console.log("Form is valid - submitting");
    //         event.preventDefault();
       
            
    //         // Uncomment to actually submit the form
    //         // form.submit();
            
    //     },
    //     invalidHandler: function(event, validator) {
    //         console.log("Form is not valid - prevent default", validator.numberOfInvalids(), "invalid fields");
    //         event.preventDefault();
    //     }
    // });
    
}
