# Xylophone_Keyboard
A non-flat keyboard to use in VR.  

<br />
<br />
#Notes



Known issues:
- A new line takes 2 times a backspace to remove.
- The spacing between keys and/or the size of the example typing object causes a good amount of accidental mistyping.
- Text is somewhat blurry because I didn't pay too much mind to getting that to look nice.
  
<br />  
<br />  
Prefabs:

TextDisplay: 
An example of an object to output into.
It has a script that implements the KeyboardOutputObject behaviors.
This means it decides how to deal with any inputs, hitting enter, and hitting backspace.

TypingObject:
A simple mallet to hit the keys with.
The sphere at the end of the mallets has been indicated as the interacting object in the example scene.
The CameraRig controller models have been disabled and the mallets have been made into hands in their stead.

XylophoneKeyboard:
A keyboard object.
At the root is a script used to specify behaviors common to the keys;
- The material applied to keys by default and the material shown briefly when 'pressed'.
- The sound played when a key is pressed. (This can be overridden on a per-key basis by adding an AudioClip to the Audio Source)
- Objects that can be used to interact with the keyboard. In the example scene the top of the mallets is used.
- The objects that respond to keyboard input. In the example this is the text display. These have to implement the KeyboardOutputObject script.
The values of keys themselves is determined by the TextMesh in their child Text component.
Backspace and enter have separate update behavior for Uodate().
  
<br />  
<br />  
Ideas for improvement/expansion:
- Actual proper looking letters.
- Visual feedback in the form of movement (keys being pushed down)
- A button to switch to a different layout
- Option to summon the keyboard at correct height and relative transform based on the headset transform.
- Handle of some sort to move the keyboard to an appropriate position in VR.
- Alternative version with everything quite small for the steady-handed people who wanna go fast.
- Nicer models and materials / textures
- Varying sound feedback
- Keys lighting up in stead of recolor (or just a nicer material effect)
- Loading keys from a file, thus allowing for remapping different characters and potentially easier editing / keyboard switching
- ~



Ideas for uses:
- Searching and filtering (i.e. AudioShield song search)
- Alternative chat mechanism (for people without mic or just due to preference or other necessity; you can only communicate so much with your hands)
- Quick-selecting smileys to show a particular facial expression, or some other form of self-expression (i.e. the faces in Rec Room)
- ~
  
<br />  
<br />  
Super important mention of MIT license.
  
<br />  
<br />  
Do whatever you want with it; Any credit given is appreciated.  
Have fun.  
--- Keffertjuh
