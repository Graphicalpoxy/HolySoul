using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int enemyHP;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      


    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<EnemyController>().GetState() != EnemyController.EnemyState.Guard)
        {
            if (other.gameObject.tag == "PlayerWeapon")
            {
                enemyHP = enemyHP - 3;
                Debug.Log("ダメージ");
            }
        }
    }

}