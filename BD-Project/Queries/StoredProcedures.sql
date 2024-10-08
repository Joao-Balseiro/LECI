------------REMOVER CLIENTE------------
GO
CREATE PROCEDURE RemoveCliente
	@NIF INTEGER
AS
BEGIN

	BEGIN TRANSACTION
	DELETE FROM SGE.Cliente
	WHERE NIF = @NIF

	IF @@ROWCOUNT = 0
	BEGIN
		ROLLBACK TRANSACTION
		PRINT 'ERRO! Cliente não encontrado';
	END
	ELSE
	BEGIN
		COMMIT TRANSACTION
		PRINT 'Cliente removido com sucesso';
	END
END;

------------ADICIONAR CLIENTE-----------
GO
CREATE PROCEDURE AdicionarCliente
	@NIF INTEGER,
    @Nome VARCHAR(255),
    @NumTelef INTEGER,
    @Endereco VARCHAR(255),
    @Email VARCHAR(255),
	@ReservaID INTEGER,
	@CC INTEGER = NULL
AS
BEGIN
	BEGIN TRANSACTION

	IF @CC IS NULL
	BEGIN
		INSERT INTO SGE.Cliente(NIF, Nome, NumTelef, Endereco, ReservaID, Email)
		VALUES (@NIF, @Nome, @NumTelef, @Endereco, @ReservaID, @Email)

		INSERT INTO SGE.Empresa (EmpresaNIF)
		VALUES (@NIF)
	END
	ELSE
	BEGIN
		INSERT INTO SGE.Cliente(NIF, Nome, NumTelef, Endereco, ReservaID, Email)
		VALUES (@NIF, @Nome, @NumTelef, @Endereco, @ReservaID, @Email)

		INSERT INTO SGE.Particular(CC, ParticularNIF)
		VALUES(@CC, @NIF)
	END

	BEGIN
	COMMIT TRANSACTION
	END
END

------------ADICIONAR RESERVA------------
GO
CREATE PROCEDURE AdicionarReserva
	@ID INTEGER,
	@ClientNIF INTEGER,
	@ManagerCC INTEGER,
	--@PaymentID INTEGER,
	@EventID INTEGER,
	@SpaceID INTEGER,
	@Status VARCHAR(255),
	@BookDate DATE

AS
BEGIN
	BEGIN TRANSACTION

	BEGIN
		INSERT INTO SGE.Reserva(ID, ClienteNIF, ManagerCC, EventoID, SpaceID, ReservaStatus, ReservaData)
		VALUES (@ID, @ClientNIF, @ManagerCC, @EventID, @SpaceID, @Status, @BookDate)
	END

	BEGIN
	COMMIT TRANSACTION
	END
END

------------REMOVER RESERVA------------
GO
CREATE PROCEDURE RemoveReserva
	@ID INTEGER
AS
BEGIN

	BEGIN TRANSACTION
	DELETE FROM SGE.Reserva
	WHERE ID = @ID

	IF @@ROWCOUNT = 0
	BEGIN
		ROLLBACK TRANSACTION
		PRINT 'ERRO! Reserva não encontrada';
	END
	ELSE
	BEGIN
		COMMIT TRANSACTION
		PRINT 'Reserva Removida com sucesso';
	END
END;


------------EDITAR RESERVA------------
GO
CREATE PROCEDURE EditarReserva
    @ID INTEGER,
	@ClientNIF INTEGER,
	@ManagerCC INTEGER,
	--@PaymentID INTEGER,
	@EventID INTEGER,
	@SpaceID INTEGER,
	@Status VARCHAR(255),
	@BookDate DATE
AS
BEGIN
    BEGIN TRANSACTION;

    UPDATE SGE.Reserva
    SET 
        ClienteNIF = COALESCE(@ClientNIF, ClienteNIF),
        ManagerCC = COALESCE(@ManagerCC, ManagerCC),
        EventoID = COALESCE(@EventID, EventoID),
		SpaceID = COALESCE(@SpaceID, SpaceID),
		ReservaStatus = COALESCE(@Status, ReservaStatus),
		ReservaData = COALESCE(@BookDate, ReservaData)

    WHERE ID = @ID;

    IF @@ROWCOUNT = 0
    BEGIN
        ROLLBACK TRANSACTION;
        PRINT 'ERRO! Reserva não encontrada';
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION;
        PRINT 'Dados editados com sucesso';
    END
END;

------------EDITAR CLIENTE------------
GO
CREATE PROCEDURE EditarCliente
    @NIF INTEGER,
    @Nome VARCHAR(255) = NULL,
    @NumTelef INTEGER = NULL,
    @Endereco VARCHAR(255) = NULL,
	@ReservaID INTEGER,
    @Email VARCHAR(255) = NULL
AS
BEGIN
    BEGIN TRANSACTION;

    UPDATE SGE.Cliente
    SET 
        Nome = COALESCE(@Nome, Nome),
        NumTelef = COALESCE(@NumTelef, NumTelef),
        Endereco = COALESCE(@Endereco, Endereco),
		ReservaID = COALESCE(@ReservaID, ReservaID),
        Email = COALESCE(@Email, Email)
    WHERE NIF = @NIF;

    IF @@ROWCOUNT = 0
    BEGIN
        ROLLBACK TRANSACTION;
        PRINT 'ERRO! Cliente não encontrado';
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION;
        PRINT 'Dados editados com sucesso';
    END
END;

------------PESQUISAR CLIENTE------------
GO
CREATE PROCEDURE PesquisarCliente
	@NIF INTEGER
AS
BEGIN
	SELECT * FROM SGE.Cliente
	WHERE  NIF = @NIF
END;

------------PESQUISAR RESERVA------------
GO
CREATE PROCEDURE PesquisarReserva
	@ID INTEGER
AS
BEGIN
	SELECT * FROM SGE.Reserva
	WHERE  ID = @ID
END;