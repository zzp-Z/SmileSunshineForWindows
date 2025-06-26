USE smile_sunshine;

-- Create basic departments
INSERT INTO department (name, description)
VALUES ('Management Department', 'Responsible for overall company management and administrative work'),
       ('Production Department', 'Responsible for product production and quality control'),
       ('Sales Department', 'Responsible for product sales and customer relationship management');

-- Create basic roles
INSERT INTO role (role_name, department_id, description)
VALUES ('Administrator', 1, 'System administrator with system management permissions, no business production permissions'),
       ('Production Worker', 2, 'Responsible for basic product production work'),
       ('Production Supervisor', 2, 'Responsible for production team management and coordination'),
       ('Sales Representative', 3, 'Responsible for product sales and customer communication'),
       ('Sales Manager', 3, 'Responsible for sales team management and sales strategy development');

-- Create administrator account
INSERT INTO user (username, password, real_name, gender, email, phone)
VALUES ('admin', '123123', 'Administrator', 'MALE','admin@smileshine.com', '13800000000');

-- Bind administrator account and administrator role
INSERT INTO user_role (user_id, role_id)
VALUES (1, 1);
-- Assuming admin user ID is 1, administrator role ID is 1

-- Add basic permissions
INSERT INTO permission (permission_name, api_path, description)
VALUES ('User Management', '/api/users', 'Permission to manage system users'),
       ('Role Management', '/api/roles', 'Permission to manage system roles'),
       ('Department Management', '/api/departments', 'Permission to manage system departments'),
       ('Product Management', '/api/products', 'Permission to manage products'),
       ('Order Management', '/api/orders', 'Permission to manage sales orders'),
       ('Production Plan Management', '/api/production-plans', 'Permission to manage production plans');

-- Assign all permissions to administrator role
INSERT INTO role_permission (role_id, permission_id)
VALUES (1, 1), -- Administrator role has user management permission
       (1, 2), -- Administrator role has role management permission
       (1, 3);
-- Administrator role has department management permission

-- Assign corresponding permissions to other roles
INSERT INTO role_permission (role_id, permission_id)
VALUES (3, 6), -- Production supervisor has production plan management permission
       (5, 5); -- Sales manager has order management permission