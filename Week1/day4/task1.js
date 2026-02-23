// 1. Store student marks in a variable
let marks = 85; 
let grade;

// 2. Use if-else statements to assign grades
if (marks >= 75) {
    grade = "Grade A";
} else if (marks >= 60) {
    grade = "Grade B";
} else if (marks >= 40) {
    grade = "Grade C";
} else {
    grade = "Fail";
}

// 3. Display the output in the console
console.log("Student Marks: " + marks);
console.log("Final Result: " + grade);