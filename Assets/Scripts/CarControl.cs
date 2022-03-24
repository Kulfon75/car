using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    [Header("Carr Variables")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 20.0f;
    public float turningFactor = 0.3f;
    public float breakForce = 1.5f;
      
    float acceleration;
    float steeringImp;
    float rotationAngle;
    float TimeDrift = 0;
    float DragOnRoad = 3;
    float DragOnDirt = 20;

    float CurrentDrag = 0;

    Rigidbody2D carRigid;
    void Start()
    {
        carRigid = GetComponent<Rigidbody2D>();
        carRigid.drag = 3;
    }

    void Update()
    {
        CheckMovement();
        ForceCar();
        Steering();
        KillTorque();
    }

    void CheckMovement()
    {
        acceleration = Input.GetAxis("Vertical");
        steeringImp = Input.GetAxis("Horizontal");
        if(Input.GetKey("space"))
        {
            if(carRigid.drag < 100)
            carRigid.drag += carRigid.drag * breakForce * Time.deltaTime;
            if (driftFactor < 1)
            {
                driftFactor += 5f * Time.deltaTime;
                TimeDrift = 0.5f;
            }

        }
        else
        {
            carRigid.drag = CurrentDrag;
            if(driftFactor > 0)
                driftFactor -= 5 * Time.deltaTime;
            else
                TimeDrift -= Time.deltaTime;
        }
    }

    void ForceCar()
    {
        Vector2 engineForceVec = transform.up * acceleration * accelerationFactor;
        if(Mathf.Sqrt(carRigid.velocity.y * carRigid.velocity.y + carRigid.velocity.x * carRigid.velocity.x) < 40)
            carRigid.AddForce(engineForceVec, ForceMode2D.Force);
    }

    void Steering()
    {
        float minSpeedTurn = carRigid.velocity.magnitude / 8;
        minSpeedTurn = Mathf.Clamp01(minSpeedTurn);
        rotationAngle -= steeringImp * turningFactor * minSpeedTurn;
        carRigid.MoveRotation(rotationAngle);
    }

    void KillTorque()
    {
        Vector2 forwardVel = transform.up * Vector2.Dot(carRigid.velocity, transform.up);
        Vector2 rightVel = transform.right * Vector2.Dot(carRigid.velocity, transform.right);
        carRigid.velocity = forwardVel + rightVel * driftFactor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Dirt")
            {
                CurrentDrag = DragOnDirt;
            }
            if (collision.tag == "Road")
            {
                CurrentDrag = DragOnRoad;
            }
            if (collision.tag == "River")
            {
                carRigid.AddForce(collision.transform.up * 200, ForceMode2D.Force);
            }
        }
    }
}
