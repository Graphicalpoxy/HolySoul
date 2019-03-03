using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int stagelevel;
    public GameObject teleporterPre;
    private bool change;
    private bool stagelevelupper;

    // Start is called before the first frame update
    void Start()
    {
        stagelevel = PlayerPrefs.GetInt("StageLevel", 1);
        change = false;
        stagelevelupper = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (change == false)
        {
            if (enemies.Length == 0)
            {
                Instantiate(teleporterPre, new Vector3(4.9f, 0, -30f), Quaternion.identity);
                if (stagelevelupper == true)
                {
                    StageLevelUP();
                    stagelevelupper = false;
                    change = true;
                }
                 

            }
        }

    }


    void StageLevelUP()
    {
        stagelevel = stagelevel + 1;
        PlayerPrefs.SetInt("StageLevel", stagelevel);
    }


}
