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

            // Return time until Christmas as a string
            // Just return rounded numbers of months, days, hours, minutes, seconds
            switch (_selectedUnit)
            {
                case TimeUnits.Months:
                    return Math.Round(timeUntilChristmas.TotalDays / 30).ToString() + " Months";
                case TimeUnits.Days:
                    return Math.Round(timeUntilChristmas.TotalDays).ToString() + " Days";
                case TimeUnits.Hours:
                    return Math.Round(timeUntilChristmas.TotalHours).ToString() + " Hours";
                case TimeUnits.Minutes:
                    return Math.Round(timeUntilChristmas.TotalMinutes).ToString() + " Minutes";
                case TimeUnits.Seconds:
                    return Math.Round(timeUntilChristmas.TotalSeconds).ToString() + " Seconds";
                default:
                    return Math.Round(timeUntilChristmas.TotalDays).ToString() + " Days";
            }
        }
    }
}
