##Базове створення
```
Додаємо ASP WEB API проект
і завантажуємо dotnet add package Swashbuckle.AspNetCore
 У Program.cs

builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();


#Додаємо Class Library .DAL .BLL
і Dependecy 
		.BLL add project refernces на .DAL
		.API add project refernces на .DAL .BLL
```

##NuGet
```
.DAL
			Microsoft.EntityFrameworkCore
			Microsoft.EntityFrameworkCore.Design
			Npgsql.EntityFrameworkCore.PostgreSQL

.API
			NuGet: Microsoft.EntityFrameworkCore.Tools

```

##STEP 2
```
Створ Entities, AppDbContext
Створ Controller

```

##Videos

Для налаштування так як і для фото потрібно StaticFiles
```csharp
string VideosPath = Path.Combine(env.ContentRootPath, StaticFilesSettings.VideosPath);

app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(VideosPath),
                RequestPath = StaticFilesSettings.WebVideosPath, //StaticFilesSettings - наш клас де прописували змінні
            });
```
і все в бразузері вводимо /Videos/vide_name.mp4 і готово
