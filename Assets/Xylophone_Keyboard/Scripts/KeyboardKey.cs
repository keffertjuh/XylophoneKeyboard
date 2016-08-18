using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KeyboardKey : MonoBehaviour {

    protected XylophoneKeyboard parentKeyboard;
    private string value;
    protected bool isHit;
    List<GameObject> objectsInteracting;

    protected void Awake() {
        this.parentKeyboard = this.GetComponentInParent<XylophoneKeyboard>();

        TextMesh keyValue = GetComponentInChildren<TextMesh>();
        this.value = keyValue.text;
        
        this.GetComponent<Renderer>().material = parentKeyboard.defaultKeyMaterial;

        if (this.GetComponent<AudioSource>().clip == null) {
            this.GetComponent<AudioSource>().clip = parentKeyboard.GetPressedKeySound();
        }

        objectsInteracting = new List<GameObject>();
    }

    void Update () {
        if (isHit) {
            foreach (KeyboardOutputObject target in parentKeyboard.GetOutputObjects()) {
                target.ReceiveKeyboardOutput(value);
            }
            isHit = false;
        }
	}


    // Check if we're dealing with an object we can interact with (or one of their children)
    // If so, set the isHit flag to true and indicate to the user that a hit has been made
    // TODO: Find cleaner way to handle the use cases
    protected void OnTriggerEnter(Collider other) {
        foreach (GameObject go in parentKeyboard.GetInteractionObjects()) {
            GameObject objectToCheck = other.gameObject;
            while (!(objectToCheck == null)) {
                if (objectsInteracting.Contains(objectToCheck)) {
                    return; // Stop if we already had a collision with another child object that did not exit yet
                }
                if (objectToCheck.Equals(go)) {
                    isHit = true;
                    objectsInteracting.Add(objectToCheck);
                    DisplayHit();
                    return;
                }
                objectToCheck = (objectToCheck.transform.parent == null) ? null : objectToCheck.transform.parent.gameObject;
            }
        }
    }

    protected void OnTriggerExit(Collider other) {
        GameObject objectToCheck = other.gameObject;
        while (!(objectToCheck == null)) {
            if (objectsInteracting.Remove(objectToCheck)) {
                return;
            }
            objectToCheck = (objectToCheck.transform.parent == null) ? null : objectToCheck.transform.parent.gameObject;
        }
    }

    private void DisplayHit() {
        // Play hitsound
        this.GetComponent<AudioSource>().Play();

        // Change material for a short moment
        StartCoroutine(KeyPressMaterialCoroutine());
    }

    private IEnumerator KeyPressMaterialCoroutine() {
        this.GetComponent<Renderer>().material = parentKeyboard.pressedKeyMaterial;
        yield return new WaitForSeconds(.2f);
        this.GetComponent<Renderer>().material = parentKeyboard.defaultKeyMaterial;
    }
}
