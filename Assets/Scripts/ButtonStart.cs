using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonStart : MonoBehaviour, IPointerClickHandler
{
    public Canvas menu;
    public int mapNum;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Camera.main.orthographicSize = 34;
        menu.enabled = false;
    }
}
