namespace Negocio.Traducciones
{
    public class TraduccionesESP : Traductor
    {
        protected override void InicializarTraducciones()
        {
            //Descripciones
            traducciones["OccursOnce"] = "Ocurre una vez. El programador se utilizará el {0} a las {1} a partir del {2}";
            traducciones["OccursEveryDayOnce"] = "Ocurre diariamente. El programador se utilizará el {0} a las {1} a partir del {2}";
            traducciones["OccursEveryDayMultiple"] = "Ocurre diariamente. El programador se utilizará el {0} desde las {1} a las {2} cada {3} horas a partir del {4}";
            traducciones["OccursEveryWeekOnce"] = "Ocurre cada {0} semana/s. El programador se utilizará el {1} a las {2} a partir del {3}";
            traducciones["OccursEveryWeekMultiple"] = "Ocurre cada {0} semana/s. El programador se utilizará el {1} desde las {2} a las {3} cada {4} horas a partir del {5}";
            traducciones["OccursEveryMonthOneDayOnce"] = "Ocurre el día {0} cada {1} meses. El programador se utilizará una vez al día a las {2} a partir del {3}";
            traducciones["OccursEveryMonthOneDayMultiple"] = "Ocurre el día {0} cada {1} meses. El programador se utilizará entre las {2} y las {3} cada {4} hora/s a partir del {5}";
            traducciones["OccursEveryMonthMultipleDaysOnce"] = "Ocurre el {0} {1} cada {2} meses. El programador se utilizará una vez al día a las {3} a partir del {4}";
            traducciones["OccursEveryMonthMultipleDaysMultiple"] = "Ocurre el {0} {1} cada {2} meses. El programador se utilizará entre las {3} y las {4} cada {5} hora/s a partir del {6}";

            // Traducciones de los días de la semana
            traducciones["Lunes"] = "Lunes";
            traducciones["Martes"] = "Martes";
            traducciones["Miercoles"] = "Miércoles";
            traducciones["Jueves"] = "Jueves";
            traducciones["Viernes"] = "Viernes";
            traducciones["Sabado"] = "Sábado";
            traducciones["Domingo"] = "Domingo";
            traducciones["Dia"] = "Dia";
            traducciones["Entre_semana"] = "Semana";
            traducciones["Fin_de_semana"] = "Fin de semana";

            // Traducciones de frecuencia del día
            traducciones["Primer"] = "Primer";
            traducciones["Segundo"] = "Segundo";
            traducciones["Tercer"] = "Tercer";
            traducciones["Cuarto"] = "Cuarto";
            traducciones["Ultimo"] = "Último";
        }
    }
}
