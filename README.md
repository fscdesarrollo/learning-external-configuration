# learning-external-configuration
Repository to show external configuration examples for .Net Core based solutions.


Docker

docker run -it --name=spring-cloud-config-server -p 8888:8888 -e SPRING_CLOUD_CONFIG_SERVER_GIT_URI=https://github.com/fscdesarrollo/learning-external-configuration-files hyness/spring-cloud-config-server