using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;
    private float range = 5.0f;
    void Start()
    {
        Debug.Log("Start");
        if(cam==null)
        {
            Debug.Log("Error, No Camera Detected!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Shoot");
            Shoot();
        }
        
    }
    void Shoot()
    {
        RaycastHit _hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit,range, mask))
        {
            string objectName = _hit.collider.name;
            Debug.Log(_hit.collider.name);
            if(objectName.Contains("Cat"))
            {
                Debug.Log("Cat Found!");
                Destroy(_hit.transform.gameObject);
            }
        }
    }
}
