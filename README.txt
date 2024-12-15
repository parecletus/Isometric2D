I wasn't planning to share my projects so I want to explain a few things.

Thomas_ : This is my first event system. 
Took me while to understand how event systems worked. Found out another way to make it using scriptable objects. But this way was more challenging.
I have read that It is important to Unsubscribe an event due to memory leakage when using statics. Went with it anyways.


JsonReader_Map : I use 'Tiled' to manage tilemaps. I really don't like Unity's Tile Palette. Problem was I couldn't get any data from Tiled.
Then I imported tilemap as json file. Searched web for a way to get data from json and found Newtonsoft.Json. library. I know that maplocation is hard coded. 
I could search through 'map file' to get jsons and select them , relative to the map I want to use. But I'm sure , There is a better way to do it. So I just kept it as it is.
I used one dimensional array on purpose. Managing is way easier then two-dim arrays. It is Faster?? Im not sure about this but yeah. 


TileManager : Probably I shouldve separated this script to its components for readability.  
 Creates Tiles relative to their positions
 When an Event is triggered :
 -It checks if previous event is different from this one.
 -If it is then it changes transparency to show tiles or not. 

