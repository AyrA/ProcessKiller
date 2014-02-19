Process Killer
==============

Kills the focused Process with a keystroke.

Supported Keystrokes:
```
[ALT]+[BACKSPACE]                - Close
[CTRL]+[ALT]+[BACKSPACE]         - Close, then kill
[SHIFT]+[CTRL]+[ALT]+[BACKSPACE] - Kill instantly
```

Close
-----
This simply sends a close signal to the process. Nothing more.
The process exists normally (as if the user would).

Close, then kill
----------------
The same as close, but if the process hangs for 5 seconds, it is terminated.
If Process Killer detects, that a user input is required,
the process is not terminated. Instead two buttons appear in the info window.
The user can kill the process with these or leave it running.

Kill instantly
--------------
This terminates a process instantly. This does not allows it to save its work.
To prevent accidental use, this hotkey has to be pressed two times in a row.
