
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("category").build();

let product = document.getElementById("product")
connection.on("updateUserCounter", (userCounter) => {
	let textMessage = document.getElementById("productUserCounter");
	let countUsers = document.createTextNode(userCounter);
	textMessage.appendChild(countUsers)
	console.log(countUsers)
	

});

if (product != null) {
	connection.start()
	
	
} else {
	console.log("no user on category page")
}





	

