CREATE DATABASE smile_sunshine;
USE smile_sunshine;

-- ======================================================User
Create Table department
(
    id          INT PRIMARY KEY AUTO_INCREMENT COMMENT 'Department ID，PK，Primary key, auto-incrementing',
    name        VARCHAR(255) NOT NULL COMMENT 'Department Name',
    description TEXT COMMENT 'Department Description (Optional)',
    created_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation Time, defaults to current timestamp',
    updated_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time, auto-updates on change'
) COMMENT ='Department Information Table';

Create Table user
(
    id        INT PRIMARY KEY AUTO_INCREMENT COMMENT 'User ID, Primary Key, Auto-incrementing',
    username  VARCHAR(50)  NOT NULL COMMENT 'Username, Unique Identifie',
    password  VARCHAR(255) NOT NULL COMMENT 'User Password, Stored Encrypted',
    email     VARCHAR(100) COMMENT 'User Email (Optional)',
    phone     VARCHAR(20) COMMENT 'User Phone Number (Optional)',
    real_name VARCHAR(50) NOT NULL COMMENT 'User Real Name, for Display',
    gender     ENUM ('male', 'female') NOT NULL COMMENT 'User Gender, Enum Type, Options: male, female',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation Time, defaults to current timestamp',
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time, auto-updates on change'
) COMMENT ='User Information Table';

Create Table role
(
    id          INT PRIMARY KEY AUTO_INCREMENT COMMENT 'Role ID, Primary Key, Auto-incrementing',
    role_name   VARCHAR(50) NOT NULL COMMENT 'Role Name, e.g., Administrator, Regular User',
    department_id INT COMMENT 'Department ID, Foreign key referencing department table',
    description TEXT COMMENT 'Role Description (Optional)',
    created_at   TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation Time, defaults to current timestamp',
    updated_at   TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time, auto-updates on change',
    FOREIGN KEY (department_id) REFERENCES department (id)
) COMMENT ='Role Information Table';

Create Table permission
(
    id              INT PRIMARY KEY AUTO_INCREMENT COMMENT 'Permission ID, Primary Key, Auto-incrementing',
    permission_name VARCHAR(100) NOT NULL COMMENT 'Permission Name, e.g., API Access Permission',
    api_path        VARCHAR(255) NOT NULL COMMENT '对应的API路径',
    description     TEXT COMMENT 'Corresponding API Path',
    created_at      TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation Time, defaults to current timestamp',
    updated_at      TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time, auto-updates on change'
) COMMENT ='Permission Information Table';

CREATE TABLE user_role
(
    user_id INT NOT NULL COMMENT 'User ID, Foreign key referencing user table',
    role_id INT NOT NULL COMMENT 'Role ID, Foreign key referencing role table',
    PRIMARY KEY (user_id, role_id),
    FOREIGN KEY (user_id) REFERENCES user (id),
    FOREIGN KEY (role_id) REFERENCES role (id)
) COMMENT ='User-Role Relationship Table';

CREATE TABLE role_permission
(
    role_id       INT NOT NULL COMMENT 'Role ID, Foreign key referencing role table',
    permission_id INT NOT NULL COMMENT 'Permission ID, Foreign key referencing permission table',
    PRIMARY KEY (role_id, permission_id),
    FOREIGN KEY (role_id) REFERENCES role (id),
    FOREIGN KEY (permission_id) REFERENCES permission (id)
) COMMENT ='Role-Permission Relationship Table';

-- ======================================================Material

Create Table supplier
(
    id                 int primary key auto_increment not null,
    reliability_rating int,
    name               varchar(100),
    contact_name       varchar(100),
    phone              varchar(100),
    address            varchar(100),
    email              varchar(100)
);

Create Table material
(
    id                 int primary key auto_increment not null,
    material_number    varchar(100),
    description        varchar(100),
    unit_of_measure    varchar(100),
    quantity_in_stock  int,
    reorder_level      int,
    reorder_quantity   int,
    last_received_date date
);
Create Table procurement_order
(
    id                 int primary key auto_increment not null,
    order_number       varchar(100),
    unit_price_cents   int,
    number_of_units    int,
    total_amount_cents int,
    supplier_id        int,
    material_id        int,
    order_date         date,
    delivery_date      date,
    payment_terms      varchar(100),
    status             enum ('pending', 'completed', 'cancelled'),
    foreign key (supplier_id) references supplier (id),
    foreign key (material_id) references material (id)
);
Create Table inventory_record
(
    id            int primary key auto_increment not null,
    material_id   int,
    type          enum ('purchase', 'used'),
    record_number varchar(100),
    quantity      int,
    date          date,
    description   varchar(100),
    foreign key (material_id) references material (id)
);

