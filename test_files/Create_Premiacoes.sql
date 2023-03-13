CREATE TABLE Premiacoes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdProcesso INT NOT NULL,
	IdIndicacao INT NOT NULL,
	ValorPremiacao DECIMAL(10,2) NULL,

	CONSTRAINT fk_Processos_premiacao
	FOREIGN KEY (IdProcesso)
	REFERENCES Processos(id),
	
	CONSTRAINT fk_Indicacoes_premiacao
	FOREIGN KEY (IdIndicacao)
	REFERENCES Indicacoes(id)
);