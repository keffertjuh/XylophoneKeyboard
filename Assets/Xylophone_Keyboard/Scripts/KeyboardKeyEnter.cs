using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KeyboardKeyEnter : KeyboardKey {

	void Update () {
        if (isHit) {
            foreach (KeyboardOutputObject target in parentKeyboard.GetOutputObjects()) {
                target.ReceiveKeyboardOutputEnter();
            }
            isHit = false;
        }
	}
}
