// Requirement: Use a global variable to store counter value
let count = 0;

// Requirement: A function incrementCounter(step)
// Requirement: Accepts step value as a parameter
function incrementCounter(step) {
    // Update the global counter
    count += step;

    // Requirement: DOM updates must happen inside functions only
    updateDisplay();
}

function resetCounter() {
    // Requirement: Reset button should reset the counter to 0
    count = 0;
    updateDisplay();
}

// Helper function to update the HTML text
function updateDisplay() {
    document.getElementById("counterValue").innerText = count;
}

// Requirement: No inline JavaScript in HTML
// We use Event Listeners instead
document.getElementById("incrementBtn").addEventListener("click", function() {
    incrementCounter(1); // Passing 1 as the 'step' parameter
});

document.getElementById("resetBtn").addEventListener("click", resetCounter);