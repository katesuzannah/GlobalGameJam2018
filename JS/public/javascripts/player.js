const socket = io();

// function setDisplay(element) {
// 	element.style.display = element.style.display==="none" ? "inline" : "none";
// }

function main() {
	const submitButton = document.querySelector(".submitbtn");
	const text = document.querySelector(".word");

	submitButton.classList.add("invis");
	text.classList.add("invis");
	// submitButton.setAttribute("display", "none");
	// text.setAttribute("display", "none");

	socket.on("startround", (data) => {
		console.log("starting round");
		submitButton.classList.remove("invis");
		text.classList.remove("invis");
	});

	socket.on("endround", (data) => {
		console.log("ending round");
		submitButton.classList.add("invis");
		text.classList.add("invis");
	});

	submitButton.addEventListener("click", () => {
		console.log("clicky");
		event.preventDefault();
		let submission = text.value;
		//TODO: sanitize input (check against dictionary?)
		socket.emit('word', submission);
		submitButton.classList.add("invis");
	});
}

document.addEventListener("DOMContentLoaded", main);

