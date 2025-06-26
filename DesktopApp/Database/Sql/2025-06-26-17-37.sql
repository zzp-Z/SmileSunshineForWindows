-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主机： 127.0.0.1
-- 生成日期： 2025-06-26 11:33:31
-- 服务器版本： 10.4.32-MariaDB
-- PHP 版本： 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 数据库： `smile_sunshine`
--

-- --------------------------------------------------------

--
-- 表的结构 `customer`
--

CREATE TABLE `customer` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phone` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 转存表中的数据 `customer`
--

INSERT INTO `customer` (`id`, `name`, `address`, `phone`) VALUES
(1, 'Wong Wei', '18 Queen\'s Road Central, Central, Hong Kong Island', '+852-9876-5432'),
(2, 'Li Na', '123 Nathan Road, Tsim Sha Tsui, Kowloon', '+852-5678-9012'),
(3, 'Chow Kai', '2/F, Sha Tin Plaza, Shatin, New Territories', '+852-1234-5678'),
(4, 'Wu Min', '300 Hennessy Road, Wan Chai, Hong Kong Island', '+852-8765-4321'),
(5, 'Lam Ho', '412 Kwun Tong Road, Kwun Tong, Kowloon', '+852-2345-6789'),
(6, 'Chan Yee', '555 Lockhart Road, Causeway Bay, Hong Kong Island', '+852-9012-3456'),
(7, 'Kwok Fung', '789 Prince Edward Road West, Mong Kok, Kowloon', '+852-4567-8901'),
(8, 'Lee Mei', '321 Tsing Yi Road, Tsing Yi, New Territories', '+852-6789-0123'),
(9, 'Tang Sing', '987 Lai Chi Kok Road, Lai Chi Kok, Kowloon', '+852-3456-7890'),
(10, 'Ng Fung', '654 Jordan Road, Yau Ma Tei, Kowloon', '+852-7890-1234');

-- --------------------------------------------------------

--
-- 表的结构 `customer_service_request`
--

CREATE TABLE `customer_service_request` (
  `id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `request_date` date DEFAULT NULL,
  `request_description` varchar(100) DEFAULT NULL,
  `status` enum('pending','in_progress','resolved','closed') DEFAULT NULL,
  `resolution` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `department`
--

