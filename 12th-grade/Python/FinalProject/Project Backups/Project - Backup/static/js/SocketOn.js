var socket = io();
var ignore_next_event = false;
// var cookie = require("cookies");
socket.on('connect', function() {
	console.log("Connecting");
});
socket.on('listen', function(data) {
	console.log("Connected");
});
socket.on('Change Video', function(data) {
	document.getElementById("linkBox").value = ""; // clears link box
	player.loadVideoById({videoId:data, startSeconds:0});
});
socket.on('Play', function(data) {
	console.log("Received event: Play");
	player.seekTo(data);
	player.playVideo();
	ignore_next_event = true;
});
socket.on('Change Time', function(data) {
	console.log("Received event: Change Time");
	player.seekTo(data);
});
socket.on('Pause', function(data) {
	console.log("Received event: Pause");
	player.pauseVideo();
	player.seekTo(data);
	ignore_next_event = false;
});
socket.on('New Message', function(data) {
	console.log("Received message");
	var para = document.createElement("p");
	var node = document.createTextNode(data);
	para.appendChild(node);

	var element = document.getElementById("ChatMessages");
	element.appendChild(para);
	
	document.getElementById("MessageBox").value = ""; // clears chat box
});