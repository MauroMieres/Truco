# Truco!

Truco es una aplicacion que permite simular partidas de truco (con algunas reglas cambiadas) entre dos jugadores manejados por la CPU, cuyos datos y estadisticas estan almacenados en una base de datos. El programa arranca con ninguna sala creada, a la espera de que el usuario las comience apretando el boton **Crear Partida**, lo cual crea la sala en la que a continuacion tendra a lugar la partida, la misma, se termina cuando uno de los dos jugadores alcance los 15 puntos o lleguen a 4 turnos jugados, en este caso, ganara el jugador con mas puntos, y en caso de empatar tambien  en esto, ganara el jugador que haya sido primero mano.


# Diagrama de clases: 
Todas las clases participantes aparecen en la imagen, no aplique pilar de herencia, pero si aplique el uso de una interfaz generica para la serializadora (serializa los objetos MazoTruco, CantosEnvido, CantosTruco) y el manejador de archivos, el cual guarda el historial de las partidas que no son canceladas en formato txt.
***https://freeimage.host/i/HK6bHj1***

## Funcionamiento y uso de la aplicacion:

Cuando abrimos la aplicacion, primero veremos una pantalla de carga con una barra de progreso, que al llegar al 100%, abrira la ventana del menu principal, donde el usuario ya puede comenzar a interactuar con la misma:
***https://freeimage.host/i/HKP2KkG***
El usuario puede elegir entre silenciar la musica y crear una partida.
El boton **Crear Partida** crea la sala, la agrega al panel verde de la derecha, y habilita el boton **Ver Partida** , el cual nos permitira ver en tiempo real, el historial de la partida ya creada y el desarrollo actual de la misma, tambien permitiendo cancelarla con el boton **Cancelar Partida**, el cual tambien aparece luego de haberse creado al menos una:
**https://freeimage.host/i/HKP2KkGhttps://freeimage.host/i/HKPK5ps**
Una vez que la partida finalice (Por finalizacion de la misma, y no por cancelacion) se abrira automaticamente un formulario con el historial de la partida terminada y el ganador de la misma, indiferentemente de si es una partida que estamos viendo o una que se sigue desarrollando en segundo plano:
**https://freeimage.host/i/HKPKeCQ**


## Caracteristicas de la aplicacion:

- Cuando elegimos una partida para ver,  veremos tambien el historial de jugadas anterior a ser seleccionada la misma.
- Cuando se cancela una partida, la misma sera cancelada al final del turno que esta siendo jugado, la misma, mostrara un mensaje que notifique al usuario que la partida fue cancelada, y al volver a seleccionarla, le indicara que la misma fue cancelada y no se ha guardado su historial.
- No esta aplicada la parda, cuando los jugadores empatan en la primera mano, de asi repetirse en la segunda, gana el jugador que haya sido mano.

## Justificacion tecnica:

**JugadoresDAO:** (SQL)
Esta es la clase que aplica lo visto sobre SQL, consultas y modificaciones de la misma. Su funcion principal es traer los jugadores cargados en la misma y poder actualizar las estadisticas de los mismos.

**Sistema:** (Clase estatica)
Decidi hacer una clase static llamada sistema, la cual seria la encargada de manejar las partidas creadas y las existentes, ya que al intentar crear varias partidas en simultaneo, la base de datos arrojaba errores de conexion, por lo cual decidi que esta clase, haga una copia de los jugadores almacenados, y los administre en tiempo de ejecucion dandoles partidas para jugar, y llamar a la base de datos, solo cuando una partida termine para actualizar la cantidad de victorias del Jugador Ganador.

**IGuardar:** (Interfaces)
Esta es una interfaz generica, el contrato de la misma, es un metodo llamador Guardar, el cual recibe un dato de tipo generico, y el nombre que queramos que tenga el archivo guardado.
Es implementado por la serializadora: se utilizo para guardar el mazo de cartas serializadas, para luego, deserializarlo cuando se necesite un mazo en vez de llamar al constructor del mismo.
Es implementado por el manejador de archivos: recibe un dato de tipo String (el historial de la partida) y lo guarda en txt.

**Sala:** (Cancellation Token)
La clase sala, es la que se encarga de crear el espacio donde se ejecutara luego la task JugarPartida. Cada sala, cuenta con un token de cancelacion, el cual sera pasado como parametro al task correspondiente, para poder cancelarlo en cualquier momento solicitado.

**Partida:** (Tasks, delegados, eventos)
Esta clase es la que contiene la logica del desarrollo de la partida. La misma tiene el metodo JugarPartida, el cual recibe un cancellation token, provisto por la sala que lo creo, de esta forma el control sobre la partida, lo tiene la sala, y no la partida misma. La partida, tiene delegados para poder escribir en el Rich_TxtBox del formulario principal, pero no se suscribe por defecto, para evitar que todas las partidas empiecen a escribir en el mismo al ser creadas, de esta forma, cuando una partida es seleccionada, se utiliza un metodo que las suscribe (recibe el delegado)  y comienza a darle uso.
Cuando una partida termina con un ganador, se arroja el evento en el formulario que muestra la partida con sus datos.

**Serializadora:** (Serializacion xml)
Esta clase se encarga de deserializar los objetos necesarios para el desarrollo de la partida, los mismos son:

- El mazo de cartas.
-  Los cantos del Envido.
-  Los cantos del Truco.

Esta clase cuenta con un metodo que nos devuelve la direccion del archivo solucion del progama, de forma que pude crear las carpetas del archivo en la carpeta raiz.

**Manejador de Archivos:** (Archivos)
Esta clase se encarga de guardar un String en formato txt, en este caso, el historial de las partidas que hayan terminado. Se guardan con el siguiente formato de nombre: Partida_NombreJugador1_NombreJugador2_HoraDePartidaTerminada.txt.
Se guardan en la carpeta, **Partidas Jugadas**, la cual se encuentra en el directorio raiz.

**EntidadesTrucoTests:** (Unit testing)
Esta clase es la encargada de verificar el correcto funcionamiento independiente de cada pequeño metodo usado en la aplicacion. Personalmente, me ayudo al final del trabajo, ya que el metodo calcular envido, generaba un error, que borraba las cartas del jugador, cuando el mismo tenia flor (3 cartas del mismo palo) y haciendo test del mismo, pude corregirlo de forma mas facil.

## Contras:
- No aplique muchas excepciones, y no pude controlar la excepcion que ocurre cuando no se encuentra un jugador libre para crear la partida porque estan todos jugando (Intente catchearla en todas partes y no consegui que el programa no se interrumpiera)
- No se pueden elegir los jugadores, actualmente se eligen al azar, pero me gustaria implementar la opcion de poder elegirlos, considero que se hacerlo pero por cuestiones de tiempo en esta entrega no voy a desarrollarlo.




