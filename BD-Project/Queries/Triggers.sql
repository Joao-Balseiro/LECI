--Apagar o Cliente das tabelas particular ou empresa quando Cliente é apagado
CREATE TRIGGER DeleteClienteTrig
ON SGE.Cliente
AFTER DELETE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM SGE.Particular WHERE ParticularNIF IN (SELECT NIF FROM deleted))
    BEGIN
        DELETE FROM SGE.Particular
        WHERE ParticularNIF IN (SELECT NIF FROM deleted);
    END

    IF EXISTS (SELECT 1 FROM SGE.Empresa WHERE EmpresaNIF IN (SELECT NIF FROM deleted))
    BEGIN
        DELETE FROM SGE.Empresa
        WHERE EmpresaNIF IN (SELECT NIF FROM deleted);
    END
END;

--Incrementar o custo total com o custo do serviço adicional
GO 
CREATE TRIGGER ServicoTotal
ON SGE.ServicoAdicional
AFTER INSERT
AS
BEGIN
    UPDATE p
    SET MontanteTotal = MontanteTotal + i.Custo
    FROM SGE.Pagamento p
    INNER JOIN SGE.Reserva r ON p.ID = r.PagamentoID
    INNER JOIN inserted i ON r.ManagerCC = i.ManagerCC;
END;

--Adicionar o salario do empregado ao custo total
GO 
CREATE TRIGGER EmpregadoTotal
ON SGE.Empregado
AFTER INSERT
AS
BEGIN
    UPDATE p
    SET MontanteTotal = MontanteTotal + i.Salario
    FROM SGE.Pagamento p
    INNER JOIN SGE.Reserva r ON p.ID = r.PagamentoID
    INNER JOIN inserted i ON r.ManagerCC = i.ManagerCC;
END;

