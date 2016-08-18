using UnityEngine;
using System.Collections;

// Purpose: do something with keyboard output; create a subclass to do so.
public abstract class KeyboardOutputObject : MonoBehaviour {
    public abstract void ReceiveKeyboardOutput(string value);
    public abstract void ReceiveKeyboardOutputEnter();
    public abstract void ReceiveKeyboardOutputBackspace();
}
