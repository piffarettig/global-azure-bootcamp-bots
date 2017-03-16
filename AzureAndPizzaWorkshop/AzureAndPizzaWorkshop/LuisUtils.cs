using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAndPizzaWorkshop
{
    public static class LuisUtils
    {

        public static string Entity_Time = "Time";
        public static string Entity_Sound = "Sound";
        public static string Entity_Temperature = "Temperature";
        public static string Entity_Thermostat_off = "ThermostatOff";

        private static bool TryGetEntityValueFromLuisResult(LuisResult result, out string entityDestination, string entityType)
        {
            entityDestination = string.Empty;
            EntityRecommendation title;
            if (result.TryFindEntity(entityType, out title))
            {
                entityDestination = title.Entity;
                return true;
            }
            return false;
        }

        public static bool TryGetSound(LuisResult result, out string sound)
        {
            return TryGetEntityValueFromLuisResult(result, out sound, Entity_Sound);
        }

        public static bool TryGetTime(LuisResult result, out string time)
        {
            return TryGetEntityValueFromLuisResult(result, out time, Entity_Time);
        }

        public static bool TryGetThermostatOff(LuisResult result, out string off)
        {
            return TryGetEntityValueFromLuisResult(result, out off, Entity_Thermostat_off);
        }

        public static bool TryGetTemperature(LuisResult result, out string temperature)
        {
            return TryGetEntityValueFromLuisResult(result, out temperature, Entity_Temperature);
        }

    }
}
