### What we have done on the hackathon
We have done a blockchain game named Head & Road and have found a critical bug in the SDK which didn't allow to send transactions correctly.

This is a PvP Fighter with a possibility of collecting unique items. Users fight in an arena using cars. You have to destroy the head of your opponent car’s driver in order to win.

This is how our interface looks like.

At the beginning of your session you should compose your car from items such as head, car body and wheels.
<p align="center">
  <img src="Enter.jpg" width="350" title="Create your car.">
</p>

Then you can fight with your opponent on a number of arenas, like this.

<p align="center">
  <img src="Fight1.png" width="350" title="First fight.">
</p>

Or like this.
<p align="center">
  <img src="Fight2.jpg" width="350" title="Second fight.">
</p>

At the end of every session we generate a transaction in the Pravda blockchain with all the information about this fight: types of the cars, users, addresses, and the result of the fight.

```
curl -X POST -H "Content-Type: application/json" --data '{"address": "21B262DDCF883D69D4642CFA21E39B463F143BA0729D195E16C3E9BD1BC139EA", "method":
 "Fight", "args": [
 {"tpe": "bytes", "value": "e30a267aef6240cf28c4761aa7da32e14e8016e24d033549c4ed2c7eaa177082"},
 {"tpe": "bytes", "value": "fcd158bb6bddebc9fadbe12df4ce2accb0e5360fc059e10c7eb3c0828c022832"}] }'
localhost:8087/api/program/method
```

<p align="center">
  <img src="Transaction.jpg" width="350" title="Transaction.">
</p>


There is a <a href="https://www.youtube.com/watch?v=TVfSyeEHNcQ">Live demo</a> of our game.

All the code was written in C#; you can find it in this repo.

We made a convenience shell <a href="https://github.com/glushenkovIG/GameNodeHackathon/blob/master/Compile%26Deploy.file">script</a> wrapper for compiling, deploying and calling the "fight" method.

Start <a href="http://download.expload.com/expload-desktop/">expload-desktop</a> and use the tutorial below to play our game.

1) Download the archive <a href="https://github.com/glushenkovIG/GameNodeHackathon/blob/master/GameForMac.zip">GameForMac.zip</a> / <a href="https://github.com/glushenkovIG/GameNodeHackathon/blob/master/GameForLinux.zip">GameForLinux.zip</a>, and run the game. (This is a version for two players, use letters "A"/"D" and Arrow keys to control the left and right cars, respectively.)

2) After you win, confirm the transaction to write this event to the blockchain.

### Future

<!-- We are going to add big economic part of our game. -->An exchange for unique cars, shops with useful parts for the cars, and workshops for upgrading current cas are coming soon.
