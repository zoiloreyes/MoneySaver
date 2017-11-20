
USE master
GO
IF EXISTS(select * from sys.databases where name='MoneySaver')
DROP DATABASE MoneySaver
GO
CREATE DATABASE MoneySaver
GO
USE MoneySaver
GO

CREATE TABLE [dbo].[User](
    Id INT NOT NULL IDENTITY(1,1),
    [Nombre] VARCHAR(50) NOT NULL,
    [Apellido] VARCHAR(50) NOT NULL,
    [Sexo] CHAR(1) NOT NULL,
    [Direccion] VARCHAR(100) NOT NULL,
    CONSTRAINT Pk_User PRIMARY KEY (Id)
)
GO
CREATE TABLE Moneda(
    MonedaID INT NOT NULL IDENTITY(1,1),
    Codigo VARCHAR(3) NOT NULL,
    Nombre VARCHAR(60) NOT NULL,
    CONSTRAINT Pk_Moneda PRIMARY KEY (MonedaID)
)
GO

CREATE TABLE Banco(
    BancoID INT NOT NULL IDENTITY(1,1),
    NombreBanco VARCHAR(200) NOT NULL,
    Pais VARCHAR(30) NOT NULL,
    UsuarioID [nvarchar](128) NOT NULL,
    CONSTRAINT Pk_Banco PRIMARY KEY(BancoID)
)
GO

CREATE TABLE Marca(
    MarcaID INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(200) NOT NULL,
    UsuarioID [nvarchar](128) NOT NULL,
    CONSTRAINT Pk_Marca PRIMARY KEY(MarcaID)
)

GO

CREATE TABLE EstadoTarjetaCredito(
    EstadoTarjetaCreditoID INT NOT NULL IDENTITY(1,1),
    Estado VARCHAR(200) NOT NULL,
    CONSTRAINT Pk_EstadoTarjetaCredito PRIMARY KEY(EstadoTarjetaCreditoID)
)

GO

CREATE TABLE TarjetaCredito(
    TarjetaCreditoID INT NOT NULL IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    BancoID INT NOT NULL,
    EstadoTarjetaCreditoID INT NOT NULL,
    MonedaID INT NOT NULL,
    NumeroTarjeta VARCHAR(40) NOT NULL,
    NombreTitular VARCHAR(80) NOT NULL,
    ApellidoTitular VARCHAR(80) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaExpiracion DATE NOT NULL,
    MarcaID INT NOT NULL,
    CVC VARCHAR(3) NOT NULL,
    TasaEfectivaAnual DECIMAL(8,4) NOT NULL,
    DeudaInicial DECIMAL(19,4) NOT NULL,
    LimiteCredito DECIMAL(19,4) NOT NULL,
    Comentario VARCHAR(800),
    CONSTRAINT Pk_TarjetaCredito PRIMARY KEY (TarjetaCreditoID),
    CONSTRAINT Fk_TarjetaCredito_Estado FOREIGN KEY(EstadoTarjetaCreditoID) REFERENCES EstadoTarjetaCredito(EstadoTarjetaCreditoID),
    CONSTRAINT Fk_TarjetaCredito_Banco FOREIGN KEY(BancoID) REFERENCES Banco(BancoID),
    CONSTRAINT Fk_TarjetaCredito_Moneda FOREIGN KEY(MonedaID) REFERENCES Moneda(MonedaID),
    CONSTRAINT Fk_TarjetaCredito_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id),
    CONSTRAINT Fk_TarjetaCredito_Marca FOREIGN KEY(MarcaID) REFERENCES Marca(MarcaID)
)
GO
CREATE TABLE EstadoCuentaBanco(
    EstadoCuentaBancoID INT NOT NULL IDENTITY(1,1),
    Estado VARCHAR(200) NOT NULL,
    CONSTRAINT Pk_EstadoCuentaBanco PRIMARY KEY(EstadoCuentaBancoID)
)
GO
CREATE TABLE CuentaBanco(
    CuentaBancoID INT NOT NULL IDENTITY(1,1),
    BancoID INT NOT NULL,
    UsuarioID INT NOT NULL,
    EstadoCuentaBancoID INT NOT NULL,
    MonedaID INT NOT NULL,
    NumeroCuenta VARCHAR(40)  NOT NULL,
    NombreTitular VARCHAR(80) NOT NULL,
    ApellidoTitular VARCHAR(80) NOT NULL,
    FechaInicio DATE NOT NULL,
    BalanceInicial Decimal(19,4) NOT NULL,
    Comentario VARCHAR(800),
    CONSTRAINT Pk_CuentaBanco PRIMARY KEY(CuentaBancoID),
    CONSTRAINT Fk_CuentaBanco_Banco FOREIGN KEY(BancoID) REFERENCES Banco(BancoID),
    CONSTRAINT Fk_CuentaBanco_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id),
    CONSTRAINT Fk_CuentaBanco_Estado FOREIGN KEY(EstadoCuentaBancoID) REFERENCES EstadoCuentaBanco(EstadoCuentaBancoID),
    CONSTRAINT Fk_CuentaBanco_Moneda FOREIGN KEY(MonedaID) REFERENCES Moneda(MonedaID) 
)
GO
CREATE TABLE EstadoTarjetaDebito(
    EstadoTarjetaDebitoID INT NOT NULL IDENTITY(1,1),
    Estado VARCHAR(200) NOT NULL,
    CONSTRAINT Pk_EstadoTarjetaDebito PRIMARY KEY(EstadoTarjetaDebitoID)
)

