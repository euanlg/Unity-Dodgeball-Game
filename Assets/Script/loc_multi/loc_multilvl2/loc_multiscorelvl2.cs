using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loc_multiscorelvl2 : MonoBehaviour {

    private int p1scorelvl2;
    private int p2scorelvl2;
    private int p3scorelvl2;
    private int p4scorelvl2;
    public Text[] p2scoretxtlvl2;
    public Text[] p3scoretxtlvl2;
    public Text[] p4scoretxtlvl2;

    void Update(){
        p1scorelvl2 = loc_multi_balllvl2.p1scorelvl2;
        p2scorelvl2 = loc_multi_balllvl2.p2scorelvl2;
        p3scorelvl2 = loc_multi_balllvl2.p3scorelvl2;
        p4scorelvl2 = loc_multi_balllvl2.p4scorelvl2;
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == false && local_m_player.p4Join == false){
            p2scoretxtlvl2[0].text = "" + p1scorelvl2.ToString();
            p2scoretxtlvl2[1].text = "" + p2scorelvl2.ToString();
        }
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == true && local_m_player.p4Join == false){
            p3scoretxtlvl2[0].text = "" + p1scorelvl2.ToString();
            p3scoretxtlvl2[1].text = "" + p2scorelvl2.ToString();
            p3scoretxtlvl2[2].text = "" + p3scorelvl2.ToString();
        }
        if (local_m_player.p1Join == true && local_m_player.p2Join == true && local_m_player.p3Join == true && local_m_player.p4Join == true){
            p4scoretxtlvl2[0].text = "" + p1scorelvl2.ToString();
            p4scoretxtlvl2[1].text = "" + p2scorelvl2.ToString();
            p4scoretxtlvl2[2].text = "" + p3scorelvl2.ToString();
            p4scoretxtlvl2[3].text = "" + p4scorelvl2.ToString();
        }
    }
}
