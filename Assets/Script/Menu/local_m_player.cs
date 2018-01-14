using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class local_m_player : MonoBehaviour {

    public Toggle p1Tgl;
    public Toggle p2Tgl;
    public Toggle p3Tgl;
    public Toggle p4Tgl;
    public static bool p1Join = false;
    public static bool p2Join = false;
    public static bool p3Join = false;
    public static bool p4Join = false;

    void Awake(){
        p1Join = false;
        p2Join = false;
        p3Join = false;
        p4Join = false;
    }

    void Update () {
        loc_multi_ball.p1score = 0;
        loc_multi_ball.p2score = 0;
        loc_multi_ball.p3score = 0;
        loc_multi_ball.p4score = 0;

        if (Input.GetButtonUp("joy1_b")){
            p1Join = false;
            p2Join = false;
            p3Join = false;
            p4Join = false;
            SceneManager.LoadScene("MainMenu");  
        }
        if (Input.GetKeyUp(KeyCode.Escape)){
            p1Join = false;
            p2Join = false;
            p3Join = false;
            p4Join = false;
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetButtonUp("joy1_start") && p1Join && p2Join && !p3Join && !p4Join){
            SceneManager.LoadScene("multi_lvlSelect");
        }
        else if (Input.GetButtonUp("joy1_start") && p1Join && p2Join && p3Join && !p4Join){
            SceneManager.LoadScene("multi_lvlSelect");
        }
        else if (Input.GetButtonUp("joy1_start") && p1Join && p2Join && p3Join && p4Join){
            SceneManager.LoadScene("multi_lvlSelect");
        }
        if (Input.GetKeyUp(KeyCode.Return) && p1Join && p2Join && !p3Join && !p4Join)
        {
            SceneManager.LoadScene("multi_lvlSelect");
        }
        else if (Input.GetKeyUp(KeyCode.Return) && p1Join && p2Join && p3Join && !p4Join)
        {
            SceneManager.LoadScene("multi_lvlSelect");
        }
        else if (Input.GetKeyUp(KeyCode.Return) && p1Join && p2Join && p3Join && p4Join)
        {
            SceneManager.LoadScene("multi_lvlSelect");
        }

        if (Input.GetButtonUp("joy1_a")){
            if(!p1Tgl.isOn){
                p1Tgl.isOn = true;
                p1Join = true;
            }else{
                p1Tgl.isOn = false;
                p1Join = false;
            }
        }

        if (Input.GetButtonUp("joy2_a")){
            if (p2Tgl.isOn == false){
                p2Tgl.isOn = true;
                p2Join = true;
            }else{
                p2Tgl.isOn = false;
                p2Join = false;
            }
        }

        if (Input.GetButtonUp("joy3_a")){
            if (p3Tgl.isOn == false){
                p3Tgl.isOn = true;
                p3Join = true;
            }
            else{
                p3Tgl.isOn = false;
                p3Join = false;
            }
        }

        if (Input.GetButtonUp("joy4_a")){
            if (p4Tgl.isOn == false){
                p4Tgl.isOn = true;
                p4Join = true;
            }
            else{
                p4Tgl.isOn = false;
                p4Join = false;
            }
        }

    }
}
