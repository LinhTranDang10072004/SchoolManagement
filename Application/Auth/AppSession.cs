// Application/Auth/AppSession.cs
using System;

namespace DemoAppQLTH.Application.Auth
{
    public static class AppSession
    {
        public static string Role { get; private set; } = "";
        public static Guid UserId { get; private set; }
        public static string Ma { get; private set; } = "";
        public static string HoTen { get; private set; } = "";

        public static void Set(string role, Guid userId, string ma, string hoTen)
        {
            Role = role;
            UserId = userId;
            Ma = ma;
            HoTen = hoTen;
        }

        public static void Clear()
        {
            Role = "";
            UserId = Guid.Empty;
            Ma = "";
            HoTen = "";
        }
    }
}
