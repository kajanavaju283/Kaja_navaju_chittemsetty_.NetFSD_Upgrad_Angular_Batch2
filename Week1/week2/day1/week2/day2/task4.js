/**
 * PROBLEM 4: Task Manager with Async Storage (LEVEL-2)
 */

// 1. Store tasks in an array
let tasks = ["Buy groceries", "Finish assignment"];

// --- STEP 1: Callback Version (Simulating Async Storage) ---
const addTaskCallback = (newTask, callback) => {
    setTimeout(() => {
        tasks.push(newTask);
        console.log(`Task added (Callback): ${newTask}`);
        callback();
    }, 1000);
};

// --- STEP 2: Promise Version (Converting Callback to Promise) ---
const addTaskPromise = (newTask) => {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (newTask) {
                tasks.push(newTask);
                resolve(`Task added (Promise): ${newTask}`);
            } else {
                reject("Task cannot be empty!");
            }
        }, 1000);
    });
};

// --- STEP 3: Async/Await Version (Refactored) ---
const listTasks = () => {
    console.log("Current Tasks:", tasks.join(", "));
};

const deleteTaskAsync = async (taskName) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks = tasks.filter(t => t !== taskName);
            resolve(`Task deleted: ${taskName}`);
        }, 1000);
    });
};

const runTaskManager = async () => {
    try {
        console.log("--- Starting Task Manager ---");
        
        // Using Async/Await to add
        const addMsg = await addTaskPromise("Learn JavaScript ES6");
        console.log(addMsg);

        // Using Async/Await to delete
        const delMsg = await deleteTaskAsync("Buy groceries");
        console.log(delMsg);

        // Displaying final list using Template Literals
        console.log(`Summary: You have ${tasks.length} tasks remaining.`);
        listTasks();

    } catch (error) {
        console.error(`Error: ${error}`);
    }
};

// Execute the application
runTaskManager();