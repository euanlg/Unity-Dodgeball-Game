using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour {

    private int scoredp;
    private int scoredai;
    public Text playerscore;
    public Text aiscore;

    void Update () {
        scoredp = sp_ball.pscore;
        scoredai = sp_ball.aiscore;

        playerscore.text = "" + scoredp.ToString();
        aiscore.text = "" + scoredai.ToString();

    }
}
