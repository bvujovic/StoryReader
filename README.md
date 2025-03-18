# Story Reader
Text/story is read by selected voices installed on Windows

![Story Reader - Main Window](ScreenShots/FrmMain.png)

## TODO
- [x] Text search should always start from current position (cursor)
	- [x] Text search could work with regular expressions
- [x] Add some sign that there are changes to text/story and/or ask user if he wants to save changes
- [x] Improve btnChangeVoiceName.Click
- [x] DoubleClick on table [Character column] -> btnApply.PerfClick()
- [ ] Add volume and rate to Voices table (DGV). Maybe switch to DS as a datasource.
- [x] Install more voices
- [ ] Improve txtOut
	- [ ] Change its type to RichTextBox
	- [ ] Mark currently read sentences (underline)
	- [ ] Mark different characters lines (back color)
	- [ ] User should play sentences by clicking on them; arrow keys: next/prev sentence
- [ ] Add File/New: New text/story
- [ ] Save/Load options (in DataSet?)
- [ ] Add button Validate, on click check:
	- [ ] do all characters in a story have a voice name, 
	- [ ] are all voices in the table installed,
	- [ ] are all oppened voice tags closed properly

