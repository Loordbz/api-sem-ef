# Projeto API Sem EF (Entity Framework)

## Descrição
Geralmente para facilitar a conexão entre banco/api geralmente são instalados os pacotes o EF. Nesse projeto, foi utilizado o DAPPER (sim ele ajuda com conexões ao banco de dados) mas toda a consulta foi escrita em SQL.

## Passos:
Será necessário executar alguns comandos para criar o banco de dados.

### 1. Ter instaldo o SSMS:
- Sql Server Management Studio (SSMS), é uma ferramenta de gerenciamento de banco de dados da Microsoft usada para gerenciar instâncias do Microsoft SQL Server. 
- Baixar aqui -> [https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16](https://aka.ms/ssmsfullsetup)

### 2. Executar os Comandos para Criação do banco:
- CREATE DATABASE Pokemons; -- Criar o banco.

- USE Pokemons; -- Acessar o banco.

- CREATE TABLE Tipos (
  	Id INT  PRIMARY KEY IDENTITY(1,1),
  	Tipo VARCHAR(10));  -- Criar a tabela Tipos, que seria o poder do pokemnon!

- CREATE TABLE Pokemon (
  	Id INT  PRIMARY KEY IDENTITY(1,1),
  	Nome VARCHAR(15),
  	Pokedex INT UNIQUE,
  	Evolucao BIT NOT NULL,
  	EvolucaoId INT); -- Criar a tabela Pokemon, onde estarão salvos os pokemons!
    
- Create Table PokemonTipo (
  	Id INT PRIMARY KEY IDENTITY(1,1),
  	IdPokemon INT UNIQUE,
  	IdTipo INT,
	  IdTpo2 INT,
  	FOREIGN KEY(IdTipo) REFERENCES Tipos(Id)); -- Criar a tabela de "conexão" entre Pokemon e Tipos.

### 3. Povar as Tabelas:
- INSERT INTO Tipos VALUES ('ÁGUA'), ('DRAGÃO'), ('ELÉTRICO'), 
  ('FADA'), ('FANTASMA'), ('FOGO'),
  ('GELO'), ('INSETO'), ('LUTADOR'),
  ('METÁLICO'), ('NORMAL'), ('NOTURNO'),
  ('PEDRA'), ('PLANTA'), ('PSÍQUICO'),
  ('TERRESTRE'), ('VENENOSO'), ('VOADOR'); -- Inserir os dados na tabela Tipos.
 
 - INSERT INTO Pokemon VALUES ('Bulbasaur', 1, 1, 2), ('Ivysaur', 2, 1, 3), ('Venusaur', 3, 0, NULL),
  ('Charmander', 4, 1, 5), ('Charmeleon', 5, 1, 6), ('Charizard', 6, 0, NULL),
  ('Squirtle', 7, 1, 8), ('Wartotle', 8, 1, 9), ('Blastoise', 9, 0, NULL), 
  ('Caterpie', 10, 1, 11), ('Metapod', 11, 1, 12), ('Butterfree', 12, 0, NULL),
  ('Weedle', 13, 1, 14), ('Kakuna', 14, 1, 15), ('Beedrill', 15, 0, NULL),
  ('Pidgey', 16, 1, 17), ('Pidgeotto', 17, 1, 18), ('Pidgeot', 18, 0, NULL),
  ('Rattata', 19, 1, 20), ('Raticate', 20, 0, 21), ('Spearow', 21, 1, 22), ('Fearow', 22, 0, NULL),
  ('Ekans', 23, 1, 24), ('Arbok', 24, 0, NULL), ('Pikachu', 25, 1, 26), ('Raichu', 26, 0, NULL); -- Inserir os dados na tabela Pokemon.

- INSERT INTO PokemonTipo VALUES (1, 14, 17), (2, 14, 17), (3, 14, 17), (4, 6, 0), (5, 6, 0), (6, 6, 0),
  (7, 1, 0), (8, 1, 0), (9, 1, 0), (10, 8, 0), (11, 8, 0), (12, 8, 18), (13, 8, 17), (14, 8, 17), (15, 8, 17),
  (16, 11, 18), (17, 11, 18), (18, 11, 18), (19, 11, 0), (20, 11, 0), (21, 11, 18), (22, 11, 18), 
  (23, 17, 0), (24, 17, 0), (25, 3, 0), (26, 3, 0); -- Inserir os dados na tabela de "conexão".
  
  # ENJOY!