-- ======================================================Design
Create Table design_concept
(
    id          int primary key auto_increment not null,
    name        varchar(100),
    description varchar(100),
    image_url   varchar(100),
    create_date date,
    feasibility int,
    status      enum ('pending', 'approved', 'rejected')
);

Create Table prototype
(
    id            int primary key auto_increment not null,
    concept_id    int,
    description   varchar(100),
    prototype_url varchar(100),
    create_date   date,
    feasibility   int,
    status        enum ('pending', 'approved', 'rejected'),
    test_result   enum ('pending', 'pass', 'fail'),
    safety_result enum ('pending', 'pass', 'fail'),
    foreign key (concept_id) references design_concept (id)
);

Create Table prototype_comment
(
    id           int primary key auto_increment not null,
    prototype_id int,
    comment      varchar(100),
    create_date  date,
    foreign key (prototype_id) references prototype (id)
);
-- ======================================================Product

Create Table product
(
    id                   int primary key auto_increment not null,
    name                 varchar(100),
    description          varchar(100),
    price_cents          int,
    image_url            varchar(100),
    safety_certification boolean,
    create_date          date,
    is_public            boolean default true,
    design_id            INT,
    foreign key (design_id) references design_concept (id)
);
-- ======================================================Production Plan
Create Table material_of_product
(
    id          int primary key auto_increment not null,
    product_id  int,
    material_id int,
    quantity    int,
    foreign key (product_id) references product (id),
    foreign key (material_id) references material (id),
    unique (product_id, material_id)
);

Create Table production_plan
(
    id                 int primary key auto_increment not null,
    product_id         int,
    plan_date          date,
    start_date         date,
    end_date           date,
    number_of_products int,
    status             enum ('pending', 'in_progress', 'completed', 'cancelled'),
    foreign key (product_id) references product (id)
);

Create Table production_process
(
    id                  int primary key auto_increment not null,
    production_plan_id  int,
    name                varchar(100),
    process_description varchar(100),
    start_date          date,
    end_date            date,
    status              enum ('pending', 'in_progress', 'completed', 'cancelled'),
    foreign key (production_plan_id) references production_plan (id)
);
Create Table prerequisite_of_process
(
    id                   int primary key auto_increment not null,
    process_id           int,
    prerequisite_process int,
    foreign key (process_id) references production_process (id),
    foreign key (prerequisite_process) references production_process (id),
    unique (process_id, prerequisite_process)
);
-- TODO 每个工人负责一个生产线流程，并组成一个工人团队。质量控制工人负责检查上一步骤的材料质量。
-- TODO 每个工人团队的负责人需要在每天结束时报告完成的零部件数量和损坏材料的数量。
-- TODO 在将零部件转移到下一个生产线流程之前，生产官员可能需要附上转运单。

-- ======================================================Sale
Create Table customer
(
    id      int primary key auto_increment not null,
    name    varchar(100),
    address varchar(100),
    phone   varchar(100)
);


