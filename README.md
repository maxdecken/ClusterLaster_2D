# ClusterLaster: SpiderPiggy (2D-Game)

<img src="https://github.com/maxdecken/ClusterLaster_2D/blob/main/spiderpiggy/Assets/Images/branding/wordart.png" height="300px"/>

SpiderPiggy ist ein 2D-Spiel für den Game-Engines Kurs des Studiengangs IMI an der HTW-Berlin im Wintersemster 22/23.

## Getting Started

WICHTIG: Das Spiel ist für Windows (10 und 11) entwickelt und lässt sich ausschließlich auf dieser Plattform spielen.

Um das Spiel zu starten muss entweder das letzte Release oder der Inhalt des Ornder <code>/builds/windows</code> heruntergeladen und die darinbefindliche <code>SpiderPiggy.exe</code> gestartet werden.

Viel Spaß beim spielen!

## Beschreibung

Bei unserem 2d Sidescroller Game geht es darum, so viele Items wie möglich einzusammeln. 
Dabei muss man sich an einem Seil von Plattform zu Plattform schwingen und darf dabei nicht in das tötliche Feuer fallen.
Unser Game ist ein Endlessrunner bei welchem es stets gilt den momentanen Highscore zu knacken, welcher einem jeweils am Ende eines Runs präsentiert wird.  

https://user-images.githubusercontent.com/68195151/205307716-fbb34aa1-1c5d-4df2-a040-04e71538d655.mp4

### Genre & Art Style
2D Sidescroller, Platformer, Endlessrunner

## Features

### Player 

