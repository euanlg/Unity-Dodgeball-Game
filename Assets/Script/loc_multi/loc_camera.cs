using System.Collections;
using UnityEngine;

public class loc_camera : MonoBehaviour{

    GameObject ball;
    GameObject p1;
    GameObject p2;
    GameObject p3;
    GameObject p4;
    public float smooth = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Start(){
        ball = GameObject.FindGameObjectWithTag("loc_ball");
        if (local_m_player.p1Join == true){
            p1 = GameObject.FindGameObjectWithTag("p1");
        }
        if (local_m_player.p2Join == true){
          p2 = GameObject.FindGameObjectWithTag("p2");
        }
        if (local_m_player.p3Join == true){
            p3 = GameObject.FindGameObjectWithTag("p3");
        }
        if (local_m_player.p4Join == true){
            p4 = GameObject.FindGameObjectWithTag("p4");
        }
    }


    void Update(){
        if (local_m_player.p1Join && local_m_player.p2Join && !local_m_player.p3Join && !local_m_player.p4Join){
            Vector3 pos = (p1.transform.position + p2.transform.position + ball.transform.position) / 3;
            pos.y = transform.position.y;
            pos.z = transform.position.z - 0f;
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
        }
        else if (local_m_player.p1Join && local_m_player.p2Join && local_m_player.p3Join && !local_m_player.p4Join){
            Vector3 pos = (p1.transform.position + p2.transform.position + p3.transform.position + ball.transform.position) / 4;
            pos.y = transform.position.y;
            pos.z = transform.position.z - 0f;
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
        }
        else if (local_m_player.p1Join && local_m_player.p2Join && !local_m_player.p3Join && local_m_player.p4Join){
            Vector3 pos = (p1.transform.position + p2.transform.position + p3.transform.position + p4.transform.position + ball.transform.position) / 5;
            pos.y = transform.position.y;
            pos.z = transform.position.z - 0f;
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
        }
    }
}

