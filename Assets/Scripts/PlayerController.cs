using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    private float turningForce = 100f;
    [SerializeField]
    private float stopForce = 50f;
    [SerializeField]
    // private GameObject brakeAnimation;
    private float movement;
    private float rotation;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        moveCar();
        turningCar();
        if (movement > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            stopCar();
        }
    }

    public void moveCar()
    {
        rb.AddRelativeForce(Vector3.forward * movement * speed);
        // brakeAnimation.SetActive(false);
    }

    public void turningCar()
    {
        Quaternion t = Quaternion.Euler(Vector3.up * rotation * turningForce * Time.deltaTime);
        rb.MoveRotation(rb.rotation * t);
    }

    public void stopCar()
    {
        if (rb.velocity.z != 0)
        {
            rb.AddRelativeForce(-Vector3.forward * stopForce);
            // brakeAnimation.SetActive(true);
        }
    }
}
