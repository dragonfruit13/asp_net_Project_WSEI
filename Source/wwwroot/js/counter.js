"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("counterHub").build();

connection.on("updateCount", (userCount) => {
	let textMessage = document.getElementById("userCount");
	let count = document.createTextNode(userCount);
	textMessage.appendChild(count + " user")
});

connection.start();