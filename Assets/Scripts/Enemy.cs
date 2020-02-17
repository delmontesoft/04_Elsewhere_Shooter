using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

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
        GameObject deathFXInstance = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathFXInstance.transform.parent = parent;
        Destroy(deathFXInstance, 5f);

        Destroy(gameObject);
    }
}
