using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loc_multi_spawn_lvl2 : MonoBehaviour {

    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform p4;
    public GameObject p1_spawn;
    public GameObject p2_spawn;
    public GameObject p3_spawn;
    public GameObject p4_spawn;
    public GameObject line_spawn;
    public GameObject P2_line;
    public GameObject P3_line;
    public GameObject P4_line;

    void Awake(){
        if (local_m_player.p1Join && local_m_player.p2Join && !local_m_player.p3Join && !local_m_player.p4Join){
            Instantiate(p1, p1_spawn.transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(p2, p2_spawn.transform.position, Quaternion.Euler(0, -90, 0));
            Instantiate(P2_line, line_spawn.transform.position, Quaternion.Euler(line_spawn.transform.position.x, line_spawn.transform.position.y, line_spawn.transform.position.z));
        }

        if (local_m_player.p1Join && local_m_player.p2Join && local_m_player.p3Join && !local_m_player.p4Join){
            Instantiate(p1, p1_spawn.transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(p2, p2_spawn.transform.position, Quaternion.Euler(0, -90, 0));
            Instantiate(p3, p3_spawn.transform.position, Quaternion.Euler(0, 180, 0));
            Instantiate(P3_line, line_spawn.transform.position, Quaternion.Euler(line_spawn.transform.position.x, line_spawn.transform.position.y, line_spawn.transform.position.z));

        }
        if (local_m_player.p1Join && local_m_player.p2Join && local_m_player.p3Join && local_m_player.p4Join){
            Instantiate(p1, p1_spawn.transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(p2, p2_spawn.transform.position, Quaternion.Euler(0, -90, 0));
            Instantiate(p3, p3_spawn.transform.position, Quaternion.Euler(0, 180, 0));
            Instantiate(p4, p4_spawn.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(P4_line, line_spawn.transform.position, Quaternion.Euler(line_spawn.transform.position.x, line_spawn.transform.position.y, line_spawn.transform.position.z));
        }
    }
}
