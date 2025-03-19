# MediQueue Backend

O **MediQueue** é um sistema desenvolvido para otimizar o fluxo de atendimento. Permitindo um gerenciamento eficiente de pacientes e triagem.

## 🛠 Tecnologias Utilizadas

- .NET 8
- Entity Framework Core (Database First)
- FluentValidation
- Swagger para documentação da API

## 🚀 Configuração do Projeto

### 1️⃣ Clonando o Repositório

```sh
git clone https://github.com/mooizabaatista/MediQueue_Backend.git
cd MediQueue_Backend
```

### 2️⃣ Configurando a String de Conexão

Antes de rodar a API, você precisa configurar a **Connection String** dentro do arquivo `appsettings.json` no projeto **MediQueue.Api**:

📌 **Altere este trecho no `appsettings.json`**:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<SERVIDOR>;Database=MediqueueDB;User Id=<USUARIO>;Password=<PASSWORD>;TrustServerCertificate=True;"
}
```

### 3️⃣ Restaurando Pacotes

```sh
dotnet restore
```

### 4️⃣ Rodando a API

```sh
dotnet run --project MediQueue.Api
```

A API estará disponível em `https://localhost:7260/swagger` para testes.
