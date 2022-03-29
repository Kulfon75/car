using UnityEngine;
public class ButtomMapSelect : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int mapa;
    [SerializeField] private Vector3 mapPos;
    [SerializeField] private ButtonStart Bst;
    [SerializeField] private GameObject MapObj;

    public void SelectMap()
    {
        Destroy(Bst.CurrentMapObj.gameObject);
        Bst.CurrentMapObj = Instantiate(MapObj);
        Bst.mapNum = mapa;
        Player.transform.position = mapPos;
        Camera.main.orthographicSize = 120;
    }

}
