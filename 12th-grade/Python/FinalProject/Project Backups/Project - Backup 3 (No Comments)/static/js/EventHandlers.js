// 5. The API calls this function when the player's state changes.
var lastPlayerState;
var neededState;
function onPlayerStateChange(event){
	console.log("StateChange: ", event.data);
	
	// currentTime = player.getCurrentTime();
	
	// console.log("preloading: " + preloading);
	// console.log("player preloading: " + playerPreloading);
	// console.log(lastPlayerState);
	console.log(neededState);
	
	if (event.data == YT.PlayerState.PLAYING) {
		if (preloading) {
			player.pauseVideo();
			//player.seekTo(0);
			player.unMute();
			document.getElementById("player").style.display = "block"; // unhides the player
			// preloading = false;
			$("#submitButton").prop("disabled", false);
		}
		else if (!playerPreloading) {
			socket.emit('Change Player State', {'state': 'Play', 'currentTime': player.getCurrentTime(), 'roomId': GetRoomId(), 'username': document.getElementById("usernameInput").value});
		}
		if (neededState == YT.PlayerState.PAUSED) {
			neededState = null;
			player.pauseVideo();
		}
	}
	else if (event.data == YT.PlayerState.PAUSED) {
		if (playerPreloading) {
			playerPreloading = false;
		}
		if (!(preloading || playerPreloading)) {
			socket.emit('Change Player State', {'state': 'Pause', 'currentTime': player.getCurrentTime(), 'roomId': GetRoomId(), 'username': document.getElementById("usernameInput").value});
		}
	}
	else if (event.data == YT.PlayerState.BUFFERING) {
		if (!(preloading || playerPreloading)) {
			socket.emit('Change Player State', {'state': 'Buffering', 'currentTime': player.getCurrentTime(), 'roomId': GetRoomId()});
		}
	}
	else if (event.data == YT.PlayerState.CUED) {
		if (!(preloading || playerPreloading)) {
			socket.emit('Change Player State', {'state': 'Pause', 'currentTime': -1, 'roomId': GetRoomId()});
		}
	}
	else if (event.data == YT.PlayerState.ENDED) {
		socket.emit('Change Player State', {'state': 'Pause', 'currentTime': -1, 'roomId': GetRoomId()});
	}
	else if (event.data == -1) { // video unstarted
	}
	lastPlayerState = event.data;
}

function onPlaybackRateChange(event) {
	socket.emit('Change Playback Rate', {'playback rate': player.getPlaybackRate() , 'roomId': GetRoomId()})
}

/* ------------------------------------------------- */
var username;

function EnterBtnForLinkBox(event) {
	if (event.keyCode === 13) { // keyCode for enter key
		event.preventDefault();
		document.getElementById("linkButton").click();
	}
}

function SendPlayerLink() {
	var videoLink = document.getElementById("linkBox").value;
	if (videoLink != "") {
		socket.emit('Send Link', {"videoId": videoLink, "roomId": GetRoomId(), 'username': document.getElementById("usernameInput").value});
		document.getElementById("linkBox").value = ""; // clears link box
	}
}

$(document).ready(function() {
  $("#submitButton").click(function(e){
	if (document.getElementById("usernameInput").value != '') {
		socket.emit('join', {'roomId': GetRoomId(), 'username': document.getElementById("usernameInput").value, 'videoId': player.getVideoUrl()});
		preloading = false;
		$('#staticBackdrop').modal('toggle');
		e.preventDefault();
	}
  });
});

/*
function JoinWithUsername() {
	if (document.getElementById("usernameInput").value != '') {
		e.preventDefault();
		socket.emit('join', {'roomId': GetRoomId(), 'username': document.getElementById("usernameInput").value, 'videoId': player.getVideoUrl()});
		preloading = false;
	}
}
*/

function EnterBtnForMessageBox(event) {
	if (event.keyCode === 13) { // keyCode for enter key
		event.preventDefault();
		document.getElementById("MessageButton").click();
	}
}

function SendChatMessage() {
	var msg = document.getElementById("MessageBox").value;
	if (msg != "") {
		socket.emit('Send Message', {"message": msg, "roomId": GetRoomId(), 'username': document.getElementById("usernameInput").value});
		document.getElementById("MessageBox").value = ""; // clears chat box
	}
}

function GetRoomId() {
	// console.log(window.location.pathname.split('/')[2])
	return window.location.pathname.split('/')[2];
}

function ChangeButtonSelection(clickedId) {
	var elements = document.getElementsByClassName("Select_Rect");
	for(var i = 0; i < elements.length; i++) {
		elements[i].classList.remove("selected");
	}
	document.getElementById(clickedId).classList.add("selected");
}