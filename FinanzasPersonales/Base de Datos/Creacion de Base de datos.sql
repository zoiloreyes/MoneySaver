
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
GO
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('EUR','Euro')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('AFN','Afgani Afgano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ZAR','Rand Sudafricano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ALL','Lek Albanés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('AOA','Kwanza Angoleño')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('XCD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ANG','Florín Antillano Neerlandés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SAR','Riyal Saudí')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('DZD','Dinar Algerino')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ARS','Peso Argentino')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('AMD','Dram Armenio')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('AWG','Florín Arubeño')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('AUD','Dólar Australiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('AZN','Manat Azerbaiyano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BSD','Dólar Bahameño')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BHD','Dinar Bahreini')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BDT','Taka')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BBD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BZD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('XOF','Franco Cfa')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BMD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BTN','Ngultrum')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BYN','Rublo Bielorruso')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MMK','Kyat Birmano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BOB','Boliviano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BAM','Marco Convertible')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BWP','Pula')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BRL','Real Brasileño')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BND','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BGN','Lev Búlgaro')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('BIF','Franco Burundés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CVE','Escudo Caboverdiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KHR','Riel Camboyano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('XAF','Franco Cfa')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CAD','Dólar Canadiense')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CLP','Peso Chileno')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CNY','Rmb Yuan Renminbi Chino')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('COP','Peso Colombiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KMF','Franco Comoriano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CDF','Franco Congoleño')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KPW','Won Norcoreano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KRW','Won Surcoreano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CRC','Colón Costarricense')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('HRK','Kuna Croata')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CUC','Peso Cubano Convertible')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('DKK','Corona Danesa')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('USD','Dólar Estadounidense')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('EGP','Libra Egipcia')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('AED','Dirham')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ERN','Nafka Eritreo')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ETB','Birr Etiope')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('FJD','Dólar Fijiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('PHP','Peso Filipino')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('RUB','Rublo Ruso')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GMD','Dalasi Gambiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GEL','Lari Georgiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GHS','Cedi Ghanés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GIP','Libra')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GBP','Libra Esterlina')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GTQ','Quetzal Guatemalteco')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GYD','Dólar Guyanés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GGP','Libra')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('GNF','Franco Guineano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('HTG','Gourde Haitiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('HNL','Lempira Hondureño')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('HKD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('HUF','Forint Húngaro')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('INR','Rupia India')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('IDR','Rupiah Indonesia')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('IQD','Dinar Iraquí')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('IRR','Rial Iraní')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('IMP','Libra')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MUR','Rupia Mauricia')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ISK','Króna Islandesa')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KYD','Dólar Caimano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('NZD','Dólar Neozelandés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SBD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('ILS','Nuevo Shékel Israeli')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('JMD','Dólar Jamaicano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('JPY','Yen Japonés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('JEP','Libra')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('JOD','Dinar Jordano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KZT','Tenge Kazajo')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KES','Chelín Keniata')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KGS','Som Kirguís')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('KWD','Dinar Kuwaití')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('LAK','Kip Lao')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('LSL','Loti Lesotense')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('LBP','Libra Libanesa')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('LRD','Dólar Liberiano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('LYD','Dinar Libio')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CHF','Franco Suizo')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('LTL','Litas Lituano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MOP','Pataca')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MKD','Denar Macedonio')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MGA','Ariary Malgache')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MYR','Ringgit Malayo')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MWK','Kwacha Malauí')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MVR','Rufiyaa Maldiva')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MAD','Dirham Marroquí')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MRO','Ouguiya Mauritana')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MXN','Peso Mexicano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MDL','Leu Moldavo')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MNT','Tughrik Mongol')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('MZN','Metical Mozambiqueño')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('NAD','Dólar Namibio')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('NPR','Rupia Nepalesa')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('NIO','Córdoba Nicaragüense')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('NGN','Naira Nigeriana')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('NOK','Corona Noruega')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('XPF','Franco Cfp')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('OMR','Rial Omaní')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('PKR','Rupia Pakistaní')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('PAB','Balboa Panameña')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('PGK','Kina')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('PYG','Guaraní')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('PEN','Nuevo Sol Peruano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('PLN','Złoty Polaco')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('QAR','Rial Qatarí')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('CZK','Koruna Checa')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('DOP','Peso Dominicano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('RWF','Franco Ruandés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('RON','Leu Rumano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SVC','Colón')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('WST','Tala Samoana')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SHP','Libra')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('STD','Dobra')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('RSD','Dinar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SCR','Rupia')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SLL','Leone')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SGD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SYP','Libra Siria')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SOS','Chelín Somalí')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('LKR','Rupia')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SDG','Dinar Sudanés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SSP','South Sudanese Pound')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SEK','Corona Sueca')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SRD','Dólar Surinamés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('SZL','Lilangeni Suazi')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('THB','Baht Tailandés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TWD','Nuevo Dólar Taiwanés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TZS','Chelín Tanzano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TJS','Somoni Tayik')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TOP','Pa Anga Tongano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TTD','Dólar')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TND','Dinar Tunecino')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TMT','Manat Turcomano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('TRY','Nueva Lira')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('UAH','Grivna Ucrainiana')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('UGX','Chelín Ugandés')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('UYU','Peso Uruguayo')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('UZS','Som Uzbeko')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('VUV','Vatu Vanuatense')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('VEF','Bolívar Fuerte Venezolano')
INSERT INTO MONEDA(Codigo,Nombre) VALUES ('VND','Dong Vietnamito')