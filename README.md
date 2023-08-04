
# Serede.Core

Pacote de projetos padronizados para utilização na criação de API's




## Stack utilizada

**Back-end:** C#
**Ver:** Net6


## Progetos

- Serede.Core.Extensions
- Serede.Core.Models
- Serede.Core.Data



# Serede.Core.Extensions
## Extensions
Extenções para configuração padrão da Api
###  ApiBehaviorExtensionExtension
#### SuppressModelStateInvalid 
Suprime a validação padrão do modelstate do controller
### AppSettingsExtension
#### ConfigureAppSettings 
Configura o carregamento do appsettings baseado na variavel Environment utilizada
### AuthenticationExtension
#### ConfigureAuthentication 
Configura a autenticação utilizando JWT, recebe IdentitySettings como parametro
#### BindIdentitySettings 
Helper para a criação de IdentitySettings utilizando bind do appsettings
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `appSettingsKey`      | `String` | Default 'IdentitySettings' |

```json
    "IdentitySettings": {
        "IdentityServerUrl": "http://identidade",
        "Scopes": [
        "identityManager.api"
        ]
    },
```
### AuthorizationExtensions
#### ConfigureAuthorization 
 Configura a police de escopos requiridos, recebe IdentitySettings como parametro
#### BindIdentitySettings 
Helper para a criação de IdentitySettings utilizando bind do appsettings
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `appSettingsKey`      | `String` | Default 'IdentitySettings' |

```json
    "IdentitySettings": {
        "IdentityServerUrl": "http://identidade",
        "Scopes": [
        "identityManager.api"
        ]
    },
```
### AuthorizationPolicyBuilderExtensions
#### RequireScope 
Estenção complementar utilizada por AuthorizationExtensions
### CorsExtension
#### ConfigureCors
Configuração de cors

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `corsName`      | `String` | Default 'CorsPolicy' |
| `corsSettings`      | `CorsSettings` | Default 'null' |

#### BindCorsSettings 
Helper para a criação de CorsSettings utilizando bind do appsettings
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `appSettingsKey`      | `String` | Default 'CorsSettings' |

```json
    "CorsSettings": {
        "IdentityServerUrl": "http://identidade",
        "Scopes": [
        "identityManager.api"
        ]
    },
```
### SereilogExtension
#### ConfigureSerilog 
Configuração padrão de log baseado no appsettings
```json
    "Serilog": {
        "Using": [ "Serilog.Sinks.File" ],
        "MinimumLevel": {
        "Default": "Information"
        },
        "WriteTo": [
        {
            "Name": "File",
            "Args": {
            "path": "Logs/Identity-.log",
            "rollingInterval": "Day",
            "outputTemplate": "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {CorrelationId} {Level:u3}] {Username} {Message:lj}{NewLine}{Exception}"
            }
        }
        ]
    },
```
### SwaggerExtension
#### ConfigureSwagger
Cofiguração padrão de Swagger
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `info`      | `OpenApiInfo` | Default null |

### Settings
Classes de configurações utilizadas pelas extenções 
#### CorsSettings
#### IdentitySettings
# Serede.Core.Models
## Models
### Model
Model padrão estendendo Notifiable<Notification> para utilização de notificações e validações  

| Atributo   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Notification` | `Notification` | Default 'null' |

## ViewModel
### Query
ViewModel padrão para consultas, possui os parametros padrões para execução das consultas dos repositories.
| Atributo   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Page`      | `int` | Default '0' |
| `Limit`      | `int` | Default '0' |
| `OrderBy`      | `string` | Default '', campo de ordenação |
| `OrderByOrder`      | `string` | Default 'ASC', orientação da ordenação |

### ResultViewModel
Result padrão para api's possui contrutores para tratamento do modelstate tranformando em notificatios disponiveis pela biblioteca flunt

| Atributo   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Data`      | `object` | Default 'null' |
| `Count`      | `int` | Default '0' |
| `Notification` | `Notification` | Default 'null' |


