# ClusterLaster: SpiderPiggy (2D-Game)

![grafik](https://user-images.githubusercontent.com/68195151/204778098-4c82c344-cbff-46c5-904b-d62e8e8b495b.png)

SpiderPiggy ist ein 2D-Spiel für den Game-Engines Kurs des Studiengangs IMI an der HTW-Berlin im Wintersemster 22/23.

## Getting Started

WICHTIG: Das Spiel ist für Windows (10 und 11) entwickelt und lässt sich auf dieser Plattform spielen.

Um das Spiel zu Starten muss der Inhalt des Ornder <code>/builds/windows</code> heruntergeladen und die darinbefindliche <code>SpiderPiggy.exe</code> gestartet werden.

Viel Spaß beim spielen!

## Beschreibung

Bei unserem 2d Sidescroller Game geht es darum, so viele Items wie möglich einzusammeln. 
Dabei muss man sich an einem Seil von Plattform zu Plattform schwingen.
Unser Game ist ein Endlessrunner und wenn man stirbt wir der Highscore präsentiert.  

### Genre & Art Style
2D Sidescroller, Platformer, Endlessrunner

## Features

### Player 

![grafik](https://user-images.githubusercontent.com/68195151/204776815-ca0aeb79-7d34-4dd1-b47d-fa2b945a79e1.png)

Der Player wird gesteuert mit den WASD Tasten.
Das Seil wir mit der linken Maustaste bediehnt.
Der Player kann auch Items einsammeln, wie Äpfel, Bananen, etc.

### Enemies

![grafik](https://user-images.githubusercontent.com/68195151/204775489-708f0707-4a34-4570-8792-e16182840c60.png)
![grafik](https://user-images.githubusercontent.com/68195151/204775565-9ffbdd2f-44c8-4dda-939e-d7eb67d3dab3.png)
![grafik](https://user-images.githubusercontent.com/68195151/204775640-d0ee9742-5993-43a2-a358-1482e8fc1342.png)

Die Enemies sind auch Prefabs.
Als Enemy gibt es Möwen, Meteroiten und Drohnen.
Möwen und Drohnen bewegen sich jeweils ... Einheiten hin und her (von rechtes nach links). Kommt der Spieler mit einem enemy in berührung, wir das Spiel neu gestartet. 
Wenn der Spieler mit dem Feuer am Boden ebenfalls in Behrührung kommt, heißt es Game Over. 


### Items

![grafik](https://user-images.githubusercontent.com/68195151/204774707-73f6fe58-cee0-4189-9d37-99d61bf89ab1.png)
![grafik](https://user-images.githubusercontent.com/68195151/204774828-f3600416-28d2-432b-a836-31d4d1a15424.png)
![grafik](https://user-images.githubusercontent.com/68195151/204774898-c2cc9ace-4180-43e4-8795-dad5fa8c67a3.png)
![grafik](https://user-images.githubusercontent.com/68195151/204774956-ce681d24-d380-46da-9d64-77da423eb273.png)

Items verbessern die Situation des Spielers oder geben ihm Kräft, die seine Spielsituation verbessern.
Es gibt folgende Items:

<li>Apfel: Big Jump</li>
<li>Karotte: Score-Booster</li>
<li>Kartoffel: Invincibility</li>
<li>Eisberg-Salat: Freeze Time (Enemies)</li>


## Das Spiel

### Start Menü

Zu Beginn des Spiels erscheint das Start Menü.

![grafik](https://user-images.githubusercontent.com/68195151/204773267-c47d8269-983f-46c3-b9e8-942706275c5d.png)

<li>Start - Das Main-Game startet</li>
<li>Tutorial - Das Tutorial startet</li>
<li>Quit - Das Spiel wird beendet</li>

### Main Game

Das Herzstück des Spiels: das Endlessrunner-Spiel das sich automatisch und zufällig erweitert. Hier geht es darum den hächsten Score zu sammeln und nicht zu sterben. Ins Feuerfallen oder die "ESC"-Taste drücken beendet das Spiel.

![grafik](https://user-images.githubusercontent.com/68195151/204773527-6bc8183b-45e2-4b4e-9ac0-7c0713c0336a.png)

### Tutorial Level

Hier wird dem Spieler in einem Mini-Level die Steuerung erklärt.

![grafik](https://user-images.githubusercontent.com/68195151/204773624-5a265ff2-d1e3-41eb-98a6-0679afb37178.png)

<li>Start - Das Main-Game startet</li>
<li>Main Menu - Rückkehr zum Startmenu</li>


### GameOver Menü 

Wenn der Player stirbt erscheint das Game-Over-Menü, hier wird der aktuell errichte Score und der bisherige Highscore angezeigt.

![grafik](https://user-images.githubusercontent.com/68195151/204773755-0328c6cf-c544-4e68-b3a7-a1408735b4ab.png)

<li>Try Again - Das Main-Game startet erneut</li>
<li>Main Menu - Rückkehr zum Startmenu</li>

### Player Control

Der Player kann mit der Steuerung sich fortbewegen, von Plattformen schwingen und Items einsammeln. Zudem kann er am Seil hochspringen. Einige dieser Aktionen werden durch Items beeinflusst und verbessert.

### Team
Max Decken, Colin Garms, Alexander Ehrenhöfer, Leah Sommer

### Built With
Software
* Unity Version 2021.3.11f1

### Resources
#### Assets
<li>Das SpeiderPiggy ist mit Dall-E (https://openai.com/dall-e-2/) generiert worden und dann händisch in Einzelteile aufgeteilt und geriggt worden.</li>
<li>City: https://anokolisa.itch.io/sidescroller-shooter-central-city</li>
<li>Food Icons: https://assetstore.unity.com/packages/2d/gui/icons/food-icons-pack-70018</li>

#### Music
<li>Game Soundtrack: https://pixabay.com/de/music/frohliche-kinderlieder-fun-happy-50s-pop-113298/</li>

####Sounds
<li>Item Sound 1: https://freesound.org/people/BloodPixelHero/sounds/591706/</li>
<li>Item Sound 2: https://freesound.org/people/Mr._Fritz_/sounds/544015/</li>
<li>Jump Sound: https://freesound.org/people/elektroproleter/sounds/157569/</li>
<li>Walk Sound: https://freesound.org/people/movingplaid/sounds/76187/</li>
