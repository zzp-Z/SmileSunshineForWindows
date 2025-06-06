USE smile_sunshine;

-- 创建基础部门
INSERT INTO department (name, description)
VALUES ('管理部门', '负责公司整体管理和行政工作'),
       ('生产部门', '负责产品生产和质量控制'),
       ('销售部门', '负责产品销售和客户关系管理');

-- 创建基础角色
INSERT INTO role (role_name, department_id, description)
VALUES ('管理员', 1, '系统管理员，系统管理权限，没有业务生产权限'),
       ('生产工人', 2, '负责产品生产的基础工作'),
       ('生产组长', 2, '负责生产团队的管理和协调'),
       ('销售员', 3, '负责产品销售和客户沟通'),
       ('销售经理', 3, '负责销售团队的管理和销售策略制定');

-- 创建管理员账户
INSERT INTO user (username, password, real_name, gender, email, phone)
VALUES ('admin', '123123', '管理员', 'MALE','admin@smileshine.com', '13800000000');

-- 绑定管理员账户和管理员角色
INSERT INTO user_role (user_id, role_id)
VALUES (1, 1);
-- 假设admin用户的ID为1，管理员角色的ID为1

-- 添加一些基础权限
INSERT INTO permission (permission_name, api_path, description)
VALUES ('用户管理', '/api/users', '管理系统用户的权限'),
       ('角色管理', '/api/roles', '管理系统角色的权限'),
       ('部门管理', '/api/departments', '管理系统部门的权限'),
       ('产品管理', '/api/products', '管理产品的权限'),
       ('订单管理', '/api/orders', '管理销售订单的权限'),
       ('生产计划管理', '/api/production-plans', '管理生产计划的权限');

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