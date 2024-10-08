--CREATE DATABASE Sistema_GestaoDeEventos;
--GO

--CREATE SCHEMA SGE;
--GO


--SELECT * FROM sys.schemas;


-- Eliminar tabelas:
DROP TABLE SGE.Particular;
DROP TABLE SGE.Empresa;
DROP TABLE SGE.Empregado;
DROP TABLE SGE.ServicoAdicional;
DROP TABLE SGE.Reserva;
DROP TABLE SGE.Pagamento;
DROP TABLE SGE.Evento;
DROP TABLE SGE.Espaco;
DROP TABLE SGE.Manager;
DROP TABLE SGE.Cliente;


CREATE TABLE SGE.Cliente(
    NIF INTEGER NOT NULL CHECK(LEN(NIF)=9),
    Nome VARCHAR(255) NOT NULL,
    NumTelef INTEGER NOT NULL,
    Endereco VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    ReservaID INTEGER,
    PRIMARY KEY(NIF)
);

CREATE TABLE SGE.Particular(
    CC INTEGER NOT NULL,
    ParticularNIF INTEGER,
    PRIMARY KEY (CC)
);

CREATE TABLE SGE.Empresa(
    EmpresaNIF INTEGER,
    PRIMARY KEY (EmpresaNIF)
);

CREATE TABLE SGE.Manager(
    CC INTEGER NOT NULL,
    Nome VARCHAR(255) NOT NULL,
    NumTelef INTEGER NOT NULL,
    Email VARCHAR(255) NOT NULL,
    PRIMARY KEY(CC)
);

CREATE TABLE SGE.Empregado(
    CC INTEGER NOT NULL,
    ManagerCC INTEGER NOT NULL,
    NIF INTEGER NOT NULL CHECK(LEN(NIF)=9),
    Trabalho VARCHAR(255) NOT NULL,
    Salario INTEGER NOT NULL CHECK(Salario >= 0),
    PRIMARY KEY(CC)
);

CREATE TABLE SGE.ServicoAdicional(
    ID INTEGER IDENTITY(1,1),
    ManagerCC INTEGER NOT NULL,
    Descricao VARCHAR(255),
    Custo INTEGER NOT NULL CHECK(Custo >= 0),
    PRIMARY KEY(ID)
);

CREATE TABLE SGE.Evento(
    ID INTEGER IDENTITY(1,1),
    DataEvento DATE NOT NULL,
    Nome VARCHAR(255) NOT NULL,
    Descricao VARCHAR(255),
    PRIMARY KEY(ID)
);

CREATE TABLE SGE.Espaco(
    ID INTEGER IDENTITY(1,1),
    Descricao VARCHAR(255),
    Nome VARCHAR(255) NOT NULL,
    Lotacao INTEGER NOT NULL CHECK(Lotacao > 0),
    Localizacao VARCHAR(255) NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE SGE.Pagamento(
    ID INTEGER IDENTITY(1,1),
    DataPagamento DATE NOT NULL,
    MetodoPagamento VARCHAR(255) NOT NULL,
    MontanteTotal INTEGER NOT NULL CHECK(MontanteTotal > 0)
    PRIMARY KEY(ID)
)

CREATE TABLE SGE.Reserva(
    ID INTEGER IDENTITY(1,1),
    ClienteNIF INTEGER NOT NULL,
    ManagerCC INTEGER NOT NULL,
    EventoID INTEGER NOT NULL UNIQUE,
    SpaceID INTEGER NOT NULL UNIQUE,
    PagamentoID INTEGER NOT NULL, 
    ReservaStatus VARCHAR(255) NOT NULL,
    PRIMARY KEY(ID)
);




-- Adicionar constraint de chave estrangeira para a tabela GE.Particular
ALTER TABLE SGE.Particular 
ADD CONSTRAINT ParticularNIF_FK FOREIGN KEY (ParticularNIF) REFERENCES SGE.Cliente(NIF)
    ON DELETE CASCADE;

-- Adicionar constraint de chave estrangeira para a tabela GE.Empresa
ALTER TABLE SGE.Empresa 
ADD CONSTRAINT EmpresaNIF_FK FOREIGN KEY (EmpresaNIF) REFERENCES SGE.Cliente(NIF)
    ON DELETE CASCADE;

-- Adicionar constraint de chave estrangeira para a tabela GE.Empregado
ALTER TABLE SGE.Empregado 
ADD CONSTRAINT ManagerCC_FK FOREIGN KEY (ManagerCC) REFERENCES SGE.Manager(CC)
    ON DELETE CASCADE;

-- Adicionar constraint de chave estrangeira para a tabela GE.ServicoAdicional
ALTER TABLE SGE.ServicoAdicional 
ADD CONSTRAINT ServicoAdicional_ManagerCC_FK FOREIGN KEY (ManagerCC) REFERENCES SGE.Manager(CC)
    ON DELETE CASCADE;

-- Adicionar constraints de chave estrangeira para a tabela GE.Reserva
ALTER TABLE SGE.Reserva 
ADD CONSTRAINT Reserva_ClienteNIF_FK FOREIGN KEY (ClienteNIF) REFERENCES SGE.Cliente(NIF)
    ON DELETE CASCADE;
ALTER TABLE SGE.Reserva 
ADD CONSTRAINT Reserva_ManagerCC_FK FOREIGN KEY (ManagerCC) REFERENCES SGE.Manager(CC)
    ON DELETE CASCADE;
ALTER TABLE SGE.Reserva 
ADD CONSTRAINT Reserva_EventoID_FK FOREIGN KEY (EventoID) REFERENCES SGE.Evento(ID)
    ON DELETE CASCADE;
ALTER TABLE SGE.Reserva 
ADD CONSTRAINT Reserva_SpaceID_FK FOREIGN KEY (SpaceID) REFERENCES SGE.Espaco(ID)
    ON DELETE CASCADE;
ALTER TABLE SGE.Reserva
ADD CONSTRAINT Reserva_PagamentoID_FK FOREIGN KEY (PagamentoID) REFERENCES SGE.Pagamento(ID)
    ON DELETE CASCADE;
ALTER TABLE SGE.Reserva





-- Eliminar dependências:
ALTER TABLE SGE.Particular DROP CONSTRAINT ParticularNIF_FK;
ALTER TABLE SGE.Empresa DROP CONSTRAINT EmpresaNIF_FK;
ALTER TABLE SGE.Empregado DROP CONSTRAINT ManagerCC_FK;
ALTER TABLE SGE.ServicoAdicional DROP CONSTRAINT ServicoAdicional_ManagerCC_FK;
ALTER TABLE SGE.Reserva DROP CONSTRAINT Reserva_ClienteNIF_FK;
ALTER TABLE SGE.Reserva DROP CONSTRAINT Reserva_ManagerCC_FK;
ALTER TABLE SGE.Reserva DROP CONSTRAINT Reserva_EventoID_FK;
ALTER TABLE SGE.Reserva DROP CONSTRAINT Reserva_SpaceID_FK;
