using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KeyboardKeyBackspace : KeyboardKey {

	void Update () {
        if (isHit) {
            foreach (KeyboardOutputObject target in parentKeyboard.GetOutputObjects()) {
                target.ReceiveKeyboardOutputBackspace();
            }
            isHit = false;
        }
	}
}
