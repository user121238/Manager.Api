﻿using Microsoft.AspNetCore.Http;
using System.Linq;

namespace API.Core.LogExtensions
{
    /// <summary>
    /// HttpContext拓展类
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// 获取客户端请求IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetClientIp(this HttpContext context)
        {
            var ip = context.Request.Headers["x-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }

            return ip;
        }
    }
}