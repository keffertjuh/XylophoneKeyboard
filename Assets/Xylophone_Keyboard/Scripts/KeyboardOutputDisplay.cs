using UnityEngine;
using System;
using System.Collections;

public class KeyboardOutputDisplay : KeyboardOutputObject {

    private TextMesh display;

    void Awake() {
        display = GetComponentInChildren<TextMesh>();
    }

    public override void ReceiveKeyboardOutput(string value) {
        handleOverflowHorizontal();
        display.text += value;
    }

    public override void ReceiveKeyboardOutputEnter() {
        display.text += System.Environment.NewLine;
        handleOverflowVertical();
    }

    public override void ReceiveKeyboardOutputBackspace() {
        int displayTextLength = display.text.Length;
        if (displayTextLength != 0) {
            if (display.text.Substring(Math.Max(0, displayTextLength - System.Environment.NewLine.Length)) == System.Environment.NewLine) {
                display.text = display.text.Substring(0, displayTextLength - System.Environment.NewLine.Length);
            } else {
                display.text = display.text.Substring(0, displayTextLength - 1);
            }
        }
    }

    // Keep things within the plane area and create room for the new text; 33 chars wide and 6 lines long
    private void handleOverflowHorizontal() {
        string[] lines = display.text.Split('\n');
        int lastLineLength = lines[lines.Length - 1].Length;
        if (lastLineLength >= 30) {
            handleOverflowVertical();
            display.text += System.Environment.NewLine;
        }
    }

    private void handleOverflowVertical() {
        string[] lines = display.text.Split('\n');
        int numberOfLines = lines.Length;
        if (numberOfLines >= 6) {
            // remove first line
            int index = display.text.IndexOf(System.Environment.NewLine);
            string newText = display.text.Substring(index + System.Environment.NewLine.Length);
            display.text = newText;
        }
    }
}
