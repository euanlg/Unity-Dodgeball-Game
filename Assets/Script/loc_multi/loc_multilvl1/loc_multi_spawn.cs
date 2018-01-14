using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loc_multi_spawn : MonoBehaviour {

    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform p4;
    public GameObject p1_spawn;
    public GameObject p2_spawn;
    public GameObject p3_spawn;
    public GameObject p4_spawn;
    public GameObject col1;
    public GameObject col2;
    public GameObject col3;
    public GameObject col4;
    public GameObject cen1;
    public GameObject cen2;
    public GameObject cen3;
    public GameObject cen4;

    void Awake(){
        if (local_m_player.p1Join && local_m_player.p2Join && !local_m_player.p3Join && !local_m_player.p4Join){
            Instantiate(p1, p1_spawn.transform.position, Quaternion.Euler(0,90,0));
            Instantiate(p2, p2_spawn.transform.position, Quaternion.Euler(0,-90,0));

            Instantiate(col1, new Vector3(0, 0, 2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(col2, new Vector3(0, 0, -2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(cen1, new Vector3(0, 0, 2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(cen2, new Vector3(0, 0, -2.5f), Quaternion.Euler(0, 0, 0));
        }
        if (local_m_player.p1Join && local_m_player.p2Join && local_m_player.p3Join && !local_m_player.p4Join){
            Instantiate(p1, p1_spawn.transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(p2, p2_spawn.transform.position, Quaternion.Euler(0, -90, 0));
            Instantiate(p3, p3_spawn.transform.position, Quaternion.Euler(0, 90, 0));

            Instantiate(col1, new Vector3(0, 0, 2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(col3, new Vector3(3.5f, 0, 0), Quaternion.Euler(0, 90, 0));
            Instantiate(col4, new Vector3(-3.5f, 0, 0), Quaternion.Euler(0, 90, 0));
            Instantiate(cen1, new Vector3(0, 0, 2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(cen3, new Vector3(3.5f, 0, 0), Quaternion.Euler(0, 90, 0));
            Instantiate(cen4, new Vector3(-3.5f, 0, 0), Quaternion.Euler(0, 90, 0));

        }
        if (local_m_player.p1Join && local_m_player.p2Join && local_m_player.p3Join && local_m_player.p4Join){
            Instantiate(p1, p1_spawn.transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(p2, p2_spawn.transform.position, Quaternion.Euler(0, -90, 0));
            Instantiate(p3, p3_spawn.transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(p4, p4_spawn.transform.position, Quaternion.Euler(0, -90, 0));

            Instantiate(col1, new Vector3(0, 0, 2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(col2, new Vector3(0, 0, -2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(col3, new Vector3(3.5f, 0, 0), Quaternion.Euler(0, 90, 0));
            Instantiate(col4, new Vector3(-3.5f, 0, 0), Quaternion.Euler(0, 90, 0));
            Instantiate(cen1, new Vector3(0, 0, 2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(cen2, new Vector3(0, 0, -2.5f), Quaternion.Euler(0, 0, 0));
            Instantiate(cen3, new Vector3(3.5f, 0, 0), Quaternion.Euler(0, 90, 0));
            Instantiate(cen4, new Vector3(-3.5f, 0, 0), Quaternion.Euler(0, 90, 0));
        }
    }
}
