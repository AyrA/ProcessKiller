Old hook attempts
=================

I made a ton of attempts with global keyboard hooks.
First of all, hooks only work if you have an application loop.
They won't fire in a console only application.
Second, global keyboard hooks are somewhat messed up.
While they work fine when debugging (and possibly disable the vshost process),
they mess up when not debugging (or vice versa).
On some systems I even needed to press the modifiers in one specific order to work on.

Solution
--------

The solution was to switch from global hooks to hotkeys. Worked fine
from the beginning on but they need a message loop and a form, where
the WndProc function is overridden:

```C#
[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
protected override void WndProc(ref Message m)
{
	//BLABLA
}
```