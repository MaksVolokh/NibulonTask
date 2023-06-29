using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NibulonDAL.Migrations
{
    /// <inheritdoc />
    public partial class FixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tables1");

            migrationBuilder.DropTable(
                name: "Tables2");

            migrationBuilder.DropTable(
                name: "Tables3");

            migrationBuilder.CreateTable(
                name: "GrainElevatorArrivalsTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentCode = table.Column<int>(type: "int", nullable: false),
                    HarvestYear = table.Column<int>(type: "int", nullable: false),
                    Contractor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moisture = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Impurity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Contamination = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrainElevatorArrivalsTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupedDataTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentCode = table.Column<int>(type: "int", nullable: false),
                    HarvestYear = table.Column<int>(type: "int", nullable: false),
                    Contractor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moisture = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Impurity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Contamination = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupedDataTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightedAverageTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentCode = table.Column<int>(type: "int", nullable: false),
                    HarvestYear = table.Column<int>(type: "int", nullable: false),
                    Contractor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageMoisture = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageImpurity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageContamination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Changes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightedAverageTables", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrainElevatorArrivalsTables");

            migrationBuilder.DropTable(
                name: "GroupedDataTables");

            migrationBuilder.DropTable(
                name: "WeightedAverageTables");

            migrationBuilder.CreateTable(
                name: "Tables1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contamination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contractor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentCode = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HarvestYear = table.Column<int>(type: "int", nullable: false),
                    Impurity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moisture = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecordNumber = table.Column<int>(type: "int", nullable: false),
                    UniqueContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contamination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contractor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentCode = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HarvestYear = table.Column<int>(type: "int", nullable: false),
                    Impurity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moisture = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecordNumber = table.Column<int>(type: "int", nullable: false),
                    UniqueContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contamination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contractor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentCode = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HarvestYear = table.Column<int>(type: "int", nullable: false),
                    Impurity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moisture = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UniqueContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables3", x => x.Id);
                });
        }
    }
}
