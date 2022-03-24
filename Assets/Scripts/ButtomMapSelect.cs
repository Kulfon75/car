using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtomMapSelect : MonoBehaviour, IPointerClickHandler
{
    public GameObject Player;
    public int mapa;
    public Vector3 mapPos;
    public ButtonStart Bst;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Bst.mapNum = mapa;
        Player.transform.position = mapPos;
        Camera.main.orthographicSize = 120;
    }
}
