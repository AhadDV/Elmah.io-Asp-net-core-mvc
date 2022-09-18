using Elmah.Io.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<ElmahIoOptions>(builder.Configuration.GetSection("ELmahIo"));
builder.Services.AddElmahIo();

// builder.Services.AddElmahIo(x=>{
// x.ApiKey="a4e9a85af8134697879b22b7362ad998";
// x.LogId=new Guid("4b50920a-b2f0-479f-a48a-b7a4f3294b64");
//    x.WebProxy = new System.Net.WebProxy("localhost", 7265);
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseElmahIo();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
