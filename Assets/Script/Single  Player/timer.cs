using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour{
    public int timeLeft = 3;
    public Text countdownText;
    GameObject spp1;
    GameObject spp2;
    GameObject p1;
    GameObject p2;
    GameObject p3;
    GameObject p4;


    void Awake(){
        spp1 = GameObject.FindGameObjectWithTag("spp1");
        spp2 = GameObject.FindGameObjectWithTag("spp2");
        p1 = GameObject.FindGameObjectWithTag("p1");
        p2 = GameObject.FindGameObjectWithTag("p2");
        p3 = GameObject.FindGameObjectWithTag("p3");
        p4 = GameObject.FindGameObjectWithTag("p4");
        if (spp1 != null){
            spp1.GetComponent<player_1_control>().enabled = false;
        }
        if (spp2 != null){
            spp2.GetComponent<player1_controllvl2>().enabled = false;
        }
        if (p1 != null){
            p1.GetComponent<p1_control>().enabled = false;
        }
        if (p2 != null){
            p2.GetComponent<p2_control>().enabled = false;
        }
        if (p3 != null)
        {
            p3.GetComponent<p3_control>().enabled = false;
        }
        if (p4 != null)
        {
            p4.GetComponent<p4_control>().enabled = false;
        }
        StartCoroutine("getReady");
    }

    void allowInput(){
        if (spp1 != null){
            spp1.GetComponent<player_1_control>().enabled = true;
        }
        if (spp2 != null){
            spp2.GetComponent<player1_controllvl2>().enabled = true;
        }
        if (p1 != null){
            p1.GetComponent<p1_control>().enabled = true;
        }
        if (p2 != null){
            p2.GetComponent<p2_control>().enabled = true;
        }
        if (p3 != null){
            p3.GetComponent<p3_control>().enabled = true;
        }
        if (p4 != null){
            p4.GetComponent<p4_control>().enabled = true;
        }
    }

    IEnumerator getReady(){
        Time.timeScale = 0;
        countdownText.text = "3";
        yield return StartCoroutine(WaitForRealSeconds(0.9f));

        countdownText.text = "2";
        yield return StartCoroutine(WaitForRealSeconds(0.9f));

        countdownText.text = "1";
        yield return StartCoroutine(WaitForRealSeconds(0.9f));

        countdownText.text = "GO";
        yield return StartCoroutine(WaitForRealSeconds(0.9f));
        countdownText.text = "";
        yield return StartCoroutine(WaitForRealSeconds(0.2f));
        allowInput();
        
        Time.timeScale = 1;
    }

    IEnumerator WaitForRealSeconds(float waitTime){
        float endTime = Time.realtimeSinceStartup + waitTime;
        while (Time.realtimeSinceStartup < endTime){
            yield return null;
        }
    }
}