GO
/*
CREATE TABLE TarjetaDebito(
    TarjetaDebitoID INT NOT NULL IDENTITY(1,1),
    BancoID INT NOT NULL,
    UsuarioID [nvarchar](128) NOT NULL,
    EstadoTarjetaDebitoID INT NOT NULL,
    MonedaID INT NOT NULL,
    NumeroTarjeta VARCHAR(40) NOT NULL,
    NombreTitular VARCHAR(80) NOT NULL,
    ApellidoTitular VARCHAR(80) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaExpiracion DATE NOT NULL,
    MarcaID INT NOT NULL,
    CVC VARCHAR(3) NOT NULL,
    SaldoInicial Decimal(19,4) NOT NULL,
    Comentario VARCHAR(800),
    CONSTRAINT Pk_TarjetaDebito PRIMARY KEY (TarjetaDebitoID),
    CONSTRAINT Fk_TarjetaDebito_Banco FOREIGN KEY (BancoID) REFERENCES Banco(BancoID),
    CONSTRAINT Fk_TarjetaDebito_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id),
    CONSTRAINT Fk_TarjetaDebito_Estado FOREIGN KEY(EstadoTarjetaDebitoID) REFERENCES EstadoTarjetaDebito(EstadoTarjetaDebito),
    CONSTRAINT Fk_TarjetaDebito_Moneda FOREIGN KEY (MonedaID) REFERENCES MONEDA(MonedaID)
)
GO
*/
CREATE TABLE CuentaPrestamo(
    CuentaPrestamoID INT NOT NULL IDENTITY(1,1),
    MonedaID INT NOT NULL,
    UsuarioID INT NOT NULL,
    CapitalInicial DECIMAL(19,4),
    TasaAnual DECIMAL(8,4) NOT NULL,
    PagosPorAno INT,
    FechaInicio DATE,
    NumeroPagos INT,
    CONSTRAINT Pk_CuentaPrestamo PRIMARY KEY(CuentaPrestamoID),
    CONSTRAINT Fk_CuentaPrestamo_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id),
    CONSTRAINT Fk_CuentaPrestamo_Moneda FOREIGN KEY(MonedaID) REFERENCES Moneda(MonedaID),
)
GO


GO
CREATE TABLE EstadoCategoria(
    EstadoCategoriaID INT NOT NULL IDENTITY(1,1),
    Estado VARCHAR(200) NOT NULL,
    CONSTRAINT Pk_EstadoCategoria PRIMARY KEY(EstadoCategoriaID)
)
GO

CREATE TABLE TipoCategoria(
    TipoCategoriaID INT NOT NULL IDENTITY(1,1),
    Tipo VARCHAR(100) NOT NULL,
    CONSTRAINT Pk_TipoCategoria PRIMARY KEY(TipoCategoriaID)
)

CREATE TABLE Categoria(
    CategoriaID INT NOT NULL IDENTITY(1,1),
    EstadoCategoriaID INT NOT NULL,
    UsuarioID INT NOT NULL,
    TipoCategoriaID INT NOT NULL,
    PadreCategoriaID INT,
    MonedaID INT NOT NULL,
    Comentario VARCHAR(800),
    Nombre VARCHAR(400),
    CONSTRAINT Pk_Categoria PRIMARY KEY(CategoriaID),
    CONSTRAINT Fk_Categoria_EstadoCategoria FOREIGN KEY(EstadoCategoriaID) REFERENCES EstadoCategoria(EstadoCategoriaID),
    CONSTRAINT Fk_Categoria_TipoCategoria FOREIGN KEY(TipoCategoriaID) REFERENCES TipoCategoria(TipoCategoriaID),
    CONSTRAINT Fk_Categoria_PadreCategoria FOREIGN KEY(PadreCategoriaID) REFERENCES Categoria(CategoriaID),
    CONSTRAINT Fk_Categoria_Moneda FOREIGN KEY(MonedaID) REFERENCES Moneda(MonedaID),
    CONSTRAINT Fk_Categoria_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id),
)
GO

CREATE TABLE PeriodoTemporal(
    PeriodoTemporalID INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(500) NOT NULL,
    CONSTRAINT Pk_PeriodoTemporal PRIMARY KEY(PeriodoTemporalID)
)

GO

