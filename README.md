# SQLScriptExecutioner
This is a small utility to make execution of sql scripts easy.

There have been a few instances when I got an .SQL script file and it was too big for SQL server to load.
The only we I was left was to use SQLCMD, but I had to look up the syntax each time.

So, this utility solves the problem. there are 2 wasys you could execute a script :
  * Using the RUN button (which uses SMO)
  * Using the SqlCmd Button (which calls into the SQLCMDD internally)
