using UnityEngine;

public class CarControl : MonoBehaviour
{
    [Header("Carr Variables")]
    [SerializeField] private float driftFactor = 0.95f;
    [SerializeField] private float accelerationFactor = 200.0f;
    [SerializeField] private float turningFactor = 2.0f;
    [SerializeField] private float breakForce = 0.9f;

    public CarObj car;

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
        SwicthCar();
        carRigid = GetComponent<Rigidbody2D>();
        carRigid.drag = 3;
    }

    void Update()
    {
        CheckMovement();
    }

    private void FixedUpdate()
    {
        ForceCar();
        Steering();
        KillTorque();
    }
    void CheckMovement()
    {
        acceleration = Input.GetAxis("Vertical");
        steeringImp = Input.GetAxis("Horizontal");
        if(Input.GetButton("Break"))
        {
            if(carRigid.drag < 100)
            carRigid.drag += carRigid.drag * breakForce * Time.deltaTime;
            if (driftFactor < 1)
            {
                driftFactor += 10f * Time.deltaTime;
                TimeDrift = 0.5f;
            }

        }
        else
        {
            carRigid.drag = CurrentDrag;
            if(driftFactor > 0)
                driftFactor -= 2 * Time.deltaTime;
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
        float minSpeedTurn = carRigid.velocity.magnitude;
        minSpeedTurn = Mathf.Clamp01(minSpeedTurn);
        if (acceleration < 0)
            steeringImp = -steeringImp;
        rotationAngle -= steeringImp * turningFactor * minSpeedTurn;
        
        carRigid.MoveRotation(rotationAngle);
    }

    void KillTorque()
    {
        Vector2 forwardVel = transform.up * Vector2.Dot(carRigid.velocity, transform.up);
        Vector2 rightVel = transform.right * Vector2.Dot(carRigid.velocity, transform.right);
        carRigid.velocity = forwardVel + rightVel * driftFactor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Road")
        {
            CurrentDrag = DragOnDirt;
        }
    }

    public void SwicthCar()
    {
        GetComponent<SpriteRenderer>().sprite = car.carSprite;
        driftFactor = car.driftFactor;
        accelerationFactor = car.accelerationFactor;
        turningFactor = car.turningFactor;
        breakForce = car.breakForce;
        DragOnDirt = car.DragOnDirt;
        DragOnRoad = car.DragOnRoad;
    }
}
