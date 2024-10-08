USE Sistema_GestaoDeEventos
GO

-- View para Cliente e Particular
DROP VIEW IF EXISTS SGE.ClienteParticular
GO

CREATE VIEW SGE.ClienteParticular AS
    SELECT C.NIF, C.Nome, C.NumTelef, C.Endereco, C.Email, C.ReservaID, P.CC
    FROM (SGE.Particular AS P JOIN SGE.Cliente AS C ON C.NIF = P.ParticularNIF);
GO

--Testes:
--SELECT * FROM SGE.ClienteParticular;


-- View para Cliente e Empresa
DROP VIEW IF EXISTS SGE.ClienteEmpresa;
GO

CREATE VIEW SGE.ClienteEmpresa AS
    SELECT C.NIF, C.Nome, C.NumTelef, C.Endereco, C.Email, C.ReservaID, E.EmpresaNIF
    FROM SGE.Empresa AS E
    JOIN SGE.Cliente AS C ON C.NIF = E.EmpresaNIF;
GO

--Testes:
--SELECT * FROM SGE.ClienteEmpresa;


-- View para Espaço da Reserva
DROP VIEW IF EXISTS SGE.ReservaEspaco;
GO

CREATE VIEW SGE.ReservaEspaco AS
    SELECT 
        R.ID AS ReservaID, R.ReservaData, R.SpaceID, E.Nome AS EspacoNome,
        E.Descricao AS EspacoDescricao,
        E.Lotacao AS EspacoLotacao,
        E.Localizacao AS EspacoLocalizacao
    FROM SGE.Reserva AS R 
    JOIN SGE.Espaco AS E ON R.SpaceID = E.ID;
GO

--Testes:
--SELECT * FROM SGE.ReservaEspaco;
--SELECT * FROM SGE.ReservaEspaco WHERE EspacoNome = 'Sala 1';




-- View para Evento da Reserva
DROP VIEW IF EXISTS SGE.ReservaEvento;
GO

CREATE VIEW SGE.ReservaEvento AS
    SELECT 
        R.ID AS ReservaID, R.ReservaData, R.EventoID,
        E.Nome AS EventoNome,
        E.DataEvento AS EventoData,
        E.Descricao AS EventoDescricao
    FROM SGE.Reserva AS R
    JOIN SGE.Evento AS E ON R.EventoID = E.ID;
GO

--Testes:
--SELECT * FROM SGE.ReservaEvento;
--SELECT * FROM SGE.ReservaEvento WHERE EventoNome = 'Evento C';


-- View para Pagamento da Reserva
DROP VIEW IF EXISTS SGE.ReservaPagamento;
GO

CREATE VIEW SGE.ReservaPagamento AS
    SELECT 
        R.ID AS ReservaID, R.ReservaData, R.PagamentoID, P.DataPagamento, P.MetodoPagamento, P.MontanteTotal
    FROM SGE.Reserva AS R
    JOIN SGE.Pagamento AS P ON R.PagamentoID = P.ID;
GO

--Testes:
--SELECT * FROM SGE.ReservaPagamento;
--SELECT * FROM SGE.ReservaPagament WHERE PagamentoID = '2';



-- View para histórico de Reservas (cujos Eventos já foram realizados)
DROP VIEW IF EXISTS SGE.ReservasEventosRealizados;
GO

CREATE VIEW SGE.ReservasEventosRealizados AS
    SELECT 
        R.ID AS ReservaID, E.DataEvento, E.Nome AS EventoNome, R.ClienteNIF, R.ManagerCC, R.SpaceID, R.PagamentoID
    FROM SGE.Reserva AS R
    JOIN SGE.Evento AS E ON R.EventoID = E.ID
    WHERE E.DataEvento < GETDATE();  -- Filtrar eventos que já aconteceram
GO

--Testes:
--SELECT * FROM SGE.ReservasEventosRealizados;


-- View para Eventos futuros
DROP VIEW IF EXISTS SGE.ReservasEventosFuturos;
GO

CREATE VIEW SGE.ReservasEventosFuturos AS
    SELECT 
        R.ID AS ReservaID, E.DataEvento, E.Nome AS EventoNome, R.EventoID, R.ClienteNIF, R.ManagerCC, R.SpaceID, R.PagamentoID
    FROM SGE.Reserva AS R
    JOIN SGE.Evento AS E ON R.EventoID = E.ID
    WHERE E.DataEvento > GETDATE(); 
GO

--Testes:
--SELECT * FROM SGE.ReservasEventosFuturos;