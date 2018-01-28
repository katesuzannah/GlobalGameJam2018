const express = require('express');
const app = express();
const server = require('http').Server(app);
const io = require('socket.io')(server);
const path = require('path');
app.use(express.static('public'));

app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'hbs');

let isRoundActive = false;

let playersConnected = 0;

let wordsSubmitted = [];

app.get("/play", (req, res) => {
	console.log("player loaded");
	res.render("home", {roundactive: isRoundActive});
	// res.render("home");
});

//expose API for Unity:
//POST /api/startround
	//--takes game data that needs to be transmitted
app.post("/api/startround", (req, res) => {
	//TODO: register game data(will there be any?)
	//reply with number of players connected
	console.log('round starting');
	io.emit('startround', "round starting");
	isRoundActive = true;
	wordsSubmitted = [];
	res.json({players:playersConnected});
});

//GET /api/endround
app.get("/api/endround", (req, res) => {
	console.log('round ending');
	io.emit('endround', "round ending");
	isRoundActive = false;
	res.json({words:wordsSubmitted});
});

//websockets:
//emit round start (in app.post(startround))
//receive words
//emit round end (in app.get(endround))
io.on('connect', socket => {
	console.log("Player connected");
	playersConnected++;

	socket.on('word', data => {
		if (isRoundActive) {
			wordsSubmitted.push(data);
		}
	});

	socket.on('disconnect', () => {
		playersConnected--;
	});
});

server.listen(3000);