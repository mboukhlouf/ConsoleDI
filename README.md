# ConsoleDI
A project template for Console Application in .NET Core with Dependency Injection

## Configure Services

In Program.cs, you can add your services in the Configure Services method.

```csharp
  private static void ConfigureService(IServiceCollection services)
  {
      services.AddSingleton<IConfiguration>(Configuration);
      services.AddScoped<Application>();
      
      // Add more services
  }
```

## Application
The Application class becomes the new entry point, you can inject services in the constructor:
```csharp
  public Application(IConfiguration configuration)
  {
      this.configuration = configuration;
  }
```

And then in put your code in the Run method (the new main):
```csharp
  public void Run(string[] args)
  {
      var message = configuration["Message"];
      Console.WriteLine(message);
  }
```
