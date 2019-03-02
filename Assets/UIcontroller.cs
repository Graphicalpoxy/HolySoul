using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Slider slider;
    public Text Level;
    private GameObject player;
    public Slider EXPSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Level.GetComponent<Text>().text = "LEVEL" + player.GetComponent<PlayerStatus>().LEVEL;
        slider.GetComponent<Slider>().value = player.GetComponent<PlayerStatus>().HP ;
        EXPSlider.GetComponent<Slider>().value = player.GetComponent<PlayerStatus>().EXP;
    }
}
