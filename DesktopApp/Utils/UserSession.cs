using DesktopApp.Database;
using DesktopApp.Database.Func;
using System.Collections.Generic;
using System.Linq;

namespace DesktopApp.Utils
{
    /// <summary>
    /// 用户会话管理类，用于存储当前登录用户的信息和权限
    /// </summary>
    public static class UserSession
    {
        private static User _currentUser;
        private static List<Permission> _userPermissions;
        private static readonly PermissionFunc _permissionFunc = new PermissionFunc();

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static User CurrentUser
        {
            get { return _currentUser; }
        }

        /// <summary>
        /// 当前用户的权限列表
        /// </summary>
        public static List<Permission> UserPermissions
        {
            get { return _userPermissions ?? new List<Permission>(); }
        }

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        /// <param name="user">用户信息</param>
        public static void SetCurrentUser(User user)
        {
            _currentUser = user;
            LoadUserPermissions();
        }

        /// <summary>
        /// 清除当前用户会话
        /// </summary>
        public static void ClearSession()
        {
            _currentUser = null;
            _userPermissions = null;
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns>当前用户信息，如果未登录返回null</returns>
        public static User GetCurrentUser()
        {
            return _currentUser;
        }

        /// <summary>
        /// 检查当前用户是否有指定权限
        /// </summary>
        /// <param name="apiPath">API路径</param>
        /// <returns>是否有权限</returns>
        public static bool HasPermission(string apiPath)
        {
            // Admin用户不受限制
            if (IsAdmin())
            {
                return true;
            }

            if (_userPermissions == null || string.IsNullOrEmpty(apiPath))
            {
                return false;
            }

            return _userPermissions.Any(p => p.ApiPath == apiPath);
        }

        /// <summary>
        /// 检查当前用户是否为管理员
        /// </summary>
        /// <returns>是否为管理员</returns>
        public static bool IsAdmin()
        {
            return _currentUser?.Username?.ToLower() == "admin";
        }

        /// <summary>
        /// 获取当前用户ID
        /// </summary>
        /// <returns>用户ID，如果未登录返回0</returns>
        public static int GetCurrentUserId()
        {
            return _currentUser?.Id ?? 0;
        }

        /// <summary>
        /// 检查是否已登录
        /// </summary>
        /// <returns>是否已登录</returns>
        public static bool IsLoggedIn()
        {
            return _currentUser != null;
        }

        /// <summary>
        /// 加载当前用户的权限
        /// </summary>
        private static void LoadUserPermissions()
        {
            if (_currentUser == null)
            {
                _userPermissions = new List<Permission>();
                return;
            }

            try
            {
                _userPermissions = GetUserPermissions(_currentUser.Id);
            }
            catch
            {
                _userPermissions = new List<Permission>();
            }
        }

        /// <summary>
        /// 获取用户的所有权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>权限列表</returns>
        private static List<Permission> GetUserPermissions(int userId)
        {
            var permissions = new List<Permission>();
            var allPermissions = _permissionFunc.GetAllPermissions();

            foreach (var permission in allPermissions)
            {
                if (_permissionFunc.CheckUserPermission(userId, permission.Id))
                {
                    permissions.Add(permission);
                }
            }

            return permissions;
        }
    }
}