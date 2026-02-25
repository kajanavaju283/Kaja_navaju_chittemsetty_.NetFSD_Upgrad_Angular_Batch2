// Student Marks Analyzer

// Requirement: Store student marks in an array
const studentMarks = [85, 92, 78, 60, 45];

// Requirement: Use arrow functions for calculations
// Requirement: Must use array methods like reduce()
const calculateTotal = (marks) => marks.reduce((acc, curr) => acc + curr, 0);

// Requirement: Calculate average marks
const calculateAverage = (marks) => calculateTotal(marks) / marks.length;

// Logic to determine pass/fail based on average
const getResult = (average) => (average >= 50 ? "Passed" : "Failed");

// Requirement: Display output using template literals
const displaySummary = (marks) => {
    const total = calculateTotal(marks);
    const average = calculateAverage(marks);
    const result = getResult(average);

    console.log(`--- Student Marks Report ---`);
    console.log(`Total Marks: ${total}`);
    console.log(`Average Marks: ${average.toFixed(2)}`);
    console.log(`Final Result: ${result}`);
};

// Execute the function
displaySummary(studentMarks);