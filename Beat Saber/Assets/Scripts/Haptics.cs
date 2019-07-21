using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Haptics : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;
    

    // Update is called once per frame
    void Update()
    {
        Pulse(2, 50, 1000, SteamVR_Input_Sources.LeftHand);
        if (trackpadAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Pulse(2, 50, 1000, SteamVR_Input_Sources.LeftHand);
        }
        if (trackpadAction.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            Pulse(2, 50, 1000, SteamVR_Input_Sources.RightHand);
        }
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);

        print("Pulse" + " " + source.ToString());
    } 
}
