# VisioTech
API desarrollada para prueba técnica.
#
Esta APi fue diseñada con Clean Arquitecture y la idea de estructurar el proyecto en capas. Tal vez al ser un proyecto pequeño no hubiese sido necesario aplicar esta arquitectura, pero pensando que la app pudiese ir creciendo y que era necesaria la creación de test, me decanté por esta opcion.

Para mantener el codigo organizado estructuré la API en tres controladores, cada uno con su capa de servicio donde son aplicadas las logicas de negocio y la transformacion de los datos y tambien con su capa de repositorio. 

He seguido los definiciones de la prueba al pie de la letra. No obtante, me gustaria comentar que algunos los metodos HTTP usados en los endpoint no son los correctos (bederian de ser todos GET). 

Para dejar el código menos poluido con continuos try catch, pensé en crear un middleware que envolviese todas las solicitudes en un try. Con esto centralizamos todo el tratamiendo de errores y excepciones en un solo lugar.  
#
Para almacenar los datos usé una base de datos SQL Server y el dockerfile esta configurado para contenedores de Windows.

