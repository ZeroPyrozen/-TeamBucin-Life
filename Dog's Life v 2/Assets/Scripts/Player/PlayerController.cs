using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float sensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>(); 
    }

    void Update()
    {
        //Calculate movement velocity as a 3D Vector
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed; //direction * speed

        //Apply movement
        motor.Move(velocity);

        //Calculate rotation as a 3D vector
        float yRot = Input.GetAxisRaw("Mouse X"); //turn around

        Vector3 rotation = new Vector3(0f, yRot, 0f) * sensitivity;

       //Apply rotation
        motor.Rotate(rotation);

        //Calculate camera rotation as a 3D vector
        float xRot = Input.GetAxisRaw("Mouse Y"); //tilt

        Vector3 camerarotation = new Vector3(xRot , 0f, 0f) * sensitivity;

        //Apply camera rotation
        motor.CameraRotate(camerarotation);
    }


}
