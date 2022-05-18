using BackEnd_Travelity.Environment;
using BackEnd_Travelity.Repository.AdminRepo;
using BackEnd_Travelity.Repository.AVBudgetRepo;
using BackEnd_Travelity.Repository.BudgetRepo;
using BackEnd_Travelity.Repository.BudgetReportRepo;
using BackEnd_Travelity.Repository.ChatRepo;
using BackEnd_Travelity.Repository.CommentRepo;
using BackEnd_Travelity.Repository.CouponRepo;
using BackEnd_Travelity.Repository.ExplorerRepo;
using BackEnd_Travelity.Repository.FriendRepo;
using BackEnd_Travelity.Repository.FriendRequestRepo;
using BackEnd_Travelity.Repository.GroupRepo;
using BackEnd_Travelity.Repository.LikeRepo;
using BackEnd_Travelity.Repository.MostVisitedRepo;
using BackEnd_Travelity.Repository.PermissionRepo;
using BackEnd_Travelity.Repository.PictureRepo;
using BackEnd_Travelity.Repository.PlaceRepo;
using BackEnd_Travelity.Repository.ReminderRepo;
using BackEnd_Travelity.Repository.TicketRepo;
using BackEnd_Travelity.Repository.UserRepo;
using BackEnd_Travelity.Services.AdminService;
using BackEnd_Travelity.Services.AVBudgetService;
using BackEnd_Travelity.Services.BudgetReportService;
using BackEnd_Travelity.Services.BudgetService;
using BackEnd_Travelity.Services.ChatService;
using BackEnd_Travelity.Services.CommentService;
using BackEnd_Travelity.Services.CouponService;
using BackEnd_Travelity.Services.ExplorerService;
using BackEnd_Travelity.Services.FriendRequestService;
using BackEnd_Travelity.Services.FriendService;
using BackEnd_Travelity.Services.GroupService;
using BackEnd_Travelity.Services.LikesService;
using BackEnd_Travelity.Services.MostVisitedService;
using BackEnd_Travelity.Services.PermissionService;
using BackEnd_Travelity.Services.PictureService;
using BackEnd_Travelity.Services.PlaceService;
using BackEnd_Travelity.Services.ReminderService;
using BackEnd_Travelity.Services.TicketService;
using BackEnd_Travelity.Services.UserService;
using Microsoft.EntityFrameworkCore;


//var UserCorsRules = "UserCors";
var AdminCorsRules = "AdminCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    //options.AddPolicy(name: UserCorsRules, builder =>
    //{
    //    builder.WithOrigins("164.68.120.109")
    //            .WithMethods("GET","PATCH","POST")
    //            .AllowAnyHeader();
    //});
    options.AddPolicy(name: AdminCorsRules, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

    });
});

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")));


// Add services to the container.
builder.Services.AddControllers();
// Adding AutoMapping to the service.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cookies if we are going to role it out to web
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromDays(30);

//    options.LoginPath = "/";
//    options.AccessDeniedPath = "/";
//    options.SlidingExpiration = true;
//});


/// <summary>
/// this is our section for the services that is used in our backend of Travelity
/// </summary>

//Admin Scope
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

//Avaliable Budget Scope
builder.Services.AddScoped<IAVBudgetRepository, AVBudgetRepository>();
builder.Services.AddScoped<IAVBudgetService, AVBudgetService>();

//Budget Scope
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IBudgetService, BudgetService>();

//Budget Report Scope
builder.Services.AddScoped<IBudgetReportRepository, BudgetReportRepository>();
builder.Services.AddScoped<IBudgetReportService, BudgetReportService>();

//Chat Scope
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();

//Comment Scope
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

//Coupon Scope
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<ICouponService, CouponService>();

//Explorer Scope
builder.Services.AddScoped<IExplorerRepository, ExplorerRepository>();
builder.Services.AddScoped<IExplorerService, ExplorerService>();

//Friend Scope
builder.Services.AddScoped<IFriendRepository, FriendRepository>();
builder.Services.AddScoped<IFriendService, FriendService>();

//Friend Scope
builder.Services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
builder.Services.AddScoped<IFriendRequestService, FriendRequestService>();


//Group Scope
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupService, GroupService>();

//ILikes Scope
builder.Services.AddScoped<ILikeRepo, LikeRepo>();
builder.Services.AddScoped<ILikesService, LikesService>();

//Most Visited Scope
builder.Services.AddScoped<IMostVisitedRepository, MostVisitedRepository>();
builder.Services.AddScoped<IMostVisitedService, MostVisitedService>();

//Permission Scope
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

//Picture Scope
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IPictureService, PictureService>();

//Place Scope
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceService, PlaceService>();

//Reminder Scope
builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
builder.Services.AddScoped<IReminderService, ReminderService>();

//Ticket Scope
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

//User Scope
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/AdminCorsRules",
        context => context.Response.WriteAsync("AdminCorsRules"))
            .RequireCors(AdminCorsRules);

    endpoints.MapControllers()
        .RequireCors(AdminCorsRules);

    endpoints.MapSwagger();
});

app.Run();
