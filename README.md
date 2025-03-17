# Product CRUD - Documentación

Este proyecto consta de una aplicación basada en Angular 19.2.3 para la gestión de productos y una API REST desarrollada en .NET 8 utilizando Dapper como ORM. La aplicación permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre productos.

## Repositorios
- **Frontend (Angular):** [ProductCrud](https://github.com/4n1ma98/ProductCrud)
- **Backend (API .NET):** [Api_ProductCrud](https://github.com/4n1ma98/Api_ProductCrud)

## Instalación y Configuración

### 1. Clonar los repositorios
Ejecuta los siguientes comandos en tu terminal:
```sh
# Clonar el frontend
git clone https://github.com/4n1ma98/ProductCrud.git

# Clonar el backend
git clone https://github.com/4n1ma98/Api_ProductCrud.git
```

### 2. Configurar la Base de Datos
1. **Instalar SQL Server** si no lo tienes.
2. **Ejecutar el script de base de datos** ubicado en el repositorio del API REST (`/Database/ProductCrud.sql`).
3. **Actualizar la cadena de conexión** en `appsettings.json` dentro del proyecto de la API:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=ProductCrud;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
}
```
4. La base de datos incluye una tabla adicional TBL_ErrorLog para registrar y gestionar los errores generados en la API.
5. Se ha dejado un diagrama en la misma carpeta del script de la base de datos (/Database/Diagrama_ProductCrud.png).

### 3. Configurar y ejecutar la API REST
Dentro del directorio `Api_ProductCrud`, ejecuta:
```sh
# Restaurar paquetes
dotnet restore

# Compilar la API
dotnet build

# Ejecutar la API
dotnet run
```

### 4. Configurar y ejecutar el Frontend
Dentro del directorio `ProductCrud`, ejecuta:
```sh
# Instalar dependencias
npm install

# Ejecutar la aplicación en modo desarrollo
ng serve
```
El frontend normalmente estará disponible en `http://localhost:4200`.
El backend normalmente estará disponible en `http://localhost:7278`.

## Funcionalidades y Uso

### 1. Creación de Productos
- Al iniciar la aplicación, se muestra un formulario de registro.
- Se ingresan los datos del producto (**nombre, descripción, precio y stock**).
- Al enviar el formulario, se consume el servicio **CreateProduct** para registrar el producto.
- Validaciones tanto en frontend como en backend aseguran que los datos sean correctos.

### 2. Listado de Productos
- Al abrir la aplicación, se carga automáticamente la lista de productos consumiendo el servicio **ReadProduct**.
- Si se especifica un ID, se muestra solo ese producto.
- Implementa paginación y un buscador para filtrar por nombre.
- La interfaz es responsive, adaptándose a distintos dispositivos.

### 3. Edición de Productos
- Cada producto tiene un botón "Editar".
- Al hacer clic, se carga un formulario prellenado con los datos actuales del producto.
- Se pueden modificar el **precio** y el **stock**.
- Al guardar los cambios, se consume el servicio **UpdateProduct**.

### 4. Eliminación de Productos
- Cada producto tiene un botón "Eliminar".
- Al hacer clic, se solicita confirmación.
- Si se confirma, se consume el servicio **DeleteProduct** para eliminarlo de la base de datos.

## Pruebas y Validaciones
- **Validaciones en el Cliente:** Se verifica que los campos sean obligatorios y tengan el formato correcto.
- **Validaciones en el Servidor:** Se implementan reglas de negocio en la API.
- **Paginación:** La lista de productos está paginada para mejorar la usabilidad.
- **Búsqueda:** Se puede filtrar productos por nombre desde el frontend.

## Consumo de la API REST
| Método HTTP | Endpoint | Descripción |
|------------|----------|-------------|
| `POST` | `/api/Product/CreateProduct` | Crear un nuevo producto |
| `GET` | `/api/Product/ReadProduct` | Obtener la lista de todos los productos |
| `GET` | `/api/Product/ReadProduct/{id}` | Obtiene un producto por su ID |
| `PUT` | `/api/Product/UpdateProduct` | Actualizar un producto (id y datos de actualización por body) |
| `DELETE` | `/api/Product/DeleteProduct/{id}` | Elimina un producto |

Para probar la API, se pueden usar herramientas como **Postman** o **Swagger**.

---
_Hecho con ❤️ por Andres David Peña Velandia._

