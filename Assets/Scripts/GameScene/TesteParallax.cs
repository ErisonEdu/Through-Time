﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TesteParallax : MonoBehaviour
{

    public GameObject cam;
    private float lenght, startpos;
    public float parallaxeffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (cam.transform.position.x * parallaxeffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z); 
    }
}
