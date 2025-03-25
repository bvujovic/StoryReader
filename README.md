# Story Reader
Text/story is read by selected voices installed on Windows

![Story Reader - Main Window](ScreenShots/FrmMain.png)

## TODO
- [ ] Bug fixes:
	- [x] File/Save doesn't work
	- [ ] Test&improve search with regular expressions
- [x] F1, F2, F3... for insert -default-, voice1, voice2...
- [x] Change keys (key kombinations) for Play/pause[, Stop]. Keypresses shouldn't interfere w/ other apps (VLC, IrfanView...)
	- [x] Just Ctrl+Shift+Z for play/pause?
- [ ] Add volume and rate to Voices table (DGV). Maybe switch to DS as a datasource.
- [ ] Improve txtOut
	- [ ] Change its type to RichTextBox
	- [ ] Mark currently read sentences (underline)
	- [ ] Mark different characters lines (back color - define a color in DGV)
	- [ ] User should play sentences by clicking on them; arrow keys: next/prev sentence
- [ ] Add File/New: New text/story
- [ ] Add new setting: light/dark mode
- [ ] Save/Load options (in DataSet?)
- [ ] Add button Validate, on click check:
	- [ ] do all characters in a story have a voice name, 
	- [ ] are all voices in the table installed,
	- [ ] are all oppened voice tags closed properly,
	- [ ] is there only 1 occurence of ***** line (header separator)

