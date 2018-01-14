using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loc_multi_score_ui : MonoBehaviour {

    public Canvas scoreCanvas2p;
    public Canvas scoreCanvas3p;
    public Canvas scoreCanvas4p;

    void Awake(){
        scoreCanvas2p.enabled = false;
        scoreCanvas3p.enabled = false;
        scoreCanvas4p.enabled = false;
    }
    void Update(){
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == false && local_m_player.p4Join == false)
        {
            scoreCanvas2p.enabled = true;
        }
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == true && local_m_player.p4Join == false)
        {
            scoreCanvas3p.enabled = true;
        }
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == true && local_m_player.p4Join == true)
        {
            scoreCanvas4p.enabled = true;
        }
    }
}
