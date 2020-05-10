using System;

namespace LibrarySystem
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TLiberatureC { get; set; }

        public int TLiberatureF => 32 + (int)(TLiberatureC / 0.5556);

        public string Summary { get; set; }
    }
}
