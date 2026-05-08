# N232GroupProjectTeam5

Aaron Ashmore, Emily Cabrera, DaRon Torrence, Abhinoor Singh 

N232 

4/28/26 

Group Milestone 4 Post Mortem: 

GitHub - https://github.com/AaronAshmore444/N232GroupProjectTeam5


Controls:
wasd and arrow keys - movement
spacebar - jump
Left Shift - sprint
Left Click - Shoot stun gun
F - Place trap and pickup trap
Escape - Pause Menu


Contributions - 

Aaron Ashmore: Balance, bug fixing, compiles team changes, trap pickup, audio

Emily Cabrera: Building the set, creating the coin/health collection, invisible walls around the map 

DaRon Torrence: Building the enemy, creating a poison projectile system for ranged enemies, with spawners around the map. 

Abhinoor Singh: Designed and implemented the gun, bullet and ammo box, the homescreen UI and all its logic as well as the options screen (with shortcuts for both) 

 

What was learned and what would be done differently - 

Aaron Ashmore: I learned how to attempt to be a leader. I learned how to create a pickup that has a maximum of one allowed in your inventory.  I also learned how to make an object interact with other objects around the map. I would try to be a little less stressed during the group project. I would also go about doing the player controller differently. It feels like there are a few too many things in a single script. 

Emily Cabrera: I learned how to make a proper health pickup, considering I have been looking for methods and scripts that would work, and on my own for that matter. Not to mention I also learned how to make invisible walls; I did not think they would be so easy though since making invisible in other game programs like Unreal Engine is a bit different. If I had more time to do things differently, I would’ve done more research on how to make a better pickup or an easier way. 

DaRon Torrence: I learned The importance of pushing and pulling before working, I've learned now to always be sure to pull origin before working to avoid conflict.  This helped me understand how important it is to stay updated with my teams work and keep everything synced. It also showed me that pushing changes regularly is just as important for smooth collaboration. 

Abhinoor Singh: 

 

Challenge I faced - 

Aaron Ashmore: I struggled with not having to rush through this project to be able to keep up with other projects. Each week I feel that I was only able to do the bare minimum or else I would fall behind. I also struggled with giving team updates on the day that they were needed. I was always a day or two later than i wanted to be. 

Emily Cabrera:  I mainly struggled with the enemy point system, while it did present if you killed an enemy in the console, it didn’t show up in the actual scoring I made. 

DaRon Torrence: I mainly struggled with debugging collision and trigger issues, merging conflicts, and fixing projectile behavior. I also struggled using github, costing the lost progress last milestone due to an improper push/pull on my end. 

Abhinoor Singh: 


-------------------------------------------------------------------------------------------------------------------

Milestone 3:

Contributions

Aaron Ashmore - Worked on Player movement, camera, gun functionality, trap functionality and ui display, trap pickup, and the door puzzle!

Emily Cabrera - Score, coins, healing pickups, level design.

Abhinoor Singh - Did not communicate or contribute this Milestone.

DaRon Torrence - Enemies, enemy spawners, damage.


For Milestone 3, we have continued implementing features to complete our game as a Ghost Extermination Service. Our game is a first person experience where the player is armed with a ghost stun gun and spirit capture mirror. When the player shoots a ghost, the ghost becomes stunned and unable to move for a time. When the ghost hovers over the capture mirror, the player gets 10 points. When all of the ghosts become captured, your services are complete and you win the game. There are collectible coins scattered around the map. Inside the house, there is a door locked by two padlocks. In the other rooms of the house, there are hidden targets that, when destroyed, destroy one of the door locks. When both locks are destroyed, the door is destroyed. Behind the door, there are more collectable coins and an extra trap pickup to give the player a power boost. The player can only hold 1 trap at a time, so they will can position their traps to help them survive and catch ghosts efficiently. There are also health pickups around the map to heal the player if they get low life.

When launching the Homescreen scene, the player is taken to a start menu. When pressing the start button, the player is loaded into level 1.

Controls:
wasd and arrow keys - movement
spacebar - jump
Left Shift - sprint
Left Click - Shoot stun gun
F - Place trap and pickup trap

We cut a few gadget ideas and the gadget upgrades, due to a member missing during this Milestone.

We had a few more features working such as spawners and the player taking damage, but a merge conflict caused us to lose a bunch of progress and we could not recover before submission. For final, we plan to fix these listed issues, and include a player losing due to health being reduced to 0, and the player winning by exterminating all of the ghosts. Another idea that has already been completed once, but needs reimplented due to a merge conflict is the extra trap pickup.

We also plan to include 1 more type of ghost along with polishing.



--------------------------------------------------------------------------------------------------------------------

Milestone 2:

Contributions

Aaron Ashmore - Player Controller, Enemy, Gadget throw

Emily Cabrera - Level Design, Coins and Scoring

Abhinoor Singh - Gun, Bullets, UI

DaRon Torrence - Worked on health and damage script from bullets for the enemies

Notable Practices - We kept our work testing in Prefabs and Scenes before merging it all into the Level 1 scene when completed.

What is working - Player Controller, Coin Pickup and Scoring, Gun Bullets, some UI, Basic Enemy, Trap spawn, Player death, Enemy death, 
Controls - Shift to sprint, Left Mouse to shoot, F to spawn trap, R to restart level, WASD and arrow keys to move, Spacebar jumps

What is not working - UI is not linked to each UI scene all the way, Enemy shouldn't attack immediatly, player spins out of control randomly

Objective - At the moment, the objective is to kill the ghost before it kills you by using the trap or gun. You can also try to find all of the coins if you want!

Plan for Milestone 3: 

Aaron Ashmore - Fix bugs with player movement, think about sounds that object might make, work with abhinoor on creating and refining gadgets to capture ghosts.

Emily Cabrera - Finish Level 1 Enviorment, Finish Scoring System

DaRon Torrence - Enemy spawns and behavior(Enemies should not chase the player immediatly, and float around the map)

Abhinoor Singh - Continue UI, Gadgets, Special mechanics such as hidden room or puzzle 
