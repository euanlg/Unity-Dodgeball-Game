using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorelvl2 : MonoBehaviour {

    private int scoredp;
    private int scoredai;
    public Text playerscore;
    public Text aiscore;

    void Update(){
        scoredp = sp_ball2.pscore;
        scoredai = sp_ball2.aiscore;

        playerscore.text = "" + scoredp.ToString();
        aiscore.text = "" + scoredai.ToString();

    }
}
