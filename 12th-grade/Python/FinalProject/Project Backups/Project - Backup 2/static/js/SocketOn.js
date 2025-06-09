var socket = io();
// var ignore_next_event = false;
// var cookie = require("cookies");
socket.on('connect', function() {
	console.log("Connecting");
});
socket.on('listen', function(data) {
	console.log("Connected");
});
/*socket.on('disconnect', function() {
	socket.emit('test');
});*/
socket.on('Change Video', function(data) {
	playerPreloading = true;
	neededState = data['lastPlayerState'];
	player.loadVideoById({videoId: data['videoId'], startSeconds: data['currentTime']});
});
socket.on('Play', function(data) {
	console.log("Received event: Play");
	player.seekTo(data);
	player.playVideo();
});
socket.on('Pause', function(data) {
	console.log("Received event: Pause");
	player.pauseVideo();
	player.seekTo(data);
});
socket.on('change playback rate', function(data) {
	console.log("Received event: Change Playback Rate");
	player.setPlaybackRate(data);
});
socket.on('get current time', function(data) {
	data['currentTime'] = player.getCurrentTime();
	data['playbackRate'] = player.getPlaybackRate();
	data['lastPlayerState'] = lastPlayerState;
	socket.emit('update player', data);
});
socket.on('Change Time', function(data) {
	console.log("Received event: Change Time");
	player.seekTo(data['currentTime']);
});
socket.on('New Message', function(data) {
	console.log("Received message");
	var para = document.createElement("p");
	var node = document.createTextNode(data);
	para.appendChild(node);
	para.setAttribute("class", "text-break");

	var element = document.getElementById("ChatMessages");
	var shouldScroll = element.scrollTop + element.clientHeight === element.scrollHeight;
	element.appendChild(para);
		
	// automatically scroll down chat if at the bottom of the scroller
	if (shouldScroll) {
		element.scrollTop = element.scrollHeight;
	}
});
socket.on('Update Video History', function(data) {
	// <img src="https://img.youtube.com/vi/AWEm4tA2hMc/maxresdefault.jpg" style="max-width: 240px; max-height: 120px;" class="img-thumbnail rounded" alt="Responsive image">
	var thumbnail = document.createElement("img");
	imgLink = "https://img.youtube.com/vi/" + data + "/maxresdefault.jpg";
	thumbnail.setAttribute("src", imgLink);
	thumbnail.style.maxWidth = "240px";
	thumbnail.style.maxHeight = "120px";
	thumbnail.setAttribute("class", "img-thumbnail rounded");
	thumbnail.setAttribute("alt", "Responsive image");
	
	var para = document.createElement("span");
	// var para = document.createElement("p");
	var videoLink = "www.youtube.com/watch?v=" + data;
	var node = document.createTextNode(videoLink);
	para.appendChild(node);
	para.setAttribute("class", "text-break");

	var element = document.getElementById("videoHistory");
	var shouldScroll = element.scrollTop + element.clientHeight === element.scrollHeight;
	
	var container = document.createElement("div");
	container.setAttribute("display", "flex");
	container.setAttribute("align-items", "center");
	
	container.appendChild(thumbnail);
	container.appendChild(para);
	element.appendChild(container);
	
	// automatically scroll down chat if at the bottom of the scroller
	if (shouldScroll) {
		element.scrollTop = element.scrollHeight;
	}
});