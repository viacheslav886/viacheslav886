let minutes = 25;
let seconds = 0;
let isRunning = false;
let interval;

const minutesEl = document.getElementById("minutes");
const secondsEl = document.getElementById("seconds");
const startBtn = document.getElementById("startBtn");

startBtn.addEventListener("click", () => {
    if (isRunning) return;

    isRunning = true;
    interval = setInterval(updateTimer, 1000);
});

function updateTimer() {
    if (seconds === 0) {
        if (minutes === 0) {
            clearInterval(interval);
            alert("Time to rest!");
            isRunning = false;
            return;
        }
        minutes--;
        seconds = 59;
    } else {
        seconds--;
    }

    minutesEl.textContent = String(minutes).padStart(2, "0");
    secondsEl.textContent = String(seconds).padStart(2, "0");
}
