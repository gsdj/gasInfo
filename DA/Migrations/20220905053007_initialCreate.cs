using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DA.Migrations
{
    public partial class initialCreate : Migration
    {
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
                    Kc1_CO2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_CO = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_N2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_H2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_CO2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_CO = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_N2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_H2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true)
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
                    Kc1_O2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_CnHm = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_CH4 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_CO2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_CO = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_N2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_H2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_O2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_CnHm = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_CH4 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_CO2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_CO = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_N2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_H2 = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true)
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
                    Cu1_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cu1_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cu1_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cu2_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cu2_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cu2_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb5_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cb5_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb5_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb5_TempBeforeHeating = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb6_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cb6_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb6_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb6_TempBeforeHeating = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb7_Consumption_Ms = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb7_Consumption_Ks = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb7_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb7_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb7_TempBeforeHeating = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb8_Consumption_Ms = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb8_Consumption_Ks = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Cb8_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb8_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb8_TempBeforeHeating = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Pkc_Consumption_Ms = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Pkc_Consumption_Ks = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: true),
                    Pkc_Pressure = table.Column<int>(type: "int", nullable: true),
                    Pkc_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Uvtp_Consumption = table.Column<int>(type: "int", nullable: true),
                    Uvtp_Pressure = table.Column<int>(type: "int", nullable: true),
                    Uvtp_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Spo_Consumption = table.Column<int>(type: "int", nullable: true),
                    Spo_Pressure = table.Column<int>(type: "int", nullable: true),
                    Spo_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Gsuf45_Consumption = table.Column<int>(type: "int", nullable: true),
                    Gsuf45_Pressure = table.Column<int>(type: "int", nullable: true),
                    Gsuf45_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb1_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cb1_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb1_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb2_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cb2_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb2_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb3_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cb3_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb3_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Cb4_Consumption = table.Column<int>(type: "int", nullable: true),
                    Cb4_Pressure = table.Column<int>(type: "int", nullable: true),
                    Cb4_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Gru1_Consumption = table.Column<int>(type: "int", nullable: true),
                    Gru1_Pressure = table.Column<int>(type: "int", nullable: true),
                    Gru1_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Gru2_Consumption = table.Column<int>(type: "int", nullable: true),
                    Gru2_Pressure = table.Column<int>(type: "int", nullable: true),
                    Gru2_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true),
                    Grp4_Consumption = table.Column<int>(type: "int", nullable: true),
                    Grp4_Pressure = table.Column<int>(type: "int", nullable: true),
                    Grp4_Temperature = table.Column<decimal>(type: "numeric(5,1)", precision: 5, scale: 1, nullable: true)
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
                    ConsDgCb1 = table.Column<int>(type: "int", nullable: false),
                    ConsDgCb2 = table.Column<int>(type: "int", nullable: false),
                    ConsDgCb3 = table.Column<int>(type: "int", nullable: false),
                    ConsDgCb4 = table.Column<int>(type: "int", nullable: false),
                    ConsPgGru1 = table.Column<int>(type: "int", nullable: false),
                    ConsPgGru2 = table.Column<int>(type: "int", nullable: false)
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
                    Consumption = table.Column<decimal>(type: "numeric(17,10)", precision: 17, scale: 10, nullable: false)
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
                    Kc1_W = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_A = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc1_V = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_W = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_A = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true),
                    Kc2_V = table.Column<decimal>(type: "numeric(8,3)", precision: 8, scale: 3, nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "User" });

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