Create Table sales_order
(
    id                   int primary key auto_increment not null,
    customer_id          int,
    order_number         varchar(100),
    payment_method       enum ('cash', 'credit card', 'bank transfer'),
    order_date           date,
    delivery_date        date,
    payment_terms        varchar(100),
    shipping_address     varchar(100),
    status               enum ('pending', 'completed', 'cancelled'),
    product_amount_cents int,
    shipping_cost_cents  int,
    tax_amount_cents     int,
    total_amount_cents   int,
    down_payment_percent int,
    down_payment_date    date,
    is_down_payment_paid boolean,
    -- customized
    is_customized        boolean default false,
    special_requirements varchar(1024),
    foreign key (customer_id) references customer (id)
);
Create Table order_item
(
    id                int primary key auto_increment not null,
    order_id          int,
    product_id        int,
    quantity          int,
    unit_price_cents  int,
    total_price_cents int,
    foreign key (order_id) references sales_order (id),
    foreign key (product_id) references product (id)
);
-- ========================================================Payment
Create Table payment
(
    id                int primary key auto_increment not null,
    order_id          int,
    payment_method    enum ('cash', 'credit card', 'bank transfer'),
    payment_date      date,
    amount_paid_cents int,
    balance_due_cents int,
    foreign key (order_id) references sales_order (id)
);
-- ========================================================shipping
Create Table shipping_method
(
    id          int primary key auto_increment not null,
    name        varchar(100),
    description varchar(100)
);
Create Table shipping_record
(
    id               int primary key auto_increment not null,
    order_id         int,
    shipping_date    date,
    shipping_method  int,
    tracking_number  varchar(100),
    carrier          varchar(100),
    shipping_address varchar(100),
    status           enum ('pending', 'in_transit', 'delivered'),
    foreign key (order_id) references sales_order (id),
    foreign key (shipping_method) references shipping_method (id)
);
-- ========================================================Customer Service
Create Table customer_service_request
(
    id                  int primary key auto_increment not null,
    order_id            int,
    customer_id         int,
    request_date        date,
    request_description varchar(100),
    status              enum ('pending', 'in_progress', 'resolved', 'closed'),
    resolution          varchar(100),
    foreign key (order_id) references sales_order (id),
    foreign key (customer_id) references customer (id)
);
Create Table technical_support
(
    id                  int primary key auto_increment not null,
    customer_service_id int,
    employee_id         int,
    support_date        date,
    support_description varchar(100),
    foreign key (customer_service_id) references customer_service_request (id),
    foreign key (employee_id) references user (id)
);
Create Table warranty_claim
(
    id                  int primary key auto_increment not null,
    customer_service_id int,
    warranty_period     int,
    claim_date          date,
    claim_description   varchar(100),
    status              enum ('pending', 'in_progress', 'resolved', 'closed'),
    resolution          varchar(100),
    foreign key (customer_service_id) references customer_service_request (id)
);
Create Table refund_return_request
(
    id                    int primary key auto_increment not null,
    customer_service_id   int,
    refund_date           date,
    return_date           date,
    reason                varchar(100),
    status                enum ('pending', 'in_progress', 'resolved', 'closed'),
    resolution            varchar(100),
    amount_refunded_cents int,
    foreign key (customer_service_id) references customer_service_request (id)
);


USE smile_sunshine;

-- 创建基础部门
INSERT INTO department (name, description)
VALUES ('Management Department', 'Oversees corporate management and administrative affairs'),
       ('Production Department', 'Manages product manufacturing and quality control'),
       ('Sales Department', 'Handles product sales and customer relationship management');

-- 创建基础角色
INSERT INTO role (role_name, department_id, description)
VALUES ('Administrator', 1, 'System administrator with system management privileges, no business production permissions'),
       ('Production Worker', 2, 'Responsible for basic product production work'),
       ('Production Team Leader', 2, 'Responsible for management and coordination of the production team'),
       ('Salesperson', 3, 'Responsible for product sales and customer communication'),
       ('Sales Manager', 3, 'Responsible for management of the sales team and formulation of sales strategies');

-- 创建管理员账户
INSERT INTO user (username, password, real_name, gender, email, phone)
VALUES ('admin', '123123', 'Administrator', 'MALE','admin@smileshine.com', '13800000000');

-- 绑定管理员账户和管理员角色
INSERT INTO user_role (user_id, role_id)
VALUES (1, 1);
-- 假设admin用户的ID为1，管理员角色的ID为1

-- 添加一些基础权限
INSERT INTO permission (permission_name, api_path, description)
VALUES ('User Management', '/api/users', 'Manage system user permissions'),
       ('Role Management', '/api/roles', 'Manage system role permissions'),
       ('Department Management', '/api/departments', 'Manage system department permissions'),
       ('Product Management', '/api/products', 'Manage product permissions'),
       ('Order Management', '/api/orders', 'Manage sales order permissions'),
       ('Production Plan Management', '/api/production-plans', 'Manage production plan permissions');

-- 为管理员角色分配所有权限
INSERT INTO role_permission (role_id, permission_id)
VALUES (1, 1), -- 管理员角色拥有用户管理权限
       (1, 2), -- 管理员角色拥有角色管理权限
       (1, 3);
-- 管理员角色拥有部门管理权限

-- 为其他角色分配相应权限
INSERT INTO role_permission (role_id, permission_id)
VALUES (3, 6), -- 生产组长拥有生产计划管理权限
       (5, 5); -- 销售经理拥有订单管理权限