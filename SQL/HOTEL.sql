-- Criar o banco de dados HOTEL
CREATE DATABASE HOTEL;
DROP DATABASE HOTEL;
USE HOTEL;

-- Tabela de Funcionários
CREATE TABLE Funcionario (
    IdFuncionario INT PRIMARY KEY,
    TipoFuncionario VARCHAR(20) NOT NULL
);

-- Tabela de Tipos de Quarto
CREATE TABLE TipoQuarto (
    IdTipoQuarto INT PRIMARY KEY,
    Descricao VARCHAR(20) NOT NULL
);

-- Tabela de Reservas
CREATE TABLE Reserva (
    IdReserva INT PRIMARY KEY,
    fkFuncionarioIdFuncionario INT,
    fkTipoQuarto INT,
    DTCheckOut DATE NOT NULL,
    DTCheckIn DATE NOT NULL,
    EstadoReserva VARCHAR(20) NOT NULL,
    DataCancelamento DATE,
    CobrancaDiaria FLOAT,
    FOREIGN KEY (fkFuncionarioIdFuncionario) REFERENCES Funcionario (IdFuncionario),
    FOREIGN KEY (fkTipoQuarto) REFERENCES TipoQuarto (IdTipoQuarto)
);

-- Tabela de Quartos
CREATE TABLE Quarto (
    IdQuarto INT PRIMARY KEY,
    fkReservaIdReserva INT NOT NULL,
    SituacaoQuarto BIT NOT NULL,
    fkTipoQuarto INT,
    FOREIGN KEY (fkReservaIdReserva) REFERENCES Reserva (IdReserva),
    FOREIGN KEY (fkTipoQuarto) REFERENCES TipoQuarto (IdTipoQuarto)
);

-- Tabela de Clientes e Contas
CREATE TABLE Cliente_Conta (
    IdCliente INT,
    IdConta INT,
    NomeCliente VARCHAR(100),
    CEPCliente VARCHAR(11),
    RuaCliente VARCHAR(100),
    EmailCliente VARCHAR(20),
    NacionalidadeCliente VARCHAR(20),
    PRIMARY KEY (IdCliente, IdConta)
);

-- Tabela de Telefones
CREATE TABLE Telefone (
    IdTelefone INT PRIMARY KEY,
    fkClienteContaIdCliente INT,
    fkClienteContaIdConta INT, 
    TipoTelefone VARCHAR(20),
    NumeroTelefone VARCHAR(11),
    FOREIGN KEY (fkClienteContaIdCliente, fkClienteContaIdConta) REFERENCES Cliente_Conta (IdCliente, IdConta)
);

-- Tabela de Cliente_Reserva (Associativa)
CREATE TABLE Cliente_Reserva (
    IdCliente INT,
    IdConta INT,
    fkReservaIdReserva INT,
    PRIMARY KEY (IdCliente, IdConta, fkReservaIdReserva),
    FOREIGN KEY (IdCliente, IdConta) REFERENCES Cliente_Conta (IdCliente, IdConta),
    FOREIGN KEY (fkReservaIdReserva) REFERENCES Reserva (IdReserva) ON DELETE CASCADE
);

-- Tabela de Pagamentos
CREATE TABLE Pagamento (
    IdPagamento INT PRIMARY KEY,
    TipoPagamento VARCHAR(20)
);

-- Tabela EFETUA para representar pagamentos
CREATE TABLE EFETUA (
    fkClienteContaIdCliente INT,
    fkClienteContaIdConta INT,
    fkPagamentoIdPagamento INT,
    DataPagamento DATE,
    PRIMARY KEY (fkClienteContaIdCliente, fkClienteContaIdConta, fkPagamentoIdPagamento),
    FOREIGN KEY (fkClienteContaIdCliente, fkClienteContaIdConta) REFERENCES Cliente_Conta (IdCliente, IdConta),
    FOREIGN KEY (fkPagamentoIdPagamento) REFERENCES Pagamento (IdPagamento)
);

-- Inserção de dados na tabela Funcionario
INSERT INTO Funcionario (IdFuncionario, TipoFuncionario)
VALUES
(1, 'Atendente'),
(2, 'Gerente'),
(3, 'Limpeza'),
(4, 'Lavanderia'),
(5, 'Cozinha');

