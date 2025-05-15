public class Startup
{
    // ... other code ...

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ... other middleware ...

        app.UseStaticFiles();

        // ... other middleware ...
    }
}