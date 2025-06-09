var input = document.getElementById("linkBox");
input.addEventListener("keyup", EnterBtnForLinkBox);

var input = document.getElementById("MessageBox");
input.addEventListener("keyup", EnterBtnForMessageBox);

document.addEventListener("DOMContentLoaded", function(){
    socket.emit('join', GetRoomId())
});