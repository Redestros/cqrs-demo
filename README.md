# CQRS Demo

This project represents an implementation of Command Query Responsibility Segregation design pattern in ASP.NET Core. It is based on work done by Ali Ashoori in his 
[Meidum article](https://levelup.gitconnected.com/how-to-avoid-fat-controllers-in-asp-net-web-api-net-framework-45acb45ba6f0).

## Example endpoints

+ RegisterClient: Used to register a client from a given command (RegisterClientCommand)
+ UpdateClientInfo: Used to update certain client infos 
+ GetClient: Retrieve client by Id

## Libraries used

+ Autofac
+ Automapper
+ FluentValidation
