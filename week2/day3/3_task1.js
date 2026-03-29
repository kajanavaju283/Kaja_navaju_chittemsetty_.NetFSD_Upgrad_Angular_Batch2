// 1. Select the button and the message element from the DOM
const feedbackBtn = document.getElementById('feedbackBtn');
const messageDisplay = document.getElementById('confirmationMessage');

// 2. Add an event listener for the 'click' event
feedbackBtn.addEventListener('click', function() {
    
    // 3. Update the text content of the paragraph dynamically
    messageDisplay.textContent = "Thank you! Your feedback has been submitted successfully.";
    
    // Optional: Log to console to verify
    console.log("Feedback submitted.");
});