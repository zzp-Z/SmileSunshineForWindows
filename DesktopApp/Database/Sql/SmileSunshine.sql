CREATE DATABASE smile_sunshine;
USE smile_sunshine;

-- ======================================================User
Create Table department
(
    id          INT PRIMARY KEY AUTO_INCREMENT COMMENT '部门ID，主键，自动递增',
    name        VARCHAR(255) NOT NULL COMMENT '部门名称',
    description TEXT COMMENT '部门描述（可选字段）',
    created_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间，默认为当前时间',
    updated_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '更新时间，自动更新'
) COMMENT ='部门信息表';

Create Table user
(
    id        INT PRIMARY KEY AUTO_INCREMENT COMMENT '用户ID，主键，自动递增',
    username  VARCHAR(50)  NOT NULL COMMENT '用户名，唯一标识',
    password  VARCHAR(255) NOT NULL COMMENT '用户密码，加密存储',
    email     VARCHAR(100) COMMENT '用户邮箱（可选）',
    phone     VARCHAR(20) COMMENT '用户电话（可选）',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间，默认为当前时间',
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '更新时间，自动更新'
) COMMENT ='用户信息表';

Create Table role
(
    id          INT PRIMARY KEY AUTO_INCREMENT COMMENT '角色ID，主键，自动递增',
    role_name   VARCHAR(50) NOT NULL COMMENT '角色名称，如管理员、普通用户等',
    department_id INT COMMENT '部门ID，关联部门表',
    description TEXT COMMENT '角色描述（可选字段）',
    created_at   TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间，默认为当前时间',
    updated_at   TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '更新时间，自动更新',
    FOREIGN KEY (department_id) REFERENCES department (id)
) COMMENT ='角色信息表';

Create Table permission
(
    id              INT PRIMARY KEY AUTO_INCREMENT COMMENT '权限ID，主键，自动递增',
    permission_name VARCHAR(100) NOT NULL COMMENT '权限名称，如API访问权限',
    api_path        VARCHAR(255) NOT NULL COMMENT '对应的API路径',
    description     TEXT COMMENT '权限描述（可选字段）',
    created_at      TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间，默认为当前时间',
    updated_at      TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '更新时间，自动更新'
) COMMENT ='权限信息表';

CREATE TABLE user_role
(
    user_id INT NOT NULL COMMENT '用户ID，关联用户表',
    role_id INT NOT NULL COMMENT '角色ID，关联角色表',
    PRIMARY KEY (user_id, role_id),
    FOREIGN KEY (user_id) REFERENCES user (id),
    FOREIGN KEY (role_id) REFERENCES role (id)
) COMMENT ='用户与角色的关联表';

CREATE TABLE role_permission
(
    role_id       INT NOT NULL COMMENT '角色ID，关联角色表',
    permission_id INT NOT NULL COMMENT '权限ID，关联权限表',
    PRIMARY KEY (role_id, permission_id),
    FOREIGN KEY (role_id) REFERENCES role (id),
    FOREIGN KEY (permission_id) REFERENCES permission (id)
) COMMENT ='角色与权限的关联表';

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