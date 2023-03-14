# pi202303
Projeto Integrador Senac, entrega em 13/03/2023

O Grupo A03 é composto pelos seguintes alunos:
- Abner Antonio Januário Marcelino
- Heitor Alexandrino dos Santos Arruda
- José Roberto Trindade Lima

## Aplicação estática

Instruções para execução da aplicação estática:
- efetuar o clone do projeto;
- abrir um prompt de comando na pasta 'indica';
- efetuar o comando `npm i`;
- após o fim da execução, efetuar o comando `npm start`;
- após a mensagem de que a aplicação está carregada (console com a mensagem `Compiled successfully`), acessar o link http://localhost:4200/ no navegador.

Se o usuário preferir, pode executar o comando `ng serve --o`, para que o navegador seja acionado automaticamente após o carregamento da aplicação.

O projeto estático contém quatro usuários válidos, conforme descrito na sua página inicial:
- alexandra
- bruna
- danilo (administrador)
- fernanda (administradora)

A senha de todos eles é 'teste'. Se for informado um usuário ou senha incorretos, a aplicação exibirá um alerta de credenciais inválidas.

Os usuários com perfil padrão podem somente indicar candidatos em processos em andamento. Assim, é necessário logar primeiro com o usuário `fernanda`, para iniciar pelo menos um processo. O usuário `fernanda` pode também aceitar indicações feitas pelos demais usuários e encerrar os processos, com ou sem indicações aprovadas.

## API 
Instruções para levantar o servidor para realizar testes:
- faça o dowload do visual studio para rodar o servidor local iis em sua maquina link: https://visualstudio.microsoft.com/pt-br/vs/.
- faça o dowload do sql server management studio para rodar o banco de dados link: https://aka.ms/ssmsfullsetup.
- com os itens anteriores instalados e o projeto clonado em sua maquina, crie um novo banco de dados para teste com o nome a sua escolha.
- em seu banco de dados crie as três tabelas de teste cujos scripts estão na pasta test_files neste projeto.
- crie sua string de conexão e substitua a que esta no appssetings da aplicação ("local").
- após fazer estas configurações, rode o iss local no visual studio e deixe ligado para receber comandos do projeto de front. 

