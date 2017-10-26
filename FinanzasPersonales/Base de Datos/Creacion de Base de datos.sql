DROP DATABASE FinanzasPersonales
GO

CREATE DATABASE FinanzasPersonales
GO
USE FinanzasPersonales

/*
INICIO SCRIPT DE BD Identity
*/

/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/24/2017 9:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
    [MigrationId] ASC,
    [ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/24/2017 9:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
    [Id] [nvarchar](128) NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/24/2017 9:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    [ClaimType] [nvarchar](max) NULL,
    [ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/24/2017 9:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
    [LoginProvider] ASC,
    [ProviderKey] ASC,
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/24/2017 9:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
    [UserId] [nvarchar](128) NOT NULL,
    [RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
    [UserId] ASC,
    [RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/24/2017 9:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
    [Id] [nvarchar](128) NOT NULL,
    [Email] [nvarchar](256) NULL,
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](max) NULL,
    [SecurityStamp] [nvarchar](max) NULL,
    [Nombre] VARCHAR(50) NOT NULL,
    [Apellido] VARCHAR(50) NOT NULL,
    [Sexo] CHAR(1) NOT NULL,
    [Direccion] VARCHAR(100) NOT NULL,
    [PhoneNumber] [nvarchar](max) NULL,
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime] NULL,
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/24/2017 9:15:47 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
    [Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/24/2017 9:15:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/24/2017 9:15:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 10/24/2017 9:15:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
    [RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/24/2017 9:15:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/24/2017 9:15:47 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
    [UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/*
    Fin Script de BD Identity
*/
USE FinanzasPersonales

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
    UsuarioID [nvarchar](128) NOT NULL,
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
    CONSTRAINT Fk_TarjetaCredito_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id),
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
    UsuarioID [nvarchar](128) NOT NULL,
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
    CONSTRAINT Fk_CuentaBanco_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id),
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
    UsuarioID [nvarchar](128) NOT NULL,
    CapitalInicial DECIMAL(19,4),
    TasaAnual DECIMAL(8,4) NOT NULL,
    PagosPorAno INT,
    FechaInicio DATE,
    NumeroPagos INT,
    CONSTRAINT Pk_CuentaPrestamo PRIMARY KEY(CuentaPrestamoID),
    CONSTRAINT Fk_CuentaPrestamo_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id),
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
    UsuarioID [nvarchar](128) NOT NULL,
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
    CONSTRAINT Fk_Categoria_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id)
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
    UsuarioID [nvarchar](128) NOT NULL,
    Nombre VARCHAR (200) NOT NULL,
    CONSTRAINT Pk_Presupuesto PRIMARY KEY(PresupuestoID),
    CONSTRAINT Fk_Presupuesto_PeriodoTemporal FOREIGN KEY(PeriodoTemporalID) REFERENCES PeriodoTemporal(PeriodoTemporalID),
    CONSTRAINT Fk_Presupuesto_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id)
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
    UsuarioID [nvarchar](128) NOT NULL,
    Nombre VARCHAR(300) NOT NULL,
    Email VARCHAR(256),
    Direccion VARCHAR(500),
    Telefono VARCHAR(400),
    CONSTRAINT Pk_Contacto PRIMARY KEY(ContactoID),
    CONSTRAINT Fk_Contacto_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id)
)

GO

GO
CREATE TABLE Transaccion(
    TransaccionID INT NOT NULL IDENTITY(1,1),
    UsuarioID [nvarchar](128) NOT NULL,
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
    CONSTRAINT Fk_Transaccion_Usuario FOREIGN KEY (UsuarioID) REFERENCES  AspNetUsers(Id),
    CONSTRAINT Fk_Transaccion_CuentaBanco FOREIGN KEY(CuentaBancoID) REFERENCES CuentaBanco(CuentaBancoID),
    CONSTRAINT Fk_Transaccion_TarjetaCredito FOREIGN KEY (TarjetaCreditoID) REFERENCES TarjetaCredito(TarjetaCreditoID),
    CONSTRAINT Fk_Transaccion_CuentaPrestamo FOREIGN KEY (CuentaPrestamoID) REFERENCES CuentaPrestamo(CuentaPrestamoID),
    CONSTRAINT Fk_Transaccion_Contacto FOREIGN KEY (ContactoID) REFERENCES Contacto(ContactoID)
)

CREATE TABLE Recordatorio(
    RecordatorioID INT NOT NULL IDENTITY(1,1),
    UsuarioID [nvarchar](128) NOT NULL,
    TransaccionID INT ,
    Descripcion VARCHAR(500) NOT NULL,
    FechaInicio Date,
    FechaFin Date,
    EsRecurrente BIT NOT NULL,
    FechaCreacion Date DEFAULT GETDATE(),
    CONSTRAINT Pk_Recordatorio PRIMARY KEY(RecordatorioID),
    CONSTRAINT Fk_Recordatorio_Transaccion FOREIGN KEY(TransaccionID) REFERENCES Transaccion(TransaccionID),
    CONSTRAINT Fk_Recordatorio_Usuario FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id) 
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
