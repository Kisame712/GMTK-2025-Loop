using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlaneController : MonoBehaviour
{
   
    [Header("Speed controls")]
    [SerializeField] private float maxForwardSpeed;
    [SerializeField] private float speedIncrement;
    [SerializeField] private float tiltResponsiveness;
    [SerializeField] private float turnResponsiveness;
    [SerializeField] private float liftResponsiveness;
    [SerializeField] private float liftPower;

    [Header("Plane effects and UI")]
    [SerializeField] private TextMeshProUGUI planeHUD;
    [SerializeField] private Transform rotator;
    [SerializeField] private GameObject smokeEffect;
    
    private float tiltResponseModifier { get { return (planeRb.mass / 10)  * tiltResponsiveness; } }
    private float turnResponseModifier { get { return (planeRb.mass / 10) * turnResponsiveness; } }
    private float liftResponseModifier { get { return (planeRb.mass / 10) * liftResponsiveness; } }

    private float throttle;
    private float turnAmount;  // along the same plane (left or right rudder)
    private float tiltAmount;  // out of the plane (like the plane is flipping sideways)
    private float liftAmount;  // out of plane (like the plane is making a loop literally)

    private bool isCrashed;

    Rigidbody planeRb;
    AudioSource audioSource;

    private void Awake()
    {
        isCrashed = false;
        planeRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(-97f, 3f, 0f);
    }


    private void Update()
    {
        if (isCrashed)
        {
            return;
        }
        PlaneRotation();
        UpdateHUD();

        rotator.Rotate(Vector3.right * throttle);
        audioSource.volume = (throttle * 0.01f)/2;

    }

    private void PlaneRotation()
    {
        turnAmount = Input.GetAxis("Yaw");
        tiltAmount = Input.GetAxis("Pitch");
        liftAmount = Input.GetAxis("Roll");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            throttle += speedIncrement;
        }

        else if (Input.GetKey(KeyCode.LeftControl))
        {
            throttle -= speedIncrement;
        }

        throttle = Mathf.Clamp(throttle, 0, 100f);
     
    }
    
    private void FixedUpdate()
    {
        if (isCrashed)
        {
            return;
        }
        MovePlaneRigidBody();
    }

    private void MovePlaneRigidBody()
    {
        planeRb.AddForce(transform.right * maxForwardSpeed * throttle);
        planeRb.AddTorque(transform.up * turnAmount * turnResponseModifier);
        planeRb.AddTorque(-transform.right * liftAmount * liftResponseModifier);
        planeRb.AddTorque(transform.forward * tiltAmount * tiltResponseModifier);

        planeRb.AddForce(Vector3.up * planeRb.linearVelocity.magnitude * liftPower);

    }

    private void UpdateHUD()
    { 
        planeHUD.text = "Throttle : " + throttle.ToString("F0") + "%\n";
        planeHUD.text += "Airspeed : " + (planeRb.linearVelocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
        planeHUD.text += "Altitude : " + transform.position.y.ToString("F0") + "m";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hazard")
        {
            StartCoroutine(SmokeEffect());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator SmokeEffect()
    {
        isCrashed = true;
        planeRb.linearVelocity = Vector3.zero;
        
        Instantiate(smokeEffect);
        yield return new WaitForSeconds(2);
    }
}
