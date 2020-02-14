using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider addedBoxCollider = gameObject.AddComponent<BoxCollider>();
        addedBoxCollider.isTrigger = false;
        addedBoxCollider.enabled = true;
    }

    void OnParticleCollision(GameObject other)
    {
        print("BOOM!");
        Destroy(gameObject);
    }
}
