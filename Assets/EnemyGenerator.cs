using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private int stagelevel;
    public GameObject enemy;
    private int i;
    private bool instEnd;

    // Start is called before the first frame update
    void Start()
    {
        stagelevel = PlayerPrefs.GetInt("StageLevel", 1);
        instEnd = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instEnd == false)
        {
            for (i = 0; i < stagelevel; i++)
            {
                Instantiate(enemy, new Vector3(5, 1, -35), Quaternion.identity);
                if (i == stagelevel - 1)
                {
                    instEnd = true;
                }
            }
        }
    }
}
