﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIcontroller : MonoBehaviour
{
    public Slider slider;
    private GameObject enemy;
    public Canvas enemycanvas;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        slider.GetComponent<Slider>().value = GetComponent<EnemyStatus>().enemyHP;
        enemycanvas.transform.rotation = Camera.main.transform.rotation;
    }
}
