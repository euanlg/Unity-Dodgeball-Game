using UnityEngine;
using System.Collections;

public class sp_score_reset : MonoBehaviour {

    void Awake(){
        sp_ball.pscore = 0;
        sp_ball.aiscore = 0;
        sp_ball2.pscore = 0;
        sp_ball2.aiscore = 0;
        loc_multi_ball.p1score = 0;
        loc_multi_ball.p2score = 0;
        loc_multi_ball.p3score = 0;
        loc_multi_ball.p4score = 0;
        loc_multi_balllvl2.p1scorelvl2 = 0;
        loc_multi_balllvl2.p2scorelvl2 = 0;
        loc_multi_balllvl2.p3scorelvl2 = 0;
        loc_multi_balllvl2.p4scorelvl2 = 0;
    }

}
