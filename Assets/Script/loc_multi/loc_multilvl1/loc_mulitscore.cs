using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loc_mulitscore : MonoBehaviour {

    private int p1score;
    private int p2score;
    private int p3score;
    private int p4score;
    public Text[] p2scoretxt;
    public Text[] p3scoretxt;
    public Text[] p4scoretxt;

    void Update(){
        p1score = loc_multi_ball.p1score;
        p2score = loc_multi_ball.p2score;
        p3score = loc_multi_ball.p3score;
        p4score = loc_multi_ball.p4score;
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == false && local_m_player.p4Join == false){
            p2scoretxt[0].text = "" + p1score.ToString();
            p2scoretxt[1].text = "" + p2score.ToString();
        }
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == true && local_m_player.p4Join == false){
            p3scoretxt[0].text = "" + p1score.ToString();
            p3scoretxt[1].text = "" + p2score.ToString();
            p3scoretxt[2].text = "" + p3score.ToString();
        }
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == true && local_m_player.p4Join == true){
            p4scoretxt[0].text = "" + p1score.ToString();
            p4scoretxt[1].text = "" + p2score.ToString();
            p4scoretxt[2].text = "" + p3score.ToString();
            p4scoretxt[3].text = "" + p4score.ToString();
        }  
    }
}
