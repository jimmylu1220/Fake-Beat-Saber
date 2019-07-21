using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,IPointerUpHandler, IPointerClickHandler
{
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.grey;
    public Color32 m_DownColor = Color.white;

    private Image m_Image = null;
    public GameObject button1, button2;
    public GameObject[] scene;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
        for (int i = 0; i < scene.Length; i++)
        {//將其他場景先停止
            scene[i].SetActive(false);
        }
        button1.SetActive(true);
        button2.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Enter");
        m_Image.color = m_HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Exit");
        m_Image.color = m_NormalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
        m_Image.color = m_DownColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("Click");
        button1.SetActive(false);
        button2.SetActive(true);
        m_Image.color = m_HoverColor;

    }

}
