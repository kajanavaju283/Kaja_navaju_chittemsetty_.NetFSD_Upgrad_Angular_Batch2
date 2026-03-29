/**
 * PROBLEM 2: Product Cart Summary (LEVEL-1)
 */

// 1. Store product objects in an array
const cart = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 1500, quantity: 2 },
    { name: "Keyboard", price: 3000, quantity: 1 }
];

// 2. Use arrow functions and reduce() to calculate total cart value
// Requirement: Must use map() and reduce()
const calculateTotal = (items) => {
    return items
        .map(item => item.price * item.quantity) // Get total for each item
        .reduce((total, current) => total + current, 0); // Sum them up
};

// 3. Display formatted invoice using template literals
const displayInvoice = (items) => {
    console.log(`--- PRODUCT INVOICE ---`);
    
    items.forEach(item => {
        console.log(`Item: ${item.name} | Qty: ${item.quantity} | Price: ${item.price}`);
    });

    const totalValue = calculateTotal(items);
    console.log(`-----------------------`);
    console.log(`Total Cart Value: ₹${totalValue}`);
    console.log(`-----------------------`);
};

// 4. Export (as per requirement: Export calculation function from a module)
// Note: In Node.js environment, we use module.exports
// In ES6 Browser modules, we use 'export'
// export { calculateTotal }; 

// Execute to see output
displayInvoice(cart);