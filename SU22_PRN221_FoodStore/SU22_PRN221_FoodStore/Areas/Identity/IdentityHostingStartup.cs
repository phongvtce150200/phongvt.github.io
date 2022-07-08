using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SU22_PRN221_FoodStore.Data;
using SU22_PRN221_FoodStore.Models;

[assembly: HostingStartup(typeof(SU22_PRN221_FoodStore.Areas.Identity.IdentityHostingStartup))]
namespace SU22_PRN221_FoodStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}