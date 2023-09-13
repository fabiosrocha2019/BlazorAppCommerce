# BlazorAppCommerce

Prezados, adicionei os projetos no repositório como solicitado.

No projeto contem um frontend de apenas uma página apenas para que possam fazer os devidos testes.
O projeto está todo em .NET CORE 6 e o foi selecionado o micro ORM Dapper, por justamente ter bastante vivência com o SQL, então utiliza-lo não teria grandes perdas em relação ao Entity Framework neste momento.
Adicionei tambem os testes unitários da classe de validações e que é uma classe que realiza validações mais simples, e tambem adicionei para a classe ProdutoServiceTests.cs
Todos os testes foram realizados utilizando xUnit, pra isso eu fiz um desenvolvimento pensando já em aplicar os testes, coloquei tambem as interfaces para que fosse possível ter uma camada a mais de segurança, e para os testes unitários tambem é mais simples na hora de criar os Mocks quando você tem as interfaces devidamente colocadas, podendo simulá-las sem precisar encher o código com os contrutores das classes.
Está configurado com a ConnectionString corretamente tambem.
Tecnologias:
.NET core 6,
Dapper,
xUnit,
Blazzor,
bootstrap.

Qualquer dúvida que venham a ter, sigo à disposição.
