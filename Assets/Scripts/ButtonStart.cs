using UnityEngine;


public class ButtonStart : MonoBehaviour
{
    [SerializeField] private Canvas menu;
    public int mapNum;
    public GameObject CurrentMapObj;
    public void StartMap()
    {
        Camera.main.orthographicSize = 34;
        menu.enabled = false;
    }
}
