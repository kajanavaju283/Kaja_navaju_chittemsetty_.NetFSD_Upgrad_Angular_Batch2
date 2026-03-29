// 1. Store purchase amount
let purchaseAmount = 5500; 
let discount = 0;

// 2. Apply discount rules
if (purchaseAmount >= 5000) {
    discount = purchaseAmount * 0.20; // 20% discount
} else if (purchaseAmount >= 3000) {
    discount = purchaseAmount * 0.10; // 10% discount
} else {
    discount = 0;
}

// 3. Calculate final payable amount
let finalAmount = purchaseAmount - discount;

// 4. Display results
console.log("Purchase Amount: " + purchaseAmount);
console.log("Discount Amount: " + discount);
console.log("Final Payable Amount: " + finalAmount);