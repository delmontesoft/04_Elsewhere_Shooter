﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }
}
