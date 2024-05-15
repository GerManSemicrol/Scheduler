namespace Negocio.Traducciones
{
    public class TraduccionesENG : Traductor
    {
        protected override void InicializarTraducciones()
        {
            //Descripciones
            traducciones["OccursOnce"] = "Occurs once. Schedule will be used on {0} at {1} starting on {2}";
            traducciones["OccursEveryDayOnce"] = "Occurs every day. Schedule will be used on {0} at {1} starting on {2}";
            traducciones["OccursEveryDayMultiple"] = "Occurs every day. Schedule will be used on {0} between {1} and {2} every {3} hours starting on {4}";
            traducciones["OccursEveryWeekOnce"] = "Occurs every {0} week/s. Schedule will be used on {1} at {2} starting on {3}";
            traducciones["OccursEveryWeekMultiple"] = "Occurs every {0} week/s. Schedule will be used on {1} between {2} and {3} every {4} hours starting on {5}";
            traducciones["OccursEveryMonthOneDayOnce"] = "Occurs on day {0} every {1} month/s. Schedule will be used on day at {2} starting on {3}";
            traducciones["OccursEveryMonthOneDayMultiple"] = "Occurs on day {0} every {1} month/s. Schedule will be used on day between {2} and {3} every {4} hours starting on {5}";
            traducciones["OccursEveryMonthMultipleDaysOnce"] = "Occurs the {0} {1} of every {2} month/s. Schedule will be used on day at {3} starting on {4}";
            traducciones["OccursEveryMonthMultipleDaysMultiple"] = "Occurs the {0} {1} of every {2} month/s. Schedule will be used on day between {3} and {4} every {5} hours starting on {6}";

            // Traducciones de los días de la semana
            traducciones["Lunes"] = "Monday";
            traducciones["Martes"] = "Monday";
            traducciones["Miercoles"] = "Wednesday";
            traducciones["Jueves"] = "Thursday";
            traducciones["Viernes"] = "Friday";
            traducciones["Sabado"] = "Saturday";
            traducciones["Domingo"] = "Sunday";
            traducciones["Dia"] = "Day";
            traducciones["Entre_semana"] = "Weekday";
            traducciones["Fin_de_semana"] = "Weekend";

            // Traducciones de frecuencia del día
            traducciones["Primer"] = "First";
            traducciones["Segundo"] = "Second";
            traducciones["Tercer"] = "Third";
            traducciones["Cuarto"] = "Fourth";
            traducciones["Ultimo"] = "Last";
        }
    }
}