CREATE TABLE `department` (
  `id` int(11) NOT NULL COMMENT '部门ID，主键，自动递增',
  `name` varchar(255) NOT NULL COMMENT '部门名称',
  `description` text DEFAULT NULL COMMENT '部门描述（可选字段）',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() COMMENT '创建时间，默认为当前时间',
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp() COMMENT '更新时间，自动更新'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='部门信息表';

--
-- 转存表中的数据 `department`
--

INSERT INTO `department` (`id`, `name`, `description`, `created_at`, `updated_at`) VALUES
(1, 'Management Department', 'Responsible for the overall management and administration of the company', '2025-06-25 05:04:45', '2025-06-26 08:56:48'),
(2, 'Production Department', 'Responsible for product production and quality control', '2025-06-25 05:04:45', '2025-06-26 08:58:52'),
(3, 'Sales Department', 'Responsible for product sales and customer relationship management', '2025-06-25 05:04:45', '2025-06-26 08:59:07'),
(4, 'After-sales department', 'Responsible for providing customer support and resolving issues after a product has been sold. It ensures customer satisfaction through services such as repairs, replacements, and handling complaints.', '2025-06-26 09:00:21', '2025-06-26 09:00:21');

-- --------------------------------------------------------

--
-- 表的结构 `design_concept`
--

CREATE TABLE `design_concept` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `create_date` date DEFAULT NULL,
  `feasibility` int(11) DEFAULT NULL,
  `status` enum('pending','approved','rejected') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `inventory_record`
--

CREATE TABLE `inventory_record` (
  `id` int(11) NOT NULL,
  `material_id` int(11) DEFAULT NULL,
  `type` enum('purchase','used') DEFAULT NULL,
  `record_number` varchar(100) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `material`
--

CREATE TABLE `material` (
  `id` int(11) NOT NULL,
  `material_number` varchar(100) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `unit_of_measure` varchar(100) DEFAULT NULL,
  `quantity_in_stock` int(11) DEFAULT NULL,
  `reorder_level` int(11) DEFAULT NULL,
  `reorder_quantity` int(11) DEFAULT NULL,
  `last_received_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `material_of_product`
--

CREATE TABLE `material_of_product` (
  `id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `material_id` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `order_item`
--

CREATE TABLE `order_item` (
  `id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `unit_price_cents` int(11) DEFAULT NULL,
  `total_price_cents` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 转存表中的数据 `order_item`
--

INSERT INTO `order_item` (`id`, `order_id`, `product_id`, `quantity`, `unit_price_cents`, `total_price_cents`) VALUES
(1, 1, 1, 6, 999, 5994),
(2, 1, 2, 6, 999, 5994),
(3, 1, 3, 9, 1299, 11691),
(4, 2, 6, 12, 1399, 16788),
(5, 2, 7, 21, 899, 18879),
(6, 2, 8, 24, 3999, 95976),
(7, 3, 3, 15, 1299, 19485),
(8, 3, 6, 15, 1399, 20985);

-- --------------------------------------------------------

--
-- 表的结构 `payment`
--

CREATE TABLE `payment` (
  `id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `payment_method` enum('cash','credit card','bank transfer') DEFAULT NULL,
  `payment_date` date DEFAULT NULL,
  `amount_paid_cents` int(11) DEFAULT NULL,
  `balance_due_cents` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `permission`
--

CREATE TABLE `permission` (
  `id` int(11) NOT NULL COMMENT '权限ID，主键，自动递增',
  `permission_name` varchar(100) NOT NULL COMMENT '权限名称，如API访问权限',
  `api_path` varchar(255) NOT NULL COMMENT '对应的API路径',
  `description` text DEFAULT NULL COMMENT '权限描述（可选字段）',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() COMMENT '创建时间，默认为当前时间',
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp() COMMENT '更新时间，自动更新'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='权限信息表';

--
-- 转存表中的数据 `permission`
--

INSERT INTO `permission` (`id`, `permission_name`, `api_path`, `description`, `created_at`, `updated_at`) VALUES
(7, 'Dashboard', '/dashboard', '', '2025-06-26 09:02:58', '2025-06-26 09:02:58'),
(8, 'Order Management', '/order', '', '2025-06-26 09:03:11', '2025-06-26 09:03:11'),
(10, 'Product Manage', '/product/manage', '', '2025-06-26 09:03:36', '2025-06-26 09:03:36'),
(11, 'Product', '/product/product', '', '2025-06-26 09:04:18', '2025-06-26 09:04:18'),
(12, 'Customer Manage', '/customer/manage', '', '2025-06-26 09:04:47', '2025-06-26 09:04:47'),
(14, 'Record of inward goods', '/inventory/inward_goods', '', '2025-06-26 09:05:14', '2025-06-26 09:05:14'),
(15, 'Product Catalog', '/product/catalog', '', '2025-06-26 09:05:25', '2025-06-26 09:05:25'),
(16, 'Product Addition', '/product/addition', '', '2025-06-26 09:05:33', '2025-06-26 09:05:33'),
(17, 'Refund Processing', '/service/refund', '', '2025-06-26 09:05:47', '2025-06-26 09:05:47'),
(18, 'Return Processing', '/service/return', '', '2025-06-26 09:06:00', '2025-06-26 09:06:00'),
(19, 'Repair Processing', '/service/repair', '', '2025-06-26 09:06:10', '2025-06-26 09:06:10'),
(20, 'Department Manage', '/system/department/manage', '', '2025-06-26 09:06:29', '2025-06-26 09:06:29'),
(21, 'Role Manage', '/system/role/manage', '', '2025-06-26 09:06:38', '2025-06-26 09:06:38'),
(22, 'User Manage', '/system/user/manage', '', '2025-06-26 09:06:48', '2025-06-26 09:06:48'),
(23, 'Permission Manage', '/system/permission/manage', '', '2025-06-26 09:06:57', '2025-06-26 09:06:57'),
(24, 'System Manage', '/system/manage', '', '2025-06-26 09:07:10', '2025-06-26 09:07:10'),
(25, 'After-service Management', '/service/management', '', '2025-06-26 09:07:24', '2025-06-26 09:07:24'),
(26, 'Inventory Control', '/inventory/control', '', '2025-06-26 09:07:36', '2025-06-26 09:07:36'),
(27, 'Product', '/product', '', '2025-06-26 09:07:44', '2025-06-26 09:07:44');

-- --------------------------------------------------------

--
-- 表的结构 `prerequisite_of_process`
--

CREATE TABLE `prerequisite_of_process` (
  `id` int(11) NOT NULL,
  `process_id` int(11) DEFAULT NULL,
  `prerequisite_process` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `procurement_order`
--

CREATE TABLE `procurement_order` (
  `id` int(11) NOT NULL,
  `order_number` varchar(100) DEFAULT NULL,
  `unit_price_cents` int(11) DEFAULT NULL,
  `number_of_units` int(11) DEFAULT NULL,
  `total_amount_cents` int(11) DEFAULT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `material_id` int(11) DEFAULT NULL,
  `order_date` date DEFAULT NULL,
  `delivery_date` date DEFAULT NULL,
  `payment_terms` varchar(100) DEFAULT NULL,
  `status` enum('pending','completed','cancelled') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `product`
--

CREATE TABLE `product` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `price_cents` int(11) DEFAULT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `safety_certification` tinyint(1) DEFAULT NULL,
  `create_date` date DEFAULT NULL,
  `is_public` tinyint(1) DEFAULT 1,
  `design_id` int(11) DEFAULT NULL,
  `quantity_in_stock` int(11) DEFAULT 0 COMMENT '库存数量'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 转存表中的数据 `product`
--

INSERT INTO `product` (`id`, `name`, `description`, `price_cents`, `image_url`, `safety_certification`, `create_date`, `is_public`, `design_id`, `quantity_in_stock`) VALUES
(1, 'ToyRobot', 'Cute robot toy with interactive features.', 999, '20250626162216_a.jpg', 1, '2025-06-26', 1, 1, 94),
(2, 'ToyBear', 'A soft, cuddly plush bear for endless play and comfort.', 999, '', NULL, '2025-06-26', 1, 2, 194),
(3, 'ToySailboat', 'A mini toy sailboat for imaginative play.', 1299, '', NULL, '2025-06-26', 1, 3, 276),
(4, 'ToyDinosaur', 'A toy dinosaur for imaginative play.', 2999, '', 1, '2025-06-26', 0, 4, 150),
(5, 'ToyFrog', 'A cute toy frog for imaginative play.', 1099, '', 1, '2025-06-26', 1, 5, 100),
(6, 'ToyTank', 'A toy tank for adventurous play.', 1399, '', 1, '2025-06-26', 1, 6, 63),
(7, 'ToyTrain', 'A toy train for imaginative play.', 899, '', 1, '2025-06-26', 1, 7, 88),
(8, 'ToyRacingCar', 'Fast,fun toy racing cars for thrilling play.', 3999, '', 1, '2025-06-26', 1, 8, 21);

-- --------------------------------------------------------

--
-- 表的结构 `production_plan`
--

CREATE TABLE `production_plan` (
  `id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `plan_date` date DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `number_of_products` int(11) DEFAULT NULL,
  `status` enum('pending','in_progress','completed','cancelled') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `production_process`
--

CREATE TABLE `production_process` (
  `id` int(11) NOT NULL,
  `production_plan_id` int(11) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `process_description` varchar(100) DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `status` enum('pending','in_progress','completed','cancelled') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `prototype`
--

CREATE TABLE `prototype` (
  `id` int(11) NOT NULL,
  `concept_id` int(11) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `prototype_url` varchar(100) DEFAULT NULL,
  `create_date` date DEFAULT NULL,
  `feasibility` int(11) DEFAULT NULL,
  `status` enum('pending','approved','rejected') DEFAULT NULL,
  `test_result` enum('pending','pass','fail') DEFAULT NULL,
  `safety_result` enum('pending','pass','fail') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `prototype_comment`
--

CREATE TABLE `prototype_comment` (
  `id` int(11) NOT NULL,
  `prototype_id` int(11) DEFAULT NULL,
  `comment` varchar(100) DEFAULT NULL,
  `create_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `refund_return_request`
--

CREATE TABLE `refund_return_request` (
  `id` int(11) NOT NULL,
  `customer_service_id` int(11) DEFAULT NULL,
  `refund_date` date DEFAULT NULL,
  `return_date` date DEFAULT NULL,
  `reason` varchar(100) DEFAULT NULL,
  `status` enum('pending','in_progress','resolved','closed') DEFAULT NULL,
  `resolution` varchar(100) DEFAULT NULL,
  `amount_refunded_cents` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `role`
--

CREATE TABLE `role` (
  `id` int(11) NOT NULL COMMENT '角色ID，主键，自动递增',
  `role_name` varchar(50) NOT NULL COMMENT '角色名称，如管理员、普通用户等',
  `department_id` int(11) DEFAULT NULL COMMENT '部门ID，关联部门表',
  `description` text DEFAULT NULL COMMENT '角色描述（可选字段）',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() COMMENT '创建时间，默认为当前时间',
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp() COMMENT '更新时间，自动更新'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='角色信息表';

--
-- 转存表中的数据 `role`
--

INSERT INTO `role` (`id`, `role_name`, `department_id`, `description`, `created_at`, `updated_at`) VALUES
(1, 'Administrator', 1, 'System administrator, system management authority, no business production authority', '2025-06-25 05:04:45', '2025-06-26 09:29:40'),
(2, 'Production Worker', 2, 'Responsible for the basic work of product production', '2025-06-25 05:04:45', '2025-06-26 09:29:18'),
(3, 'Production Team Leader', 2, 'Responsible for the management and coordination of the production team', '2025-06-25 05:04:45', '2025-06-26 09:29:13'),
(4, 'Sales', 3, 'Responsible for product sales and customer communication', '2025-06-25 05:04:45', '2025-06-26 09:29:58'),
(5, 'Sales Manager', 3, 'Responsible for sales team management and sales strategy formulation', '2025-06-25 05:04:45', '2025-06-26 09:26:12'),
(6, 'After-sales customer service staff', 4, 'Answer customer queries,resolve issues,process returns/exchanges,assist with warranties,and maintain records.', '2025-06-26 09:31:55', '2025-06-26 09:32:25');

-- --------------------------------------------------------

--
-- 表的结构 `role_permission`
--

CREATE TABLE `role_permission` (
  `role_id` int(11) NOT NULL COMMENT '角色ID，关联角色表',
  `permission_id` int(11) NOT NULL COMMENT '权限ID，关联权限表'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='角色与权限的关联表';

--
-- 转存表中的数据 `role_permission`
--

INSERT INTO `role_permission` (`role_id`, `permission_id`) VALUES
(2, 7),
(3, 7),
(4, 7),
(5, 7),
(5, 10),
(5, 11),
(5, 27),
(6, 7),
(6, 17),
(6, 18),
(6, 19),
(6, 25);

-- --------------------------------------------------------

--
-- 表的结构 `sales_order`
--

CREATE TABLE `sales_order` (
  `id` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_number` varchar(100) DEFAULT NULL,
  `payment_method` enum('cash','credit card','bank transfer') DEFAULT NULL,
  `order_date` date DEFAULT NULL,
  `delivery_date` date DEFAULT NULL,
  `payment_terms` varchar(100) DEFAULT NULL,
  `shipping_address` varchar(100) DEFAULT NULL,
  `status` enum('pending','completed','cancelled') DEFAULT NULL,
  `product_amount_cents` int(11) DEFAULT NULL,
  `shipping_cost_cents` int(11) DEFAULT NULL,
  `tax_amount_cents` int(11) DEFAULT NULL,
  `total_amount_cents` int(11) DEFAULT NULL,
  `down_payment_percent` int(11) DEFAULT NULL,
  `down_payment_date` date DEFAULT NULL,
  `is_down_payment_paid` tinyint(1) DEFAULT NULL,
  `is_customized` tinyint(1) DEFAULT 0,
  `special_requirements` varchar(1024) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 转存表中的数据 `sales_order`
--

INSERT INTO `sales_order` (`id`, `customer_id`, `order_number`, `payment_method`, `order_date`, `delivery_date`, `payment_terms`, `shipping_address`, `status`, `product_amount_cents`, `shipping_cost_cents`, `tax_amount_cents`, `total_amount_cents`, `down_payment_percent`, `down_payment_date`, `is_down_payment_paid`, `is_customized`, `special_requirements`) VALUES
(1, 1, 'OR20250626001', 'cash', '2025-06-26', '2025-07-03', '', '18 Queen\'s Road Central, Central, Hong Kong Island', 'pending', 23679, 1200, 2367, 27246, 1, NULL, 1, 1, ''),
(2, 2, 'OR202506260002', 'credit card', '2025-06-26', '2025-07-03', '', '123 Nathan Road, Tsim Sha Tsui, Kowloon', 'pending', 131643, 2400, 13164, 147207, 0, NULL, 0, 0, 'QUICK'),
(3, 6, 'OR202506260004', 'bank transfer', '2025-06-26', '2025-07-03', '', '555 Lockhart Road, Causeway Bay, Hong Kong Island', 'pending', 40470, 3300, 4047, 47817, 1, NULL, 0, 1, '');

-- --------------------------------------------------------

--
-- 表的结构 `shipping_method`
--

CREATE TABLE `shipping_method` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `shipping_record`
--

CREATE TABLE `shipping_record` (
  `id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `shipping_date` date DEFAULT NULL,
  `shipping_method` int(11) DEFAULT NULL,
  `tracking_number` varchar(100) DEFAULT NULL,
  `carrier` varchar(100) DEFAULT NULL,
  `shipping_address` varchar(100) DEFAULT NULL,
  `status` enum('pending','in_transit','delivered') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `supplier`
--

CREATE TABLE `supplier` (
  `id` int(11) NOT NULL,
  `reliability_rating` int(11) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `contact_name` varchar(100) DEFAULT NULL,
  `phone` varchar(100) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `technical_support`
--

CREATE TABLE `technical_support` (
  `id` int(11) NOT NULL,
  `customer_service_id` int(11) DEFAULT NULL,
  `employee_id` int(11) DEFAULT NULL,
  `support_date` date DEFAULT NULL,
  `support_description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 表的结构 `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL COMMENT '用户ID，主键，自动递增',
  `username` varchar(50) NOT NULL COMMENT '用户名，唯一标识',
  `password` varchar(255) NOT NULL COMMENT '用户密码，加密存储',
  `email` varchar(100) DEFAULT NULL COMMENT '用户邮箱（可选）',
  `phone` varchar(20) DEFAULT NULL COMMENT '用户电话（可选）',
  `real_name` varchar(50) NOT NULL COMMENT '用户真实姓名，用于显示',
  `gender` enum('male','female') NOT NULL COMMENT '用户性别，枚举类型，可选值：male、female',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() COMMENT '创建时间，默认为当前时间',
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp() COMMENT '更新时间，自动更新'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='用户信息表';

--
-- 转存表中的数据 `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `email`, `phone`, `real_name`, `gender`, `created_at`, `updated_at`) VALUES
(1, 'admin', '123123', 'admin@smileshine.com', '13800000000', 'Smile Shine Admin', 'male', '2025-06-25 05:04:45', '2025-06-26 09:20:42'),
(2, 'Jude', '123123', 'JIEHUA@GMAIL.COM', '+85298170622', 'JIEHUA', 'male', '2025-06-26 09:25:02', '2025-06-26 09:25:02');

-- --------------------------------------------------------

--
-- 表的结构 `user_role`
--

CREATE TABLE `user_role` (
  `user_id` int(11) NOT NULL COMMENT '用户ID，关联用户表',
  `role_id` int(11) NOT NULL COMMENT '角色ID，关联角色表'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='用户与角色的关联表';

--
-- 转存表中的数据 `user_role`
--

INSERT INTO `user_role` (`user_id`, `role_id`) VALUES
(1, 1),
(2, 5);

-- --------------------------------------------------------

--
-- 表的结构 `warranty_claim`
--

CREATE TABLE `warranty_claim` (
  `id` int(11) NOT NULL,
  `customer_service_id` int(11) DEFAULT NULL,
  `warranty_period` int(11) DEFAULT NULL,
  `claim_date` date DEFAULT NULL,
  `claim_description` varchar(100) DEFAULT NULL,
  `status` enum('pending','in_progress','resolved','closed') DEFAULT NULL,
  `resolution` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 转储表的索引
--

--
-- 表的索引 `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `customer_service_request`
--
ALTER TABLE `customer_service_request`
  ADD PRIMARY KEY (`id`),
  ADD KEY `order_id` (`order_id`),
  ADD KEY `customer_id` (`customer_id`);

--
-- 表的索引 `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `design_concept`
--
ALTER TABLE `design_concept`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `inventory_record`
--
ALTER TABLE `inventory_record`
  ADD PRIMARY KEY (`id`),
  ADD KEY `material_id` (`material_id`);

--
-- 表的索引 `material`
--
ALTER TABLE `material`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `material_of_product`
--
ALTER TABLE `material_of_product`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `product_id` (`product_id`,`material_id`),
  ADD KEY `material_id` (`material_id`);

--
-- 表的索引 `order_item`
--
ALTER TABLE `order_item`
  ADD PRIMARY KEY (`id`),
  ADD KEY `order_id` (`order_id`),
  ADD KEY `product_id` (`product_id`);

--
-- 表的索引 `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`id`),
  ADD KEY `order_id` (`order_id`);

--
-- 表的索引 `permission`
--
ALTER TABLE `permission`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `prerequisite_of_process`
--
ALTER TABLE `prerequisite_of_process`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `process_id` (`process_id`,`prerequisite_process`),
  ADD KEY `prerequisite_process` (`prerequisite_process`);

--
-- 表的索引 `procurement_order`
--
ALTER TABLE `procurement_order`
  ADD PRIMARY KEY (`id`),
  ADD KEY `supplier_id` (`supplier_id`),
  ADD KEY `material_id` (`material_id`);

--
-- 表的索引 `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `production_plan`
--
ALTER TABLE `production_plan`
  ADD PRIMARY KEY (`id`),
  ADD KEY `product_id` (`product_id`);

--
-- 表的索引 `production_process`
--
ALTER TABLE `production_process`
  ADD PRIMARY KEY (`id`),
  ADD KEY `production_plan_id` (`production_plan_id`);

--
-- 表的索引 `prototype`
--
ALTER TABLE `prototype`
  ADD PRIMARY KEY (`id`),
  ADD KEY `concept_id` (`concept_id`);

--
-- 表的索引 `prototype_comment`
--
ALTER TABLE `prototype_comment`
  ADD PRIMARY KEY (`id`),
  ADD KEY `prototype_id` (`prototype_id`);

--
-- 表的索引 `refund_return_request`
--
ALTER TABLE `refund_return_request`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customer_service_id` (`customer_service_id`);

--
-- 表的索引 `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`id`),
  ADD KEY `department_id` (`department_id`);

--
-- 表的索引 `role_permission`
--
ALTER TABLE `role_permission`
  ADD PRIMARY KEY (`role_id`,`permission_id`),
  ADD KEY `permission_id` (`permission_id`);

--
-- 表的索引 `sales_order`
--
ALTER TABLE `sales_order`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customer_id` (`customer_id`);

--
-- 表的索引 `shipping_method`
--
ALTER TABLE `shipping_method`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `shipping_record`
--
ALTER TABLE `shipping_record`
  ADD PRIMARY KEY (`id`),
  ADD KEY `order_id` (`order_id`),
  ADD KEY `shipping_method` (`shipping_method`);

--
-- 表的索引 `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `technical_support`
--
ALTER TABLE `technical_support`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customer_service_id` (`customer_service_id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- 表的索引 `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- 表的索引 `user_role`
--
ALTER TABLE `user_role`
  ADD PRIMARY KEY (`user_id`,`role_id`),
  ADD KEY `role_id` (`role_id`);

--
-- 表的索引 `warranty_claim`
--
ALTER TABLE `warranty_claim`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customer_service_id` (`customer_service_id`);

--
-- 在导出的表使用AUTO_INCREMENT
--

--
-- 使用表AUTO_INCREMENT `customer`
--
ALTER TABLE `customer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- 使用表AUTO_INCREMENT `customer_service_request`
--
ALTER TABLE `customer_service_request`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `department`
--
ALTER TABLE `department`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '部门ID，主键，自动递增', AUTO_INCREMENT=5;

--
-- 使用表AUTO_INCREMENT `design_concept`
--
ALTER TABLE `design_concept`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `inventory_record`
--
ALTER TABLE `inventory_record`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `material`
--
ALTER TABLE `material`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `material_of_product`
--
ALTER TABLE `material_of_product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `order_item`
--
ALTER TABLE `order_item`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- 使用表AUTO_INCREMENT `payment`
--
ALTER TABLE `payment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `permission`
--
ALTER TABLE `permission`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '权限ID，主键，自动递增', AUTO_INCREMENT=28;

--
-- 使用表AUTO_INCREMENT `prerequisite_of_process`
--
ALTER TABLE `prerequisite_of_process`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `procurement_order`
--
ALTER TABLE `procurement_order`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `product`
--
ALTER TABLE `product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- 使用表AUTO_INCREMENT `production_plan`
--
ALTER TABLE `production_plan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `production_process`
--
ALTER TABLE `production_process`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `prototype`
--
ALTER TABLE `prototype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `prototype_comment`
--
ALTER TABLE `prototype_comment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `refund_return_request`
--
ALTER TABLE `refund_return_request`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `role`
--
ALTER TABLE `role`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '角色ID，主键，自动递增', AUTO_INCREMENT=7;

--
-- 使用表AUTO_INCREMENT `sales_order`
--
ALTER TABLE `sales_order`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- 使用表AUTO_INCREMENT `shipping_method`
--
ALTER TABLE `shipping_method`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `shipping_record`
--
ALTER TABLE `shipping_record`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `supplier`
--
ALTER TABLE `supplier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `technical_support`
--
ALTER TABLE `technical_support`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用表AUTO_INCREMENT `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '用户ID，主键，自动递增', AUTO_INCREMENT=3;

--
-- 使用表AUTO_INCREMENT `warranty_claim`
--
ALTER TABLE `warranty_claim`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 限制导出的表
--

--
-- 限制表 `customer_service_request`
--
ALTER TABLE `customer_service_request`
  ADD CONSTRAINT `customer_service_request_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `sales_order` (`id`),
  ADD CONSTRAINT `customer_service_request_ibfk_2` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`id`);

--
-- 限制表 `inventory_record`
--
ALTER TABLE `inventory_record`
  ADD CONSTRAINT `inventory_record_ibfk_1` FOREIGN KEY (`material_id`) REFERENCES `material` (`id`);

--
-- 限制表 `material_of_product`
--
ALTER TABLE `material_of_product`
  ADD CONSTRAINT `material_of_product_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`),
  ADD CONSTRAINT `material_of_product_ibfk_2` FOREIGN KEY (`material_id`) REFERENCES `material` (`id`);

--
-- 限制表 `order_item`
--
ALTER TABLE `order_item`
  ADD CONSTRAINT `order_item_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `sales_order` (`id`),
  ADD CONSTRAINT `order_item_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`);

--
-- 限制表 `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `sales_order` (`id`);

--
-- 限制表 `prerequisite_of_process`
--
ALTER TABLE `prerequisite_of_process`
  ADD CONSTRAINT `prerequisite_of_process_ibfk_1` FOREIGN KEY (`process_id`) REFERENCES `production_process` (`id`),
  ADD CONSTRAINT `prerequisite_of_process_ibfk_2` FOREIGN KEY (`prerequisite_process`) REFERENCES `production_process` (`id`);

--
-- 限制表 `procurement_order`
--
ALTER TABLE `procurement_order`
  ADD CONSTRAINT `procurement_order_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `supplier` (`id`),
  ADD CONSTRAINT `procurement_order_ibfk_2` FOREIGN KEY (`material_id`) REFERENCES `material` (`id`);

--
-- 限制表 `production_plan`
--
ALTER TABLE `production_plan`
  ADD CONSTRAINT `production_plan_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`);

--
-- 限制表 `production_process`
--
ALTER TABLE `production_process`
  ADD CONSTRAINT `production_process_ibfk_1` FOREIGN KEY (`production_plan_id`) REFERENCES `production_plan` (`id`);

--
-- 限制表 `prototype`
--
ALTER TABLE `prototype`
  ADD CONSTRAINT `prototype_ibfk_1` FOREIGN KEY (`concept_id`) REFERENCES `design_concept` (`id`);

--
-- 限制表 `prototype_comment`
--
ALTER TABLE `prototype_comment`
  ADD CONSTRAINT `prototype_comment_ibfk_1` FOREIGN KEY (`prototype_id`) REFERENCES `prototype` (`id`);

--
-- 限制表 `refund_return_request`
--
ALTER TABLE `refund_return_request`
  ADD CONSTRAINT `refund_return_request_ibfk_1` FOREIGN KEY (`customer_service_id`) REFERENCES `customer_service_request` (`id`);

--
-- 限制表 `role`
--
ALTER TABLE `role`
  ADD CONSTRAINT `role_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `department` (`id`);

--
-- 限制表 `role_permission`
--
ALTER TABLE `role_permission`
  ADD CONSTRAINT `role_permission_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `role` (`id`),
  ADD CONSTRAINT `role_permission_ibfk_2` FOREIGN KEY (`permission_id`) REFERENCES `permission` (`id`);

--
-- 限制表 `sales_order`
--
ALTER TABLE `sales_order`
  ADD CONSTRAINT `sales_order_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`id`);

--
-- 限制表 `shipping_record`
--
ALTER TABLE `shipping_record`
  ADD CONSTRAINT `shipping_record_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `sales_order` (`id`),
  ADD CONSTRAINT `shipping_record_ibfk_2` FOREIGN KEY (`shipping_method`) REFERENCES `shipping_method` (`id`);

--
-- 限制表 `technical_support`
--
ALTER TABLE `technical_support`
  ADD CONSTRAINT `technical_support_ibfk_1` FOREIGN KEY (`customer_service_id`) REFERENCES `customer_service_request` (`id`),
  ADD CONSTRAINT `technical_support_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `user` (`id`);

--
-- 限制表 `user_role`
--
ALTER TABLE `user_role`
  ADD CONSTRAINT `user_role_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `user_role_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `role` (`id`);

--
-- 限制表 `warranty_claim`
--
ALTER TABLE `warranty_claim`
  ADD CONSTRAINT `warranty_claim_ibfk_1` FOREIGN KEY (`customer_service_id`) REFERENCES `customer_service_request` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
