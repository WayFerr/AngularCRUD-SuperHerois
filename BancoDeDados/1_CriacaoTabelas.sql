
-- Criação da tabela Superpoderes
CREATE TABLE Superpoderes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Superpoder NVARCHAR(50) NOT NULL,
    Descricao NVARCHAR(250) NOT NULL
);

-- Inserção dos superpoderes iniciais
INSERT INTO Superpoderes (Superpoder, Descricao) VALUES
('Força Sobre-Humana', 'Capacidade de exercer força física muito além dos limites humanos.'),
('Voo', 'Habilidade de voar sem ajuda de equipamentos.'),
('Telepatia', 'Capacidade de ler ou comunicar-se com a mente de outras pessoas.'),
('Invisibilidade', 'Capacidade de tornar o corpo invisível à visão humana.'),
('Manipulação do Tempo', 'Habilidade de desacelerar, acelerar ou parar o tempo temporariamente.');

-- Criação da tabela Herois
CREATE TABLE Herois (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(120) NOT NULL,
    NomeHeroi NVARCHAR(120) NOT NULL UNIQUE,
    DataNascimento DATE NOT NULL,
    Altura FLOAT NOT NULL,
    Peso FLOAT NOT NULL
);

-- Criação da tabela de associação HeroisSuperpoderes
CREATE TABLE HeroisSuperpoderes (
    HeroiId INT NOT NULL,
    SuperpoderId INT NOT NULL,
    PRIMARY KEY (HeroiId, SuperpoderId),
    FOREIGN KEY (HeroiId) REFERENCES Herois(Id) ON DELETE CASCADE,
    FOREIGN KEY (SuperpoderId) REFERENCES Superpoderes(Id) ON DELETE CASCADE
);
