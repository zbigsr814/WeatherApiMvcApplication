DESCRIPTION

The application retrieves and displays data from a free weather api from https://www.weatherapi.com/ First, a corresponding URL containing the name of the city and the number of days with the weather forecast is created, which queries the weather api. The weather api sends a JSON file in response, which is then deserialized in my application. The corresponding models containing the weather data are then created. The models are sent in a controller action to the views and presented on the page.

We have the choice of displaying the current weather for the given cities and the weather forecast for the next 3 days. 

TECHNOLOGIES USED
- ASP.NET MVC
- Newtonsoft JSON
- Razor code
- .Net HttpClient for connecting to an external api
- Chart.js
