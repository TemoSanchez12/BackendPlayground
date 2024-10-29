# Proyecto ASP.NET Core - Web APIs con Entity Framework, Manejo de usuarios

Este proyecto es una aplicación ASP.NET Core que expone una serie de Web APIs para la gestión de datos a través de Entity Framework.

## Tecnologías utilizadas

- **ASP.NET Core**: Framework para la creación de aplicaciones web.
- **Entity Framework Core**: ORM para interactuar con la base de datos de manera eficiente.
- **User Secrets**: Herramienta para manejar configuraciones sensibles en el entorno de desarrollo.
- **Postgress **: Base de datos relacional utilizada en el proyecto.

## Requisitos previos

- **SDK de .NET Core 8.0 o superior**
- **SQL Server**
- **Herramienta de gestión de paquetes como NuGet**
- **Visual Studio 2022**

## Configuración del entorno

### 1. Clonar el repositorio

```bash
git clone https://github.com/TemoSanchez12/BackendPlayground
cd BackendPlayground
```

### 2. Configuración de User Secrets

- Abre la terminal en el directorio del proyecto.
- Entrar al proyecto ExamenBackend.API
- Inicializa los secretos de usuario:

```bash
dotnet user-secrets init
```

- Configurar key para JWT:

```bash
dotnet user-secrets set "JwtSettings:Secret" "D3V56k#@fKz8F9x2_!Mf37Ljp3!KD3V56k#@fKz8F9x2_!Mf37Ljp3!KD3V56k#@fKz8F9x2_!Mf37Ljp3!K"
dotnet user-secrets set "JwtSettings:Issuer" "localhost.com"
dotnet user-secrets set "JwtSettings:Audience" "localhost.com"
```

### 3. Restaurar paquetes

- Abre la terminal en el directorio del proyecto.
- Entrar al proyecto ExamenBackend.API
- Ejecutar comando

```bash
dotnet restore
```

### 4. Hacer migracion a base de datos

En el archivo appsettings.Development.json se encuentra el archivo de configuracion del proyecto, se tiene que replazar ahi la cadena de conexion que se utilizara.

```code
{
 "Logging": {
   "LogLevel": {
     "Default": "Information",
     "Microsoft.AspNetCore": "Warning"
   }
 },
 "ConnectionStrings": {
   "ExamenDb": "Server=localhost;User Id=postgres;Password=Dona21; Port=5432; Database=ExamenDb; Include Error Detail = true;"
 }
}

```

En este caso la cadena es

```code
"ExamenDb": "Server=localhost;User Id=postgres;Password=Dona21; Port=5432; Database=ExamenDb; Include Error Detail = true;"

```

Hay que hacer el remplazo.

#### Ejecutar comando update

- Abrir la consola de administrador de paquetes nuget, situar el proyecto default en Infrastructura y ejecutar el siguiente comando

```bash
Update-Database
```

### 5. Ejecutar proyecto

- Abre la terminal en el directorio del proyecto ExamenBack.API
- Ejecutar

```bash
dotnet run
```
