# Teknisk manual.

## Arduino:
Arduino er en lille micro controller som kan styre forskellige ting igennem deres kode, koden som skrives på er kun den kode eksekveres.

de har en en del pins som kan bruges til at interakter med den virkelige verden.

### Sensorer:
Arduinoer har en del mulighedere for at have sensorer tilslusttet, i dette projekt er der bygget ud fra at sensoren der bliver brugt er en DHT11 [0].

#### DHT11:
Dette er en temperatur og luft fugtigheds sensor som er akkurat ned til +/- 2 grader i Celsius og +/- 5% luft fugtighed [1]

### Sheilds:

Arduinoer kan udvides med forskellige sheilds, i dette project vil der blive brugt et Ethernet shield.

#### Ethernet Shield:

Ethernet shield kommer med ingen konfiguration dette betyder at arduinoen skal definere en MAC addresse til Ethernet sheildet fra hvilken MAC skal bruges. ved at kigge på dokumentationen [2] er der MAC addresser som er enten reseveret eller ubrugte. disse er de MAC addresser at der skal generes udfra.

##### Arduino webserver over Ethernet:

Ethernet biblioteket kommer også med et webserver til at kunne modtage og sende information mellem Arduinoen og andre computere. serveren kan blive fundet her [3].

##### Kommunikation medium:
Kommunikations medium vil være JSON til og fra Arduinoer.

****

## Arduino Kommunikator:
Arduino Kommunikator vil generer UUID, IP og MAC for en Arduino, dette data vil blive gemt i en database, så Arduino kommunikator vil vide at det er en registeret sensor, og vil aktivt få data fra sensore, dette program skal bruge et DLL bibliotek til at gemme og modtage data fra database, skal have begrænset kommunikation med Web API for at sende alarmer til brugere.

### Oprettelse af sensor:
for at oprette en sensor kan man sætte et brugervenligt navn op med det samme i programmets grafiske interface, programmet vil genere et UUID, IP og MAC addresse for arduino'en til at skulle bruge.

### Standard Opførsel:
Kommunikator kan have en aktiv opførsel hvilket gør at den aktivt kontakter Arduinoen og får data, hvilken den så skal gemme i en database. 

### Data kommer ikke fra Arduino:
I tilfælde hvor data for en timeout i forspørgslen skal Kommunikator sende en ICMP(ping) forspørgsel og hvis ingen svar kommer skal Kommunikator rapportere dette til Web API for front-end delen.

### Kommunikations Medium:
Kommunikator skal forstå JSON og håndtere data baseret på det.


****

## Web API:
Web API'en skal stå for beskeder som brugerene skal se, dette API skal også have begrænset kommunikation med Arduino Kommunikator, det skal primært kommunikere med front-end og database, vise notifikationer, sætte og få informormation til slut brugere. den importere et DLL bibliotok som står for at udvide med database tilgang og andre hjælpe klasser.

### Bruger interaktion:
Dette er hvad en bruger skal kunne gennem web API'en

#### Gemme brugervenlig information omkring arduino sensorer:
Web API skal gemme bruger venlig information omkring en Arduino skanner, dette information skal indholde et Navn og en beskrivelse. 

#### Gemme Grænseværdier både standard og indivduelle:
Grænseværdier skal kunne sættes indivduelle værdier på skannere men også standard værdier.

#### Vise informationer fra sensorer:
tidligere skanninger skal kunne læses ved at navigere ind på en sensor, med sensoren's UUID. 

#### Læse notifikationer:
Notifikationer skal kunne sendes og modtages på brugere så en bruger vil få information vedr sensorer som ikke svarer eller overstiger grænseværdier.

#### Sætte tids frekvens for standard og individuelle sensorer:
brugere skal kunne sætte en tidsfrekvens at en Arduino Kommunikator skal kommunikere med arduinoner.


### Automatiske handlinger:
Web API'en skal også kunne tjekke for eventuelle problemer undervejs, dette skal ske hvert 10 minut dette vil genere notifikationer hvis der ikke allerede er en notifikation til det der er blevet fundet problem med.

#### Arduino overstiger grænseværdi:
hvis en arduino har haft overstiget en grænse værdi skal dette noteres ned som en notifikation til brugere.

#### Arduino har ikke svaret men svarer på pings:
Arduino svarer ikke på HTTP forspørgsler, men svarer på pings(ICMP)

### Servering af Angular hjemmeside:
Web API skal også servere en bruger med en angular hjemmeside.

****

## DLL Bibliotek:
DLL biblioteket skal udvide standard kode med klasser som indholder informationer som er samlet mellem Web API og Arduino Kommunikator.

### Database adgang:
DLL biblioteket skal have 2 interfaces for at kunne skrive til databasen og en til at læse. den skal også pakke resultaterne fra forspørgslerne ind i klasser 

### Klasser:
klasser til at pakke information ind i. hvilket vil blive brugt til at uploade til database, med information indholdt i dem. eller sendt i JSON format til hvor de skal hen til.


****

## Angular hjemmeside:
Angular hjemmesiden skal give information til brugeren som modtages fra web API'en data skal også sendes til apien baseret på hvad der skal gøres.

### Modtag data fra API om skanner:
angular skal hente information omkring enhed(er), hvilke temperaturer og luft fugtigheds målninger der er målt over tid.

### Send data til API til brugervendte systemer:
Angular skal kunne sende brugervenlige navne til serveren denne kode vil blive vist til brugere. dette kan være at have en sensor som er kendt som et UUID(Windows version hedder GUID), hvor du kan sætte et navn op på.

### Sætte grænseværdier på enheder:
grænseværdier kan ændres baseret på hvor disse sensorer er, dette kan være i et server rum hvor man ikke ønsker temperatueren går over eller under en temperatur.




****

# Kilder:
[0] DHT11 Dokumentation: https://www.mouser.com/datasheet/2/758/DHT11-Technical-Data-Sheet-Translated-Version-1143054.pdf
[1] DHT11 målings præcision: https://howtomechatronics.com/tutorials/arduino/dht11-dht22-sensors-temperature-and-humidity-tutorial-using-arduino/#:~:text=Also%20the%20DHT22%20sensor%20has,is%20better%20than%20the%20DHT22.
[2] MAC Addresse specifikation: https://www.iana.org/assignments/ethernet-numbers/ethernet-numbers.xhtml
[3]  https://www.arduino.cc/en/Tutorial/WebServer


****

**Sidste ændring 09:12 16/09-2020**