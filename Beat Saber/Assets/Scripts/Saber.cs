using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;
    public SteamVR_Input_Sources hand;
    public TextMesh txt;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("Score").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Pulse(2, 50, 1000, hand);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer)) //碰到符合的方塊的layer
        {
            
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Pulse(2, 25, 2000, hand);
                score = Int32.Parse(txt.text);
                score++;
                txt.text = "Score: " + score.ToString();
                print("hit");
                Destroy(hit.transform.gameObject);
            }
        }
        previousPos = transform.position;
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        for (int i = 0; i < 100; i++)
        {
            hapticAction.Execute(0, duration, frequency, amplitude, source);

        }
        print("Pulse" + " " + source.ToString());
    }


}
