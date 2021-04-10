# Prueba Tecnica Carvajal (Leidy Tatiana Sanchez Arevalo)

## Requisitos 
 * Net core 3.1
 * Node v14.15.4
 * Npm 6.14.11
 * Angular CLI 11.0.7


## Pasos para Ejecutar el proyecto

Validar la cadena de conexion en el archivo appsettings.json
~~~
  "ConnectionStrings": {
    "CarvajalDb": "Server=localhost;Database=CarvajalDb;integrated security=true"
  }
~~~

### 1. Aplicar Migracion 
~~~
cd BackEnd\Carvajal.Infraestructure\
dotnet ef database update
~~~

### 2. Ejecutar Proyecto BackEnd
~~~
cd BackEnd\Carvajal.Api\
dotnet run .\Carvajal.Api.csproj
~~~

### 2. Ejecutar Proyecto FrontEnd
~~~
cd .\Client\ 
ng serve 
~~~