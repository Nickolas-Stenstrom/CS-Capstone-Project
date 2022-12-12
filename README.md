# CS-Capstone-Project

Table Of Contents

1. Introduction
2. Installation
3. User Manual
4. List of Features


Introduction

This is my PC game I made for my computer science capstone course. is heavily inspired by old school games on consoles like the Game Boy in
both it's graphics and gameplay. In the game, you take control of a girl trapped in a haunted house where you're tasked with finding three keys 
to escape! While exploring the house, you'll have to avoid enemies such as spiders, ghosts, and zombies. I built the game using Unity, and all of 
the code is written in C#. The game works on Windows computers, it most likely runs on Mac OS computers as well but I haven't been able to test it
on Mac.


Installation

Step 1: You can download the game right from Github by clicking the green button that says "Code," and then clicking "Download Zip." This 
        Will also give you all of the files on Github, which aren't necessary to run the game. You can delete the "Assets" folder if you'd 
        like since it isn't needed to play the game.
        
Step 2: Extract the folder anywhere on your computer.

Step 3: Open the "Spooky Retro Adventure" folder. Make sure to keep all of the files and folders together or else the game won't run.
        Double click "Spooky Adventure Game" to run the game. If Windows is showing a pop up and preventing the game from being ran,
        click "More Options," and then "Run Anyway."
        
        
User Manual
  
  - To learn how to install the game, see the Installation section.
  
  - Player Movement: To move, use the WASD keys or the arrow keys. You can sprint by holding the spacebar while moving, and you can 
                     sneak by moving and holding the right Shift key.
                     
  - Interacting:    Some objects in the game can be interacted with, such as doors and inventory items. You can press the E key to interact
                    with interactable objects. Some objects react differently if you have certain items in your inventory. If you get stuck 
                    on what to do next, make sure you try interacting with everything!
                 
  - Pausing:        You can pause the game by pressing the Esc key, or by clicking the pause button in the top left corner. In the pause menu, you 
                    have the option to review the game's controls and the option to quit the game.
             
  - Inventory:      Objects you pick up will be put in the inventory. You can open and close the inventory using the Tab key. The top row of the 
                    inventory is used for objects that will be lost when used. The the bottom row is used for keys that you find that will always
                    stay in your inventory. If you want to use an inventory object on something, walk up to it and press the E key.
                    
          
List of Features

  - Player Movement: Allows the player to move using the WASD keys and the arrow keys. While moving, the player can hold down the spacebar or the
                     right Shift key to sprint or sneak. The code for this is in the PlayerController.cs file in the Scripts folder.
                     
  - Inventory System: Lets the player store and pickup items. The code for the inventory UI is in the Inventory_UI.cs and Slots_UI.cs files in the UI Scripts
                      folder inside the Scripts folder, and the Inventory.cs file inside the Scripts folder. The code for pickup items is in Pickup_Item.cs
                      inside the Scripts folder.
                      
  - Player Health and Knockback: When the player takes damage from an enemy, they lose one health point and are knocked back away from the enemy that hit them.
                                 If the player takes too much damage, a death animation plays and the Game Over screen is shown. The code for this is in 
                                 Player_Hit.cs in the scripts folder, and in the GameOver_UI.cs file in the UI_Scripts folder.
                                 
  - Interactable Objects: Interactable objects are the objects the player can interact with that aren't inventory items. There are three different types of
                          interactable objects: one that lets the player input a password, one that requires a certain item in the player's inventory to use,
                          and the last type just displays the same dialog each time it is interacted with. You can find the code for each of the different types
                          of interactable objects in the Interactable.cs, InteractableNeedsObject.cs, and InteractablePassword.cs files in the Scripts folder.
                          There were a few variations of these classes I had to make for some specific parts in the game, which are the InteractableDoor.cs and
                          Candle.cs files in the Scripts folder. Interacting with an interactable object also brings up a dialog box. The code for the dialog boxes
                          is in the 
                          
  - Puase Menu: The player can press the Esc key or click the pause button to pause the game. In the pause screen, the player also has the options to quit
                the game or view the controls. The code for this is in the Pause_UI.cs script inside the UI_Scripts folder in the Scripts folder.
                
  - Ghost Enemies: Ghost enemies follow the player around the room as long as the ghost and the player is in the same room, and the player will take damage if they
                   run into them. The code for the ghost UI is in the Ghost.cs file in the EnemyAI folder, which is in the Scripts folder. The file Rooms.cs in the                        Scripts folder is also used for the implementation of the ghosts.
    
  - Health Bar and Health Items: The health bar displays how much health the player has left, and health items can be picked up to increase the health by one.
                                 The code for the health bar is in the Overlay.cs script in the UI Scripts folder inside the Scripts folder, and the code for
                                 the health items is in the HealthPickup.cs file in the Scripts folder.
                                 
  - Spider Enemies: Spiders will drop down and damage the player if the player isn't sneaking when they walk underneath them. The code for this can be found\
                    in the SpiderAI.cs and SpiderTrigger.cs files in the EnemyAI folder is the Scripts folder. 
                    
  - Zombie Enemies: Zombies walk in horizontal or vertical lines, and will turn around if they bump into a wall or the player. The player takes damage if they
                    bump into them. The code for the zombies is in the Zombie_AI_Vertical.cs and Zombie_AI_Horizontal.cs folder in the EnemyAI folder.
                    
  - Player and Enemy Animations: All of the sprites for the player and enemies can be found in the Art folder. The animation files for the player are in 
                                 Assets/Characters/Player/Animations folder, and the animation files for the enemies can be foud in Assets/Characters/Enemies.
                                 Each folder in the Enemies folder is designated for each enemy type, and holds the animation files for each enemy.
                                 
  - Graphics: The sprites that I used for the rest of the game's visuals are in the Art/Tiles folder.

  - Level 1: The first level of the game tasks the player with figuring out the right position to turn the hands of a clock to. Since I was able to build the 
             first level just using the scripts and assets I already made, I didn't have to write any new code for it. You can watch a video walkthrough of 
             the first and second level here: 
             
  - Level 2: The second level of the game takes place in the second story of the house, and the player must explore to figure out how to unlock the closet in
             the dining room. I had to make the file Candle.cs to handle one of the puzzles, which is a slightly modified version of the InteractableNeedsObject.cs
             file. Candle.cs is in the Scripts folder. The CheckWin.cs file in the Scripts folder makes sure that the player has the final key in their inventory.
             You can watch a walkthrough of the second level in the video above.
    
  


       
