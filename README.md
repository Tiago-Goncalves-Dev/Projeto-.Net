# Nome do Projeto

Web App de gestão de reclamações. 

## Tecnologias
- .NET 10
- Razor Pages
- Entity Framework Core

## Features
- Portal de reclamações
- Autenticação
- Validagem de usuario no login e acesso às páginas

## 0.0.1 
- Criado Model e migrations usando o tutorial de aula 
- Planificada a arquitetura do projeto e design

Documentação usada:
Moodle
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-10.0&referrer=grok.com - Identity ( tornar admin )
https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.usermanager-1?view=aspnetcore-10.0 - Validator para Dashboard

Admin user:
    User: Admin@admin.com
    Pass: Admin_123
User user:
    User: Teste_123@gmail.com
    Pass: Teste_123

Criadas na BD ( diretamente ) Autenticação de Admin e usuario ( Apenas a admin é importante )
Criado Validator de tipo de usuario, se for Admin é rederecionado para o Dashboard de Admin
Adicionado validator de identidade ao logar, se tiver role de Admin vai para admin e user para user. 
Alterados Bits and pieces no projeto para ficar mais realista tais como.
    - Botão para voltar no edit.
    - Fechar pedidos pelo admin e inalteraveis pelo user nesse estado
    - Filtragem de vizualização de pedidos por e-mail (os users só podem ver os seus pedidos)
    - etc


## New Features Adionados

- Admin agora pode adiconar produtos ou remover 
- Imagem de User e logo da App adicionadas no projeto exportadas do Figma como SVG
- 
