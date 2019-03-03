using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetController : MonoBehaviour
{
    private bool resetbuttom;

    // Start is called before the first frame update
    void Start()
    {
        resetbuttom = false;
    }

    // Update is called once per frame
    public void Onclick()
    {
        Debug.Log("押す");
            PlayerPrefs.DeleteKey("StageLevel");
        
    }

}
