# ********************************************
# *	         NEO-GEO-MINI ROM TOOL	         *
# *	        by your friend, Athene		       *
# ********************************************

# BEFORE YOU START:

I am not responsible for any damage to your device. This tool is provided as-is - it may have additional work in future but this is not guaranteed.

I highly recommend making a backup of your NGMH/ASP folder before you begin. 

This was designed around and tested with the Don Annis NGMH pack, no guarantees it'll work with any of the other distributions.

The maximum number of permitted roms in a folder by this tool is 80. If all your folders for a single emulator have 80 or more roms in them, a new folder will not be created - this should be done manually and added to the lang array ini file yourself.

# HOW TO:

1. load the exe. You'll be presented with a folder select dialog.
2. Pick your NGMH/ASP folder. I only own an NGMH but in theory ASP should work just fine the same way.
3. The main window will load - it may load minimised for some reason. 
4. On the left of the window are two grids - the upper grid is the list of emulators set up on your device. The lower grid is the list of roms for the selected emulator.
5. Selecting a rom in the lower grid will present you with the ROM data on the right of the window. The images, display name and directory/romid can be modified.
6. When you're happy with your changes, click Save Rom and the changes will be written to your NGMH/ASP folder.
7. Changing image is as simple as hitting load image, selecting an image with the file select dialog, and then saving the ROM. Resizing is done automatically, I'd recommend using square images for best results.
8. "Fix Roms" normalises your rom IDs to only be lowercase alphanumeric - there have been reported issues with the NGM refusing to recognise roms that aren't in this format. This is an automated process - one click and it's done.
9. To add a new rom, click "New Rom" then use the "Load" button to locate the (UNZIPPED) raw file e.g. Sonic2.md. Note that the file dialog does not filter by rom type, so please check that the emulator selected is correct for the ROM you are adding!
10. Add a rom display name and click ok to save the new rom. Note this will run the Fix Roms process and reload the lists within the app.
11. Your new rom will be at the bottom of the list of the selected emulator. You can then edit it as normal e.g. to add an image.
