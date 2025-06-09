// 5. The API calls this function when the player's state changes.
function onPlayerStateChange(event){
	console.log("StateChange: ", event.data);
	
	//currentTime = player.getCurrentTime();
	
	if (event.data == YT.PlayerState.PLAYING) {
		if (preloading) {
			player.pauseVideo();
			//player.seekTo(0);
			player.unMute();
			document.getElementById("player").style.display = "block"; // unhides the player
			preloading = false;
		}
		else {
			console.log(ignore_next_event);
			if (!ignore_next_event) {
				socket.emit('Play Player', {'currentTime': player.getCurrentTime(), "roomId": GetRoomId()});
			}
			else {
				ignore_next_event = true;
				console.log("Ignored event: Play");
			}
		}
	}
	else if (event.data == YT.PlayerState.PAUSED) {
		if (!preloading) {
			console.log(ignore_next_event);
			if (!ignore_next_event) {
				socket.emit('Pause Player', {'currentTime': player.getCurrentTime(), "roomId": GetRoomId()});
			}
			else {
				ignore_next_event = true;
				console.log("Ignored event: Pause");
			}
		}
	}
	else if (event.data == YT.PlayerState.BUFFERING) {
		if (!preloading) {
			socket.emit('Pause Player', {'currentTime': -1, "roomId": GetRoomId()});
		}
	}
	else if (event.data == YT.PlayerState.CUED) {
		if (!preloading) {
			socket.emit('Pause Player', {'currentTime': -1, "roomId": GetRoomId()});
		}
	}
	else if (event.data == YT.PlayerState.ENDED) {
		socket.emit('Pause Player', {'currentTime': -1, "roomId": GetRoomId()});
	}
}

/* ------------------------------------------------- */

function EnterBtnForLinkBox(event) {
	if (event.keyCode === 13) { // keyCode for enter key
		event.preventDefault();
		document.getElementById("linkButton").click();
	}
}

function SendPlayerLink() {
	socket.emit('Send Link', {"videoId": document.getElementById("linkBox").value, "roomId": GetRoomId()});
}

function EnterBtnForMessageBox(event) {
	if (event.keyCode === 13) { // keyCode for enter key
		event.preventDefault();
		document.getElementById("MessageButton").click();
	}
}

function SendChatMessage() {
	socket.emit('Send Message', {"message": document.getElementById("MessageBox").value, "roomId": GetRoomId()});
}

function GetRoomId() {
	// console.log(window.location.pathname.split('/')[2])
	return window.location.pathname.split('/')[2];
}