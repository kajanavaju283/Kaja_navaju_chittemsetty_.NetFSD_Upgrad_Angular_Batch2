USE Ecommappdb;
GO

-- 1. Insert Categories
INSERT INTO categories (category_name)
VALUES ('Mountain Bikes'), ('Road Bikes'), ('Electric Bikes'), ('Accessories'), ('Kids Bikes');

-- 2. Insert Brands
INSERT INTO brands (brand_name)
VALUES ('Trek'), ('Giant'), ('Specialized'), ('Cannondale'), ('Scott');

-- 3. Insert Products
INSERT INTO products (product_name, brand_id, category_id, model_year, list_price)
VALUES 
('Marlin 7',1,1,2023,1200),
('Defy Advanced',2,2,2024,2200),
('Turbo Vado',3,3,2023,3500),
('Trail 5',4,1,2022,950),
('Aspect 940',5,1,2024,1100);

-- 4. Insert Customers (Now this will work!)
INSERT INTO customers (first_name, last_name, phone, email, street, city, state, zip_code)
VALUES
('Rahul','Sharma','9876543210','rahul@gmail.com','MG Road','Delhi','DL','11000'),
('Anita','Verma','9876543211','anita@gmail.com','Link Road','Mumbai','MH','40000'),
('Ravi','Kumar','9876543212','ravi@gmail.com','Banjara Hills','Hyderabad','TS','50008'),
('Sneha','Reddy','9876543213','sneha@gmail.com','Indiranagar','Bangalore','KA','56000'),
('Amit','Patel','9876543214','amit@gmail.com','Navrangpura','Ahmedabad','GJ','38000');

-- 5. Final Queries
-- Get Products with Brand and Category
SELECT p.product_name, b.brand_name, c.category_name, p.model_year, p.list_price
FROM products p
JOIN brands b ON p.brand_id=b.brand_id
JOIN categories c ON p.category_id=c.category_id;

-- Get Delhi Customers
SELECT * FROM customers WHERE city='Delhi';

-- Count Products per Category
SELECT c.category_name, COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p ON c.category_id=p.category_id
GROUP BY c.category_name;