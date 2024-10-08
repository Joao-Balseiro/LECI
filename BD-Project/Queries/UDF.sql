USE Sistema_GestaoDeEventos;
GO


-- Função para filtrar Clientes por Reserva, Nome e NIF:

DROP FUNCTION IF EXISTS filtrarCLientesPorReservaENifENome;
GO

CREATE FUNCTION filtrarCLientesPorReservaENifENome(@reservaID INTEGER, @nif INTEGER, @nome varchar(100)) RETURNS TABLE
AS
RETURN (
    SELECT C.NIF, C.Nome, C.NumTelef, C.Endereco, C.Email, C.ReservaID
    FROM SGE.Cliente as C JOIN SGE.Reserva as R ON C.ReservaID = R.ID
    WHERE
        (R.ID = @reservaID OR @reservaID IS NULL) AND 
        (C.Nome = @nome OR @nome IS NULL) AND
        (C.NIF = @NIF OR @NIF IS NULL)
);
GO



-- Teste com apenas reservaID
SELECT * FROM filtrarClientesPorReservaENifENome(NULL, NULL, 'Maria Oliveira');




-- Função para filtrar Manager por Reserva e CC:

DROP FUNCTION IF EXISTS filtrarManagerPorReservaENomeECartaoCidadao;
GO


CREATE FUNCTION filtrarManagerPorReservaENomeECartaoCidadao(@reservaID INTEGER, @Nome VARCHAR(100), @CC INTEGER) RETURNS TABLE
AS
RETURN (
    SELECT M.CC, M.Nome, M.NumTelef, M.Email, M.ReservaID
    FROM SGE.Manager as M JOIN SGE.Reserva as R ON M.ReservaID = R.ID
    WHERE
        (R.ID = @reservaID OR @reservaID IS NULL) AND
        (M.Nome = @Nome OR @Nome IS NULL) AND
        (M.CC = @CC OR @CC IS NULL)
);
GO

-- Teste com apenas reservaID

SELECT * FROM filtrarManagerPorReservaENomeECartaoCidadao(NULL, NULL, 1001);




-- Função para filtrar Reserva por ManagerCC, ReservaID, EspacoID, EventoID, PagamentoID:

DROP FUNCTION IF EXISTS filtrarReservaPorIdEManagerEEspacoEEventoEPagamento;
GO


CREATE FUNCTION filtrarReservaPorIdEManagerEEspacoEEventoEPagamento(@reservaID INTEGER, @managerCC INTEGER, @espacoID INTEGER, @eventoID INTEGER, @pagamentoID INTEGER) RETURNS TABLE
AS
RETURN (
    SELECT R.ID, R.ClienteNIF, R.ManagerCC, R.EventoID, R.SpaceID, R.PagamentoID, R.ReservaStatus, R.ReservaData
    FROM SGE.Reserva as R 
    JOIN SGE.Manager as M ON R.ManagerCC = M.CC
    JOIN SGE.Evento as E ON R.EventoID = E.ID
    JOIN SGE.Espaco as S ON R.SpaceID = S.ID
    JOIN SGE.Pagamento as P ON R.PagamentoID = P.ID
    WHERE
        (M.CC = @managerCC OR @managerCC IS NULL) AND
        (R.ID = @reservaID OR @reservaID IS NULL) AND
        (E.ID = @espacoID OR @espacoID IS NULL) AND
        (S.ID = @eventoID OR @eventoID IS NULL) AND
        (P.ID = @pagamentoID OR @pagamentoID IS NULL)
);
GO


--Teste
SELECT * FROM filtrarReservaPorIdEManagerEEspacoEEventoEPagamento(NULL, 1001, NULL, NULL, NULL);