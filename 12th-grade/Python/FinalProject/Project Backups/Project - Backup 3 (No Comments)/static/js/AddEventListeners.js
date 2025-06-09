var input = document.getElementById("linkBox");
input.addEventListener("keyup", EnterBtnForLinkBox);

var input = document.getElementById("MessageBox");
input.addEventListener("keyup", EnterBtnForMessageBox);

document.addEventListener("DOMContentLoaded", function(){
	$("#submitButton").prop("disabled", true);
    $('#staticBackdrop').modal('toggle');
});

// JavaScript for disabling form submissions if there are invalid fields
(function () {
  'use strict'

  // Fetch all the forms we want to apply custom Bootstrap validation styles to
  var forms = document.querySelectorAll('.needs-validation')

  // Loop over them and prevent submission
  Array.prototype.slice.call(forms)
    .forEach(function (form) {
      form.addEventListener('submit', function (event) {
        if (!form.checkValidity()) {
          event.preventDefault()
          event.stopPropagation()
        }

        form.classList.add('was-validated')
      }, false)
    })
})()

window.onbeforeunload = function () {
	socket.emit('leave', {'roomId': GetRoomId(), 'username': document.getElementById("usernameInput").value});
}