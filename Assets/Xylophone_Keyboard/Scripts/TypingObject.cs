using UnityEngine;
using System.Collections;

public class TypingObject : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
        if (other.GetComponent<KeyboardKey>()) {
            int index = (int)gameObject.GetComponentInParent<SteamVR_TrackedObject>().index;
            SteamVR_Controller.Input(index).TriggerHapticPulse(500);
        }
    }
}
