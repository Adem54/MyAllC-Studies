using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Security.jwt;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Encryption;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.DependencyResolvers;

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
           //--------------------------
            //services.AddCors u ekliyoruz...
            //Apimize bizim izin verdigimizin disinda bir istek geldiginde onu guvensiz
            //baglanma ve tehdit algilamasi icin yazariz bu kodu..
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost/3000"));
            });//Origin istek yapilan yer demektir
               //localhost:3000 demek bir React uygulamasinin yayin adresidir
               //Burasi test ortami icin bunu yazdik ama gercek bir uygulamada 
               //"http://localhost/3000" yerine domain ismimizi yazariz...
               //Birden fazla domaine sahipsek de onlari virgulle ayirarak devam edebilirz
               //Cunku WithOrigins params paramatresine sahip bunu uzerine mausumuzla gidince gorebiliriz
               //Bu islemden sonra bir de Configure icerisinde Middleware eklemeliyiz...
               //---------------------------------

            //services.AddCors un bitimine asagida ekledigimiz authentication in servisini yazariz..
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {// Microsoft.AspNetCore.Authentication.JwtBearer paketini yuklemeliyiz.....
                //TokenValidationParameters  Microsoft.IdentityModel.Tokens dan gelir
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

           };
            });

            services.AddDependencyResolvers(new ICoreModule[]{
            new CoreModule(),
            //Biz bu kendi olusturdugumuz extension u bu sekilde calistirinca bu extension icerisindde
            //kendisi hem Load islemini yapiyor hem de servise baglanmamizi servis yapilandirmamizi
            //sagliyor kendisi
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //-------------------Middleware ekleme

            app.ConfigureCustomExceptionMiddleware();
            //Eger talep 3000 den gelirse burdan gelen herturlu talebe cevap ver demektir
            //AllowAnyHeader Header demek get,post,put,patch gibi http istekleridir onlarin
            //hepsine izin ver demis oluyoruz...
            app.UseCors(builder => builder.WithOrigins("http://localhost/3000").AllowAnyHeader());
            //----------------
            app.UseHttpsRedirection();

            app.UseRouting();
            //----UseAuthentication buraya eklenmeli ki gelen talep lere karsilik verebilelim
            //Authentication Authorization inuzerinde olmali cunku once Authentciation ile sisteme
            //girilir ve token alinir daha sonra ekstra ozel kaynaklara ulasmak icin yetki kontrolu
            //yapilir...
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
