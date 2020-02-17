using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        scoreBoard.scoreHit(scorePerHit);

        GameObject deathFXInstance = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathFXInstance.transform.parent = parent;

        Destroy(gameObject);
    }
}
