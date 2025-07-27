# AngularCRUD-SuperHerois 🦸‍♂️

Este projeto é um CRUD completo de gerenciamento de heróis utilizando Angular no front-end e ASP.NET Core no back-end, com Entity Framework Core e SQL Server.

## 🛠️ Tecnologias Utilizadas

- **Front-end:** Angular 20
- **Back-end:** ASP.NET Core Web API (.NET 8.0)
- **Banco de Dados:** SQL Server
- **ORM:** Entity Framework Core

---

## ⚙️ Como Configurar o Projeto

### 1. Clonar o repositório

```bash
git clone git@github.com:WayFerr/AngularCRUD-SuperHerois.git
```

---

### 2. Configurar a Connection String

No projeto do back-end (`SuperHeroisApi`), edite o arquivo `appsettings.json` e adicione a string de conexão ao banco de dados:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=localhost\\SQLEXPRESS;Initial Catalog=NomeDoBancoDeDados;User Id=UsuarioDoBanco;Password=SenhaDoBanco;TrustServerCertificate=True;MultipleActiveResultSets=True;"
}

```

---

### 3. Restaurar Pacotes e Criar o Banco

Você pode optar por uma das formas abaixo para criar o banco de dados:

#### 💡 Opção 1: Usando Migrations
Execute o comando no **Package Manager Console**:
!!! Certifique-se de que o projeto padrão no console esteja apontado para "4 - Infra\SuperHeroisApi.Infra".

```powershell
Update-Database
```

#### 💡 Opção 2: Usando scripts SQL
Use os scripts disponíveis na pasta:

```
/BancoDeDados
```

---

## 🧙 Autor

Desenvolvido por [@WayFerr](https://github.com/WayFerr)
