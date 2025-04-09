# Story Reader
Text/story is read by selected voices installed on Windows

![Story Reader - Main Window](ScreenShots/FrmMain.png)

## TODO
- [ ] Bug fixes:
	- [ ] Test&improve search with regular expressions
	- [x] Overtype character: autoscroll goes to the top
- [x] Remember setting: light/dark mode
- [ ] Make a list of keypresses: documentation (in code) and/or in user interface
- [ ] Add pitch, volume and rate to Voices table (DGV)
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

https://speechgen.io/en/node/prosody/#ank3
https://speechgen.io/en/node/multi-voice/
https://speechgen.io/en/node/emphasis/

<voice name="cousin">
<prosody rate='130%' pitch='x-high'>Looks like it's your turn to do it</prosody>
</voice>
<voice name="default">
<prosody rate='slow' pitch='low'>my cousin said to me with a smile</prosody>
</voice>
<emphasis level='strong'></emphasis>