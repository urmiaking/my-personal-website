using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Data;
using PersonalWebsite.Models;

namespace PersonalWebsite.Utilities
{
    public class VisitorCounterMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public VisitorCounterMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context, AppDbContext db)
        {
            var visitorId = context.Request.Cookies["VisitorId"];
            if (visitorId == null)
            {
                //do the necessary staffs here to save the count by one

                var ipAddress = context.Connection.RemoteIpAddress.MapToIPv4().ToString();

                await db.ClientVisits.AddAsync(new ClientVisit()
                {
                    IpAddress = ipAddress,
                    DateTime = DateTime.Now
                });

                await db.SaveChangesAsync();

                context.Response.Cookies.Append("VisitorId", Generator.GenerationUniqueName(), new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true,
                    Secure = false,
                    Expires = DateTimeOffset.Now.AddDays(365)
                });
            }

            await _requestDelegate(context);
        }
    }
}
