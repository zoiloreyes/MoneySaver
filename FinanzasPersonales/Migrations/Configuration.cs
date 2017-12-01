namespace FinanzasPersonales.Migrations
{
    using FinanzasPersonales.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinanzasPersonales.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinanzasPersonales.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var EstadosCuentaBanco = new List<EstadoCuentaBanco>
            {
                new EstadoCuentaBanco{Estado = "Activo"},
                new EstadoCuentaBanco{Estado = "Inactivo"}
            };
            EstadosCuentaBanco.ForEach(s => context.EstadosCuentaBanco.Add(s));
            context.SaveChanges();

            var EstadosTarjetaCredito = new List<EstadoTarjetaCredito>
            {
                new EstadoTarjetaCredito{Estado = "Activo"},
                new EstadoTarjetaCredito{Estado = "Inactivo"}
            };
            EstadosTarjetaCredito.ForEach(s => context.EstadosTarjetaCredito.Add(s));
            context.SaveChanges();

            var EstadosCategoria = new List<EstadoCategoria>
            {
                new EstadoCategoria{Estado = "Activo"},
                new EstadoCategoria{Estado = "Inactivo"}
            };
            EstadosCategoria.ForEach(x => context.EstadosCategoria.Add(x));
            context.SaveChanges();

            var TipoCategoria = new List<TipoCategoria>
            {
                new TipoCategoria{Tipo = "Ingreso"},
                new TipoCategoria{Tipo = "Egreso"}
            };
            TipoCategoria.ForEach(t => context.TiposCategoria.Add(t));
            context.SaveChanges();

            var Monedas = new List<Moneda>
            {
                new Moneda { Codigo ="DOP", Nombre="Peso Dominicano"},
                new Moneda { Codigo ="EUR", Nombre="Euro"},
                new Moneda { Codigo ="AFN", Nombre="Afgani Afgano"},
                new Moneda { Codigo ="ZAR", Nombre="Rand Sudafricano"},
                new Moneda { Codigo ="ALL", Nombre="Lek Alban�s"},
                new Moneda { Codigo ="AOA", Nombre="Kwanza Angole�o"},
                new Moneda { Codigo ="XCD", Nombre="D�lar"},
                new Moneda { Codigo ="ANG", Nombre="Flor�n Antillano Neerland�s"},
                new Moneda { Codigo ="SAR", Nombre="Riyal Saud�"},
                new Moneda { Codigo ="DZD", Nombre="Dinar Algerino"},
                new Moneda { Codigo ="ARS", Nombre="Peso Argentino"},
                new Moneda { Codigo ="AMD", Nombre="Dram Armenio"},
                new Moneda { Codigo ="AWG", Nombre="Flor�n Arube�o"},
                new Moneda { Codigo ="AUD", Nombre="D�lar Australiano"},
                new Moneda { Codigo ="AZN", Nombre="Manat Azerbaiyano"},
                new Moneda { Codigo ="BSD", Nombre="D�lar Bahame�o"},
                new Moneda { Codigo ="BHD", Nombre="Dinar Bahreini"},
                new Moneda { Codigo ="BDT", Nombre="Taka"},
                new Moneda { Codigo ="BBD", Nombre="D�lar"},
                new Moneda { Codigo ="BZD", Nombre="D�lar"},
                new Moneda { Codigo ="XOF", Nombre="Franco Cfa"},
                new Moneda { Codigo ="BMD", Nombre="D�lar"},
                new Moneda { Codigo ="BTN", Nombre="Ngultrum"},
                new Moneda { Codigo ="BYN", Nombre="Rublo Bielorruso"},
                new Moneda { Codigo ="MMK", Nombre="Kyat Birmano"},
                new Moneda { Codigo ="BOB", Nombre="Boliviano"},
                new Moneda { Codigo ="BAM", Nombre="Marco Convertible"},
                new Moneda { Codigo ="BWP", Nombre="Pula"},
                new Moneda { Codigo ="BRL", Nombre="Real Brasile�o"},
                new Moneda { Codigo ="BND", Nombre="D�lar"},
                new Moneda { Codigo ="BGN", Nombre="Lev B�lgaro"},
                new Moneda { Codigo ="BIF", Nombre="Franco Burund�s"},
                new Moneda { Codigo ="CVE", Nombre="Escudo Caboverdiano"},
                new Moneda { Codigo ="KHR", Nombre="Riel Camboyano"},
                new Moneda { Codigo ="XAF", Nombre="Franco Cfa"},
                new Moneda { Codigo ="CAD", Nombre="D�lar Canadiense"},
                new Moneda { Codigo ="CLP", Nombre="Peso Chileno"},
                new Moneda { Codigo ="CNY", Nombre="Rmb Yuan Renminbi Chino"},
                new Moneda { Codigo ="COP", Nombre="Peso Colombiano"},
                new Moneda { Codigo ="KMF", Nombre="Franco Comoriano"},
                new Moneda { Codigo ="CDF", Nombre="Franco Congole�o"},
                new Moneda { Codigo ="KPW", Nombre="Won Norcoreano"},
                new Moneda { Codigo ="KRW", Nombre="Won Surcoreano"},
                new Moneda { Codigo ="CRC", Nombre="Col�n Costarricense"},
                new Moneda { Codigo ="HRK", Nombre="Kuna Croata"},
                new Moneda { Codigo ="CUC", Nombre="Peso Cubano Convertible"},
                new Moneda { Codigo ="DKK", Nombre="Corona Danesa"},
                new Moneda { Codigo ="USD", Nombre="D�lar Estadounidense"},
                new Moneda { Codigo ="EGP", Nombre="Libra Egipcia"},
                new Moneda { Codigo ="AED", Nombre="Dirham"},
                new Moneda { Codigo ="ERN", Nombre="Nafka Eritreo"},
                new Moneda { Codigo ="ETB", Nombre="Birr Etiope"},
                new Moneda { Codigo ="FJD", Nombre="D�lar Fijiano"},
                new Moneda { Codigo ="PHP", Nombre="Peso Filipino"},
                new Moneda { Codigo ="RUB", Nombre="Rublo Ruso"},
                new Moneda { Codigo ="GMD", Nombre="Dalasi Gambiano"},
                new Moneda { Codigo ="GEL", Nombre="Lari Georgiano"},
                new Moneda { Codigo ="GHS", Nombre="Cedi Ghan�s"},
                new Moneda { Codigo ="GIP", Nombre="Libra"},
                new Moneda { Codigo ="GBP", Nombre="Libra Esterlina"},
                new Moneda { Codigo ="GTQ", Nombre="Quetzal Guatemalteco"},
                new Moneda { Codigo ="GYD", Nombre="D�lar Guyan�s"},
                new Moneda { Codigo ="GGP", Nombre="Libra"},
                new Moneda { Codigo ="GNF", Nombre="Franco Guineano"},
                new Moneda { Codigo ="HTG", Nombre="Gourde Haitiano"},
                new Moneda { Codigo ="HNL", Nombre="Lempira Hondure�o"},
                new Moneda { Codigo ="HKD", Nombre="D�lar"},
                new Moneda { Codigo ="HUF", Nombre="Forint H�ngaro"},
                new Moneda { Codigo ="INR", Nombre="Rupia India"},
                new Moneda { Codigo ="IDR", Nombre="Rupiah Indonesia"},
                new Moneda { Codigo ="IQD", Nombre="Dinar Iraqu�"},
                new Moneda { Codigo ="IRR", Nombre="Rial Iran�"},
                new Moneda { Codigo ="IMP", Nombre="Libra"},
                new Moneda { Codigo ="MUR", Nombre="Rupia Mauricia"},
                new Moneda { Codigo ="ISK", Nombre="Kr�na Islandesa"},
                new Moneda { Codigo ="KYD", Nombre="D�lar Caimano"},
                new Moneda { Codigo ="NZD", Nombre="D�lar Neozeland�s"},
                new Moneda { Codigo ="SBD", Nombre="D�lar"},
                new Moneda { Codigo ="ILS", Nombre="Nuevo Sh�kel Israeli"},
                new Moneda { Codigo ="JMD", Nombre="D�lar Jamaicano"},
                new Moneda { Codigo ="JPY", Nombre="Yen Japon�s"},
                new Moneda { Codigo ="JEP", Nombre="Libra"},
                new Moneda { Codigo ="JOD", Nombre="Dinar Jordano"},
                new Moneda { Codigo ="KZT", Nombre="Tenge Kazajo"},
                new Moneda { Codigo ="KES", Nombre="Chel�n Keniata"},
                new Moneda { Codigo ="KGS", Nombre="Som Kirgu�s"},
                new Moneda { Codigo ="KWD", Nombre="Dinar Kuwait�"},
                new Moneda { Codigo ="LAK", Nombre="Kip Lao"},
                new Moneda { Codigo ="LSL", Nombre="Loti Lesotense"},
                new Moneda { Codigo ="LBP", Nombre="Libra Libanesa"},
                new Moneda { Codigo ="LRD", Nombre="D�lar Liberiano"},
                new Moneda { Codigo ="LYD", Nombre="Dinar Libio"},
                new Moneda { Codigo ="CHF", Nombre="Franco Suizo"},
                new Moneda { Codigo ="LTL", Nombre="Litas Lituano"},
                new Moneda { Codigo ="MOP", Nombre="Pataca"},
                new Moneda { Codigo ="MKD", Nombre="Denar Macedonio"},
                new Moneda { Codigo ="MGA", Nombre="Ariary Malgache"},
                new Moneda { Codigo ="MYR", Nombre="Ringgit Malayo"},
                new Moneda { Codigo ="MWK", Nombre="Kwacha Malau�"},
                new Moneda { Codigo ="MVR", Nombre="Rufiyaa Maldiva"},
                new Moneda { Codigo ="MAD", Nombre="Dirham Marroqu�"},
                new Moneda { Codigo ="MRO", Nombre="Ouguiya Mauritana"},
                new Moneda { Codigo ="MXN", Nombre="Peso Mexicano"},
                new Moneda { Codigo ="MDL", Nombre="Leu Moldavo"},
                new Moneda { Codigo ="MNT", Nombre="Tughrik Mongol"},
                new Moneda { Codigo ="MZN", Nombre="Metical Mozambique�o"},
                new Moneda { Codigo ="NAD", Nombre="D�lar Namibio"},
                new Moneda { Codigo ="NPR", Nombre="Rupia Nepalesa"},
                new Moneda { Codigo ="NIO", Nombre="C�rdoba Nicarag�ense"},
                new Moneda { Codigo ="NGN", Nombre="Naira Nigeriana"},
                new Moneda { Codigo ="NOK", Nombre="Corona Noruega"},
                new Moneda { Codigo ="XPF", Nombre="Franco Cfp"},
                new Moneda { Codigo ="OMR", Nombre="Rial Oman�"},
                new Moneda { Codigo ="PKR", Nombre="Rupia Pakistan�"},
                new Moneda { Codigo ="PAB", Nombre="Balboa Paname�a"},
                new Moneda { Codigo ="PGK", Nombre="Kina"},
                new Moneda { Codigo ="PYG", Nombre="Guaran�"},
                new Moneda { Codigo ="PEN", Nombre="Nuevo Sol Peruano"},
                new Moneda { Codigo ="PLN", Nombre="Zloty Polaco"},
                new Moneda { Codigo ="QAR", Nombre="Rial Qatar�"},
                new Moneda { Codigo ="CZK", Nombre="Koruna Checa"},
                new Moneda { Codigo ="RWF", Nombre="Franco Ruand�s"},
                new Moneda { Codigo ="RON", Nombre="Leu Rumano"},
                new Moneda { Codigo ="SVC", Nombre="Col�n"},
                new Moneda { Codigo ="WST", Nombre="Tala Samoana"},
                new Moneda { Codigo ="SHP", Nombre="Libra"},
                new Moneda { Codigo ="STD", Nombre="Dobra"},
                new Moneda { Codigo ="RSD", Nombre="Dinar"},
                new Moneda { Codigo ="SCR", Nombre="Rupia"},
                new Moneda { Codigo ="SLL", Nombre="Leone"},
                new Moneda { Codigo ="SGD", Nombre="D�lar"},
                new Moneda { Codigo ="SYP", Nombre="Libra Siria"},
                new Moneda { Codigo ="SOS", Nombre="Chel�n Somal�"},
                new Moneda { Codigo ="LKR", Nombre="Rupia"},
                new Moneda { Codigo ="SDG", Nombre="Dinar Sudan�s"},
                new Moneda { Codigo ="SSP", Nombre="South Sudanese Pound"},
                new Moneda { Codigo ="SEK", Nombre="Corona Sueca"},
                new Moneda { Codigo ="SRD", Nombre="D�lar Surinam�s"},
                new Moneda { Codigo ="SZL", Nombre="Lilangeni Suazi"},
                new Moneda { Codigo ="THB", Nombre="Baht Tailand�s"},
                new Moneda { Codigo ="TWD", Nombre="Nuevo D�lar Taiwan�s"},
                new Moneda { Codigo ="TZS", Nombre="Chel�n Tanzano"},
                new Moneda { Codigo ="TJS", Nombre="Somoni Tayik"},
                new Moneda { Codigo ="TOP", Nombre="Pa Anga Tongano"},
                new Moneda { Codigo ="TTD", Nombre="D�lar"},
                new Moneda { Codigo ="TND", Nombre="Dinar Tunecino"},
                new Moneda { Codigo ="TMT", Nombre="Manat Turcomano"},
                new Moneda { Codigo ="TRY", Nombre="Nueva Lira"},
                new Moneda { Codigo ="UAH", Nombre="Grivna Ucrainiana"},
                new Moneda { Codigo ="UGX", Nombre="Chel�n Ugand�s"},
                new Moneda { Codigo ="UYU", Nombre="Peso Uruguayo"},
                new Moneda { Codigo ="UZS", Nombre="Som Uzbeko"},
                new Moneda { Codigo ="VUV", Nombre="Vatu Vanuatense"},
                new Moneda { Codigo ="VEF", Nombre="Bol�var Fuerte Venezolano"},
                new Moneda { Codigo ="VND", Nombre="Dong Vietnamito"}
            };
            Monedas.ForEach(x => context.Monedas.Add(x));
            context.SaveChanges();
        }
    }
}
    