![grafik](https://user-images.githubusercontent.com/68195151/204776815-ca0aeb79-7d34-4dd1-b47d-fa2b945a79e1.png)

Der Player (Als Prefab implementiert) wird gesteuert mit den WASD Tasten.
Das Seil wir mit der linken Maustaste bedient.
Der Player kann auch Items wie Äpfel, Bananen, etc. einsammeln, welche jeweils unterschiedliche Vorteile bringen.

### Enemies

![grafik](https://user-images.githubusercontent.com/68195151/204775489-708f0707-4a34-4570-8792-e16182840c60.png)
![grafik](https://user-images.githubusercontent.com/68195151/204775565-9ffbdd2f-44c8-4dda-939e-d7eb67d3dab3.png)
![grafik](https://user-images.githubusercontent.com/68195151/204775640-d0ee9742-5993-43a2-a358-1482e8fc1342.png)

Die Enemies sind auch Prefabs.
Als Enemy gibt es Möwen, Meteroiten und Drohnen.
Möwen und Drohnen bewegen sich jeweils x Einheiten hin und her (von rechtes nach links). Kommt der Spieler mit einem Enemy in Berührung wird das Spiel neu gestartet. 
Sobald der Spieler mit dem Feuer am Boden in Behrührung kommt, heißt es Game Over. 


### Items

![grafik](https://user-images.githubusercontent.com/68195151/204774707-73f6fe58-cee0-4189-9d37-99d61bf89ab1.png)
![grafik](https://user-images.githubusercontent.com/68195151/204774828-f3600416-28d2-432b-a836-31d4d1a15424.png)
![grafik](https://user-images.githubusercontent.com/68195151/204774898-c2cc9ace-4180-43e4-8795-dad5fa8c67a3.png)
![grafik](https://user-images.githubusercontent.com/68195151/204774956-ce681d24-d380-46da-9d64-77da423eb273.png)

Items verbessern die Situation des Spielers oder geben ihm Kraft, was für ein erfolgreiches Gameplay essentiell ist.
Es gibt folgende Items:

* Apfel: Big Jump
* Karotte: Score-Booster
* Kartoffel: Invincibility
* Eisberg-Salat: Freeze Time (Enemies)


## Das Spiel

### Start Menü

Zu Beginn des Spiels erscheint das Start Menü.

![grafik](https://user-images.githubusercontent.com/68195151/204773267-c47d8269-983f-46c3-b9e8-942706275c5d.png)

* Start - Das Main-Game startet
* Tutorial - Das Tutorial startet
* Quit - Das Spiel wird beendet

### Main Game

Das Herzstück des Spiels: Die sich automatisch / zufällig während dem Gameplay aufbauende Endlessrunner-Szene. Hier geht es darum den höchstmöglichen Score zu erreichen und dabei nicht zu sterben. In das Feuer zu fallen oder die "ESC"-Taste drücken beendet das Spiel.

![grafik](https://user-images.githubusercontent.com/68195151/204862896-e4f63271-089c-4085-9fc9-c3c930ae9225.png)
![grafik](https://user-images.githubusercontent.com/68195151/204863417-930feb32-66b9-4296-91a4-81af09f4d1a1.png)

### Tutorial Level

Hier wird dem Spieler in einem Mini-Level die Steuerung erklärt.

![grafik](https://user-images.githubusercontent.com/68195151/205256954-2ae90333-2e44-4153-8ee7-3145107c485f.png)

* Start - Das Main-Game startet
* Main Menu - Rückkehr zum Startmenu


### GameOver Menü 

Wenn der Player stirbt erscheint das Game-Over-Menü. Hier wird der aktuell erreichte Score sowie der bisherige Highscore angezeigt.

![grafik](https://user-images.githubusercontent.com/68195151/204773755-0328c6cf-c544-4e68-b3a7-a1408735b4ab.png)

* Try Again - Das Main-Game startet erneut
* Main Menu - Rückkehr zum Startmenü

### Player Control

Der Player kann sich mit der Steuerung fortbewegen, von Plattform zu Plattform schwingen und Items einsammeln. Zudem kann er sich sprunghaft dem Seil entlang hochziehen. Einige dieser Aktionen werden durch Items beeinflusst und verbessert.

Tasten:
A & D: Nach links bzw. rechts bewegen / schwingen
Q: Am Seil hochziehen
Leertaste & W: Springen -> Mehrere Sprünge sind möglich, Sprung kann auch in der Luft verwendet werden. Nach drei Srpüngen setzt eine Cooldown-Zeit ein.
Linker Mausklick: An der Wand in Richtung des Maus-Icons wird ein Haken platziert, um das Seil zu spannen. In freier Luft kann kein Haken gesetzt werden. Wenn bereits ein Seil gespannt ist, wird mit einem weiteren Mausklick das Seil entfernt. 

### Team
Max Decken, Colin Garms, Alexander Ehrenhöfer, Leah Sommer

### Built With
Software
* Unity Version 2021.3.11f1

### Resources
#### Assets
* Das SpeiderPiggy ist mit Dall-E (https://openai.com/dall-e-2/) generiert worden und dann händisch in Einzelteile aufgeteilt und geriggt worden.
* Die Möwe wurde ebenfalls mit Dall-E (https://openai.com/dall-e-2/) generiert und in Photoshop in mehrere Tiles umgesetzt.
* Drohne: https://craftpix.net/freebies/free-drones-pack-pixel-art/
* Meteor: https://kenney.nl/assets/space-shooter-redux
* City: https://anokolisa.itch.io/sidescroller-shooter-central-city
* Food Icons: https://assetstore.unity.com/packages/2d/gui/icons/food-icons-pack-70018

#### Music
* Game Soundtrack: https://pixabay.com/de/music/frohliche-kinderlieder-fun-happy-50s-pop-113298/

#### Sounds
* Item Sound 1: https://freesound.org/people/BloodPixelHero/sounds/591706/
* Item Sound 2: https://freesound.org/people/Mr._Fritz_/sounds/544015/
* Jump Sound: https://freesound.org/people/elektroproleter/sounds/157569/
* Walk Sound: https://freesound.org/people/movingplaid/sounds/76187/

#### Code
* Für den LineRenderer des Seils wurde sich an einem Tutorial orientiert (https://www.youtube.com/watch?v=BXTjsCERdsw&ab_channel=DonHaulGameDev-Wabble-UnityTutorials)   Zugrif am 13.12.2022, 16:34 Uhr
