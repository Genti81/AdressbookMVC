// Write your JavaScript code.

function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('todayTime').innerHTML =
        h + ":" + m + ":" + s;
}
function checkTime(i) {
    if (i < 10) { i = "0" + i; }
    return i;
}
var d = new Date();
var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
document.getElementById("nameOfWeek").innerHTML = days[d.getDay()];

var t = setInterval(startTime, 1000);