-- Inserção de dados na tabela TipoQuarto
INSERT INTO TipoQuarto (IdTipoQuarto, Descricao)
VALUES
(1, 'Solteiro'),
(2, 'Casal'),
(3, 'Família'),
(4, 'Presidencial');

-- Inserção de dados na tabela Pagamento
INSERT INTO Pagamento (IdPagamento, TipoPagamento)
VALUES
(1, 'Dinheiro'),
(2, 'Pix'),
(3, 'Cartão de Crédito'),
(4, 'Cartão de Débito');

-- Inserção de dados na tabela Cliente_Conta
INSERT INTO Cliente_Conta (IdCliente, IdConta, NomeCliente, CEPCliente, RuaCliente, EmailCliente, NacionalidadeCliente)
VALUES
(1, 101, 'João Silva', '12345-678', 'Rua A', 'joao@email.com', 'Brasileiro'),
(2, 102, 'Maria Oliveira', '54321-876', 'Rua B', 'maria@email.com', 'Brasileira'),
(3, 103, 'Carlos Souza', '98765-432', 'Rua C', 'carlos@email.com', 'Brasileiro');

-- Inserção de dados na tabela Telefone
INSERT INTO Telefone (IdTelefone, fkClienteContaIdCliente, fkClienteContaIdConta, TipoTelefone, NumeroTelefone)
VALUES
(1, 1, 101, 'Celular', '123456789'),
(2, 2, 102, 'Fixo', '987654321'),
(3, 3, 103, 'Celular', '999888777');

-- Inserção de dados na tabela Reserva
INSERT INTO Reserva (IdReserva, fkFuncionarioIdFuncionario, fkTipoQuarto, DTCheckOut, DTCheckIn, EstadoReserva, DataCancelamento, CobrancaDiaria)
VALUES
(1, 1, 1, '2024-01-31', '2024-01-28', 'Ativa', NULL, 150.00),
(2, 2, 2, '2024-02-10', '2024-02-05', 'Ativa', NULL, 200.00),
(3, 3, 3, '2024-03-15', '2024-03-10', 'Ativa', NULL, 250.00);

-- Inserção de dados na tabela Cliente_Reserva
INSERT INTO Cliente_Reserva (IdCliente, IdConta, fkReservaIdReserva)
VALUES
(1, 101, 1),
(2, 102, 2),
(3, 103, 3);

-- Obter a lista de funcionários do hotel para fins de contato ou feedback.
SELECT IdFuncionario, TipoFuncionario
FROM Funcionario;

-- Obter informações detalhadas sobre um cliente específico.
SELECT NomeCliente, CEPCliente, RuaCliente, EmailCliente, NacionalidadeCliente
FROM Cliente_Conta
WHERE IdCliente = '1';

-- Obter as informações das reservas de um cliente específico
SELECT Reserva.IdReserva, Reserva.DTCheckIn, Reserva.DTCheckOut, Reserva.EstadoReserva, Reserva.CobrancaDiaria
FROM Reserva, Cliente_Reserva
WHERE Reserva.IdReserva = Cliente_Reserva.fkReservaIdReserva
AND Cliente_Reserva.IdCliente = '1';

-- Segunda parta exercício hotel

CREATE TABLE Filial(

Id_filial INT PRIMARY KEY,
Nome VARCHAR(100),
CEPFilial VARCHAR(11),
RuaFilial VARCHAR(100),
Quantidade_estrelas INT,
Numero_quartos INT,

);

ALTER TABLE Quarto ADD fk_id_filial INT;
ALTER TABLE Quarto ADD CONSTRAINT fk_id_filial FOREIGN KEY (fk_id_filial) REFERENCES Filial(Id_filial); 

ALTER TABLE TipoQuarto ADD Capacidade INT;
ALTER TABLE TipoQuarto ADD CapacidadeOpcional BIT;

INSERT INTO Funcionario (IdFuncionario, TipoFuncionario)
VALUES
(6, 'Diretor'),
(7, 'Contabilidade'),
(8, 'Lavanderia');

