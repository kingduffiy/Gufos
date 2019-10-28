Create Database Gufos;

Use Gufos

Create Table tipo_usuario(
	tipo_usuario_id int identity primary key,
	titulo varchar(255) unique not null
);
Create Table usuario(
	usuario_id int identity primary key,
	nome varchar(255) not null,
	email varchar(255) unique not null,
	senha varchar(255) not null,
	tipo_usuario_id int foreign key references tipo_usuario(tipo_usuario_id)
);
Create Table localizacao(
	localizacao_id int identity primary key,
	CNPJ char(14) unique not null,
	razao_social varchar(255) unique not null,
	endereco varchar(255) not null
);
Create Table categoria(
	categoria_id int identity primary key,
	titulo varchar(255) unique not null,
);
create table evento(
	evento_id int identity primary key,
	titulo varchar(255) not null,
	categoria_id int foreign key references categoria(categoria_id),
	acesso_livre bit default(1) not null,
	data_evento datetime not null,
	localizacao_id int foreign key references localizacao(localizacao_id)
);
Create Table presenca(
	presenca_id int identity primary key,
	evento_id int foreign key references evento(evento_id),
	usuario_id int foreign key references usuario(usuario_id),
	presenca_status varchar(255)
);