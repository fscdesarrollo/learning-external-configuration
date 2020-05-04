# learning-external-configuration
Repositorio para mostrar ejemplos de configuración externa para soluciones basadas en .Net Core.

## Frameworks/Tecnologias
 - .Net Core 3.1: https://docs.microsoft.com/es-es/dotnet/core/
 - Spring Cloud Config: https://cloud.spring.io/spring-cloud-config/reference/html/
 - Azure App Configuration: https://github.com/Azure/AppConfiguration
 - Refit: https://github.com/reactiveui/refit
 - Polly: https://github.com/App-vNext/Polly
 - Docker: https://www.docker.com/
 - Docker Compose: https://docs.docker.com/compose/

### Docker

    docker run -it --name=spring-cloud-config-server -p 8888:8888 -e SPRING_CLOUD_CONFIG_SERVER_GIT_URI=https://github.com/fscdesarrollo/learning-external-configuration-files hyness/spring-cloud-config-server
