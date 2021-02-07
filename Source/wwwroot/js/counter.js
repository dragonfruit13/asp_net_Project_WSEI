﻿
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("counterHub").build();

connection.on("updateCounter", (userCount) => {
	let textMessage = document.getElementById("counter");
	let count = document.createTextNode(userCount);
	textMessage.appendChild(count)
});

connection.start()
	