CREATE TABLE Servicos(

Id_servico INT IDENTITY(1,1) PRIMARY KEY,
Descricao VARCHAR(100),
Valor	FLOAT,
fk_id_filial INT,
CONSTRAINT fk_servicos_id_filial FOREIGN KEY (fk_id_filial) REFERENCES Filial(Id_filial)
);

CREATE TABLE Restaurante(

Id_restaurante INT IDENTITY(1,1) PRIMARY KEY,
Local_consumo VARCHAR(20),
Descricao VARCHAR(100),
Valor FLOAT,
fk_id_filial INT,
CONSTRAINT fk_restaurante_id_filial FOREIGN KEY (fk_id_filial) REFERENCES Filial(Id_filial)
);

CREATE TABLE Frigobar(

Id_frigobar INT IDENTITY(1,1) PRIMARY KEY,
Descricao VARCHAR(100),
Valor FLOAT,
fk_id_filial INT,
CONSTRAINT fk_frigobar_id_filial FOREIGN KEY (fk_id_filial) REFERENCES Filial(Id_filial)
);

CREATE TABLE Consumo(

Id_consumo INT IDENTITY(1,1) PRIMARY KEY,
fk_frigobar INT,
fk_restaurante INT,
fk_servico INT,
fkClienteContaIdConta INT,
fkClienteContaIdCliente INT,
CONSTRAINT fk_servico FOREIGN KEY (fk_servico) REFERENCES Servicos(Id_servico),
CONSTRAINT fk_restaurante FOREIGN KEY(fk_restaurante) REFERENCES Restaurante(Id_restaurante),
CONSTRAINT fk_frigobar FOREIGN KEY (fk_frigobar) REFERENCES Frigobar(Id_frigobar),
CONSTRAINT fk_consumo_cliente FOREIGN KEY (fkClienteContaIdCliente, fkClienteContaIdConta) REFERENCES Cliente_Conta (IdCliente, IdConta)
);

INSERT INTO Filial VALUES(1, 'NIPO', '01020304-01','Rua Nipo Calvacante',4,20);
INSERT INTO Filial VALUES(2, 'San Juan', '02030405-06','Rua 7 de Setembro',3,50);
INSERT INTO Filial VALUES(3, 'BRISTOL', '03040506-07','Rua Cajuro',5,10);

INSERT INTO Restaurante VALUES('Restaurante','Hamburger', 19.90, 1);
INSERT INTO Restaurante VALUES('Quarto','Suco de Laranja', 8.00, 2); 
INSERT INTO Restaurante VALUES('Restaurante','Macarrao', 22.50, 3);

INSERT INTO Frigobar VALUES('Coca-cola', 5.90, 1);
INSERT INTO Frigobar VALUES('Água', 2.90, 2);
INSERT INTO Frigobar VALUES('Suco de Uva', 10.00, 3);

INSERT INTO Servicos VALUES('Lavar e passar terno', 59.90, 1);
INSERT INTO Servicos VALUES('Lavar e passar vestido', 22.50, 2);
INSERT INTO Servicos VALUES('Lavar e passar camisa social', 40.00, 3);

INSERT INTO Consumo VALUES(1,2,1,101,1);
INSERT INTO Consumo VALUES(2,3,3,102,2);
INSERT INTO Consumo VALUES(3,2,2,103,3);

-- Obter o consumo do cliente para o funcionario

SELECT c.NomeCliente, * FROM Cliente_Conta c JOIN Consumo com ON c.IdCliente = com.fkClienteContaIdCliente

SELECT c.NomeCliente, r.Descricao, r.Valor, f.Descricao, f.Valor, s.Descricao, s.Valor 
FROM Cliente_Conta c, Restaurante r, Frigobar f, Servicos s, Consumo con WHERE c.IdCliente = con.fkClienteContaIdCliente 
AND con.fk_restaurante = r.Id_restaurante AND con.fk_frigobar = f.Id_frigobar AND con.fk_servico = s.Id_servico AND con.fkClienteContaIdCliente = 1

-- Obter as informações de uma Filial em especifico e retornar os seus serviços para um cliente

SELECT f.Nome, s.Descricao, s.valor FROM Filial f JOIN Servicos s ON f.id_filial = s.fk_id_filial WHERE f.Id_filial = 1