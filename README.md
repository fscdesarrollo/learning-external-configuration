# learning-external-configuration
Repositorio para mostrar ejemplos de configuración externa para soluciones basadas en .Net Core.

## Frameworks/Tecnologias
 - [x] .Net Core 3.1: https://github.com/reactiveui/refit
 - [x] Spring Cloud Config: https://cloud.spring.io/spring-cloud-config/reference/html/
 - [x] Azure App Configuration: https://github.com/Azure/AppConfiguration
 - [x] Refit: https://github.com/reactiveui/refit
 - [x] Polly: https://github.com/App-vNext/Polly
 - [x] Docker: https://github.com/App-vNext/Polly

### Docker

    docker run -it --name=spring-cloud-config-server -p 8888:8888 -e SPRING_CLOUD_CONFIG_SERVER_GIT_URI=https://github.com/fscdesarrollo/learning-external-configuration-files hyness/spring-cloud-config-server
