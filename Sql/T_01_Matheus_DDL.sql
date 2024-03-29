CREATE DATABASE T_OpFlix

USE T_OpFlix

CREATE TABLE Categoria
(
	IdCategoria		INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR(255) NOT NULL
);

CREATE TABLE TipoUsuario
(
	IdTipo			INT PRIMARY KEY IDENTITY
	,Tipo			VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Identificacao
(
	IdIdentificacao	INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR(255) NOT NULL
);

CREATE TABLE Usuario
(
	IdUsuario		INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR(255) NOT NULL
	,Email			VARCHAR(255) NOT NULL UNIQUE
	,Senha			VARCHAR(255) NOT NULL
	,IdTipo			INT FOREIGN KEY REFERENCES TipoUsuario (IdTipo)
);

CREATE TABLE Classificacao
(
	IdClassificacao INT PRIMARY KEY IDENTITY
	,Classificacao	VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE FilmeSeries
(
	IdFS			INT PRIMARY KEY IDENTITY
	,Titulo			VARCHAR(255) NOT NULL UNIQUE
	,DataLancamento	DATE
	,IdCategoria	INT FOREIGN KEY REFERENCES Categoria(IdCategoria)
	,IdIdentificacao INT FOREIGN KEY REFERENCES Identificacao(IdIdentificacao)
	,Sinopse		VARCHAR(255) NOT NULL
	,TempoDuracao	INT NOT NULL
	,Veiculo		VARCHAR(255) NOT NULL
	,IdClassificacao INT FOREIGN KEY REFERENCES Classificacao(IdClassificacao)
	,IdPlataforma	INT FOREIGN KEY REFERENCES Plataforma(IdPlataforma)
);

CREATE TABLE Plataforma
(
	IdPlataforma	INT PRIMARY KEY IDENTITY
	,Nome			VARCHAR(255) NOT NULL UNIQUE
);

ALTER TABLE FilmeSeries
ALTER COLUMN Sinopse VARCHAR(600)

select * from Usuario 