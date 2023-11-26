using HotelProject.BussinessLayer.Abstract;
using HotelProject.BussinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProjectWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<Context>();
            services.AddScoped<IStaffDal, EfStaffDal>();//hafýzada bir nesne örneði oluþtur ve bunu kullan
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<IRoomDal, EfRoomDal>();//hafýzada bir nesne örneði oluþtur ve bunu kullan
            services.AddScoped<IRoomService, RoomManager>();

            services.AddScoped<IServicesDal, EfServiceDal>();//hafýzada bir nesne örneði oluþtur ve bunu kullan
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<ISubscribeDal, EfSubscribeDal>();//hafýzada bir nesne örneði oluþtur ve bunu kullan
            services.AddScoped<ISubscribeService, SubscribeManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();//hafýzada bir nesne örneði oluþtur ve bunu kullan
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<IGuestDal, EfGuestDal>();
            services.AddScoped<IGuestService, GuestManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactMenager>();


            services.AddAutoMapper(typeof(Startup));//automapper.

            services.AddCors(opt =>
            {
                opt.AddPolicy("OtelApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); //you can get permission every header,method, and more, consume edeceðim alanlar

                });
            }); //a api can use by another api or some other platforms. We get the permission it

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelProjectWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelProjectWebApi v1"));
            }

            app.UseRouting();
            app.UseCors("OtelApiCors"); //we use this name on up !

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
