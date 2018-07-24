### What we have done on the hackathon
We have done a blockchain game named Head & Road and have found critical bug in SDK which didn't allow to sent transactions correctly.

This is a PvP Fighter with a possibility of collecting unique items. Users fight in an arena using cars. You have to destroy the head of your opponent car’s driver to win.

This is how our interface looks like.

At the beginning of your session you should collect your car from some items like head, car body and wheels.
<p align="center">
  <img src="Enter.jpg" width="350" title="Create your car.">
</p>

Then you can fight with your opponent on some arenas like this.

<p align="center">
  <img src="Fight1.png" width="350" title="First fight.">
</p>

Or like this.
<p align="center">
  <img src="Fight2.jpg" width="350" title="Second fight.">
</p>

At the end of every session we generate the transaction in the Pravda blockchain with all the information about this fight: types of the cars, users, addresses and the result of the fight.

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


There is a <a href="https://www.youtube.com/watch?v=TVfSyeEHNcQ"> Life demo </a> of our game.

All code was written in C# and you can find it in this github.

To be convenience we have done the shell <a href="https://github.com/glushenkovIG/GameNodeHackathon/blob/master/Compile%26Deploy.file" >scrypt </a> for compiling, deploying and calling fight method.

Start the <a href="http://download.expload.com/expload-desktop/"> expload-desktop </a> and use tutorial below to play our game.
1) Download archive <a href="https://github.com/glushenkovIG/GameNodeHackathon/blob/master/GameForMac.zip"> GameForMac.zip </a> / <a href="https://github.com/glushenkovIG/GameNodeHackathon/blob/master/GameForLinux.zip"> GameForLinux.zip </a>, and run the game. (This is a version for two players, use letters "A"/"D" and Arrow keys to control left and right car)
2) After you win your opponent confirm the transaction to write this event in blockchain.

### Future

We are going to add big economic part of our game. Exchange for unique cars, shops with useful parts of cars and upgrage of current car workshop are coming soon.
