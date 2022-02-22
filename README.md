# Fincance Solution

O projeto Finance Solution de principio tem como principal intuito ajudar todos os seus usuarios a terem uma melhor visão financeira. Conseguindo de forma simples, gerenciar o seu dinheiro economizando em diversas pontas.

Tem como um de deus pontos positivos a facilidade de uso, pois possui uma interface simples e intuitiva, permitindo que todos os usuarios possam ter uma melhor visão financeira.

<p align="center"> <img src="Docs/img/login-page.png" style="border-radius: 10px; width: 80%"> </p>

# Desenvolvedores

É Necessario a aqueles que vão trabalhar no projeto, que sigam os passos abaixo para que o o ambiente de desenvolvimento esteja devidamente configurado para uso.

E um dos principais passos para quem usa o prompt de comando, é necessario que o mesmo esteja no diretorio do projeto. `..\FinanceSolution\`.

## Banco de Dados

Todos os comandos que vão ser executados para configurar o banco de dados, devem ser executados no diretorio do projeto Data.
`..\FinanceSolution\FinanceSolution.Data`,

### Comandos para Migration

Para gerar uma nova migration, basta executar o comando:
```
dotnet ef --startup-project ..\FinanceSolution.Inteface migrations add ****
```
Lembrando que é necessario alterar o nome da migration para que ela seja gerada corretamente.

Para remover uma migration, basta executar o comando:
```
dotnet ef --startup-project ..\FinanceSolution.Inteface migrations remove
```
E se for necessario excluir uma migration especifica, basta executar o comando abaixo, trocar os asteristicos por o nome da migration:
```
dotnet ef --startup-project ..\FinanceSolution.Inteface migrations remove ****
```

### Comandos para Banco

Para atualizar o banco de dados utilizando as migrations e tambem o framework `EntityFramework`, basta executar o comando:
```
dotnet ef --startup-project ..\FinanceSolution.Inteface  database update
```
