## Introduction ##
Here are the basic quick start information for MagicWords, it will tell you how to type existing MagicWord and how to add some new ones.

## Show the input box ##
MagicWords command line textbox is hidden by default, so when the program start you just see an icon in the tray bar. To display the textbox and enter a magic word, you can :
  * double click on the MagicWords tray icon
  * right click on the tray icon, and click on "Show"
  * right click on the tray icon, and select the "MagicWords" menu item, it will show your MagicWords library as children menu items.
  * or the fastest way : press the CTRL-F12 hotkey

The input box use build in autocompletion feature, so your MagicWord will probably be completed after typing 2 or 3 caracters.


## How to open the new MagicWord dialog ##

You can add a new magic word, the following ways:

  * right click the tray icon, and click on "New MagicWord..." item. The new MagicWord form is then displayed
  * Right click the tray icon, and click on the "Setup.." item. An editable MagicWords data grid view is displayed, there you can view your Magic Words library, edit, insert or delete MagicWords.
  * Finally you can add the current focused application by pressing the CTRL-F11 hotkey combinaison. The new MagicWord form will be displayed, filled with current focused application data.

## MagicWord data ##
  * Alias = the 'magicword' that will lauchn the file
  * Filename =  the file to open
  * Arguments = arguments that will be passed to the file
  * Startup path = the working directory (very optional)
  * Startup mode = indicates the the window style (normal, maximized, minimized, etc)
  * Notes: some comment. will also be display on the argument input form

## Variables ##
Variables can be used in either the 'filename' or the 'arguments' data of a MagicWord, it used to create dynamic magicword.

Available variables are:
  * $I$: a simple word replacement, a form is opened to allow user to type the input.
  * $W$: urlencoded version of $I$
  * $C$: clipboard data
  * $FILE$: replaced by a filename, a Open file dialog is poped up.

Variables can be add via the MagicWords extensibility framework, more on the [ExtensibilityPage](ExtensibilityPage.md).

Usage samples:
  * Google map: http://www.google.com/maps?f=q&hl=fr&q=$W$&ie=UTF8&z=16&s&om=1&iwloc=addr

## BuildIn MagicWords ##
  * setup : open the option form
  * hide : hide the input form in the tray
  * exit : terminate the application
  * add : open the new magicword form
  * help : open the online help

## Other information ##
Your MagicWords library is automatically saved.