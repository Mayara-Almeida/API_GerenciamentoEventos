-- Criando o banco

CREATE DATABASE GerenciamentoEventos;
GO

USE GerenciamentoEventos;
GO

-- Criando tabelas

CREATE TABLE Especialidade(
	EspecialidadeID INT PRIMARY KEY IDENTITY,
	NomeEspecialidade VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE TipoUsuario(
	TipoUsuarioID INT PRIMARY KEY IDENTITY,
	Tipo VARCHAR(50) UNIQUE NOT NULL
);
GO

CREATE TABLE Usuario(
	UsuarioID INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(60) NOT NULL,
	Email VARCHAR(150) UNIQUE NOT NULL,
	Senha VARBINARY(32) NOT NULL,

	EspecialidadeID INT FOREIGN KEY REFERENCES Especialidade(EspecialidadeID),
	TipoUsuarioID INT FOREIGN KEY REFERENCES TipoUsuario(TipoUsuarioID)
);
GO

CREATE TABLE Evento(
	EventoID INT PRIMARY KEY IDENTITY,
	Nome NVARCHAR(150) NOT NULL,
	DataEvento DATE NOT NULL,
	LocalEvento NVARCHAR(150) NOT NULL
);
GO

CREATE TABLE UsuarioEvento(
	UsuarioID INT NOT NULL,
	EventoID INT NOT NULL,

	CONSTRAINT PK_UsuarioEvento PRIMARY KEY(UsuarioID, EventoID),
	CONSTRAINT FK_UsuarioID FOREIGN KEY(UsuarioID) REFERENCES Usuario(UsuarioID) ON DELETE CASCADE,
	CONSTRAINT FK_EventoID FOREIGN KEY(EventoID) REFERENCES Evento(EventoID) ON DELETE CASCADE
);
GO

-- Inserir dados

INSERT INTO Especialidade(NomeEspecialidade)
	VALUES
	('Estudante'),	
	('Psicologia'),
	('Administração')
GO

INSERT INTO TipoUsuario(Tipo)
	VALUES
	('Participante'),	
	('Palestrante'),
	('Administrador')
GO

INSERT INTO Usuario(Nome, Email, Senha, EspecialidadeID,TipoUsuarioID)
	VALUES
	('Mayara Almeida', 'mayaraAlmeida@eventos.com', HASHBYTES('SHA2_256', 'admin@123'), 3, 3),
	('Rafaella Hahon', 'rafaHahon@gmail.com', HASHBYTES('SHA2_256', 'senha@123'), 1, 1)
GO

INSERT INTO Evento(Nome, DataEvento, LocalEvento)
	VALUES
	('Entendendo a mente humana', '2026-03-21', 'Auditório Áureo, Alameda dos Poetas, 456 – 10º Andar – Centro Histórico, Villa das Artes (RS)')
GO

INSERT INTO UsuarioEvento(UsuarioID, EventoID)
	VALUES
	(2, 1)
GO
