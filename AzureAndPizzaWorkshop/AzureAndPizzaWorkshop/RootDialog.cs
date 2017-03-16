using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AzureAndPizzaWorkshop
{
    [LuisModel("aa0a4611-115d-488e-a0af-36288e550c35", "d374875c80fe40ff8e7d8a085caeca64")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string intentNotFoundMessage = $"Disculpa, no pude entender tu mensaje.";
            await context.PostAsync(intentNotFoundMessage);
            context.Wait(MessageReceived);
        }

        [LuisIntent("turn_lights_on")]
        public async Task TurnLightsOn(IDialogContext context, LuisResult result)
        {
            string message = $"luces prendidas!";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("set_alarm")]
        public async Task SetAlarm(IDialogContext context, LuisResult result)
        {
            string message = "";
            string time;
            string sound;
            bool soundWasFound = LuisUtils.TryGetSound(result, out sound);
            bool timeWasFound = LuisUtils.TryGetTime(result, out time);

            if (timeWasFound)
            {
                if (soundWasFound)
                {
                    message = $"Alarma para las {time} activada con sonido: {sound}";
                } else
                {
                    message = $"Alarma para las {time} activada, no se ha asignado sonido.";
                }
            } else
            {
                message = $"Debes asignar una hora para colocar la alarma!";
            }

            await context.PostAsync(message);
            context.Wait(MessageReceived);

        }

        [LuisIntent("turn_thermostat")]
        public async Task TurnThermostat(IDialogContext context, LuisResult result)
        {
            string message = "";
            string temperature;
            string offValue;
            bool offOrderWasFound = LuisUtils.TryGetThermostatOff(result, out offValue);
            bool temperatureWasFound = LuisUtils.TryGetTemperature(result, out temperature);

            if (offOrderWasFound)
            {
                message = "Apagando el termostato...";
            } else
            {
                if (temperatureWasFound)
                {
                    message = $"Termostato activo en {temperature} grados.";
                }
                else
                {
                    message = $"Debes decirme un valor de temperatura!";
                }
            }

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

    }
}