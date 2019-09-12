USE T_OpFlix

SELECT * FROM Categoria 
INSERT INTO Categoria (Nome) VALUES ('Ação') 
								   ,('Horror')
								   ,('Investigação')
								   ,('Animação');

DELETE FROM Categoria
WHERE IdCategoria = 8

SELECT * FROM TipoUsuario
INSERT INTO TipoUsuario (Tipo) VALUES ('ADMINISTRAÇÃO')
									 ,('CLIENTE');

UPDATE TipoUsuario
SET Tipo = 'ADMINISTRADOR'
WHERE Tipo = 'ADMINISTRAÇÃO'


SELECT * FROM Identificacao
INSERT INTO Identificacao(Nome) VALUES ('Filme')
									  ,('Série');


SELECT * FROM Plataforma
INSERT INTO Plataforma(Nome) VALUES ('NetFlx');





SELECT * FROM Classificacao
INSERT INTO Classificacao (Classificacao) VALUES ('L'), ('10'), ('12'), ('14'), ('16'), ('+18');


SELECT * FROM usuario
INSERT INTO Usuario (Nome, Email, Senha, IdTipo) VALUES ('Erik', 'erik@email.com', '123456', 1)
														,('Cassiana', 'cassiana@email.com', '123456', 1)
														,('Helena', 'helena@email.com', '123456', 2)
														,('Roberto', 'rob@email.com', '3110', 2);
delete Usuario
where IdUsuario = '12'


SELECT * FROM FilmeSeries
INSERT INTO FilmeSeries (Titulo, Sinopse, TempoDuracao, DataLancamento, Veiculo, IdCategoria, IdClassificacao, IdIdentificacao, IdPlataforma)
	VALUES ('O Rei Leão', 'O Rei Leão, da Disney, dirigido por Jon Favreau, retrata uma jornada pela savana africana, onde nasce o futuro rei da Pedra do Reino, Simba. O pequeno leão que idolatra seu pai, o rei Mufasa, é fiel ao seu destino de assumir o reinado. Mas nem todos no reino pensam da mesma maneira. Scar, irmão de Mufasa e ex-herdeiro do trono, tem seus próprios planos. A batalha pela Pedra do Reino é repleta de traição, eventos trágicos e drama, o que acaba resultando no exílio de Simba. Com a ajuda de dois novos e inusitados amigos, Simba terá que crescer e voltar para recuperar o que é seu por direito', '118', '18/07/2019', 'Cinema', 1, 1, 1, 1)
	,('La Casa De Papel 3 temp', 'Oito habilidosos ladrões se trancam na Casa da Moeda da Espanha com o ambicioso plano de realizar o maior roubo da história e levar com eles mais de 2 bilhões de euros. Para isso, a gangue precisa lidar com as dezenas de pessoas que manteve como refém, além dos agentes da força de elite da polícia, que farão de tudo para que a investida dos criminosos fracasse.',	'650', '19/07/2019', 'NetFlix',	2, 5, 2, 1)
	,('Deuses Americanos', 'Shadow Moon é um ex-vigarista que serve como segurança e companheiro de viagem para o Sr. Wednesday, um homem fraudulento que é, na verdade, um dos velhos deuses, e está na Terra em uma missão: reunir forças para lutar contra as novas entidades.', '620', '30/04/2017', 'Prime Video',	3, 6, 2, 1)
	,('Toy Story 4', 'Woody sempre teve certeza sobre o seu lugar no mundo e que sua prioridade é cuidar de sua criança, seja Andy ou Bonnie. Mas quando Bonnie adiciona um relutante novo brinquedo chamado Garfinho ao seu quarto, uma aventura na estrada ao lado de velhos e novos amigos mostrará a Woody quão grande o mundo pode ser para um brinquedo.', '100',	'20/06/2019', 'Cinema', 4, 1, 1, 1)

DELETE FilmeSeries  
WHERE IdFS = 1

