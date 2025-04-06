# Story Reader
Text/story is read by selected voices installed on Windows

![Story Reader - Main Window](ScreenShots/FrmMain.png)

## TODO
- [ ] Bug fixes:
	- [ ] Test&improve search with regular expressions
- [x] Click on Speak -> Don't (stop) + Speak
- [x] Save/Load settings (in DataSet?): font size, windows size&location, searches
	- [x] Find text/search: txt -> cmb (recent searches&replaces)
- [ ] Add new setting: light/dark mode
- [ ] Make a list of keypresses: documentation (in code) and/or in user interface
- [ ] Add volume and rate to Voices table (DGV). Maybe switch to DS as a datasource.
- [ ] Improve txtOut
	- [ ] Change its type to RichTextBox
	- [ ] Mark currently read sentences (underline)
	- [ ] Mark different characters lines (back color - define a color in DGV)
	- [ ] User should play sentences by clicking on them; arrow keys: next/prev sentence
- [ ] Add File/New: New text/story
- [ ] Add button Validate, on click check:
	- [ ] do all characters in a story have a voice name, 
	- [ ] are all voices in the table installed,
	- [ ] are all oppened voice tags closed properly,
	- [ ] is there only 1 occurence of ***** line (header separator)
