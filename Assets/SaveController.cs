using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveController : MonoBehaviour
{
    public int stagelevelsave;
    private int stagelevel;
    
    

    // Start is called before the first frame update
    void Start()
    {
        stagelevelsave = 1;
        stagelevelsave = PlayerPrefs.GetInt("STAGELEVEL", 1);
    }

    // Update is called once per frame
    void Update()
    {
        stagelevel = GameObject.Find("StageController").GetComponent<StageController>().stagelevel;

        if (stagelevel > stagelevelsave)
        {
            stagelevel = stagelevelsave;
            PlayerPrefs.SetInt("STAGELEVEL", stagelevel);
        }

    }
}
