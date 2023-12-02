namespace Christmas_Countdown.View_Models_and_Logic
{
    internal class ChristmasLogic
    {
        private static ChristmasLogic _instance;
        public static ChristmasLogic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ChristmasLogic();
                return _instance;
            }
        }

        // Define enum for months, days, hours, minutes, seconds
        public enum TimeUnits
        {
            Months,
            Days,
            Hours,
            Minutes,
            Seconds
        }

        private TimeUnits _selectedUnit;

        public ChristmasLogic()
        {
            _selectedUnit = TimeUnits.Days;
        }

        public void SwitchTimeUnit()
        {
            switch (_selectedUnit)
            {
                case TimeUnits.Months:
                    _selectedUnit = TimeUnits.Days;
                    break;
                case TimeUnits.Days:
                    _selectedUnit = TimeUnits.Hours;
                    break;
                case TimeUnits.Hours:
                    _selectedUnit = TimeUnits.Minutes;
                    break;
                case TimeUnits.Minutes:
                    _selectedUnit = TimeUnits.Seconds;
                    break;
                case TimeUnits.Seconds:
                    _selectedUnit = TimeUnits.Months;
                    break;
            }
        }

        public string GetTimeUnitString()
        {
            switch (_selectedUnit)
            {
                case TimeUnits.Months:
                    return "Months";
                case TimeUnits.Days:
                    return "Days";
                case TimeUnits.Hours:
                    return "Hours";
                case TimeUnits.Minutes:
                    return "Minutes";
                case TimeUnits.Seconds:
                    return "Seconds";
                default:
                    return "Days";
            }
        }

        // Define method to calculate time until Christmas and return it as a string
        public string GetTimeLeft()
        {
            // Get current date and time
            DateTime currentDate = DateTime.Now;

            // Get Christmas date and time
            DateTime christmasDate = new DateTime(currentDate.Year, 12, 25);

            // If Christmas has already passed this year, add a year to the Christmas date
            if (currentDate > christmasDate)
                christmasDate = christmasDate.AddYears(1);

            // Calculate time until Christmas
            TimeSpan timeUntilChristmas = christmasDate - currentDate;

            // Method to return singular or plural unit based on the value
            string GetUnitName(double value, string unit) => value == 1 ? unit : unit + "s";

            // Return time until Christmas as a string with correct singular or plural units
            switch (_selectedUnit)
            {
                case TimeUnits.Months:
                    double months = timeUntilChristmas.TotalDays / 30;
                    return $"{Math.Floor(months)} {GetUnitName(months, "Month")}";
                case TimeUnits.Days:
                    // Seconds in a day = 86400
                    double days = timeUntilChristmas.TotalSeconds / 86400;
                    // Account for today as a whole day
                    days += 1;
                    return $"{Math.Floor(days)} {GetUnitName(days, "Day")}";
                case TimeUnits.Hours:
                    double hours = timeUntilChristmas.TotalHours;
                    return $"{Math.Floor(hours)} {GetUnitName(hours, "Hour")}";
                case TimeUnits.Minutes:
                    double minutes = timeUntilChristmas.TotalMinutes;
                    return $"{Math.Floor(minutes)} {GetUnitName(minutes, "Minute")}";
                case TimeUnits.Seconds:
                    double seconds = timeUntilChristmas.TotalSeconds;
                    return $"{Math.Floor(seconds)} {GetUnitName(seconds, "Second")}";
                default:
                    return $"{Math.Floor(timeUntilChristmas.TotalDays)} {GetUnitName(timeUntilChristmas.TotalDays, "Day")}";
            }
        }
    }
}
