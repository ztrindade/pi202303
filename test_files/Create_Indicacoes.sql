CREATE TABLE Indicacoes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NomeIndicado VARCHAR(200) NOT NULL,
    TelefoneIndicado VARCHAR(14) NOT NULL,
    IdProcesso INT NOT NULL,
	MatriculaIndicante NVARCHAR(50) NOT NULL,
	Status VARCHAR(20),
	Linkedin VARCHAR(200)
	
	CONSTRAINT fk_Processos
        FOREIGN KEY (IdProcesso)
        REFERENCES Processos(id)
);

