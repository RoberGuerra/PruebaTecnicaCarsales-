# PruebaTecnicaCarsales

BFF en .NET 8 consumiendo la API de Rick & Morty, + Frontend en Angular 19 (standalone).

## 🛠 Prerrequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- [Node.js (≥18)](https://nodejs.org/) y npm  
- Angular CLI (`npm install -g @angular/cli`)

## 📥 Instalación

1. Clona el repositorio:  
   ```bash
   git clone https://github.com/tu-usuario/PruebaTecnicaCarsales.git
   cd PruebaTecnicaCarsales

## Backend (.NET Core)
2. Entra al folder del backend y restaura dependencias: 
   ```bash
    cd PruebaTecnicaCarsales       # contiene PruebaTecnicaCarsales.csproj
    dotnet restore

3. Configura tu clave API y la URL base de Rick & Morty en appsettings.json: 
   ```bash
    {
      "RickAndMortyApi": {
        "BaseUrl": "https://rickandmortyapi.com/api/"
      },
      "ApiKey": "UG9yZmF2b3IgY29udHLDoXRlbm1l"
    }

4. Levanta el servidor: 
   ```bash
    dotnet run
    //Verás lo siguiente: Now listening on: http://localhost:5056 //

5. Abre Swagger UI para probar endpoints: 
   ```bash
    http://localhost:5056/swagger

## Frontend (Angular)

6. En otra terminal, ve al folder Angular y instala paquetes:
   ```bash
    cd ../PruebaTecnicaCarsales-Frontend  # o la carpeta donde esté tu proyecto Angular
    npm install

7. Configura la URL y API Key en src/environments/environment.ts:
   ```bash
    export const environment = {
      production: false,
      apiBaseUrl: 'http://localhost:5056/api/rickandmorty',
      apiKey: 'UG9yZmF2b3IgY29udHLDoXRlbm1l'
    };
   
8. Inicia la app Angular:
   ```bash
   ng serve --open

## 🚀 Uso
- Navega a /episodes para ver la lista paginada de episodios.
- Haz clic en “Mostrar personajes” para expandir y en la flecha o nombre para ver el detalle en /character/:id.

## 📝 Estructura
   ```bash
    /
    ├─ README.md
    ├─ PruebaTecnicaCarsales/          ← proyecto .NET
    │  ├─ appsettings.json
    │  ├─ Program.cs
    │  └─ …
    └─ PruebaTecnicaCarsales-Frontend/  ← proyecto Angular
       ├─ src/
       ├─ angular.json
       └─ …
