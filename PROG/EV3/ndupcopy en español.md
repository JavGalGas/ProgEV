# ndupcopy

## Objetivos/Conceptos

El objetivo de esta práctica es que el alumnado sea capaz de crear una herramienta de línea de comandos.

| Dificultad            | Tipo de actividad   |
|-----------------------|---------------------|
| Medio                 | Desarrollo          |

## Introducción

La práctica trata de copiar archivos de una carpeta a otra pero sin copiar archivos duplicados.

## Especificaciones

Se debe crear una herramienta de línea de comandos a la cual se le pasarán una serie de directorios de origen y un directorio de destino. La herramienta deberá explorar todos los archivos de las carpetas de origen (y subcarpetas) y copiarlos a la carpeta de destino. En caso de que se detecte que un archivo ya existe en la carpeta de destino, no se copiará. De esta manera, el efecto será que todos los archivos se copien ignorando los duplicados.

Las carpetas de entrada pueden contener subcarpetas que deben ser recorridas de forma recursiva para buscar todos los archivos.

Para pasar las rutas de las carpetas de origen y destino a la aplicación, se puede optar por una de las siguientes opciones, pero se pueden proponer otras:

- Pasar las rutas de las carpetas como argumentos de línea de comandos.
- Crear archivos que el programa leerá e interpretará. De esta manera, en un archivo de texto, por ejemplo, puede haber una serie de líneas que representen las rutas de las carpetas de origen. Como mínimo, si se considera que recorrer varias carpetas de origen sería una tarea demasiado compleja, se puede usar una sola carpeta de origen y una de destino, con la consiguiente reducción de puntos (3 puntos).

## Restricciones

El programa a desarrollar tiene una serie de requisitos. En caso de incumplimiento de alguno de ellos, la práctica no será corregida.

- Antes de presentar la práctica, es necesario probarla. Para demostrarlo, se debe entregar un archivo zip con varias carpetas para probar el programa. También se debe proporcionar la línea de comandos que se utilizará para probar el programa. Antes de la corrección, esta línea de comandos proporcionada se ejecutará con las carpetas que hay dentro del archivo zip (el cual se descomprimirá, evidentemente).
- El programa debe estar bien estructurado, utilizando funciones y variables con nombres que indiquen claramente para qué sirven.
- Para leer un archivo, no se pueden utilizar instrucciones de nivel superior que lo hagan directamente; se debe utilizar una función que, con un bucle, lea un flujo y lo almacene en un array de bytes.
- Para comparar dos archivos, primero se deben comparar sus hashes. En caso de que los hashes coincidan, entonces sí se compara el contenido del archivo. El hash que se puede utilizar debe ser uno conocido, como MD5 o SHA256.

## Ampliaciones

Opcionalmente, se puede realizar alguna de las siguientes mejoras:

- Se puede utilizar el tamaño del archivo en lugar del hash para determinar si son iguales o no.
- Se puede utilizar un hash del tipo "entero" extraído del propio archivo como paso previo a la comparación de hashes.
- Se puede replicar la estructura de carpetas dentro de las carpetas de origen en la carpeta de destino.
- Se puede generar el hash de manera secuencial sin necesidad de tener todo el archivo en la memoria RAM. Esto, junto con el hecho de no utilizar mucha memoria RAM.
- Si el archivo no tiene un formato de fecha y es de tipo vídeo o imagen, intentar ponerle en el nombre del archivo algo que indique la fecha en que se tomó la posible foto o vídeo.
- Se puede hacer una función para comparar dos archivos que no necesite que el contenido completo de los archivos esté en la RAM para poder compararlos.
