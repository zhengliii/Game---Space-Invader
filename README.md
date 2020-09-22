# Game---Space-Invader
Sept 18
The player ship, enemy ships and bullets are added rigid body physics. After enemy ships are hit, it falls to the ground. The fallen enemy ships cannot destroy the player ship. The player cannot immediately achieve a point as hitting an enemy ship. The player should push the enemy ships into the vortex to get scores. But the enemy ship can explode in 4 seconds after being hit, in which case the player cannot get a score. The bullets from enemy are disruptive until they hit the ground, where they can accumulate. The player should push them in to the vortex to clear the ground.

Sept 21
I add UFO to the new version. I create a new resource ‘Star’. It appears randomly on the screen. If it is hit by the player’s bullet, an extra life can be rewarded. If it is not hit, it will disappear in 4 seconds. I also deploy the game to IOS platform. But I haven’t set the touch input. So I can only rotate the camera, but cannot move the player ship.