
# learning-external-configuration
## Purpose
Implementation of external configuration providers:
 - Spring Cloud Config: https://cloud.spring.io/spring-cloud-config/reference/html/
 - Azure:
	 - Azure App Configuration: https://github.com/Azure/AppConfiguration
	 - Azure Feature Flags: https://docs.microsoft.com/en-us/azure/azure-app-configuration/manage-feature-flags

## Frameworks/Libraries
 - Source Code:
	 - .Net Core 3.1: https://docs.microsoft.com/es-es/dotnet/core/
 - REST:
	 - Refit: https://github.com/reactiveui/refit
 - Resilience and transient-fault-handling:
	 - Polly: https://github.com/App-vNext/Polly
 - Container:
	 - Docker: https://www.docker.com/
	 - Docker Compose: https://docs.docker.com/compose/

### Docker

    docker run -it --name=spring-cloud-config-server -p 8888:8888 -e SPRING_CLOUD_CONFIG_SERVER_GIT_URI=https://github.com/fscdesarrollo/learning-external-configuration-files hyness/spring-cloud-config-server
