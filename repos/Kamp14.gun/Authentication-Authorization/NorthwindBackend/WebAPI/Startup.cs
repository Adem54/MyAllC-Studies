using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000"));
            });//Origin denilen istek yapilan yerdemektir
               //Ornegin localhost:3000 demek bir react uygulamasinin yayin adresidir bu
               //default yayin da 3000 dir React ta
               //Burasi test ortami ama normalde biz buraya domain imiz ne ise onu yazariz
               //Birden fazla varsa virgulle onlari da yazabiliriz cunku arraydir o
               //Veya WithOrigins ustune gidersek onun params oldugunu goruruz bu da istedgimiz kadar
               //ekleyebiliriz demektir
               //Bu islemden sonra bir de Configure icerisinde Middleware eklemeliyiz...


            //-------------------------
            //Simdi de asagi da configure de ekledigimiz Authenticationin  servisini ekliyoruz
            //Burda biz Bearer Authentication denilen yapiyi kullanacagiz

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//TokenOptions bolumunu oku
                //Ve Get operasyonu ile hangi nesneye baglayacagimizi soyleriz
                //Buraya dikkat edelim bu bizim Security icindeki jwt icindeki TokenOptions imiz dir
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters {

                    ValidateIssuer = true,//yani issue bilgilisini validate edeyimmi
                    //Biz kullaniciya token verdigimiz zaman issuer olarak engin.com u veriyoruz ve ondan bana bu bilginin
                    //geri gelmesi gerekiyor
                    ValidateAudience = true,
                    ValidateLifetime = true,//Biz suresiz token vermedigimiz icin true yaptik
                    ValidIssuer = tokenOptions.Issuer,//Bunu Tokenoptions dan almak istiyorum    
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,//Amahtari da kontrol edeyimmi evet kontrol et
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    //Bu bizim yazdiigmiz SecurityKeyHelper
                    //SigningKey SecurityKey tipinde olmasi gerekiyor uzerine gelirsek zaten goruruz
                };
                //TokenValidationParameters using Microsoft.IdentityModel.Tokens; dan geliyor....
            });
            //JwtBearerDefaults yazinca ustine glirsek bize install packages 
            //Authentication.JwtBearer diye bir paket gelir karsimiza o paketi yukleriz..

            //SIMDI SERVICECOLLECTION A YAZDIGIMIZ EXTENSION I BURDA KULLANABILIRIZ...
            services.AddDependencyResolvers(new ICoreModule[] {
   //Bu demektir ki yarin oburgun baska ICoreModule implementasyonu olan Modullerim olursa onlari da
   //buraya CoreModule un devamin a ekleyebiliriz
            new CoreModule(),
            });
            //Bu yapi ile beraber .Net Core tarafindaki bizim framwork seviyesinde uygulayabilecegimiz
            //butun merkezi servis injection konfigurasyonlarini burada yapmis olduk!!!!
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();
            //---burayi ekledik!!-----
            //Eger talep 3000 den gelirse burdan gelen herturlu talebe cevap ver demektir
            //AllowAnyHeader Header demek get,post,put,patch gibi http istekleridir onlarin
            //hepsine izin ver demis oluyoruz...
            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
            //---burayi ekledik--
            app.UseHttpsRedirection();

            app.UseRouting();
            //--  app.UseAuthentication(); ekledik
            app.UseAuthentication();//
            app.UseAuthorization();
            //UseAuthorization HttpContextAccessor yapisini enjekte ediyor...
            
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
