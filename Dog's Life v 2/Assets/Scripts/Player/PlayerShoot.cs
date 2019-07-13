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
    public AudioSource sfx;
    public float fireRate = 3.0f;
    private float nextFire = 0.0f;
    public Player player;
    void Start()
    {
        Debug.Log("Start");
        if(cam==null)
        {
            Debug.Log("Error, No Camera Detected!");
        }
        sfx.SetScheduledEndTime(0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Debug.Log("Shoot");
            nextFire = Time.time + fireRate;
            Shoot();
        }
        
    }
    void Shoot()
    {
        sfx.Play();
        RaycastHit _hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit,range, mask))
        {
            string objectName = _hit.collider.name;
            
            Debug.Log(_hit.collider.name);
            if(objectName.Contains("Cat"))
            {
                Debug.Log("Cat Found!");
                player.AddPlayerScore(5);
                AICat cat =  _hit.transform.gameObject.GetComponent<AICat>();
                cat.TakeDamage(5);
                //Destroy(_hit.transform.gameObject);
            }
        }
    }

}
