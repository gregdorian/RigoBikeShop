# RigoBikeShop
sistema de venta de elementos deportivos, Rigo Rigo

Se desarrollo en: 

•	 C# en .NET Core version 6

•	 Ado .net

•	 Con Procedimientos Almacenados (ver Listado)

•	Versionamiento de código (Git) https://github.com/gregdorian/RigoBikeShop

•	Manejo de Base de Datos sql Server

Se Realizaron los siguientes entidades/Tablas

![Rigo](https://github.com/gregdorian/RigoBikeShop/blob/master/RigoRigo.jpg)

Producto

FacturaEnc

Cliente

FacturaDetalle

Estructurado el proyecto en capas 

•	Acceso a datos = RigoBikeshop.Infraestructure.Data

•	Negocio = RigoBikeshop.Domain.Core

•	Entidades = RigoBikeshop.Domain.Entities

•	Presentación = RigoBikeshop.UIWebApi

# Cambiar la Cadena de conexion

**Se encuentra en appSettings.json**

"ConnectionStrings": {
   "DefaultConnection" : "Server=<<Instancia/NombreServidor>> ; Database= <<NombreBaseDatos>>; Integrated Security=true; TrustServerCertificate=true"
   }
SP Usadas en el proyecto

![Rigo](https://github.com/gregdorian/RigoBikeShop/blob/master/spRigoRigo.jpg)

**FRONTEND** 
Se realizo webApi restfull con Asp.net Core
![Rigo](https://github.com/gregdorian/RigoBikeShop/blob/master/ConsultaClientes.jpg)
Presentación se llama el webApi en pagina Razor MVC de Asp.net Core
![Rigo](https://github.com/gregdorian/RigoBikeShop/blob/master/PantallaVenta.jpg)
se debe tener encuenta que se esten inicializando estos dos proyectos para que tome los Endpoints del web api.
![Rigo](https://github.com/gregdorian/RigoBikeShop/blob/master/propiedadesSolucion.jpg)
