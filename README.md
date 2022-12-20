# Autenticación y Refresh Token API REST .NET CORE 7

## Implementacion simple de JSON WEB TOKEN y Refresh Token en ASP.NET CORE

### Para Iniciar el proyecto
1. Ejecutar los scripts de SQLQUERYS para crear la base de datos con sus tablas
2. Poner la siguiente instruccion en la consola de nugget sacando los parentesis ==Scaffold-DbContext "Server=(SuServer); DataBase=(SubaseDeDatos); Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models==
3. Crear sobre el proyecto el archivo ==appsettings.json== y copiar todo lo que contenga appsettings.Development.json y agregarle el codigo de abajo con sus respectivas credenciales

	`
		"AllowedHosts": "*",
		"ConnectionStrings": {
			"cadenaSQL": "Server=(SuServer); DataBase=(SuBaseDeDatos); Trusted_Connection=True; TrustServerCertificate=True;"
		},
		"JwtSettings": {
			"key": "=probando_jwt1234="
		}
	`

## Librerias usadas
  - Microsoft.EntityFrameworkCore.SqlServer - version 7
  - Microsoft.EntityFrameworkCore.Tools - version 7
  - Microsoft.AspNetCore.Authentication.JwtBearer - version 7
  - System.IdentityModel.Tokens.Jwt - version 6.25.1



