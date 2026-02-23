// 1. Store signal color in a variable
let signalColor = "green"; 

// 2. Use a switch statement to display instructions
// Note: .toLowerCase() helps handle inputs like "RED" or "Red"
switch (signalColor.toLowerCase()) {
    case "red":
        console.log("Stop");
        break;
    
    case "yellow":
        case "amber": // Extra: handling common variations
        console.log("Get Ready");
        break;
    
    case "green":
        console.log("Go");
        break;
    
    // 3. Handle invalid signal input gracefully
    default:
        console.log("Invalid Input: Please enter 'red', 'yellow', or 'green'.");
}