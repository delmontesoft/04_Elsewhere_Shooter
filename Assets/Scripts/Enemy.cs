using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hitPoints = 3;

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
        ProcessHit();

        if (hitPoints <= 0)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        scoreBoard.scoreHit(scorePerHit);
        //TODO consider add hit FX
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
        GameObject deathFXInstance = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathFXInstance.transform.parent = parent;

        Destroy(gameObject);
    }
}
