CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS products(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  description text NOT NULL comment 'text for description',
  price int NOT NULL comment 'price of product',
  creatorId VARCHAR(255) NOT NULL comment 'ID of creator'
) default charset utf8 comment '';

ALTER TABLE warehouse_products ADD COLUMN creatorId VARCHAR(255) NOT NULL comment 'ID of creator';
CREATE TABLE IF NOT EXISTS warehouses(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  location VARCHAR(255) NOT NULL comment 'location of warehouse',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
) default charset utf8 comment '';


CREATE TABLE IF NOT EXISTS warehouse_products(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
  productId int NOT NULL comment 'product id',
  warehouseId int NOT NULL comment 'warehouse id'
) default charset utf8 comment '';
