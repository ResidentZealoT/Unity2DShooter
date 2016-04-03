# Unity2DShooter
A 2D space shooter for CSC3020H 

DP Defense is a top down 2 player space shooter based off the tutorial by PixelElement: http://www.pixelelement.com/blog/unity-2d-space-shooter-tutorial-part-1/

The game includes 2 players, one offensive and one defensive.

player1 controls a fighter ship that scores points by shooting down enemy spaceships, if player1 loses all the ships lives the game is over! CONTROLS : WASD and (space) to shoot

Player2 controls a limited (speed and movement) support vehicle that can catch enemy spaceships and turn them into lives for player1. Once enough enemies have been caught they can increase their speed using (numpadEnter)
CONTROLS : numpadMinus, numpadPlus for movement and numpadEnter for speedboost

There is a limited Menu screen that just displays game title and button to game scene.
Enemies spawn randomly and shoot at player 1 while moving straight down towards the bottom of the screen.
Once the game is over it will automatically reset.

The game is controled via the game manager which handles states Opening, Gameplay and Gameover.
A scheduler handles the enemy spawns.
