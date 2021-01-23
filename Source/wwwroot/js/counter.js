"use strict"

import { signalR } from "./signalr/dist/browser/signalr"

var connection = new signalR.HubConnectionBuilder().withUrl("/CountUser").build();

connection.on("updateCounter", (userCounter) => {
    let textMessage = document.getElementById("userCounter");
    let count = document.createTextNode(userCounter);
    textMessage.appendChild(count);
});

connection.start();