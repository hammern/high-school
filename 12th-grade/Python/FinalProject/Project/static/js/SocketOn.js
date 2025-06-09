var socket = io();
socket.on('connect', function() {
	console.log("Connecting");
});
socket.on('listen', function(data) {
	console.log("Connected");
});
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
	para.classList.add("text-break");
	
	if (data.split(":")[0] == "SERVER") {
		para.classList.add("Server_Message_Text");
	}
	else {
		para.classList.add("Message_Text");
	}
	
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
	thumbnail.style.maxWidth = "150px";
	thumbnail.style.maxHeight = "100px";
	thumbnail.setAttribute("class", "rounded");
	thumbnail.setAttribute("alt", "Responsive image");
	thumbnail.classList.add("Video_Thumbnail");
	
	var para = document.createElement("span");
	// var para = document.createElement("p");
	var videoLink = "www.youtube.com/watch?v=" + data;
	var node = document.createTextNode(videoLink);
	para.appendChild(node);
	para.classList.add("text-break");
	para.classList.add("Video_History_Text");

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
socket.on('Update Current Users', function(data) {
	var para = document.createElement("p");
	var node = document.createTextNode(data);
	para.appendChild(node);
	para.classList.add("text-break");
	para.classList.add("Message_Text");
	para.classList.add("Current_User");
	
	var element = document.getElementById("UserList");
	var shouldScroll = element.scrollTop + element.clientHeight === element.scrollHeight;
	element.appendChild(para);
		
	// automatically scroll down chat if at the bottom of the scroller
	if (shouldScroll) {
		element.scrollTop = element.scrollHeight;
	}
});
socket.on('Delete Leaving User', function(data) {
	$(".Current_User").each(function(i, elem) {
		if (elem.textContent == data) {
			document.getElementById("UserList").removeChild(document.getElementById("UserList").childNodes[i]);
		}
	});
});