using UnityEngine;
using UnityEngine.UI;

public class ChangeCar : MonoBehaviour
{
    [SerializeField] private CarObj car;
    [SerializeField] private Text Acceleration;
    [SerializeField] private Text BreakForce;
    [SerializeField] private Text WeelDrag;
    [SerializeField] private Text CarGrip;
    [SerializeField] private CarControl CarC;

    public void ChangeCarFunc()
    {
        Acceleration.text = car.accelerationFactor.ToString();
        BreakForce.text = car.breakForce.ToString();
        WeelDrag.text = car.DragOnRoad.ToString();  
        CarGrip.text = car.turningFactor.ToString();    
        CarC.car = car;
        CarC.SwicthCar();
    }
}
