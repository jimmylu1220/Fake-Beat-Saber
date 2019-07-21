using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTransition2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.grey;
    public Color32 m_DownColor = Color.white;
   
    private Image m_Image = null;
    public GameObject menu_cam, menu_scene, stage_cam, stage_scene;
    private bool start = false;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
        
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
        menu_cam.SetActive(false);
        menu_scene.SetActive(false);
        stage_cam.SetActive(true);
        stage_scene.SetActive(true);
        UnityEditor.PrefabUtility.ResetToPrefabState(stage_scene);
        m_Image.color = m_HoverColor;

    }

}
