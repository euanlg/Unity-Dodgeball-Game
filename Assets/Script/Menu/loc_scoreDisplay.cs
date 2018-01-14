using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loc_scoreDisplay : MonoBehaviour {

    public Text p1sc;
    public Text p2sc;
    public Text p3sc;
    public Text p4sc;


    void Update(){
        p1sc.text = "" + loc_multi_ball.p1score.ToString();
        p2sc.text = "" + loc_multi_ball.p2score.ToString();
        p3sc.text = "" + loc_multi_ball.p3score.ToString();
        p4sc.text = "" + loc_multi_ball.p4score.ToString();
    }

}
