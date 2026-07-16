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