// 1. Store a number in a variable
let num = 5; 

console.log("--- Number Analysis for: " + num + " ---");

// 2. Use conditional (ternary) operator to check: Positive or Negative
let positivity = (num >= 0) ? "Positive" : "Negative";
console.log("Positivity: " + positivity);

// 3. Use if-else to check: Even or Odd
if (num % 2 === 0) {
    console.log("Parity: Even");
} else {
    console.log("Parity: Odd");
}

// 4. Use a loop to print all numbers from 1 to the given number
console.log("Counting from 1 to " + num + ":");

if (num < 1) {
    console.log("Number is less than 1, cannot count up.");
} else {
    for (let i = 1; i <= num; i++) {
        console.log(i);
    }
}