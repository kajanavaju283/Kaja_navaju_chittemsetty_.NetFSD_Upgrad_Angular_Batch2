// 1. Requirement: Create a student object with properties
let student = {
    name: "Suresh",
    rollNo: "A101",
    marks: 85
};

// 2. Requirement: Create a function updateStudentProfile(studentObj)
// Requirement: Accepts the object as a parameter
function updateStudentProfile(studentObj) {
    // Technical Constraint: Use document.getElementById for DOM manipulation
    const profileDiv = document.getElementById("studentProfile");

    // Requirement: Displays details in a styled <div>
    // Technical Constraint: DOM elements should be updated dynamically
    profileDiv.innerHTML = `
        <div style="border: 2px solid blue; padding: 15px; width: 250px; border-radius: 10px; background-color: #f0f8ff;">
            <h3 style="margin-top: 0;">Student Profile</h3>
            <p><strong>Name:</strong> ${studentObj.name}</p>
            <p><strong>Roll No:</strong> ${studentObj.rollNo}</p>
            <p><strong>Marks:</strong> ${studentObj.marks}</p>
        </div>
    `;
}

// 3. Requirement: Add another function updateMarks(newMarks)
function updateMarks(newMarks) {
    // Requirement: Updates marks property of the object
    student.marks = newMarks;

    // Requirement: Refreshes the display
    updateStudentProfile(student);
}

// Requirement: Ensure the profile shows up when the script loads
updateStudentProfile(student);s