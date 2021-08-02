USE Patrimonio_Escolar;


INSERT INTO Sala		(Andar, Nome, Metragem)
VALUES				 ('Primeiro', 'Antonio Valmir', '34,67'),
					 ('Segundo', 'Airton Senna', '38,02'),
					 ('Auditório', 'Luiz Anversa', '45,9')


INSERT INTO Equipamentos(IdSala, Marca, Tipo, Numero_de_Serie, Descricao, Status_)
VALUES				 (1, 'Kodac', 'Eletro', 134343434, 'Datashow', 'Ativo'),
					 (2, 'Smartec', 'Eletro', 234467787, 'Lousa Digital','Inativo'),
					 (3, 'Lenovo', 'Eletro', 98765432, 'Notebook', 'Ativo')

INSERT INTO Usuario(Email, Senha)
VALUES             ('yuri@gmail.com', '1234sapo'),
				   ('maiara@gmail.com', '1234suco')