CREATE TABLE Presupuesto(
    PresupuestoID INT NOT NULL IDENTITY(1,1),
    PeriodoTemporalID INT NOT NULL,
    UsuarioID int NOT NULL,
    Nombre VARCHAR (200) NOT NULL,
    CONSTRAINT Pk_Presupuesto PRIMARY KEY(PresupuestoID),
    CONSTRAINT Fk_Presupuesto_PeriodoTemporal FOREIGN KEY(PeriodoTemporalID) REFERENCES PeriodoTemporal(PeriodoTemporalID),
    CONSTRAINT Fk_Presupuesto_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id)
)

Go



CREATE TABLE PresupuestoCategoria(
    PresupuestoCategoriaID INT NOT NULL IDENTITY(1,1),
    CategoriaID INT NOT NULL,
    PresupuestoID INT NOT NULL,
    Monto DECIMAL(19,4),
    CONSTRAINT Pk_PresupuestoCategoria PRIMARY KEY(PresupuestoCategoriaID),
    CONSTRAINT Fk_PresupuestoCategoria_Categoria FOREIGN KEY(CategoriaID) REFERENCES Categoria(CategoriaID),
    CONSTRAINT Fk_PresupuestoCategoria_Presupuesto FOREIGN KEY(PresupuestoID) REFERENCES Presupuesto(PresupuestoID)
)

GO

CREATE TABLE Contacto(
    ContactoID INT NOT NULL IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    Nombre VARCHAR(300) NOT NULL,
    Email VARCHAR(256),
    Direccion VARCHAR(500),
    Telefono VARCHAR(400),
    CONSTRAINT Pk_Contacto PRIMARY KEY(ContactoID),
    CONSTRAINT Fk_Contacto_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id)
)

GO

GO
CREATE TABLE Transaccion(
    TransaccionID INT NOT NULL IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    CuentaBancoID INT,
    TarjetaCreditoID INT,
    CuentaPrestamoID INT,
    ContactoID INT,
    No_Ref_Externo VARCHAR(100),
    Fecha DATE DEFAULT GETDATE(),
    EFECTIVO BIT,
    Adjunto VARCHAR(900),
    MontoIngreso DECIMAL(19,4),
    MontroEgreso DECIMAL (19,4),
    CONSTRAINT Pk_Transaccion PRIMARY KEY (TransaccionID),
    CONSTRAINT Fk_Transaccion_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id),
    CONSTRAINT Fk_Transaccion_CuentaBanco FOREIGN KEY(CuentaBancoID) REFERENCES CuentaBanco(CuentaBancoID),
    CONSTRAINT Fk_Transaccion_TarjetaCredito FOREIGN KEY (TarjetaCreditoID) REFERENCES TarjetaCredito(TarjetaCreditoID),
    CONSTRAINT Fk_Transaccion_CuentaPrestamo FOREIGN KEY (CuentaPrestamoID) REFERENCES CuentaPrestamo(CuentaPrestamoID),
    CONSTRAINT Fk_Transaccion_Contacto FOREIGN KEY (ContactoID) REFERENCES Contacto(ContactoID)
)

CREATE TABLE Recordatorio(
    RecordatorioID INT NOT NULL IDENTITY(1,1),
    UsuarioID int NOT NULL,
    TransaccionID INT ,
    Descripcion VARCHAR(500) NOT NULL,
    FechaInicio Date,
    FechaFin Date,
    EsRecurrente BIT NOT NULL,
    FechaCreacion Date DEFAULT GETDATE(),
    CONSTRAINT Pk_Recordatorio PRIMARY KEY(RecordatorioID),
    CONSTRAINT Fk_Recordatorio_Transaccion FOREIGN KEY(TransaccionID) REFERENCES Transaccion(TransaccionID),
    CONSTRAINT Fk_Recordatorio_Usuario FOREIGN KEY(UsuarioID) REFERENCES dbo.[User](Id)
)

CREATE TABLE TipoRecurrencia(
    TipoRecurrenciaID INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(200) NOT NULL,
    CONSTRAINT Pk_TipoRecurrencia PRIMARY KEY(TipoRecurrenciaID)
)
GO
CREATE TABLE PatronRecurrente(
    PatronRecurrenteID INT NOT NULL IDENTITY(1,1),
    RecordatorioID INT NOT NULL,
    TipoRecurrenciaID INT NOT NULL,
    NumeroSeparaciones INT,
    NumeroMaxOcurrencia INT,
    DiaDeSemana INT,
    SemanaDeMes INT,
    DiaDeMes INT,
    MesDeAno INT,
    CONSTRAINT Pk_PatronRecurrente PRIMARY KEY(PatronRecurrenteID),
    CONSTRAINT Fk_PatronRecurrente_Recordatorio FOREIGN KEY(RecordatorioID) REFERENCES Recordatorio(RecordatorioID),
    CONSTRAINT Fk_PatronRecurrente_TipoRecurrencia FOREIGN KEY (TipoRecurrenciaID) REFERENCES TipoRecurrencia(TipoRecurrenciaID)
)
