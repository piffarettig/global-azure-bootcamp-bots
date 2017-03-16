# Azure & Pizza - Workshop (Bot Framework + Cognitive Services)

Workshop para el evento Azure &amp; Pizza llevado a cabo en Montevideo y organizado por Microsoft y Green Blue Technologies

## Objetivo

El objetivo de este workshop es mostrar algunas de las capacidades existentes dentro de Azure como plataforma para construir aplicaciones. Particularmente, quien siga este workshop será introducido en el mundo de los Bots/Chatbots y en cómo estos pueden ser inteligentes a partir del uso de diferentes APIs brindadas por Bing & Microsoft Cognitive Services. Estas, permiten que el desarrollador común pueda acceder a un conjunto de algoritmos trabajados y perfeccionados por expertos de Microsoft, permitiendo realzar nuestras apps y  agregar valor en una enormidad de contextos de aplicación.

## Slides de la presentación

Aquí se adjuntan las slides dadas en el evento que funcionan como introducción y marco teórico de los conceptos a poner en práctica:

- SLIDE COGNITIVE
- SLIDE BOT FR

## Pre-Workshop

### ¿Qué vamos a desarrollar? 

En este workshop construiremos un bot que reconoce imagenes

### ¿Qué tecnologías vemos en este workshop

- Microsoft Bot Framework
- Cognitive Services: LUIS (entendimiento de lenguaje natural) 
- Cognitive Services: 

### Requisitos del workshop

- Microsoft Visual Studio 2015 (Enterprise o Communty)
- .NET Framework VERSION???
- Bot Visual Studio Template - C# [(Descarga aquí)](http://aka.ms/bf-bc-vstemplate)
- Bot Framework Emulator (Mac/Windows) - [(Descarga aquí)](https://emulator.botframework.com/)

## Workshop - Parte 1: Ambiente de desarrollo y fundamentos básicos un bot

1) Agregamos el template de 'Bot Application' a nuestros Templates en Visual Studio. Para ello debemos descrimir el .zip y copiar la carpeta en ```C:\...\Documents\Visual Studio 2015\Templates\ProjectTemplates\Visual C#```

IMAGEN 1

2) Abrimos el Visual Studio y creamos una nueva 'Bot Application', con el nombre y ubicación de destino que queramos.

IMAGEN 2

3) Observar y entender el template y la estructura del proyecto creado. 


IMAGEN 3

¿A qué nos recuerda?


Examinar el siguiente fragmento de código:

```C#
 public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
 {
    if (activity.Type == ActivityTypes.Message)
    {
        ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
        // calculate something for us to return
        int length = (activity.Text ?? string.Empty).Length;

        // return our reply to the user
        Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
        await connector.Conversations.ReplyToActivityAsync(reply);
    }
    else
    {
        HandleSystemMessage(activity);
    }
    var response = Request.CreateResponse(HttpStatusCode.OK);
    return response;
}
```

4) Compilar y ejecutar el proyecto, donde se abrirá una ventana del explorador indicando el puerto en el que nuestro bot está
atendiendo solicitudes

IMAGEN 4

5) Abrimos el Bot Framework Emulator que deberíamos haber descargado previamente, y colocamos la ```Bot url```; es decir el endpoint en el que nuestro bot va a estar esperando recibir los mensajes por parte de los clientes.

Si tu aplicación está corriendo sobre el puerto 12345, entonces tu ```bot url``` quedaría algo así:  ```http://localhost:12345/api/messages```


IMAGEN 5

6) Probamos nuestro bot a través del emulador y vemos lo qué sucede. ¿Qué hay detrás de cada mensaje que enviamos y recibimos mediante el bot?

IMAGEN 6

## Workshop - Parte 2: Reconocimiento de Lenguaje Natural

Para esta parte utilizaremos la herramienta LUIS para que nuestro bot pueda entender las intenciones detrás de los mensajes que enviamos. De esa forma, podemos asignarle un cierto comportamiento o lógica a cada intención.

1) Lo primero que haremos será registrar nuestro modelo de LUIS en el portal brindado por Azure para acceder a dicha funcionalidad. Para ello debemos ingresar a [(luis.ai)](https://www.luis.ai/home/index/) y elegir ```Import App```. De esa forma elegimos el archivo .json que existe en este repositorio y desde el cual importaremos este modelo.

IMAGEN 7


Lo importante a ver aquí es que este modelo fue entrenado por quienes dictan el workshop para ahorrar el tiempo de entrenamiento del mismo. De todas formas, el modelo deberá ser mejorado y reentrenado para resolver ciertos casos que veremos en el workshop.
