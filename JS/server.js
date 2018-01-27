const express = require('express');
const app = express();
const server = require('http').Server(app);
const io = require('socket.io')(server);
app.use(express.static('public'))

app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'hbs')

let roundTrigger = false;
let isRoundActive = false;

let playersConnected = 0;

let wordsSubmitted = [];

//expose API for Unity:
//POST /api/startround
	//--takes game data that needs to be transmitted
app.post("/api/startround", (req, res) => {
	//TODO: register game data(will there be any?)
	//reply with number of players connected
	console.log('round starting');
	io.emit('startround', "round starting");
	res.json({players:playersConnected});
});

//GET /api/endround
app.get("/api/endround", (req, res) => {
	console.log('round ending');
	//TODO: hook into socket
	res.json({words:wordsSubmitted});
});

//websockets:
//emit round start
//receive words
//emit round end
io.on('connect', socket => {
	playersConnected++;

	socket.on('disconnect', () => {
		playersConnected--;
	});
});

server.listen(3000);