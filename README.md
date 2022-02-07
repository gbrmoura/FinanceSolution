# Fincance Solution

## Oque é?

Finance Solution é uma pagina web com o intuito de ajudar seus usuarios a terem o controle melhor de sua situação financeira.

Possuindo uma interface simples, e de facil utilização.





## Banco de Dados

Todos os comando que vão ser executados aqui devem primeiro estar no diretorio `..\FinanceSolution\FinanceSolution.Data`, e para chergamos a este diretorio, tendo como base o diretorio pai do projeto, deve-se executar o comando `cd FinanceSoltuion.Data`.


### Comandos para Migration

Para gerar uma migração nova, é necessario o comando `dotnet ef --startup-project ..\FinanceSolution.Inteface migrations add ****`, lembrando que onde se encontra os asteriscos deve ser sempre mudado para o nome da migration. 

Para remover uma migração é necessario executar o comando `dotnet ef --startup-project ..\FinanceSolution.Inteface migrations remove`, para remover uma migration especificar é somente necessario colocar o nome da propria na frente do remove.

### Comandos para Banco

Para atualizar o banco de dados por meio de comandos, usando o entity framework, é necessario somente rodar `dotnet ef --startup-project ..\FinanceSolution.Inteface  database update`.

E caso seja necesserario, é possivel dar drop do banco de dados por comando, `dotnet ef --startup-project ..\FinanceSolution.Inteface database drop`.