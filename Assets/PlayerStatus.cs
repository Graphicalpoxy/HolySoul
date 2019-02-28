using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int HP;
    public int EXP;
    public int LEVEL;


    // Start is called before the first frame update
    void Start()
    {
        LEVEL = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HP);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            if (!Input.GetMouseButton(1))
            {
                HP = HP - 3;
                Debug.Log("ダメージ");
            }
        }
        if (EXP == 5)
        {
            LEVEL = LEVEL + 1;
            EXP = 0;
        }

    }

    public void EXPup()
    {
        EXP = EXP + 1;
    }

}
