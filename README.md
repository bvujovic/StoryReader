# Story Reader
Text/story is read by selected voices installed on Windows

![Story Reader - Main Window](ScreenShots/FrmMain.png)

## TODO
- [ ] Bug fixes:
	- [ ] Test&improve search with regular expressions
- [ ] Code cleanup: remove commented lines of code in FrmMain, Speaker
- [x] Add context menu with Find Selection: find selected text from rtbOut in txtIn
- [x] User can enter a number without '%' for Volume or Rate in dgvVoices
- [ ] Make a list of keypresses: documentation (in code) and/or in user interface
	- [ ] Keypresses: 4, 5, 6 (on numeric keyboard) for backward, play/pause, forward?
- [ ] Improve txtOut
	- [x] Mark currently read sentences (underline)
	- [ ] User should play sentences by clicking on them; arrow keys: next/prev sentence
- [ ] Add File/New: New text/story
- [ ] Add button Validate, on click check:
	- [ ] do all characters in a story have a voice name, 
	- [ ] are all voices in the table installed,
	- [ ] are all oppened voice tags closed properly,
	- [ ] is there only 1 occurence of ***** line (header separator)

https://speechgen.io/en/node/prosody/#ank3
https://speechgen.io/en/node/multi-voice/
https://speechgen.io/en/node/emphasis/
<emphasis level='strong'></emphasis>