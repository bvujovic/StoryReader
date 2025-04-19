# Story Reader
Text/story is read by selected voices installed on Windows

![Story Reader - Main Window](ScreenShots/FrmMain.png)

## TODO
- [x] Move "Del \r\n" functionality from button to Edit menu item; remove button
- [x] Move file/story name from label to caption of the form; remove blue ribbon
- [x] Fix bad logic for using lastSentenceBack (FrmMain)
- [x] Add ctx menu for cmbFind with Remove item: remove saved search
- [x] Besides font size, remember rate and volume
- [x] Add new screenshot(s)
- [ ] Fix reading chapter names like 1.2 (dot is not the end of sentence)
- [ ] Add player for background sounds: mp3, remember folder with sounds, option: playing after Stop/Pause reading
- [ ] Remove leading spaces in paragraphs (rtbOut)
- [ ] Fix bugs regarding underlining: 2nd sentence is not underlined
- [ ] Bug fix: search initially jumps over first occurence
- [ ] Make a list of keypresses: documentation (in code) and/or in user interface
	- [x] Keypresses: F5, F6, F7 for play/pause, backward, forward
- [ ] Improve txtOut
	- [ ] Improve reliability of underlining currently read sentences
	- [ ] User should play sentences by clicking on them
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