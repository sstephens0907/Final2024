# Final2024
The goal is for Alice to catch the Rabbit. However, there are obstacles along her way. The Caterpillar blows smoke which sends Alice flying. The Cat stuns Alice if she gets too close. The Rabbit, Caterpillar, and Cat are always moving so Alice has to be ready. Alice can also get tangled in the Flowers, slowing her down. There are also Rabbit Holes that send Alice to another platform if she falls in them.

Alice
dress changes when she's jumping, falling, or idle
turns grey if stunned by Cat

Rabbit
Teleports on an interval
Has a particle system (with new added material) that activates just before he leaves, as an indicator that he's about to change positions

Caterpillar
Teleports on an interval
Has a particle system that activates when Alice is within a specific distance
Has a trigger to push Alice if she is within a specific distance

Cat
Teleports on an interval
Has a color-changing particle system
Has a trigger to stun Alice if she is within a specific distance

Flowers
On a different sorting level so Alice can move behind them
Has a trigger that slows Alice's speed when she is within a specific distance
 
