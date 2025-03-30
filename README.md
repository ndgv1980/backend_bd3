# Backend Base de Datos III

Esta librería es un backend para interactuar con una base de datos relacional MySQL y una base de datos no relacional MongoDB. Es parte del proyecto de la asignatura Base de Datos III de la Universidad Galileo, del primer trimestre del año 2025 de la carrera TDS -Técnico en Desarrollo de Software-.

## Requisitos

- Windows 10 o superior.
- .NET 9.
- Opcional: Visual Studio o Visual Studio Code.

## Cómo ejecutarlo ▶️

1. Clonar el repositorio usando:
```
git clone https://github.com/ndgv1980/backend_bd3.git
```
O descargando el repositorio como zip.

2. Abrir una terminal e ir a la carpeta donde se encuentra el proyecto BackendBDIII.

3. Compilar el proyecto utilizando el siguiente comando:
```
dotnet build 
```

4. Agregar a las variables de entorno el URI de MongoDB, donde la llave de la variable tiene que ser MONGODB_URI.

5. Ejecutar el proyecto con el siguiente comando:
```
dotnet run
```


## Cómo configurar MongoDB 🔧

1. Crear un cluster.

2. Crear tres colecciones:
    - operator_comments
    - products_history
    - sales_history 

```
⚠️ Agregar la IP donde se va a ejecutar a la lista de IPs habilitadas por MongoDB.
```