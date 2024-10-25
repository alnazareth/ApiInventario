# ApiInventario

![image](https://github.com/user-attachments/assets/0761257f-1ef9-4469-89dc-996ec1033a10)


# API del Sistema de Inventario

Esta API proporciona servicios para gestionar productos en un sistema de inventario. Permite operaciones como la creación, actualización, eliminación y reducción de stock de productos.

## Características

- Gestión de productos (crear, editar, eliminar).
- Reducción de stock de productos.
- Categorización de productos por estado (Ejemplo: `En stock`, `Defectuoso`).
- Endpoints RESTful.

Endpoints Principales
Método	Endpoint	Descripción
GET	/api/productos	Obtiene la lista de productos.
GET	/api/productos/{id}	Obtiene un producto por su ID.
POST	/api/productos	Crea un nuevo producto.
PUT	/api/productos/{id}	Actualiza un producto existente.
PUT	/api/SalidaProductos/{id}	Reduce el stock de un producto.
DELETE	/api/productos/{id}	Elimina un producto por su ID.

## Prerrequisitos

- **.NET SDK** 6 o superior.
- **Microsoft.EntityFrameworkCore.Tools** 
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.AspNetCore.Authentication.JwtBearer**

## Instalación

1. Descarga el Zip o clona el repositorio

2. extraer proyecto y abrir solucion

![image](https://github.com/user-attachments/assets/469a5185-758c-45bd-b18a-61fbd92c540c)

3.Ejecutar

![image](https://github.com/user-attachments/assets/1b6618c0-7077-40f6-9776-c7208b2ab127)
