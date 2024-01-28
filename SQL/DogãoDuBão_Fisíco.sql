/* DogãoDuBão_Fisíco: */

CREATE TABLE Clientes (
    Id_cliente INT PRIMARY KEY,
    fk_Telefone_Id_Telefone INT,
    fk_Pedidos_Id_pedido INT,
    Nome VARCHAR(100),
    Rua VARCHAR(100),
    CEP VARCHAR(08),
    Numero INT,
    Estado VARCHAR(20),
    Pais VARCHAR(100)
);

CREATE TABLE Pedidos (
    Id_pedido INT PRIMARY KEY,
    Status INT,
    Data_emissao DATE
);

CREATE TABLE TB_produto (
    Id_TB_Produto INT PRIMARY KEY,
    Nome VARCHAR(100),
    Preco FLOAT
);

CREATE TABLE Entregadores (
    Id_entregadores INT PRIMARY KEY,
    Nome VARCHAR(100),
    fk_Entregas_Id_entrega INT
);

CREATE TABLE Entregas (
    Id_entrega INT PRIMARY KEY
);

CREATE TABLE ItensPedidos (
    Id_itensPedidos INT PRIMARY KEY,
    Quantidade INT
);

CREATE TABLE Telefone (
    Id_Telefone INT PRIMARY KEY,
    Telefone VARCHAR(20)
);

CREATE TABLE POSSUI (
    FK_Pedidos_Id_pedido INT,
    FK_ItensPedidos_Id_itensPedidos INT
);

CREATE TABLE POSSUI_Pedidos_TB_produto_Entregadores (
    fk_Pedidos_Id_pedido INT,
    fk_TB_produto_Id_TB_Produto INT,
    fk_Entregadores_Id_entregadores INT
);
 
ALTER TABLE Clientes ADD CONSTRAINT FK_Clientes_2
    FOREIGN KEY (fk_Telefone_Id_Telefone)
    REFERENCES Telefone (Id_Telefone)
    ON DELETE CASCADE;
 
ALTER TABLE Clientes ADD CONSTRAINT FK_Clientes_3
    FOREIGN KEY (fk_Pedidos_Id_pedido)
    REFERENCES Pedidos (Id_pedido)
    ON DELETE RESTRICT;
 
ALTER TABLE Entregadores ADD CONSTRAINT FK_Entregadores_2
    FOREIGN KEY (fk_Entregas_Id_entrega)
    REFERENCES Entregas (Id_entrega)
    ON DELETE RESTRICT;
 
ALTER TABLE POSSUI ADD CONSTRAINT FK_POSSUI_1
    FOREIGN KEY (FK_Pedidos_Id_pedido)
    REFERENCES Pedidos (Id_pedido)
    ON DELETE RESTRICT;
 
ALTER TABLE POSSUI ADD CONSTRAINT FK_POSSUI_2
    FOREIGN KEY (FK_ItensPedidos_Id_itensPedidos)
    REFERENCES ItensPedidos (Id_itensPedidos)
    ON DELETE RESTRICT;
 
ALTER TABLE POSSUI_Pedidos_TB_produto_Entregadores ADD CONSTRAINT FK_POSSUI_Pedidos_TB_produto_Entregadores_1
    FOREIGN KEY (fk_Pedidos_Id_pedido)
    REFERENCES Pedidos (Id_pedido)
    ON DELETE RESTRICT;
 
ALTER TABLE POSSUI_Pedidos_TB_produto_Entregadores ADD CONSTRAINT FK_POSSUI_Pedidos_TB_produto_Entregadores_2
    FOREIGN KEY (fk_TB_produto_Id_TB_Produto)
    REFERENCES TB_produto (Id_TB_Produto)
    ON DELETE NO ACTION;
 
ALTER TABLE POSSUI_Pedidos_TB_produto_Entregadores ADD CONSTRAINT FK_POSSUI_Pedidos_TB_produto_Entregadores_3
    FOREIGN KEY (fk_Entregadores_Id_entregadores)
    REFERENCES Entregadores (Id_entregadores)
    ON DELETE NO ACTION;