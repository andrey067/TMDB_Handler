Este projeto tem por finalidade fazer uma api onde pudesse gerenciar usuario e seus perfis.

Linguagem ultilizada: .Net 6, EFCore, e Sqlite

A api está disponivel em : https://tmdbhandler.herokuapp.com/swagger/index.html

 - End-points:
  * users/createUser - caso não tenha um usuario cadastrado, crie um usuario para ultilizar todos os metodos da api, a senha do usuario e criptografada e salva no banco de dados.
    - por padrão o primeiro perfil que criar será o perfil de administrador.
  * auth/login - ultiliza dois parametro email e senha - a senha é verificada no banco de dados e validada retornando um token;
    - Com o token gerado deve-se clicar em Authorize digitar 'Bearer' espaço e colocar o token, para que os demais metodos sejam liberados;  
  * users/getProfiles - retorna todos os perfis cadastrados no banco de dados;
  * users/addprofile  - adiciona um perfil ao usuario, o perfil deve ser passado como parametro e o id do usuario deve ser passado como parametro;
  * movies/find-all-movies - retorna todas as filmes buscando da api tmdb api;
  * movies/add-movie - adiciona uma novo filme ao perfil do usuario, o id do filme deve ser passado como parametro e o id do usuario deve ser passado como parametro e o profileName que sera o perfil a ser salvo;
  * movies/get-movies-suggested - retorna filmes sugeridos para o usuario, o id do usuario deve ser passado como parametro e o profileName;
  * movies/search-movie - busca o filme texto digitado, ultilizando uma chama para api TMDB;
  * movies/add-watch-list - adiciona um filme a lista de assistir, o id do filme deve ser passado como parametro e o id do usuario deve ser passado como parametro, e o profileName deve ser pasa como parametro;
  * movies/add-watched - adiciona um filme a lista de assistido, o id do filme deve ser passado como parametro e o id do usuario deve ser passado como parametro, e o profileName deve ser pasa como parametro;