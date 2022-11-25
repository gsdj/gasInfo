using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DA.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asdue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    TecNorth = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false),
                    TecSouth = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false),
                    Gps2Gss1 = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false),
                    Gps2Gss2 = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false),
                    NaturalGasQn = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: false),
                    OutPkg = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asdue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacteristicsDg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Kc1CO2 = table.Column<decimal>(name: "Kc1_CO2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1CO = table.Column<decimal>(name: "Kc1_CO", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1N2 = table.Column<decimal>(name: "Kc1_N2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1H2 = table.Column<decimal>(name: "Kc1_H2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2CO2 = table.Column<decimal>(name: "Kc2_CO2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2CO = table.Column<decimal>(name: "Kc2_CO", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2N2 = table.Column<decimal>(name: "Kc2_N2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2H2 = table.Column<decimal>(name: "Kc2_H2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacteristicsDg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacteristicsKg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Kc1O2 = table.Column<decimal>(name: "Kc1_O2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1CnHm = table.Column<decimal>(name: "Kc1_CnHm", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1CH4 = table.Column<decimal>(name: "Kc1_CH4", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1CO2 = table.Column<decimal>(name: "Kc1_CO2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1CO = table.Column<decimal>(name: "Kc1_CO", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1N2 = table.Column<decimal>(name: "Kc1_N2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1H2 = table.Column<decimal>(name: "Kc1_H2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2O2 = table.Column<decimal>(name: "Kc2_O2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2CnHm = table.Column<decimal>(name: "Kc2_CnHm", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2CH4 = table.Column<decimal>(name: "Kc2_CH4", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2CO2 = table.Column<decimal>(name: "Kc2_CO2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2CO = table.Column<decimal>(name: "Kc2_CO", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2N2 = table.Column<decimal>(name: "Kc2_N2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2H2 = table.Column<decimal>(name: "Kc2_H2", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacteristicsKg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevicesKip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Cu1Consumption = table.Column<int>(name: "Cu1_Consumption", type: "int", nullable: true),
                    Cu1Pressure = table.Column<int>(name: "Cu1_Pressure", type: "int", nullable: true),
                    Cu1Temperature = table.Column<decimal>(name: "Cu1_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cu2Consumption = table.Column<int>(name: "Cu2_Consumption", type: "int", nullable: true),
                    Cu2Pressure = table.Column<int>(name: "Cu2_Pressure", type: "int", nullable: true),
                    Cu2Temperature = table.Column<decimal>(name: "Cu2_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb5Consumption = table.Column<int>(name: "Cb5_Consumption", type: "int", nullable: true),
                    Cb5Pressure = table.Column<int>(name: "Cb5_Pressure", type: "int", nullable: true),
                    Cb5Temperature = table.Column<decimal>(name: "Cb5_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb5TempBeforeHeating = table.Column<decimal>(name: "Cb5_TempBeforeHeating", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb6Consumption = table.Column<int>(name: "Cb6_Consumption", type: "int", nullable: true),
                    Cb6Pressure = table.Column<int>(name: "Cb6_Pressure", type: "int", nullable: true),
                    Cb6Temperature = table.Column<decimal>(name: "Cb6_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb6TempBeforeHeating = table.Column<decimal>(name: "Cb6_TempBeforeHeating", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb7ConsumptionMs = table.Column<decimal>(name: "Cb7_Consumption_Ms", type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb7ConsumptionKs = table.Column<decimal>(name: "Cb7_Consumption_Ks", type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb7Pressure = table.Column<int>(name: "Cb7_Pressure", type: "int", nullable: true),
                    Cb7Temperature = table.Column<decimal>(name: "Cb7_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb7TempBeforeHeating = table.Column<decimal>(name: "Cb7_TempBeforeHeating", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb8ConsumptionMs = table.Column<decimal>(name: "Cb8_Consumption_Ms", type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb8ConsumptionKs = table.Column<decimal>(name: "Cb8_Consumption_Ks", type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb8Pressure = table.Column<int>(name: "Cb8_Pressure", type: "int", nullable: true),
                    Cb8Temperature = table.Column<decimal>(name: "Cb8_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb8TempBeforeHeating = table.Column<decimal>(name: "Cb8_TempBeforeHeating", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    PkcConsumptionMs = table.Column<decimal>(name: "Pkc_Consumption_Ms", type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    PkcConsumptionKs = table.Column<decimal>(name: "Pkc_Consumption_Ks", type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    PkcPressure = table.Column<int>(name: "Pkc_Pressure", type: "int", nullable: true),
                    PkcTemperature = table.Column<decimal>(name: "Pkc_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    UvtpConsumption = table.Column<int>(name: "Uvtp_Consumption", type: "int", nullable: true),
                    UvtpPressure = table.Column<int>(name: "Uvtp_Pressure", type: "int", nullable: true),
                    UvtpTemperature = table.Column<decimal>(name: "Uvtp_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    SpoConsumption = table.Column<int>(name: "Spo_Consumption", type: "int", nullable: true),
                    SpoPressure = table.Column<int>(name: "Spo_Pressure", type: "int", nullable: true),
                    SpoTemperature = table.Column<decimal>(name: "Spo_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Gsuf45Consumption = table.Column<int>(name: "Gsuf45_Consumption", type: "int", nullable: true),
                    Gsuf45Pressure = table.Column<int>(name: "Gsuf45_Pressure", type: "int", nullable: true),
                    Gsuf45Temperature = table.Column<decimal>(name: "Gsuf45_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb1Consumption = table.Column<int>(name: "Cb1_Consumption", type: "int", nullable: true),
                    Cb1Pressure = table.Column<int>(name: "Cb1_Pressure", type: "int", nullable: true),
                    Cb1Temperature = table.Column<decimal>(name: "Cb1_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb2Consumption = table.Column<int>(name: "Cb2_Consumption", type: "int", nullable: true),
                    Cb2Pressure = table.Column<int>(name: "Cb2_Pressure", type: "int", nullable: true),
                    Cb2Temperature = table.Column<decimal>(name: "Cb2_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb3Consumption = table.Column<int>(name: "Cb3_Consumption", type: "int", nullable: true),
                    Cb3Pressure = table.Column<int>(name: "Cb3_Pressure", type: "int", nullable: true),
                    Cb3Temperature = table.Column<decimal>(name: "Cb3_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb4Consumption = table.Column<int>(name: "Cb4_Consumption", type: "int", nullable: true),
                    Cb4Pressure = table.Column<int>(name: "Cb4_Pressure", type: "int", nullable: true),
                    Cb4Temperature = table.Column<decimal>(name: "Cb4_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Gru1Consumption = table.Column<int>(name: "Gru1_Consumption", type: "int", nullable: true),
                    Gru1Pressure = table.Column<int>(name: "Gru1_Pressure", type: "int", nullable: true),
                    Gru1Temperature = table.Column<decimal>(name: "Gru1_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Gru2Consumption = table.Column<int>(name: "Gru2_Consumption", type: "int", nullable: true),
                    Gru2Pressure = table.Column<int>(name: "Gru2_Pressure", type: "int", nullable: true),
                    Gru2Temperature = table.Column<decimal>(name: "Gru2_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Grp4Consumption = table.Column<int>(name: "Grp4_Consumption", type: "int", nullable: true),
                    Grp4Pressure = table.Column<int>(name: "Grp4_Pressure", type: "int", nullable: true),
                    Grp4Temperature = table.Column<decimal>(name: "Grp4_Temperature", type: "numeric(5,1)", precision: 5, scale: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicesKip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DgPgChmkEb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    ConsDgCb1 = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ConsDgCb2 = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ConsDgCb3 = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ConsDgCb4 = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ConsPgGru1 = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ConsPgGru2 = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DgPgChmkEb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KgChmkEb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Consumption = table.Column<decimal>(type: "numeric(20,10)", precision: 20, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KgChmkEb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutputMultipliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Sv = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Fv = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Peka = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb1 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb2 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb3 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb4 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb5 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb6 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb7 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    Cb8 = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false),
                    PKP = table.Column<decimal>(type: "numeric(14,10)", precision: 14, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputMultipliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pressure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Value = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pressure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Kc1W = table.Column<decimal>(name: "Kc1_W", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1A = table.Column<decimal>(name: "Kc1_A", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1V = table.Column<decimal>(name: "Kc1_V", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2W = table.Column<decimal>(name: "Kc2_W", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2A = table.Column<decimal>(name: "Kc2_A", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2V = table.Column<decimal>(name: "Kc2_V", type: "numeric(8,3)", precision: 8, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Chmk = table.Column<decimal>(type: "numeric(16,10)", precision: 16, scale: 10, nullable: false),
                    TecNorth = table.Column<decimal>(type: "numeric(16,10)", precision: 16, scale: 10, nullable: false),
                    TecSouth = table.Column<decimal>(type: "numeric(16,10)", precision: 16, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmmountCb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    OutputMultipliersId = table.Column<int>(type: "int", nullable: false),
                    Cb1 = table.Column<int>(type: "int", nullable: false),
                    Cb2 = table.Column<int>(type: "int", nullable: false),
                    Cb3 = table.Column<int>(type: "int", nullable: false),
                    Cb4 = table.Column<int>(type: "int", nullable: false),
                    Cb5 = table.Column<int>(type: "int", nullable: false),
                    Cb6 = table.Column<int>(type: "int", nullable: false),
                    Cb7 = table.Column<int>(type: "int", nullable: false),
                    Cb8 = table.Column<int>(type: "int", nullable: false),
                    PKP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmountCb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmmountCb_OutputMultipliers_OutputMultipliersId",
                        column: x => x.OutputMultipliersId,
                        principalTable: "OutputMultipliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Asdue",
                columns: new[] { "Id", "Date", "Gps2Gss1", "Gps2Gss2", "NaturalGasQn", "OutPkg", "TecNorth", "TecSouth" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1202109.25m, 623785.25m },
                    { 2, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1210836.625m, 678807.438m },
                    { 3, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1216379.5m, 659785.188m },
                    { 4, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1220913.125m, 661455.75m },
                    { 5, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1275228.25m, 675696.625m },
                    { 6, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1271219m, 653792.062m },
                    { 7, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1263621.75m, 639858.562m },
                    { 8, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1233371.5m, 627278.5m },
                    { 9, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1220212.125m, 618869.5m },
                    { 10, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1194737m, 605011.312m },
                    { 11, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1223113.75m, 613180.25m },
                    { 12, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1258818.5m, 629169.938m },
                    { 13, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1258085.625m, 639324.938m },
                    { 14, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1242764m, 621362.375m },
                    { 15, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1228805.125m, 630230.875m },
                    { 16, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1217370.125m, 617022.875m },
                    { 17, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1213002.5m, 610523.875m },
                    { 18, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1214280.625m, 597552.568m },
                    { 19, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1203295.25m, 596240.875m },
                    { 20, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1203814.375m, 587936.062m },
                    { 21, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1179715.25m, 560536.938m },
                    { 22, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1122585m, 527059.562m },
                    { 23, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1150668m, 538152.75m },
                    { 24, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1174988.875m, 552836.375m },
                    { 25, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1219484.75m, 563639m },
                    { 26, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1204480.25m, 546306.562m },
                    { 27, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1201333.5m, 561174.75m },
                    { 28, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1205495.625m, 565309.438m },
                    { 29, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1355796.75m, 591316.375m },
                    { 30, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1323448.125m, 550431.5m },
                    { 31, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m, 0m, 1296275.275m, 577219.375m }
                });

            migrationBuilder.InsertData(
                table: "CharacteristicsDg",
                columns: new[] { "Id", "Date", "Kc1_CO", "Kc1_CO2", "Kc1_H2", "Kc1_N2", "Kc2_CO", "Kc2_CO2", "Kc2_H2", "Kc2_N2" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 16.5m, 5.1m, 56.9m, 21.2m, 16.5m, 5.1m, 56.9m },
                    { 2, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 16.5m, 5.1m, 56.9m, 21.2m, 16.5m, 5.1m, 56.9m },
                    { 3, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.3m, 17.5m, 5.4m, 55.5m, 21.3m, 17.5m, 5.4m, 55.5m },
                    { 4, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.8m, 13m, 5.2m, 58.7m, 22.8m, 13m, 5.2m, 58.7m },
                    { 5, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.77m, 15.67m, 5.23m, 57m, 21.77m, 15.67m, 5.23m, 57m },
                    { 6, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.5m, 17.7m, 4.5m, 57m, 20.5m, 17.7m, 4.5m, 57m },
                    { 7, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.8m, 19.4m, 7.4m, 51.1m, 21.8m, 19.4m, 7.4m, 51.1m },
                    { 8, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.7m, 19.9m, 8.3m, 47.8m, 23.7m, 19.9m, 8.3m, 47.8m },
                    { 9, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.87m, 17.1m, 5.88m, 54.9m, 21.87m, 17.1m, 5.88m, 54.9m },
                    { 10, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.6m, 16.6m, 6.3m, 54.2m, 22.6m, 16.6m, 6.3m, 54.2m },
                    { 11, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.4m, 19.8m, 7m, 49.5m, 23.4m, 19.8m, 7m, 49.5m },
                    { 12, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.7m, 20m, 7.9m, 47.1m, 24.7m, 20m, 7.9m, 47.1m },
                    { 13, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.57m, 17.4m, 7.07m, 51.7m, 23.57m, 17.4m, 7.07m, 51.7m },
                    { 14, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.1m, 15.7m, 6.9m, 52m, 25.1m, 15.7m, 6.9m, 52m },
                    { 15, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.6m, 17.6m, 7.1m, 50.4m, 24.6m, 17.6m, 7.1m, 50.4m },
                    { 16, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.2m, 20.1m, 5.5m, 51.9m, 22.2m, 20.1m, 5.5m, 51.9m },
                    { 17, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 24m, 17.8m, 6.5m, 51.4m, 24m, 17.8m, 6.5m, 51.4m },
                    { 18, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.4m, 17.7m, 5.1m, 55.5m, 21.4m, 17.7m, 5.1m, 55.5m },
                    { 19, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.9m, 18.3m, 6.7m, 49.8m, 24.9m, 18.3m, 6.7m, 49.8m },
                    { 20, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.7m, 18.6m, 6.3m, 51.1m, 23.7m, 18.6m, 6.3m, 51.1m },
                    { 21, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.9m, 19m, 7m, 50.8m, 22.9m, 19m, 7m, 50.8m },
                    { 22, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.4m, 17.8m, 6.3m, 53.2m, 22.4m, 17.8m, 6.3m, 53.2m },
                    { 23, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.5m, 18.9m, 5.4m, 54.9m, 20.5m, 18.9m, 5.4m, 54.9m },
                    { 24, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.7m, 18.4m, 7.2m, 48.4m, 25.7m, 18.4m, 7.2m, 48.4m },
                    { 25, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.1m, 16.6m, 7.1m, 50.9m, 25.1m, 16.6m, 7.1m, 50.9m },
                    { 26, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.9m, 17m, 7m, 51.8m, 23.9m, 17m, 7m, 51.8m },
                    { 27, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.8m, 19.8m, 7.4m, 46.7m, 25.8m, 19.8m, 7.4m, 46.7m },
                    { 28, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.6m, 18.1m, 8.4m, 45.6m, 27.6m, 18.1m, 8.4m, 45.6m },
                    { 29, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 24m, 16.9m, 8.8m, 50.8m, 24m, 16.9m, 8.8m, 50.8m },
                    { 30, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.2m, 16.4m, 7.5m, 51.6m, 24.2m, 16.4m, 7.5m, 51.6m },
                    { 31, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.2m, 17.7m, 6.8m, 53m, 22.2m, 17.7m, 6.8m, 53m }
                });

            migrationBuilder.InsertData(
                table: "CharacteristicsKg",
                columns: new[] { "Id", "Date", "Kc1_CH4", "Kc1_CO", "Kc1_CO2", "Kc1_CnHm", "Kc1_H2", "Kc1_N2", "Kc1_O2", "Kc2_CH4", "Kc2_CO", "Kc2_CO2", "Kc2_CnHm", "Kc2_H2", "Kc2_N2", "Kc2_O2" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 2, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 3, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 4, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 5, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 6, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 7, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 8, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m, 21.2m, 7.6m, 2.8m, 2m, 58.6m, 6.1m, 1.7m },
                    { 9, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.1m, 7.7m, 2.5m, 2m, 58.7m, 6.3m, 1.7m, 21.1m, 7.7m, 2.5m, 2m, 58.7m, 6.3m, 1.7m },
                    { 10, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.3m, 7.6m, 2.7m, 2m, 59.2m, 5.5m, 1.7m, 21.3m, 7.6m, 2.7m, 2m, 59.2m, 5.5m, 1.7m },
                    { 11, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.7m, 2.6m, 2.1m, 58m, 6.5m, 1.9m, 21.2m, 7.7m, 2.6m, 2.1m, 58m, 6.5m, 1.9m },
                    { 12, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.7m, 2.6m, 2.1m, 58m, 6.5m, 1.9m, 21.2m, 7.7m, 2.6m, 2.1m, 58m, 6.5m, 1.9m },
                    { 13, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.7m, 2.6m, 2.1m, 58m, 6.5m, 1.9m, 21.2m, 7.7m, 2.6m, 2.1m, 58m, 6.5m, 1.9m },
                    { 14, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.8m, 7.5m, 2.7m, 1.8m, 57.9m, 6.5m, 1.8m, 21.8m, 7.5m, 2.7m, 1.8m, 57.9m, 6.5m, 1.8m },
                    { 15, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.5m, 7.7m, 2.6m, 1.9m, 58.1m, 6.4m, 1.8m, 21.5m, 7.7m, 2.6m, 1.9m, 58.1m, 6.4m, 1.8m },
                    { 16, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.6m, 7.6m, 2.5m, 2m, 58.3m, 6.2m, 1.8m, 21.6m, 7.6m, 2.5m, 2m, 58.3m, 6.2m, 1.8m },
                    { 17, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.7m, 7.3m, 2.7m, 1.8m, 58.2m, 6.4m, 1.9m, 21.7m, 7.3m, 2.7m, 1.8m, 58.2m, 6.4m, 1.9m },
                    { 18, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.8m, 7.5m, 2.6m, 1.8m, 58.1m, 6.3m, 1.9m, 21.8m, 7.5m, 2.6m, 1.8m, 58.1m, 6.3m, 1.9m },
                    { 19, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.8m, 7.5m, 2.6m, 1.8m, 58.1m, 6.3m, 1.9m, 21.8m, 7.5m, 2.6m, 1.8m, 58.1m, 6.3m, 1.9m },
                    { 20, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.8m, 7.5m, 2.6m, 1.8m, 58.1m, 6.3m, 1.9m, 21.8m, 7.5m, 2.6m, 1.8m, 58.1m, 6.3m, 1.9m },
                    { 21, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.7m, 2.9m, 1.8m, 57.8m, 6.7m, 1.9m, 21.2m, 7.7m, 2.9m, 1.8m, 57.8m, 6.7m, 1.9m },
                    { 22, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.4m, 7.6m, 2.7m, 1.9m, 58m, 6.5m, 1.9m, 21.4m, 7.6m, 2.7m, 1.9m, 58m, 6.5m, 1.9m },
                    { 23, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.3m, 7.6m, 2.8m, 2m, 57.9m, 6.5m, 1.9m, 21.3m, 7.6m, 2.8m, 2m, 57.9m, 6.5m, 1.9m },
                    { 24, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.5m, 7.5m, 2.9m, 1.8m, 57.8m, 6.6m, 1.9m, 21.5m, 7.5m, 2.9m, 1.8m, 57.8m, 6.6m, 1.9m },
                    { 25, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.1m, 7.9m, 2.4m, 1.8m, 58.2m, 6.7m, 1.9m, 21.1m, 7.9m, 2.4m, 1.8m, 58.2m, 6.7m, 1.9m },
                    { 26, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.1m, 7.9m, 2.4m, 1.8m, 58.2m, 6.7m, 1.9m, 21.1m, 7.9m, 2.4m, 1.8m, 58.2m, 6.7m, 1.9m },
                    { 27, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.1m, 7.9m, 2.4m, 1.8m, 58.2m, 6.7m, 1.9m, 21.1m, 7.9m, 2.4m, 1.8m, 58.2m, 6.7m, 1.9m },
                    { 28, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.2m, 7.8m, 2.6m, 1.9m, 58m, 6.6m, 1.9m, 21.2m, 7.8m, 2.6m, 1.9m, 58m, 6.6m, 1.9m },
                    { 29, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.3m, 7.7m, 2.7m, 1.8m, 57.8m, 6.8m, 1.9m, 21.3m, 7.7m, 2.7m, 1.8m, 57.8m, 6.8m, 1.9m },
                    { 30, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.4m, 7.3m, 2.5m, 1.8m, 58.1m, 7m, 1.9m, 21.4m, 7.3m, 2.5m, 1.8m, 58.1m, 7m, 1.9m },
                    { 31, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.9m, 7.4m, 2.5m, 1.9m, 58m, 6.4m, 1.9m, 21.9m, 7.4m, 2.5m, 1.9m, 58m, 6.4m, 1.9m }
                });

            migrationBuilder.InsertData(
                table: "DevicesKip",
                columns: new[] { "Id", "Pkc_Pressure", "Pkc_Temperature", "Pkc_Consumption_Ks", "Pkc_Consumption_Ms", "Date", "Cb1_Consumption", "Cb1_Pressure", "Cb1_Temperature", "Cb2_Consumption", "Cb2_Pressure", "Cb2_Temperature", "Cb3_Consumption", "Cb3_Pressure", "Cb3_Temperature", "Cb4_Consumption", "Cb4_Pressure", "Cb4_Temperature", "Cb5_Consumption", "Cb5_Pressure", "Cb5_TempBeforeHeating", "Cb5_Temperature", "Cb6_Consumption", "Cb6_Pressure", "Cb6_TempBeforeHeating", "Cb6_Temperature", "Cb7_Pressure", "Cb7_TempBeforeHeating", "Cb7_Temperature", "Cb7_Consumption_Ks", "Cb7_Consumption_Ms", "Cb8_Pressure", "Cb8_TempBeforeHeating", "Cb8_Temperature", "Cb8_Consumption_Ks", "Cb8_Consumption_Ms", "Cu1_Consumption", "Cu1_Pressure", "Cu1_Temperature", "Cu2_Consumption", "Cu2_Pressure", "Cu2_Temperature", "Grp4_Consumption", "Grp4_Pressure", "Grp4_Temperature", "Gru1_Consumption", "Gru1_Pressure", "Gru1_Temperature", "Gru2_Consumption", "Gru2_Pressure", "Gru2_Temperature", "Gsuf45_Consumption", "Gsuf45_Pressure", "Gsuf45_Temperature", "Spo_Consumption", "Spo_Pressure", "Spo_Temperature", "Uvtp_Consumption", "Uvtp_Pressure", "Uvtp_Temperature" },
                values: new object[,]
                {
                    { 1, 1030, 26m, 11665m, 12576m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 924484, 391, 28m, 1062402, 391, 28m, 0, 0, 0m, 1041164, 414, 22m, 7435, 391, 26m, 61m, 7218, 391, 26m, 65m, 446, 31m, 62m, 2539m, 2542m, 427, 30m, 57m, 3013m, 2570m, 1664569, 1124, 34m, 709345, 744, 31m, 0, 0, 0m, 16584, 627, -11m, 14976, 425, -104m, 5609, 1046, 36m, 29001, 610, 19m, 18516, 1040, 26m },
                    { 2, 1043, 27m, 12003m, 14354m, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 919649, 397, 27m, 1004744, 397, 27m, 0, 0, 0m, 1040120, 419, 21m, 7462, 381, 24m, 58m, 6917, 388, 24m, 62m, 469, 31m, 61m, 2350m, 2259m, 461, 30m, 61m, 2672m, 2227m, 1673337, 1147, 34m, 708767, 757, 31m, 0, 0, 0m, 15600, 618, -8m, 13920, 434, -7.6m, 3674, 1067, 36m, 29524, 893, 9m, 18841, 1059, 27m },
                    { 3, 1054, 26m, 11015m, 10198m, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 923255, 392, 28m, 1032434, 392, 28m, 0, 0, 0m, 1076294, 411, 23m, 7826, 385, 25m, 59m, 7779, 380, 25m, 64m, 446, 32m, 55m, 2593m, 2476m, 410, 30m, 62m, 3002m, 2562m, 1685176, 1138, 34m, 733009, 679, 30m, 0, 0, 0m, 15672, 624, -7m, 14040, 438, -11.4m, 3484, 1076, 38m, 28485, 866, 6m, 19185, 1066, 26m },
                    { 4, 1027, 22m, 11424m, 10001m, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 939789, 404, 26m, 1064600, 404, 26m, 0, 0, 0m, 1037908, 430, 20m, 6991, 384, 23m, 55m, 7455, 392, 23m, 60m, 461, 30m, 54m, 2464m, 2394m, 440, 28m, 61m, 2735m, 2441m, 1699491, 1120, 34m, 727462, 811, 29m, 0, 0, 0m, 16272, 630, -12m, 14664, 429, -10.9m, 5953, 1049, 36m, 28831, 795, 9m, 19064, 1035, 22m },
                    { 5, 1054, 25m, 11073m, 9545m, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 912882, 403, 23m, 1024448, 403, 23m, 0, 0, 0m, 1024275, 427, 17m, 7482, 373, 24m, 54m, 7165, 389, 24m, 59m, 470, 30m, 55m, 2577m, 2425m, 430, 28m, 61m, 2844m, 2432m, 1676852, 1141, 33m, 735857, 804, 29m, 0, 0, 0m, 16152, 623, -12m, 14664, 430, -11.2m, 4960, 1070, 36m, 28371, 692, 7m, 19182, 1056, 25m },
                    { 6, 1069, 28m, 11658m, 9707m, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 938413, 374, 22m, 1057257, 374, 22m, 0, 0, 0m, 1018196, 400, 16m, 7670, 390, 24m, 56m, 7323, 389, 24m, 61m, 463, 30m, 59m, 2621m, 2438m, 422, 28m, 63m, 2892m, 2463m, 1714918, 1175, 33m, 737096, 746, 30m, 0, 0, 0m, 16008, 620, -14m, 14640, 434, -14m, 5399, 1097, 35m, 28780, 903, 11m, 18936, 1079, 28m },
                    { 7, 1039, 29m, 11613m, 10748m, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 868483, 424, 29m, 966859, 424, 29m, 0, 0, 0m, 989561, 450, 23m, 7725, 396, 25m, 62m, 7303, 378, 25m, 65m, 458, 31m, 59m, 2595m, 2483m, 425, 29m, 55m, 2813m, 2413m, 1701660, 1145, 34m, 722180, 725, 30m, 0, 0, 0m, 15984, 626, -14m, 14712, 433, -13.5m, 4596, 1103, 36m, 28405, 915, 10m, 19037, 1087, 29m },
                    { 8, 1040, 25m, 11688m, 9046m, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 918677, 423, 31m, 987649, 423, 31m, 0, 0, 0m, 995020, 450, 24m, 7800, 392, 24m, 60m, 7402, 389, 24m, 63m, 456, 30m, 59m, 2652m, 2609m, 422, 28m, 54m, 2876m, 2460m, 1698772, 1141, 34m, 729908, 750, 30m, 0, 0, 0m, 13752, 633, -14m, 11472, 468, -13m, 5759, 1074, 36m, 28476, 849, 9m, 18795, 1060, 25m },
                    { 9, 1024, 23.9m, 12053m, 10283m, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 900382, 445, 28m, 982851, 445, 28m, 0, 0, 0m, 990016, 471, 22m, 7851, 375, 24m, 59m, 7580, 391, 24m, 63m, 464, 31m, 60m, 2550m, 2462m, 424, 30m, 55m, 2859m, 2431m, 1708982, 1147, 34m, 740416, 762, 31m, 0, 0, 0m, 11760, 622, -10m, 10992, 469, -9.8m, 3516, 1065, 35m, 29517, 792, 8m, 19093, 1046, 23.9m },
                    { 10, 1026, 27m, 11016m, 10144m, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 941103, 450, 29m, 1025022, 450, 29m, 0, 0, 0m, 1020291, 477, 24m, 7821, 376, 24m, 61m, 7448, 382, 24m, 65m, 459, 31m, 60m, 2615m, 2498m, 438, 31m, 57m, 2790m, 2379m, 1533358, 1158, 34m, 691937, 861, 30m, 0, 0, 0m, 14112, 637, -12m, 10152, 472, -11m, 3924, 1088, 37m, 28933, 763, 5m, 18722, 1063, 27m },
                    { 11, 972, 29m, 11242m, 10771m, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 856518, 467, 30m, 965836, 467, 30m, 0, 0, 0m, 989109, 490, 25m, 7820, 380, 25m, 64m, 7596, 380, 25m, 67m, 482, 30m, 62m, 2471m, 2321m, 440, 30m, 61m, 2658m, 2241m, 1556101, 1112, 35m, 660752, 798, 29m, 0, 0, 0m, 14208, 633, -11m, 12336, 453, -11m, 2369, 1065, 37m, 30862, 739, 16m, 20299, 1034, 29m },
                    { 12, 950, 23m, 10013m, 11336m, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 839624, 461, 23m, 934758, 461, 23m, 0, 0, 0m, 996163, 483, 18m, 7973, 387, 23m, 55m, 7658, 397, 23m, 59m, 459, 31m, 59m, 2566m, 2427m, 427, 29m, 57m, 2768m, 2333m, 1568548, 1086, 33m, 703454, 780, 30m, 0, 0, 0m, 9096, 635, -4m, 8064, 484, -3.5m, 3431, 1002, 35m, 29981, 818, 6m, 19051, 976, 23m },
                    { 13, 1022, 26m, 9162m, 11576m, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 889357, 475, 26m, 960159, 475, 26m, 0, 0, 0m, 957249, 497, 21m, 8009, 384, 24m, 55m, 7787, 390, 24m, 61m, 451, 32m, 59m, 2682m, 2609m, 420, 30m, 58m, 2951m, 2496m, 1608113, 1149, 34m, 740796, 898, 31m, 0, 0, 0m, 12864, 633, -3m, 12576, 442, -1.1m, 2850, 1070, 35m, 30187, 1066, 21m, 19296, 1055, 26m },
                    { 14, 955, 24m, 9844m, 10716m, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 874499, 441, 30m, 1006873, 441, 30m, 0, 0, 0m, 985946, 463, 24m, 8256, 372, 24m, 61m, 7725, 391, 24m, 64m, 442, 31m, 59m, 2749m, 2671m, 409, 30m, 60m, 2965m, 2513m, 1751963, 1092, 34m, 750385, 814, 30m, 0, 0, 0m, 15288, 623, -12m, 12624, 448, -12m, 1653, 1045, 35m, 31616, 1058, 3m, 19150, 1039, 24m },
                    { 15, 983, 23.9m, 9701m, 11334m, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 876085, 416, 29.4m, 1010803, 416, 29.4m, 0, 0, 0m, 1023193, 428, 24m, 8277, 366, 25m, 58m, 7863, 385, 25m, 62m, 447, 31m, 58m, 2752m, 2621m, 410, 29m, 56m, 3010m, 2537m, 1927282, 1123, 34m, 746930, 811, 29m, 0, 0, 0m, 12048, 644, -8m, 10296, 472, -7.4m, 890, 1026, 35.5m, 32563, 1088, 6m, 18833, 1017, 23.9m },
                    { 16, 960, 24.2m, 10845m, 10732m, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 870631, 438, 26.7m, 986019, 438, 26.7m, 0, 0, 0m, 950564, 462, 20.6m, 7913, 373, 23m, 55m, 7615, 385, 23m, 60m, 455, 31m, 58m, 2630m, 2497m, 418, 29m, 56m, 2917m, 2452m, 1861067, 1124, 31m, 699552, 786, 30m, 0, 0, 0m, 13920, 635, -11m, 12792, 448, -10.6m, 1337, 1061, 35.5m, 31474, 1088, 5m, 19621, 1056, 24m },
                    { 17, 1014, 25m, 10730m, 11159m, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 899508, 415, 25.3m, 997962, 415, 25.3m, 0, 0, 0m, 999598, 437, 19.7m, 8227, 368, 23m, 55m, 7873, 378, 23m, 60m, 444, 31m, 59m, 2701m, 2543m, 416, 29m, 57m, 2875m, 2449m, 1915373, 1189, 31m, 746869, 757, 30.8m, 0, 0, 0m, 6732, 630, -10m, 7704, 493, -10.2m, 5458, 1069, 33m, 29493, 1173, 9m, 17964, 1080, 25m },
                    { 18, 926, 26m, 10272m, 10211m, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 934485, 416, 29.8m, 1002861, 416, 29.8m, 0, 0, 0m, 1007676, 440, 24m, 8251, 370, 24.7m, 60m, 7830, 383, 24.7m, 63.7m, 439, 32.2m, 60.3m, 2728m, 2588m, 407, 31.2m, 61.6m, 2946m, 2514m, 1917339, 1117, 32m, 738747, 707, 31m, 0, 0, 0m, 15360, 625, -4m, 0, 0, 0m, 4625, 1052, 35m, 25325, 1093, 6m, 18354, 1070, 26m },
                    { 19, 882, 28m, 10440m, 9576m, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 860064, 420, 30.2m, 1004208, 420, 30.2m, 0, 0, 0m, 952659, 454, 26m, 8139, 387, 26m, 63.4m, 7544, 389, 26m, 66.8m, 434, 32.5m, 61.1m, 2607m, 2417m, 401, 32.3m, 64.2m, 2888m, 2446m, 1858861, 1081, 34m, 681303, 642, 30m, 0, 0, 0m, 11568, 637, -1m, 0, 0, 0m, 2232, 1002, 37m, 24999, 1051, 10m, 18268, 993, 28m },
                    { 20, 871, 27m, 9682m, 11036m, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 859025, 426, 29m, 1007885, 426, 29m, 0, 0, 0m, 1014935, 443, 24m, 8845, 373, 24m, 60.4m, 8375, 368, 24m, 64m, 429, 31.5m, 53.3m, 2612m, 2489m, 402, 30.7m, 57.1m, 2763m, 2384m, 1912454, 1079, 32m, 737773, 653, 30m, 0, 0, 0m, 12552, 644, -11m, 0, 0, 0m, 232, 993, 36.5m, 25863, 1044, 3m, 18365, 983, 27m },
                    { 21, 955, 20.3m, 9804m, 11413m, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 885934, 414, 26.7m, 1003317, 414, 26.7m, 0, 0, 0m, 1014410, 436, 21m, 9036, 368, 22.9m, 56.2m, 8576, 369, 22.9m, 61.1m, 413, 30.6m, 55.7m, 2845m, 2740m, 382, 29m, 57.9m, 3051m, 2585m, 1954729, 1175, 31m, 799929, 680, 29m, 0, 0, 0m, 12048, 645, -9m, 0, 0, 0m, 3254, 1095, 34m, 27722, 1139, 1m, 17368, 1086, 20.3m },
                    { 22, 900, 20.4m, 9605m, 10951m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 881688, 407, 25.8m, 973243, 407, 25.8m, 0, 0, 0m, 977636, 431, 19.9m, 8774, 365, 24m, 58.9m, 8291, 375, 24m, 63m, 425, 29.8m, 59.9m, 2874m, 2796m, 390, 29.4m, 59.4m, 3061m, 2631m, 1966875, 1150, 31m, 820117, 719, 29m, 0, 0, 0m, 15024, 635, -14m, 0, 0, 0m, 2880, 1083, 34m, 26645, 1128, 11m, 16895, 1075, 20.4m },
                    { 23, 879, 21m, 9546m, 11302m, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 883484, 412, 18.9m, 1027047, 412, 18.9m, 0, 0, 0m, 1012531, 435, 12.9m, 10091, 361, 46.7m, 66.6m, 9677, 361, 46.7m, 69.4m, 429, 25.9m, 57.5m, 2935m, 2732m, 403, 27.2m, 52.6m, 3022m, 2573m, 1954418, 1154, 30m, 833346, 760, 29m, 0, 0, 0m, 13656, 637, -20m, 0, 0, 0m, 15025, 1066, 34.4m, 26650, 1086, 4m, 17789, 1048, 21m },
                    { 24, 816, 23m, 11209m, 12056m, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 829433, 433, 24m, 940590, 433, 24m, 0, 0, 0m, 960443, 459, 17.5m, 10158, 363, 46.1m, 62.6m, 9421, 361, 46.1m, 64.8m, 435, 26m, 59.6m, 2919m, 2805m, 402, 28.1m, 52.6m, 2980m, 2551m, 1952118, 1134, 31m, 812560, 710, 30m, 0, 0, 0m, 15672, 632, -16m, 0, 0, 0m, 3829, 1079, 33m, 29116, 1029, 13m, 18477, 1046, 23m },
                    { 25, 877, 21.7m, 12943m, 11734m, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 831096, 425, 20.2m, 923851, 425, 20.2m, 0, 0, 0m, 946388, 451, 12.9m, 9578, 368, 22.3m, 48.6m, 8599, 364, 22.3m, 54.4m, 409, 22.6m, 57.4m, 3016m, 2852m, 388, 25.5m, 57.4m, 3044m, 2639m, 1955707, 1147, 30m, 805953, 710, 29m, 0, 0, 0m, 14352, 632, -19m, 12312, 454, -19m, 16489, 1092, 32.5m, 32831, 1105, 5m, 18506, 1053, 21.7m },
                    { 26, 1003, 24.5m, 13285m, 11989m, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 868643, 447, 22.1m, 934013, 447, 22.1m, 0, 0, 0m, 961052, 475, 13.3m, 9002, 368, 22m, 54.5m, 8618, 365, 22m, 57.8m, 412, 20.1m, 58.6m, 3073m, 2987m, 386, 26.6m, 56.9m, 3077m, 2670m, 1934729, 1203, 32m, 812697, 691, 29m, 0, 0, 0m, 14496, 631, -22m, 10416, 475, -19m, 12500, 1108, 33.2m, 29638, 1178, 11m, 19626, 1063, 24.5m },
                    { 27, 1003, 25.7m, 13514m, 11061m, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 849986, 436, 23.8m, 905790, 436, 23.8m, 0, 0, 0m, 918830, 465, 16.1m, 8678, 375, 24.5m, 56.3m, 7965, 381, 24.5m, 59.7m, 420, 24.9m, 61.2m, 2964m, 2870m, 389, 28.8m, 59.8m, 3014m, 2643m, 1904849, 1200, 33m, 791723, 683, 31m, 0, 0, 0m, 15096, 636, -20m, 13440, 447, -18.9m, 7048, 1124, 35.4m, 31483, 1164, 14m, 19312, 1068, 25.7m },
                    { 28, 951, 22.8m, 14036m, 11732m, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 795320, 480, 18.2m, 847951, 480, 18.2m, 0, 0, 0m, 903540, 507, 10.7m, 9464, 366, 24m, 53.4m, 8803, 375, 24m, 58.4m, 485, 29.8m, 59.5m, 2954m, 2855m, 395, 28.1m, 56.6m, 3028m, 2643m, 1937655, 1172, 33m, 819515, 696, 30m, 0, 0, 0m, 14640, 618, -24m, 11784, 464, 23.9m, 12262, 1115, 34.5m, 36216, 1115, 13m, 18036, 1047, 22.8m },
                    { 29, 1008, 24.3m, 13947m, 12498m, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 775879, 490, 22.5m, 879488, 490, 22.5m, 0, 0, 0m, 932230, 516, 16m, 9469, 366, 26.3m, 59.7m, 8911, 375, 26.3m, 64m, 429, 29.4m, 60.5m, 3009m, 2819m, 370, 29.2m, 59.4m, 3209m, 2731m, 1973533, 1222, 34m, 824131, 697, 31m, 0, 0, 0m, 14880, 634, -14m, 11880, 459, 12.4m, 9991, 1127, 35.7m, 35114, 1162, 13m, 18036, 1047, 24.3m },
                    { 30, 947, 23m, 12757m, 12770m, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 819082, 457, 21.4m, 910995, 457, 21.4m, 0, 0, 0m, 932344, 403, 13.1m, 8749, 372, 22.2m, 51.7m, 7991, 379, 22.2m, 54.4m, 408, 25.3m, 58.2m, 2982m, 2835m, 377, 26.8m, 58.4m, 3119m, 2628m, 1887465, 1157, 30m, 782414, 719, 29m, 0, 0, 0m, 14640, 625, -19m, 12576, 457, -17.4m, 13929, 1143, 34m, 29696, 1116, 6m, 19403, 1092, 23m },
                    { 31, 878, 24m, 12939m, 14165m, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 795087, 443, 22.2m, 894413, 443, 22.2m, 0, 0, 0m, 910158, 464, 15m, 7807, 389, 23.3m, 51.9m, 7469, 382, 23.3m, 55.5m, 440, 23.2m, 59.4m, 2663m, 2614m, 410, 27m, 58.9m, 2863m, 2416m, 1839322, 1103, 31m, 721658, 698, 29m, 0, 0, 0m, 14736, 631, -16m, 13176, 448, -15m, 5919, 1040, 33m, 24193, 1066, 12m, 20009, 972, 24m }
                });

            migrationBuilder.InsertData(
                table: "DgPgChmkEb",
                columns: new[] { "Id", "ConsDgCb1", "ConsDgCb2", "ConsDgCb3", "ConsDgCb4", "ConsPgGru1", "ConsPgGru2", "Date" },
                values: new object[,]
                {
                    { 1, 9914000m, 10992000m, 0m, 11247000m, 157000m, 197000m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 11686000m, 13793000m, 0m, 14300000m, 225000m, 283000m, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KgChmkEb",
                columns: new[] { "Id", "Consumption", "Date" },
                values: new object[,]
                {
                    { 1, 67531.7866247823m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 69667.8925154352m, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 68953.1712841524m, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 69939.5419027066m, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 72275.0246165528m, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 72612.2070062839m, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 71704.3928671672m, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 69786.2858947427m, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 69032.1577705482m, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 66401.172621294m, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 68165.0878773898m, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 70197.4147692687m, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 69917.682186537m, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 68265.8823294886m, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 68480.7669778473m, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 66966.7467386559m, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 67303.0508169076m, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 67178.5835874m, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 66617.3171970218m, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 66396.7163720362m, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 64503.4995834297m, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 61782.359575544m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 64103.4522248006m, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 63951.8226675738m, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 66027.8105984822m, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 64602.5m, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 64837.0833333333m, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 65119.1666666667m, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 70770.8333333333m, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 67837.9166666667m, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 67909.3055555555m, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OutputMultipliers",
                columns: new[] { "Id", "Cb1", "Cb2", "Cb3", "Cb4", "Cb5", "Cb6", "Cb7", "Cb8", "Date", "Fv", "PKP", "Peka", "Sv" },
                values: new object[] { 1, 10.44m, 12.78m, 0m, 12.81m, 13.33m, 13.33m, 13.33m, 13.28m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.375m, 6.94m, 420m, 1.274m });

            migrationBuilder.InsertData(
                table: "Pressure",
                columns: new[] { "Id", "Date", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 752m },
                    { 2, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 754m },
                    { 3, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 757m },
                    { 4, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 755m },
                    { 5, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 753m },
                    { 6, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 749m },
                    { 7, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 744m },
                    { 8, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 741m },
                    { 9, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 741m },
                    { 10, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 747m },
                    { 11, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 750m },
                    { 12, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 747m },
                    { 13, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 740m },
                    { 14, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 737m },
                    { 15, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 743m },
                    { 16, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 745m },
                    { 17, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 745m },
                    { 18, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 743m },
                    { 19, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 742m },
                    { 20, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 741m },
                    { 21, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 742m },
                    { 22, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 744m },
                    { 23, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 743m },
                    { 24, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 745m },
                    { 25, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 751m },
                    { 26, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 747m },
                    { 27, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 756m },
                    { 28, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 761m },
                    { 29, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 755m },
                    { 30, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 749m },
                    { 31, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 754m }
                });

            migrationBuilder.InsertData(
                table: "Quality",
                columns: new[] { "Id", "Date", "Kc1_A", "Kc1_V", "Kc1_W", "Kc2_A", "Kc2_V", "Kc2_W" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.25m, 28.85m, 8.05m, 10.05m, 28.6m, 8.1m },
                    { 2, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.3m, 28.6m, 7.95m, 10.1m, 28.55m, 8.2m },
                    { 3, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.2m, 28.15m, 8.15m, 10.05m, 28.5m, 8.05m },
                    { 4, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.25m, 28.3m, 8.2m, 10.1m, 28.55m, 8.2m },
                    { 5, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.25m, 28.25m, 8.2m, 10.1m, 28.5m, 8.1m },
                    { 6, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.2m, 28.5m, 8.2m, 10.25m, 28.5m, 7.65m },
                    { 7, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.05m, 28.35m, 7.9m, 9.95m, 28.2m, 7.95m },
                    { 8, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.1m, 27.75m, 8m, 9.85m, 27.8m, 7.95m },
                    { 9, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.15m, 28.35m, 8.2m, 10.05m, 28.2m, 8.05m },
                    { 10, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.45m, 28.7m, 7.4m, 10.1m, 29.05m, 7.45m },
                    { 11, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.3m, 28.75m, 7.7m, 9.85m, 28.7m, 7.45m },
                    { 12, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.35m, 28.35m, 7.95m, 10.3m, 28.8m, 8.1m },
                    { 13, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.55m, 28.95m, 7.9m, 10.15m, 29.05m, 7.75m },
                    { 14, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.05m, 28.95m, 7.85m, 9.75m, 28.25m, 7.7m },
                    { 15, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.25m, 29.3m, 8.55m, 9.85m, 29.35m, 7.95m },
                    { 16, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.4m, 29.35m, 8.5m, 10.4m, 29.85m, 8.6m },
                    { 17, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.3m, 29.05m, 7.8m, 10.25m, 29.05m, 7.45m },
                    { 18, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.4m, 29.6m, 8.2m, 10.4m, 29.7m, 7.95m },
                    { 19, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.4m, 29.85m, 8.05m, 10.35m, 29.3m, 8m },
                    { 20, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.35m, 29.3m, 8.35m, 10.48m, 29.35m, 8.2m },
                    { 21, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.9m, 29.35m, 7.85m, 10m, 29.05m, 8.1m },
                    { 22, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.8m, 29.45m, 8.4m, 10.4m, 29.4m, 8.5m },
                    { 23, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.15m, 29.65m, 7.6m, 9.9m, 29.2m, 7.7m },
                    { 24, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.6m, 29.25m, 8.3m, 9.65m, 28.7m, 8.2m },
                    { 25, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.45m, 29.6m, 8.15m, 10.1m, 29.25m, 8.35m },
                    { 26, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.7m, 29.4m, 8.3m, 9.85m, 29.05m, 8.25m },
                    { 27, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.85m, 29.5m, 7.8m, 10.2m, 29.25m, 8.05m },
                    { 28, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.5m, 29.1m, 8.6m, 10.75m, 28.7m, 8.55m },
                    { 29, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.1m, 28m, 8.05m, 9.95m, 29.05m, 7.85m },
                    { 30, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.5m, 29.3m, 8.1m, 10.5m, 28.95m, 8.2m },
                    { 31, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.95m, 30.05m, 7.9m, 9.85m, 17.7m, 7.95m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Tec",
                columns: new[] { "Id", "Chmk", "Date", "TecNorth", "TecSouth" },
                values: new object[,]
                {
                    { 1, 886.85m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 657.85m, 467.61m },
                    { 2, 919.56m, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 704.9m, 417.24m },
                    { 3, 1112.72m, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 506.14m, 460.66m },
                    { 4, 936.25m, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 652.51m, 466.63m },
                    { 5, 958.7m, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 697.84m, 439.29m },
                    { 6, 1028.13m, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 572.85m, 429m },
                    { 7, 1050.14m, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 557.37m, 466.52m },
                    { 8, 1030.02m, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 566.33m, 437.37m },
                    { 9, 998.41m, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 659.27m, 481.18m },
                    { 10, 874.58m, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 677.99m, 488.14m },
                    { 11, 919.03m, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 673.52m, 424.84m },
                    { 12, 1083.58m, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 396.81m, 426.18m },
                    { 13, 955.35m, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 585.35m, 422.11m },
                    { 14, 852.95m, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 795.92m, 489.72m },
                    { 15, 974.53m, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 676.68m, 471.17m },
                    { 16, 1036.24m, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 570.28m, 421.46m },
                    { 17, 1153.89m, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 573.07m, 358.81m },
                    { 18, 1137.68m, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 608.76m, 365.05m },
                    { 19, 1086.08m, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 573.33m, 356.43m },
                    { 20, 1061.22m, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 609.3m, 349.44m },
                    { 21, 1327.36m, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 450.62m, 338.06m },
                    { 22, 1246.94m, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 504.46m, 377.51m },
                    { 23, 1210.47m, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 523.13m, 399.21m },
                    { 24, 1281.73m, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 343.4m, 420.1m },
                    { 25, 1362.84m, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 383.75m, 403.66m },
                    { 26, 1405.93m, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 389.79m, 403.98m },
                    { 27, 1382.75m, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 409.26m, 405.18m },
                    { 28, 1342.01m, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 407.49m, 409.87m },
                    { 29, 1480.86m, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 499.13m, 217.84m },
                    { 30, 1320.07m, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 784.45m, 265.72m },
                    { 31, 1242.05m, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 570.8m, 241.82m }
                });

            migrationBuilder.InsertData(
                table: "AmmountCb",
                columns: new[] { "Id", "Cb1", "Cb2", "Cb3", "Cb4", "Cb5", "Cb6", "Cb7", "Cb8", "Date", "OutputMultipliersId", "PKP" },
                values: new object[,]
                {
                    { 1, 78, 84, 0, 80, 48, 48, 47, 53, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12 },
                    { 2, 74, 79, 0, 83, 51, 52, 53, 53, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11 },
                    { 3, 72, 79, 0, 79, 51, 51, 56, 56, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11 },
                    { 4, 78, 84, 0, 82, 51, 51, 56, 56, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11 },
                    { 5, 75, 79, 0, 81, 52, 52, 56, 56, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 6, 73, 79, 0, 79, 53, 52, 56, 56, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11 },
                    { 7, 77, 84, 0, 84, 52, 53, 55, 55, new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 8, 75, 79, 0, 79, 53, 52, 54, 54, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 9, 75, 80, 0, 83, 53, 53, 54, 54, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11 },
                    { 10, 74, 81, 0, 77, 50, 51, 54, 53, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 11, 71, 76, 0, 78, 50, 50, 51, 51, new DateTime(2019, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 12, 74, 79, 0, 78, 52, 51, 52, 53, new DateTime(2019, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 13, 74, 80, 0, 85, 50, 51, 56, 57, new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 14, 76, 82, 0, 82, 52, 51, 57, 57, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 15, 77, 86, 0, 82, 54, 54, 54, 54, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 16, 72, 77, 0, 77, 49, 48, 54, 54, new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 17, 74, 82, 0, 81, 54, 54, 54, 54, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 18, 79, 86, 0, 82, 54, 54, 56, 55, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 19, 69, 77, 0, 76, 51, 51, 51, 51, new DateTime(2019, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 20, 72, 78, 0, 77, 52, 53, 54, 54, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 21, 77, 85, 0, 86, 53, 53, 58, 59, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 22, 75, 82, 0, 82, 57, 57, 59, 59, new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 23, 73, 72, 0, 82, 57, 56, 61, 60, new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 24, 76, 85, 0, 82, 57, 58, 62, 63, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 25, 73, 81, 0, 86, 61, 61, 64, 63, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 26, 77, 83, 0, 82, 57, 57, 60, 61, new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 27, 77, 82, 0, 82, 55, 55, 60, 59, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 28, 73, 79, 0, 80, 55, 55, 58, 58, new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 29, 78, 83, 0, 82, 57, 57, 60, 62, new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 30, 69, 75, 0, 76, 52, 52, 55, 55, new DateTime(2019, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 31, 69, 75, 0, 76, 52, 52, 52, 54, new DateTime(2019, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "RoleId" },
                values: new object[] { 1, "AsupAdmin", "55914", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AmmountCb_Date",
                table: "AmmountCb",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AmmountCb_OutputMultipliersId",
                table: "AmmountCb",
                column: "OutputMultipliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Asdue_Date",
                table: "Asdue",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacteristicsDg_Date",
                table: "CharacteristicsDg",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacteristicsKg_Date",
                table: "CharacteristicsKg",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DevicesKip_Date",
                table: "DevicesKip",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DgPgChmkEb_Date",
                table: "DgPgChmkEb",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KgChmkEb_Date",
                table: "KgChmkEb",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputMultipliers_Date",
                table: "OutputMultipliers",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pressure_Date",
                table: "Pressure",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quality_Date",
                table: "Quality",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tec_Date",
                table: "Tec",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmmountCb");

            migrationBuilder.DropTable(
                name: "Asdue");

            migrationBuilder.DropTable(
                name: "CharacteristicsDg");

            migrationBuilder.DropTable(
                name: "CharacteristicsKg");

            migrationBuilder.DropTable(
                name: "DevicesKip");

            migrationBuilder.DropTable(
                name: "DgPgChmkEb");

            migrationBuilder.DropTable(
                name: "KgChmkEb");

            migrationBuilder.DropTable(
                name: "Pressure");

            migrationBuilder.DropTable(
                name: "Quality");

            migrationBuilder.DropTable(
                name: "Tec");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OutputMultipliers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
