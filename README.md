ProcessKiller
=============

Kills the focused Process with a keystroke.

You can either use [CTRL]+[ALT]+[BACKSPACE] to close the main window.
This causes the process to exit normally, including any save/exit routines.
if you use [SHIFT]+[CTRL]+[ALT]+[BACKSPACE] the process is first asked to
exit normally (as it would without shift). After 5 seconds the reaction
depends on the process state. If it waits for input, the user can click
the "Kill anyway" button. If it hangs, it is terminated automatically.
