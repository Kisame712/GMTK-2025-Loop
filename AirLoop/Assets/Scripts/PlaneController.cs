using UnityEngine;

public class PlaneController : MonoBehaviour
{
   
    [Header("Speed controls")]
    [SerializeField] private float maxForwardSpeed;
    [SerializeField] private float speedIncrement;
    [SerializeField] private float tiltResponsiveness;
    [SerializeField] private float turnResponsiveness;
    [SerializeField] private float liftResponsiveness;
   
    private float tiltResponseModifier { get { return planeRb.mass / 10  * tiltResponsiveness; } }
    private float turnResponseModifier { get { return planeRb.mass / 10 * turnResponsiveness; } }
    private float liftResponseModifier { get { return planeRb.mass / 10 * liftResponsiveness; } }

    private float forwardSpeed;
    private float turnAmount;  // along the same plane (left or right rudder)
    private float tiltAmount;  // out of the plane (like the plane is flipping sideways)
    private float liftAmount;  // out of plane (like the plane is making a loop literally)

    Rigidbody planeRb;

    private void Awake()
    {
        planeRb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        PlaneRotation();
    }

    private void PlaneRotation()
    {
        turnAmount = Input.GetAxis("Yaw");
        tiltAmount = Input.GetAxis("Pitch");
        liftAmount = Input.GetAxis("Roll");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            forwardSpeed += speedIncrement;
        }

        else if (Input.GetKey(KeyCode.LeftControl))
        {
            forwardSpeed -= speedIncrement;
        }

        forwardSpeed = Mathf.Clamp(forwardSpeed, 0, maxForwardSpeed);
     
    }
    
    private void FixedUpdate()
    {
        MovePlaneRigidBody();
    }

    private void MovePlaneRigidBody()
    {
        planeRb.AddForce(transform.right * forwardSpeed , ForceMode.Acceleration);
        planeRb.AddTorque(transform.up * turnAmount * turnResponseModifier, ForceMode.VelocityChange);
        planeRb.AddTorque(-transform.right * liftAmount * liftResponseModifier, ForceMode.VelocityChange);
        planeRb.AddTorque(transform.forward * tiltAmount * tiltResponseModifier, ForceMode.VelocityChange);
    }

}
