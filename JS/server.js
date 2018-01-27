const express = require('express');
const app = express();
const server = require('http').Server(app);
const io = require('socket.io')(server);
app.use(express.static('public'))

app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'hbs')

//expose API for Unity:
//POST /api/startround
	//--takes game data that needs to be transmitted
//GET /api/endround

//websockets:
//emit round start
//receive words
//emit round end
io.on('connect', socket => {

});

server.listen(3000);