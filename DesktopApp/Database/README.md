# 数据库连接使用说明

## 概述

本项目现在使用单例模式来管理数据库连接，确保全局只有一个数据库连接实例，提高性能并避免连接资源浪费。

## 使用方法

### 1. 获取数据库引擎实例

```csharp
// 获取单例数据库引擎实例
Database.Engine dbEngine = Database.Engine.Instance;
```

### 2. 直接使用静态方法（推荐）

```csharp
// 打开数据库连接
if (Database.Engine.OpenDatabaseConnection())
{
    // 获取连接对象
    MySqlConnection connection = Database.Engine.GetDatabaseConnection();
    
    // 执行数据库操作
    // ...
    
    // 关闭连接
    Database.Engine.CloseDatabaseConnection();
}
```

### 3. 在Func类中使用

```csharp
// 在构造函数中注入数据库引擎
public UserFunc(Engine dbEngine)
{
    _dbEngine = dbEngine;
}

// 或者直接使用单例实例
public UserFunc()
{
    _dbEngine = Engine.Instance;
}
```

## 优势

1. **资源节约**: 全局只维护一个数据库连接，避免多个连接造成的资源浪费
2. **线程安全**: 使用双重检查锁定模式确保线程安全
3. **易于管理**: 集中管理数据库连接的生命周期
4. **性能优化**: 减少连接创建和销毁的开销

## 注意事项

1. 在应用程序退出时，建议调用 `Database.Engine.DisposeInstance()` 来正确释放资源
2. 数据库操作完成后记得关闭连接
3. 在多线程环境下，确保正确处理连接的并发访问

## 配置信息

当前数据库配置：
- 服务器: localhost
- 端口: 3307
- 数据库: smile_sunshine
- 用户名: root
- 密码: 123123

如需修改配置，请在 `Engine.cs` 的 `Initialize()` 方法中更新相应参数。