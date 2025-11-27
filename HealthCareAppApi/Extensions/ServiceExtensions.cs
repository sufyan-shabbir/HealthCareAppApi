//using Kutiyana_Memon_Hospital_Api.API.Entities;
//using Kutiyana_Memon_Hospital_Api.API.Services.GetCurrentUser;
//using Kutiyana_Memon_Hospital_Api.API.Services.Implementation;
//using Kutiyana_Memon_Hospital_Api.API.Services.Interfaces;
//using Kutiyana_Memon_Hospital_Api.Services.Implementation;
//using Kutiyana_Memon_Hospital_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens; 
using System.Text;

namespace HealthCareAppApi.API.Extensions
{
    public static class ServiceExtensions


    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var key = Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"]);
            var issuer = config["JwtSettings:Issuer"];
            var audience = config["JwtSettings:Audience"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true
                };
            });
        }




        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IRoleService, RoleService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ICompanyService, CompanyService>();
            //services.AddScoped<IUserContextService, UserContextService>();
            //services.AddScoped<IJwtService, JwtService>();
            //services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<IMenuService, MenuService>();
            //services.AddScoped<ILookupService, LookupService>();
            //services.AddScoped<IPatientService, PatientService>();
            //services.AddScoped<ICityService, CityService>();
            //services.AddScoped<IAreaService, AreaService>();
            //services.AddScoped<IServiceKmhService, ServiceKmhService>();
            //services.AddScoped<IDepartmentService, DepartmentService>();
            //services.AddScoped<ISubDepartmentService, SubDepartmentService>();
            //services.AddScoped<IWardProcedureService, WardProcedureService>();
            //services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            //services.AddScoped<IOPDBillService, OPDBillService>();
            //services.AddScoped<IFilterService, FilterService>();
            //services.AddScoped<IOPDRefundService, OPDRefundService>();
            //services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
            //services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<IStateService, StateService>();
            //services.AddScoped<IStatusService, StatusService>();
            //services.AddScoped<IDesignationService, DesignationService>();
            //services.AddScoped<INationalityService, NationalityService>();
            //services.AddScoped<IPanelService, PanelService>();
            //services.AddScoped<IVisitInformationService, VisitInformationService>();
            //services.AddScoped<IPaymentModeService, PaymentModeService>();
            //services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentService>();
            //services.AddScoped<IWelfareService, WelfareService>();
            //services.AddScoped<IZakatService, ZakatService>();
            //services.AddScoped<IKMH_DIA_REG_Services, KMH_DIA_REG_Service>();
            //services.AddScoped<IEmergencyPatientService, EmergencyPatientService>();
            //services.AddScoped<IDialysisBookingService, DialysisBookingService>();
            //services.AddScoped<IDialysisMachineService, DialysisMachineService>();


            services.AddHttpContextAccessor();
        }


    }
}
