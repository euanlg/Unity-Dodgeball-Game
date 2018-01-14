using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loc_multi_balllvl2 : MonoBehaviour {

    int whichHold = 0;
    bool p1_hold;
    bool p1_throw;
    bool p2_hold;
    bool p2_throw;
    bool p3_hold;
    bool p3_throw;
    bool p4_hold;
    bool p4_throw;
    GameObject p1;
    GameObject p2;
    GameObject p3;
    GameObject p4;
    public static int p1scorelvl2 = 0;
    public static int p2scorelvl2 = 0;
    public static int p3scorelvl2 = 0;
    public static int p4scorelvl2 = 0;

    void Start(){
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

    private void Update(){
        if (local_m_player.p1Join == true){
            p1_hold = p1.GetComponent<p1_control>().p1_hold;
            p1_throw = p1.GetComponent<p1_control>().p1_throw;
        }
        if (local_m_player.p2Join == true){
            p2_hold = p2.GetComponent<p2_control>().p2_hold;
            p2_throw = p2.GetComponent<p2_control>().p2_throw;
        }
        if (local_m_player.p3Join == true){
            p3_hold = p3.GetComponent<p3_control>().p3_hold;
            p3_throw = p3.GetComponent<p3_control>().p3_throw;
        }
        if (local_m_player.p4Join == true){
            p4_hold = p4.GetComponent<p4_control>().p4_hold;
            p4_throw = p4.GetComponent<p4_control>().p4_throw;
        }
        if (p1_hold || p1_throw){
            whichHold = 1;
        }
        if (p2_hold || p2_throw){
            whichHold = 2;
        }
        if (p3_hold || p3_throw){
            whichHold = 3;
        }
        if (p4_hold || p4_throw){
            whichHold = 4;
        }
        if (!p1_hold && !p1_throw && !p2_hold && !p2_throw && !p3_hold && !p3_throw && !p4_hold && !p4_throw){
            whichHold = 0;
        }
        if (p1scorelvl2 >= 3 || p2scorelvl2 >= 3 || p3scorelvl2 >= 3 || p4scorelvl2 >= 3){
            SceneManager.LoadScene("loc_multi_scorelvl2");
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "p1"){
            switch (whichHold){
                case 2:
                    p2scorelvl2 = p2scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 3:
                    p3scorelvl2 = p3scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 4:
                    p4scorelvl2 = p4scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
            }
        }
        if (collision.gameObject.tag == "p2"){
            switch (whichHold){
                case 1:
                    p1scorelvl2 = p1scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 3:
                    p3scorelvl2 = p3scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 4:
                    p4scorelvl2 = p4scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
            }
        }
        if (collision.gameObject.tag == "p3"){
            switch (whichHold){
                case 1:
                    p1scorelvl2 = p1scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 2:
                    p2scorelvl2 = p2scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 4:
                    p4scorelvl2 = p4scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
            }
        }
        if (collision.gameObject.tag == "p4"){
            switch (whichHold){
                case 1:
                    p1scorelvl2 = p1scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 2:
                    p2scorelvl2 = p2scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
                case 3:
                    p3scorelvl2 = p3scorelvl2 + 1;
                    SceneManager.LoadScene("loc_multi_octagon");
                    break;
            }
        }
    }
}