INSERT INTO FilmeSeries (Titulo, Sinopse, TempoDuracao, DataLancamento, Veiculo, IdCategoria, IdClassificacao, IdIdentificacao, IdPlataforma)
values ('La Casa De Papel 3 temp', 'Oito habilidosos ladrões se trancam na Casa da Moeda da Espanha com o ambicioso plano de realizar o maior roubo da história e levar com eles mais de 2 bilhões de euros. Para isso, a gangue precisa lidar com as dezenas de pessoas que manteve como refém, além dos agentes da força de elite da polícia, que farão de tudo para que a investida dos criminosos fracasse.',	'650', '19/07/2019', 'NetFlix',	1, 1, 1, 1)
--Desafios--


--- Incluir uma imagem para cada usuário cadastrado;
ALTER TABLE Usuario ADD Foto IMAGE;
SELECT * FROM Usuario
INSERT INTO Usuario (Nome, Email, Senha, IdTipo, Foto) VALUES ('Erik', 'erik@email.com', '123456', 1, 'Foto_1.jpeg')
														,('Cassiana', 'cassiana@email.com', '123456', 1, 'Foto_2.jpeg')
														,('Helena', 'helena@email.com', '123456', 2, 'Foto_3.jpeg')
														,('Roberto', 'rob@email.com', '3110', 2, 'Foto_4.jpeg');


-- Atualizar o usuário Helena para administrador;
SELECT * FROM Usuario

UPDATE Usuario
SET IdTipo = 1
WHERE IdUsuario = 17

--- Alterar La Casa De Papel 3 temp para La Casa De Papel - 3º Temporada;
SELECT * FROM FilmeSeries

UPDATE FilmeSeries
SET Titulo = 'La Casa De Papel - 3º Temporada'
WHERE Titulo = 'La Casa De Papel 3 temp'

--- Atualizar data de lançamento do filme O Rei Leão para a data de lançamento da animação original, 08/07/1994, e alterar veiculo para VHS;
SELECT * FROM FilmeSeries

UPDATE FilmeSeries
SET DataLancamento = '08/07/1994'
WHERE Titulo = 'O Rei Leão'

UPDATE FilmeSeries
SET Veiculo = 'VHS'
WHERE TITULO = 'O Rei Leão'

--- Inserir 3 filmes que estão atualmente no cinema;
SELECT * FROM FilmeSeries

INSERT INTO FilmeSeries (Titulo, Sinopse, TempoDuracao, DataLancamento, Veiculo, IdCategoria, IdClassificacao, IdIdentificacao)
	VALUES ('Annabelle 3: De Volta Para Casa', 'Os investigadores paranormais Ed e Lorraine Warren mantêm a boneca Annabelle trancada em uma sala de artefatos em sua casa. No entanto, em uma noite terrível, Annabelle desperta outros espíritos malignos e ameaça a jovem filha do casal e suas amigas.', '106', '26/06/2019', 'Cinema', '2', '4', '1')
		  ,('Homem-Aranha: Longe de Casa', 'Peter Parker está em uma viagem de duas semanas pela Europa, ao lado de seus amigos de colégio, quando é surpreendido pela visita de Nick Fury. Convocado para mais uma missão heróica, ele precisa enfrentar vários vilões que surgem em cidades-símbolo do continente, como Londres, Paris e Veneza, e também a aparição do enigmático Mysterio.', '130', '04/07/2019', 'Cinema', '10', '2', '1')
		  ,('Turma Da Monica - Laços', 'Floquinho, o cachorro do Cebolinha, desapereceu. Ele desenvolve um plano infalível para resgatar o cãozinho, mas para isso vai precisar da ajuda de seus fieis amigos: Mônica, Magali e Cascão. Juntos, eles irão enfrentar desafios e viver grandes aventuras para levar Floquinho de volta para casa.', '96', '07/06/2019', 'Cinema', '4', '1', '1')




--- Inserir as categorias: Terror, Ação, Comédia, Documentário, Drama e Ficção Científica.
SELECT * FROM Categoria

INSERT INTO Categoria (Nome) VALUES ('Terror'), ('Ação'), ('Documetário'), ('Drama'), ('Ficção Científica')



