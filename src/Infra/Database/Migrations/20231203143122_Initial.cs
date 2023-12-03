using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestmentsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    InvestmentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentsHistory_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestmentsHistory_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Symbol = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AveragePurchasePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AcquisitionValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CurrentValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProfitabilityPercentage = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProfitabilityValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TransactionType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AvailableQuantity", "Name", "Price", "Symbol" },
                values: new object[,]
                {
                    { 1, 201257220, "ALPARGATAS", 20.63m, "ALPA4" },
                    { 3, 201257220, "AMBEV S/A", 14.51m, "ABEV3" },
                    { 4, 596875824, "AMERICANAS", 15.93m, "AMER3" },
                    { 5, 794531367, "ASSAI", 15.65m, "ASAI3" },
                    { 6, 327741172, "AZUL", 11.58m, "AZUL4" },
                    { 7, 327741172, "B3", 10.72m, "B3SA3" },
                    { 8, 341124068, "BANCO PAN", 7.08m, "BPAN4" },
                    { 9, 671629692, "BBSEGURIDADE", 27.88m, "BBSE3" },
                    { 10, 828273884, "BR MALLS PAR", 7.82m, "BRML3" },
                    { 11, 1516726535, "BRADESCO", 14.16m, "BBDC3" },
                    { 12, 201257220, "BRADESCO", 17.05m, "BBDC4" },
                    { 13, 251402249, "BRADESPAR", 22.33m, "BRAP4" },
                    { 14, 1420530937, "BRASIL", 34.67m, "BBAS3" },
                    { 15, 264975728, "BRASKEM", 34.08m, "BRKM5" },
                    { 16, 1076512610, "BRF SA", 16.07m, "BRFS3" },
                    { 17, 1301655996, "BTGP BANCO", 22.47m, "BPAC11" },
                    { 18, 410988561, "CARREFOUR BR", 16.93m, "CRFB3" },
                    { 19, 1115693556, "CCR SA", 12.28m, "CCRO3" },
                    { 20, 1448479060, "CEMIG", 10.65m, "CMIG4" },
                    { 21, 1144359228, "CIELO", 4.08m, "CIEL3" },
                    { 22, 1828106676, "COGNA ON", 2.22m, "COGN3" },
                    { 23, 1563365506, "COPEL", 6.9m, "CPLE6" },
                    { 24, 1171063698, "COSAN", 17.49m, "CSAN3" },
                    { 25, 187732538, "CPFL ENERGIA", 32.14m, "CPFE3" },
                    { 26, 1120593365, "CSNMINERACAO", 3.4m, "CMIN3" },
                    { 27, 276543929, "CVC BRASIL", 6.76m, "CVCB3" },
                    { 28, 281609283, "CYRELA REALT", 12.26m, "CYRE3" },
                    { 29, 295712871, "DEXCO", 9.71m, "DXCO3" },
                    { 30, 339237914, "ECORODOVIAS", 5.4m, "ECOR3" },
                    { 31, 985704248, "ELETROBRAS", 44.63m, "ELET3" },
                    { 32, 242987127, "ELETROBRAS", 45.67m, "ELET6" },
                    { 33, 734588205, "EMBRAER", 11.87m, "EMBR3" },
                    { 34, 230931405, "ENERGIAS BR", 21.29m, "ENBR3" },
                    { 35, 248477689, "ENERGISA", 40.65m, "ENGI11" },
                    { 36, 1557479978, "ENEVA", 14.35m, "ENEV3" },
                    { 37, 255217329, "ENGIE BRASIL", 42.17m, "EGIE3" },
                    { 38, 1100513485, "EQUATORIAL", 23.05m, "EQTL3" },
                    { 39, 101618236, "EZTEC", 16.37m, "EZTC3" },
                    { 40, 303373882, "FLEURY", 15.27m, "FLRY3" },
                    { 41, 1097534498, "GERDAU", 23.81m, "GGBR4" },
                    { 42, 698275321, "GERDAU MET", 9.94m, "GOAU4" },
                    { 43, 167095214, "GOL", 7.97m, "GOLL4" },
                    { 44, 834914221, "GRUPO NATURA", 15.84m, "NTCO3" },
                    { 45, 489316435, "GRUPO SOMA", 9.77m, "SOMA3" },
                    { 46, 201257220, "HAPVIDA", 5.95m, "HAPV3" },
                    { 47, 410253528, "HYPERA", 39.93m, "HYPE3" },
                    { 48, 180013980, "IGUATEMI SA", 18.87m, "IGTI11" },
                    { 49, 1255286531, "IRBBRASIL RE", 2m, "IRBR3" },
                    { 50, 201257220, "ITAUSA", 8.47m, "ITSA4" },
                    { 51, 201257220, "ITAUUNIBANCO", 23.26m, "ITUB4" },
                    { 52, 1290736673, "JBS", 30.73m, "JBSS3" },
                    { 53, 305915142, "JHSF PART", 5.6m, "JHSF3" },
                    { 54, 812994397, "KLABIN S/A", 18.9m, "KLBN11" },
                    { 55, 735708470, "LOCALIZA", 55.42m, "RENT3" },
                    { 56, 418965264, "LOCAWEB", 6.74m, "LWSA3" },
                    { 57, 977821540, "LOJAS RENNER", 24.42m, "LREN3" },
                    { 58, 201257220, "MAGAZ LUIZA", 2.86m, "MGLU3" },
                    { 59, 348234011, "MARFRIG", 13.39m, "MRFG3" },
                    { 60, 548153725, "MELIUZ", 1.08m, "CASH3" },
                    { 61, 260409710, "MINERVA", 13.22m, "BEEF3" },
                    { 62, 294647234, "MRV", 8.68m, "MRVE3" },
                    { 63, 272718548, "MULTIPLAN", 23.98m, "MULT3" },
                    { 64, 156946474, "PACUCAR-CBD", 16.9m, "PCAR3" },
                    { 65, 201257220, "PETROBRAS", 31.93m, "PETR3" },
                    { 66, 201257220, "PETROBRAS", 29.33m, "PETR4" },
                    { 67, 839159130, "PETRORIO", 22.67m, "PRIO3" },
                    { 68, 336154589, "PETZ", 9.87m, "PETZ3" },
                    { 69, 78053723, "POSITIVO TEC", 6.64m, "POSI3" },
                    { 70, 277027077, "QUALICORP", 10.43m, "QUAL3" },
                    { 71, 1071076905, "RAIADROGASIL", 20.03m, "RADL3" },
                    { 72, 772010260, "REDE D OR", 30.25m, "RDOR3" },
                    { 73, 1216056103, "RUMO SA", 16.09m, "RAIL3" },
                    { 74, 340001934, "SABESP", 43.55m, "SBSP3" },
                    { 75, 362703399, "SANTANDER BR", 27.53m, "SANB11" },
                    { 76, 642398790, "SID NACIONAL", 14.41m, "CSNA3" },
                    { 77, 96270946, "SLC AGRICOLA", 42.35m, "SLCE3" },
                    { 78, 283167854, "SUL AMERICA", 22.1m, "SULA11" },
                    { 79, 726779281, "SUZANO SA", 46.91m, "SUZB3" },
                    { 80, 218568234, "TAESA", 40.25m, "TAEE11" },
                    { 81, 413890875, "TELEF BRASIL", 46.83m, "VIVT3" },
                    { 82, 808619532, "TIM", 12.9m, "TIMS3" },
                    { 83, 519851955, "TOTVS", 25.89m, "TOTS3" },
                    { 84, 1086067887, "ULTRAPAR", 12.46m, "UGPA3" },
                    { 85, 514680651, "USIMINAS", 8.91m, "USIM5" },
                    { 86, 201257220, "VALE", 69.21m, "VALE3" },
                    { 87, 1596295753, "VIA", 2.51m, "VIIA3" },
                    { 88, 1131883365, "VIBRA", 16.54m, "VBBR3" },
                    { 89, 1484859030, "WEG", 25.84m, "WEGE3" },
                    { 90, 300833122, "YDUQS PART", 13.9m, "YDUQ3" },
                    { 91, 200372163, "3R PETROLEUM", 29.43m, "RRRP3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentsHistory_AccountId",
                table: "InvestmentsHistory",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentsHistory_AssetId",
                table: "InvestmentsHistory",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_AccountId",
                table: "Portfolios",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_AssetId",
                table: "Portfolios",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_AccountId",
                table: "TransactionHistory",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentsHistory");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
