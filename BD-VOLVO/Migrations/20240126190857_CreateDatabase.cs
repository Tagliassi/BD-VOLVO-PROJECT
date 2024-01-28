using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BD_VOLVO.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteContas",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CEPCliente = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    RuaCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NacionalidadeCliente = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteContas", x => new { x.IdCliente, x.IdConta });
                });

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    IdFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CEPFilial = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    RuaFilial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantidadeEstrelas = table.Column<int>(type: "int", nullable: false),
                    NumeroQuartos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.IdFilial);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoFuncionario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPagamento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.IdPagamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuartos",
                columns: table => new
                {
                    IdTipoQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    CapacidadeOpcional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuartos", x => x.IdTipoQuarto);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    IdTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkClienteContaIdCliente = table.Column<int>(type: "int", nullable: false),
                    fkClienteContaIdConta = table.Column<int>(type: "int", nullable: false),
                    TipoTelefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.IdTelefone);
                    table.ForeignKey(
                        name: "FK_Telefones_ClienteContas_fkClienteContaIdCliente_fkClienteContaIdConta",
                        columns: x => new { x.fkClienteContaIdCliente, x.fkClienteContaIdConta },
                        principalTable: "ClienteContas",
                        principalColumns: new[] { "IdCliente", "IdConta" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frigobares",
                columns: table => new
                {
                    IdFrigobar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkFrigobarIdFilial = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigobares", x => x.IdFrigobar);
                    table.ForeignKey(
                        name: "FK_Frigobares_Filiais_fkFrigobarIdFilial",
                        column: x => x.fkFrigobarIdFilial,
                        principalTable: "Filiais",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    IdRestaurante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkRestauranteIdFilial = table.Column<int>(type: "int", nullable: false),
                    LocalConsumo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.IdRestaurante);
                    table.ForeignKey(
                        name: "FK_Restaurantes_Filiais_fkRestauranteIdFilial",
                        column: x => x.fkRestauranteIdFilial,
                        principalTable: "Filiais",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkServicoIdFilial = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servicos_Filiais_fkServicoIdFilial",
                        column: x => x.fkServicoIdFilial,
                        principalTable: "Filiais",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Efetua",
                columns: table => new
                {
                    fkClienteContaIdCliente = table.Column<int>(type: "int", nullable: false),
                    fkClienteContaIdConta = table.Column<int>(type: "int", nullable: false),
                    fkPagamentoIdPagamento = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efetua", x => new { x.fkClienteContaIdCliente, x.fkClienteContaIdConta, x.fkPagamentoIdPagamento });
                    table.ForeignKey(
                        name: "FK_Efetua_ClienteContas_fkClienteContaIdCliente_fkClienteContaIdConta",
                        columns: x => new { x.fkClienteContaIdCliente, x.fkClienteContaIdConta },
                        principalTable: "ClienteContas",
                        principalColumns: new[] { "IdCliente", "IdConta" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Efetua_Pagamentos_fkPagamentoIdPagamento",
                        column: x => x.fkPagamentoIdPagamento,
                        principalTable: "Pagamentos",
                        principalColumn: "IdPagamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkFuncionarioIdFuncionario = table.Column<int>(type: "int", nullable: false),
                    fkTipoQuarto = table.Column<int>(type: "int", nullable: false),
                    DTCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DTCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoReserva = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataCancelamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CobrancaDiaria = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Funcionarios_fkFuncionarioIdFuncionario",
                        column: x => x.fkFuncionarioIdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_TipoQuartos_fkTipoQuarto",
                        column: x => x.fkTipoQuarto,
                        principalTable: "TipoQuartos",
                        principalColumn: "IdTipoQuarto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    IdConsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkFrigobar = table.Column<int>(type: "int", nullable: true),
                    fkRestaurante = table.Column<int>(type: "int", nullable: true),
                    fkServico = table.Column<int>(type: "int", nullable: true),
                    fkClienteContaIdCliente = table.Column<int>(type: "int", nullable: false),
                    fkClienteContaIdConta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.IdConsumo);
                    table.ForeignKey(
                        name: "FK_Consumos_ClienteContas_fkClienteContaIdCliente_fkClienteContaIdConta",
                        columns: x => new { x.fkClienteContaIdCliente, x.fkClienteContaIdConta },
                        principalTable: "ClienteContas",
                        principalColumns: new[] { "IdCliente", "IdConta" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumos_Frigobares_fkFrigobar",
                        column: x => x.fkFrigobar,
                        principalTable: "Frigobares",
                        principalColumn: "IdFrigobar");
                    table.ForeignKey(
                        name: "FK_Consumos_Restaurantes_fkRestaurante",
                        column: x => x.fkRestaurante,
                        principalTable: "Restaurantes",
                        principalColumn: "IdRestaurante");
                    table.ForeignKey(
                        name: "FK_Consumos_Servicos_fkServico",
                        column: x => x.fkServico,
                        principalTable: "Servicos",
                        principalColumn: "IdServico");
                });

            migrationBuilder.CreateTable(
                name: "ClienteReservas",
                columns: table => new
                {
                    FkIdCliente = table.Column<int>(type: "int", nullable: false),
                    FkIdConta = table.Column<int>(type: "int", nullable: false),
                    fkReservaIdReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteReservas", x => new { x.FkIdCliente, x.FkIdConta, x.fkReservaIdReserva });
                    table.ForeignKey(
                        name: "FK_ClienteReservas_ClienteContas_FkIdCliente_FkIdConta",
                        columns: x => new { x.FkIdCliente, x.FkIdConta },
                        principalTable: "ClienteContas",
                        principalColumns: new[] { "IdCliente", "IdConta" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteReservas_Reservas_fkReservaIdReserva",
                        column: x => x.fkReservaIdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    IdQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkReservaIdReserva = table.Column<int>(type: "int", nullable: false),
                    fkTipoQuarto = table.Column<int>(type: "int", nullable: false),
                    fkIdFilial = table.Column<int>(type: "int", nullable: false),
                    SituacaoQuarto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.IdQuarto);
                    table.ForeignKey(
                        name: "FK_Quartos_Filiais_fkIdFilial",
                        column: x => x.fkIdFilial,
                        principalTable: "Filiais",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quartos_Reservas_fkReservaIdReserva",
                        column: x => x.fkReservaIdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quartos_TipoQuartos_fkTipoQuarto",
                        column: x => x.fkTipoQuarto,
                        principalTable: "TipoQuartos",
                        principalColumn: "IdTipoQuarto",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteReservas_fkReservaIdReserva",
                table: "ClienteReservas",
                column: "fkReservaIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_fkClienteContaIdCliente_fkClienteContaIdConta",
                table: "Consumos",
                columns: new[] { "fkClienteContaIdCliente", "fkClienteContaIdConta" });

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_fkFrigobar",
                table: "Consumos",
                column: "fkFrigobar");

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_fkRestaurante",
                table: "Consumos",
                column: "fkRestaurante");

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_fkServico",
                table: "Consumos",
                column: "fkServico");

            migrationBuilder.CreateIndex(
                name: "IX_Efetua_fkPagamentoIdPagamento",
                table: "Efetua",
                column: "fkPagamentoIdPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Frigobares_fkFrigobarIdFilial",
                table: "Frigobares",
                column: "fkFrigobarIdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_fkIdFilial",
                table: "Quartos",
                column: "fkIdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_fkReservaIdReserva",
                table: "Quartos",
                column: "fkReservaIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_fkTipoQuarto",
                table: "Quartos",
                column: "fkTipoQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_fkFuncionarioIdFuncionario",
                table: "Reservas",
                column: "fkFuncionarioIdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_fkTipoQuarto",
                table: "Reservas",
                column: "fkTipoQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_fkRestauranteIdFilial",
                table: "Restaurantes",
                column: "fkRestauranteIdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_fkServicoIdFilial",
                table: "Servicos",
                column: "fkServicoIdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_fkClienteContaIdCliente_fkClienteContaIdConta",
                table: "Telefones",
                columns: new[] { "fkClienteContaIdCliente", "fkClienteContaIdConta" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteReservas");

            migrationBuilder.DropTable(
                name: "Consumos");

            migrationBuilder.DropTable(
                name: "Efetua");

            migrationBuilder.DropTable(
                name: "Quartos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Frigobares");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "ClienteContas");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "TipoQuartos");
        }
    }
}
