using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sp_ball2 : MonoBehaviour {

    public static int pscore = 0;
    public static int aiscore = 0;
    bool aithrow;
    bool playerthrow;
    GameObject p1;
    GameObject ai;

    void Start(){
        p1 = GameObject.FindGameObjectWithTag("spp2");
        ai = GameObject.FindGameObjectWithTag("ai1");
    }

    void Update(){
        aithrow = ai.GetComponent<AINav2>().ai_throw;
        playerthrow = p1.GetComponent<player1_controllvl2>().p1_throw;
        if (aiscore >= 5 || pscore >= 5){
            SceneManager.LoadScene("Scorelvl2");
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Player_1" && aithrow == true){
            aiscore = aiscore + 1;
            SceneManager.LoadScene("Octagon_areana");
        }
        if (collision.gameObject.name == "AI_1" && playerthrow == true){
            pscore = pscore + 1;
            SceneManager.LoadScene("Octagon_areana");
        }
    }
}
