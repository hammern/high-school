// 2. This code loads the IFrame Player API code asynchronously.
var tag = document.createElement('script');

tag.src = "https://www.youtube.com/player_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

// 3. This function creates an <iframe> (and YouTube player)
//    after the API code downloads.
var player;
document.getElementById("player").style.display = "none"; // hides the player
function onYouTubeIframeAPIReady() {
	player = new YT.Player('player', {
		playerVars: {
			modestbranding: 1,
			rel: 1
			// start: 0,
			// mute: 1 // allows autoplay
		},
		width: '1280',
		height: '720',
		videoId: 'AWEm4tA2hMc',
		events: {
			'onReady': onPlayerReady,
			'onStateChange': onPlayerStateChange,
			'onPlaybackRateChange': onPlaybackRateChange
		}
	});
}

var preloading = false;
var playerPreloading = false;
// 4. The API will call this function when the video player is ready.
function onPlayerReady(event) {
	console.log("Player Ready");
	preloading = true;
	player.mute();
	player.seekTo(0);
}
