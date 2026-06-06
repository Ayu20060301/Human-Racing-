using UnityEngine;
using UnityEngine.InputSystem;

public class PadInput : MonoBehaviour
{

    // ===== Button =====

    public static bool ADown(Gamepad pad) =>
        pad.buttonSouth.wasPressedThisFrame;

    public static bool AHeld(Gamepad pad) =>
        pad.buttonSouth.isPressed;

    public static bool BDown(Gamepad pad) =>
        pad.buttonEast.wasPressedThisFrame;

    public static bool BHeld(Gamepad pad) =>
        pad.buttonEast.isPressed;

    public static bool XDown(Gamepad pad) =>
        pad.buttonWest.wasPressedThisFrame;

    public static bool XHeld(Gamepad pad) =>
        pad.buttonWest.isPressed;

    public static bool YDown(Gamepad pad) =>
        pad.buttonNorth.wasPressedThisFrame;

    public static bool YHeld(Gamepad pad) =>
        pad.buttonNorth.isPressed;

    // ===== Trigger =====

    public static bool R2(Gamepad pad) =>
        pad.rightTrigger.ReadValue() > 0.8f;

    public static bool L2(Gamepad pad) =>
        pad.leftTrigger.ReadValue() > 0.8f;

    public static bool R1Down(Gamepad pad) =>
        pad.rightShoulder.wasPressedThisFrame;

    public static bool R1Held(Gamepad pad) =>
        pad.rightShoulder.isPressed;

    public static bool L1Down(Gamepad pad) =>
        pad.leftShoulder.wasPressedThisFrame;

    public static bool L1Held(Gamepad pad) =>
        pad.leftShoulder.isPressed;

    // ===== Stick =====

    public static float Steer(Gamepad pad) =>
        pad.leftStick.ReadValue().x;
}
