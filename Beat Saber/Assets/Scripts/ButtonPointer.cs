﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPointer : MonoBehaviour
{
    public float m_DefaultLength = 5.0f; //預設長度
    public GameObject m_Dot;
    public VRInputModule m_InputModule; 

    private LineRenderer m_LineRenderer = null; //射線樣式

    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    
    // Update is called once per frame
    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {

        PointerEventData data = m_InputModule.GetData();
        float targetLength = m_DefaultLength;
        //float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLength : data.pointerCurrentRaycast.distance;

        RaycastHit hit = CreateRaycast(targetLength);
        Vector3 endPosition = transform.position + (transform.forward * targetLength); 

        if (hit.collider != null)
            endPosition = hit.point;

        m_Dot.transform.position = endPosition;
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);

        return hit;
    }
}
