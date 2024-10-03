Aplikacja pobiera i wyświetla dane z darmowego api pogodowego ze strony https://www.weatherapi.com/
Najpierw tworzony jest odpowiedni URL zawierajęcy nazwę miasta i ilość dni z prognozą pogody, który odpytuje api pogodowe.
Api pogodowe w odpowiedzi wysyła plik JSON, który następnie w mojej aplikacji jest deserializowany.
Następnie tworzone są odpowiednie modele zawierające dane pogodowe. Modele przesyłane są w akcji kontrolera do widoków i prezentowane na stronie.

Mamy do wyboru wyświetlenie aktualnej pogdy dla danych miast oraz prognozy pogody na najbliższe 3 dni. Wykorzystano ASP.NET MVC, wykresy tworzone przy pomocy Chart.js
