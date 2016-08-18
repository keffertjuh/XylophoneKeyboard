using UnityEngine;
using System.Collections;

public class XylophoneKeyboard : MonoBehaviour {

    public Material defaultKeyMaterial;
    public Material pressedKeyMaterial;
    public AudioClip pressedKeySound;
    public GameObject[] interactionObjects;
    public KeyboardOutputObject[] outputObjects;

    public Material GetDefaultKeyMaterial() {
        return this.defaultKeyMaterial;
    }
    public Material GetPressedKeyMaterial() {
        return this.pressedKeyMaterial;
    }
    public AudioClip GetPressedKeySound() {
        return this.pressedKeySound;
    }
    public GameObject[] GetInteractionObjects() {
        return this.interactionObjects;
    }
    public KeyboardOutputObject[] GetOutputObjects() {
        return this.outputObjects;
    }
}
