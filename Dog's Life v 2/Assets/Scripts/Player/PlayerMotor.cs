using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]


public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camerarotation = Vector3.zero;
    private Rigidbody rb;
    public static Vector3 playerPos;
    public bool isGrounded;
  void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(TrackPlayer());
    }

    IEnumerator TrackPlayer()
    {
        while (true)
        {
            playerPos = gameObject.transform.position;
            yield return null;
        }

    }

    //Gets movement vector 
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Gets rotation vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Gets camera rotation vector
    public void CameraRotate(Vector3 _camerarotation)
    {
        camerarotation = _camerarotation;
    }

    //Run every physics iteration (on a fixed time)
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
      
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero) 
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        
        if(cam!=null)
        {
            cam.transform.Rotate(-camerarotation);

        }

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}