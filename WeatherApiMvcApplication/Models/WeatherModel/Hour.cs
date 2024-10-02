namespace WeatherApiMvcApplication.Models.WeatherModel
{
	public class Hour
	{
		public long time_epoch { get; set; }
		public string time { get; set; }
		public double temp_c { get; set; }
		public double temp_f { get; set; }
		public int is_day { get; set; }
		public Condition condition { get; set; }
		public double wind_mph { get; set; }
		public double wind_kph { get; set; }
		public double wind_degree { get; set; }
		public string wind_dir { get; set; }
		public double pressure_mb { get; set; }
		public double pressure_in { get; set; }
		public double precip_mm { get; set; }
		public double precip_in { get; set; }
		public double humidity { get; set; }
		public double cloud { get; set; }
		public double feelslike_c { get; set; }
		public double feelslike_f { get; set; }
		public double windchill_c { get; set; }
		public double windchill_f { get; set; }
		public double heatindex_c { get; set; }
		public double heatindex_f { get; set; }
		public double dewpoint_c { get; set; }
		public double dewpoint_f { get; set; }
		public double vis_km { get; set; }
		public double vis_miles { get; set; }
		public double uv { get; set; }
		public double gust_mph { get; set; }
		public double gust_kph { get; set; }
	}
}
