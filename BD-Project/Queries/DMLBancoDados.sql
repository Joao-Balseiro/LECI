USE Sistema_GestaoDeEventos;
GO 


-- Inserir dados na tabela SGE.Cliente
INSERT INTO SGE.Cliente (NIF, Nome, NumTelef, Endereco, Email, ReservaID)
VALUES 
(123456789, 'João Silva', 912345678, 'Rua A, 123', 'joao.silva@example.com', NULL),
(987654381, 'Maria Oliveira', 987654391, 'Avenida B, 456', 'maria.oliveira@example.com', NULL),
(456123789, 'Carlos Sousa', 956123789, 'Travessa C, 789', 'carlos.sousa@example.com', NULL),
(153456789, 'João Silva', 912345648, 'Rua A, 140', 'joao.gomes@example.com', NULL);

INSERT INTO SGE.Particular (CC, ParticularNIF)
VALUES 
(1111, 123456789),
(2222, 987654381),
(1234, 153456789);
GO

-- Inserir dados de teste na tabela SGE.Empresa
INSERT INTO SGE.Empresa (EmpresaNIF)
VALUES 
(456123789),
(153456789);
GO

-- Inserir dados na tabela SGE.Manager
INSERT INTO SGE.Manager (CC, Nome, NumTelef, Email, ReservaID)
VALUES 
(1001, 'Ana Costa', 911234567, 'ana.costa@example.com', NULL),
(1002, 'Pedro Martins', 922345678, 'pedro.martins@example.com', NULL);

INSERT INTO SGE.Pagamento (DataPagamento, MetodoPagamento, MontanteTotal)
VALUES 
('2024-05-20', 'Cartão de Crédito', 150),
('2024-05-21', 'Transferência Bancária', 300),
('2024-05-05', 'Cartão de Crédito', 200),
('2024-05-01', 'Cartão de Crédito', 220),
('2004-12-03', 'Cartão de Crédito', 55);

-- Inserir dados na tabela SGE.Evento
INSERT INTO SGE.Evento (DataEvento, Nome, Descricao)
VALUES 
('2024-05-10', 'Evento A', 'Descricao A'),
('2024-05-11', 'Evento B', 'Descricao B'),
('2024-05-12', 'Evento C', 'Descricao C'),
('2024-05-13', 'Evento D', 'Descricao D'),
('2025-05-15', 'Evento E', 'Descricao D');
GO

-- Inserir dados na tabela SGE.Espaco
INSERT INTO SGE.Espaco (Descricao, Nome, Lotacao, Localizacao)
VALUES 
('Espaco A', 'Sala 1', 100, 'Local 1'),
('Espaco B', 'Sala 2', 200, 'Local 2'),
('Espaco C', 'Sala 3', 150, 'Local 3'),
('Espaco D', 'Sala 4', 250, 'Local 4'),
('Espaco E', 'Sala 1', 1000, 'Local 5');
GO

-- Inserir dados na tabela SGE.Reserva usando os IDs das tabelas anteriores
-- Presume-se que os IDs de Evento, Espaco e Pagamento são 1 e 2 conforme as inserções acima
INSERT INTO SGE.Reserva (ClienteNIF, ManagerCC, EventoID, SpaceID, PagamentoID, ReservaStatus, ReservaData)
VALUES 
(123456789, 1001, 1, 1, 1, 'Confirmada', '2024-05-10'),
(456123789, 1002, 2, 2, 2, 'Pendente', '2024-05-11'),
(987654381, 1001, 3, 3, 3, 'Pendente', '2024-05-04'),
(153456789, 1002, 4, 4, 4, 'Pendente', '2024-05-01'),
(456123789, 1000, 5, 5, 5, 'Confirmada', '2004-12-03');





-- Atualizar a tabela SGE.Cliente para definir ReservaID
UPDATE SGE.Cliente
SET ReservaID = R.ID
FROM SGE.Cliente C
JOIN SGE.Reserva R ON C.NIF = R.ClienteNIF;

-- Atualizar a tabela SGE.Manager para definir ReservaID
UPDATE SGE.Manager
SET ReservaID = R.ID
FROM SGE.Manager M
JOIN SGE.Reserva R ON M.CC = R.ManagerCC;

-- Atualizar a tabela SGE.Reserva para definir ClienteNIF
UPDATE SGE.Reserva
SET ClienteNIF = C.NIF
FROM SGE.Reserva R
JOIN SGE.Cliente C ON R.ID = C.ReservaID;

-- Atualizar a tabela SGE.Reserva para definir ManagerCC
UPDATE SGE.Reserva
SET ManagerCC = M.CC
FROM SGE.Reserva R
JOIN SGE.Manager M ON R.ID = M.ReservaID;

-- Atualizar a tabela SGE.Reserva para definir EventoID
UPDATE SGE.Reserva
SET EventoID = E.ID
FROM SGE.Reserva R
JOIN SGE.Evento E ON R.ID = E.ID;

-- Atualizar a tabela SGE.Reserva para definir SpaceID
UPDATE SGE.Reserva
SET SpaceID = S.ID
FROM SGE.Reserva R
JOIN SGE.Espaco S ON R.ID = S.ID;

-- Atualizar a tabela SGE.Reserva para definir PagamentoID
UPDATE SGE.Reserva
SET PagamentoID = P.ID
FROM SGE.Reserva R
JOIN SGE.Pagamento P ON R.ID = P.ID;

