# Use cases for full system

## Arduino sender ikke data:
1. Opsat Arduino har ikke sendt data i et døgn.
1. Server sender advarsler på hjemmeside som notifikation.
1. Aktør ser advarsler.
1. Aktør går til lokalet for at bekræfte opsætning ikke er ændret på.
1. Aktør løser den fysiske opsætning.
1. Arduino sender data igen

**status** = Ikke implementeret (8:04 15/09-2020)

****

## Arduino sender normal data:
1. Arduino læser temperatur i lokale.
1. Arduino sender læst temperatur til server.
1. server modtager data og gemmer det i database.
1. arduino venter i defineret tid fra server respons.
1. gentag 1.

**status** = Ikke implementeret (8:05 15/09-2020)

****

## Arduino Opsætning:
1. Arduino sat op fysisk i lokale.
1. Aktør forspøger server for IP, MAC og UUID.
1. Aktør indsætter IP, MAC og UUID ind Konfigurations delen.
1. Aktør sætter strøm I arduino og Ethernet stik
1. Arduino sender første skanning til server.
1. Server modtager skanning og gemmer data.
1. Server finder frekvens for UUID og sender til Arduino
1. Modtager eventuelt frekvens for at sende data.

**status** = Ikke implementeret (8:05 15/09-2020)

****

## Arduino sender ingen data:
1. Arduino sender målinger uden data i over et døgn.
2. Server sender advarsler på hjemmeside som notifikation.
3. Aktør ser advarsel
4. Aktør går til lokalet for at bekræfte at der ikke er løse forbindelser.
5. Aktør sikre ingen løse forbindelser.
6. Arduino sender data igen.

**status** = Ikke implementeret (8:05 15/09-2020)

****

## Data fra sensor i rum overskriver grænseværdi:
1. Arduino rapportere høje/lave temperaturer.
1. Advarsel sendes på hjemmeside som notifikation.
1. Aktør ser advarsel på hjemme side.
1. Aktør går til lokale for at bekræfte at der ikke er noget fysisk galt.
1. Aktør tjekker Arduino opsætning for løse forbindelser eller tildækninger
1. Arduino sender normal data.

**status** = Ikke implementeret (8:07 15/09-2020)

****

## Skift tids frekvens for specifikke Arduinoer:
1. Aktør navigere ind på hjemmeside.
1. Aktør vælger enheder at ændre frekvens på og gemmer.
1. Server gemmer data i database.
1. Arduino sender data fra måler modtager ændring i frekvens og gemmer.
1. Arduino sender data efter ønsket frekvens.

**status** = Ikke implementeret (8:08 15/09-2020)

****

## Skift standard tids frekvens:
1. Aktør navigere ind på hjemmeside.
1. Aktør ændre standard tids frekvens og gemmer nye værdi.
1. Server gemmer ny frekvens i database.
1. Arduino sender data fra sensor, og modtager ny frekvens.
1. Arduino sender først data fra ny frekvens.
1. Arduino'er med specifik tidsfrekvens følger deres egne. baseret fra UUID 

**status** = Ikke implementeret (8:10 15/09-2020)

****

## Skift standard grænseværdi:
1. Aktør navigere til hjemmeside.
1. Aktør ændre i standard grænse værdier og gemmer.
1. Server gemmer nye værdier og tjekker de sidste 5 dage op imod nye grænseværdier
1. Aktør vil få notifikationer hvis sensorer har overskrevet nye grænse værdier i de sidste 5 dage.

**status** = Ikke implementeret (8:12 15/09-2020)

****

## Skift bruger-venligt navn og beskrivelse til Arduino:
1. Aktør navigere til hjemmeside.
1. Aktør vælger én arduino og klikker på "Skift Navn og beskrivelse".
1. Aktør skriver ny info ind og gemmer.
1. Server gemmer information på Arduinoen.
1. Akør kan nu se det nye navn og beskrivelse for arduino.

**status** = Ikke implementeret (8:13 15/09-2020)

****

## Fjern sensor fra system:
1. Aktør navigere til hjemmeside.
1. Aktør vælger Arduino der skal fjernes.
1. Aktør klikker på fjern.
1. Server gemmer information at den er inaktiv.
1. Server vil sende notifikation at forbundet UUID stadig rapportere ind
1. Aktør fjerner Arduino.

**status** = Ikke implementeret (8:14 15/09-2020)

****

## Arduino læser sensor information:
1. Arduino læser data fra DTH11 sensor.
1. Arduino printer information til et output.
1. Arduino venter et stykke tid før læsning fra DHT11 sensor
1. gentag 1.

**status** = Ikke implementeret (8:33 15/09-2020)

****

## Arduino kommunikator kan genere UUID,IP og MAC for Arduino:
1. Aktør registere ny Arduino, information generes til Arduino.
1. Kommunikator gemmer genereret data i Database.
1. Kommunikator klar til at sende/modtage data fra Arduino.

**status** = Ikke implementeret (8:38 15/09-2020)

****