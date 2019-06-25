using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    public List<Player> targets;
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<Player>();
    }
    private void Update() {
        try {
            foreach (Player e in targets) {
                if (e == null) {
                    targets.Remove(e);
                }
            }
        } catch (Exception e) {
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (transform.parent.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                targets.Add(other.gameObject.GetComponent<Player>());
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject.GetComponent<Player>());
    }
}
