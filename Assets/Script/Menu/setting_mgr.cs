using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class setting_mgr : MonoBehaviour {
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQDrowdown;
    public Dropdown antiADropdown;
    public Dropdown vSyncDropdown;
    public Button applyButton;

    public Resolution[] resolutions;
    public game_set game_set;

    void OnEnable(){
        game_set = new game_set();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQDrowdown.onValueChanged.AddListener(delegate { OnTextureQChange(); });
        antiADropdown.onValueChanged.AddListener(delegate { OnAntiAChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVsyncChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions){
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoasSettings();
    }

    public void OnFullScreenToggle(){
       game_set.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange(){
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        game_set.resIndex = resolutionDropdown.value;
    }

    public void OnTextureQChange(){
        QualitySettings.masterTextureLimit = game_set.textureQ = textureQDrowdown.value;  
    }

    public void OnAntiAChange(){
        QualitySettings.antiAliasing = game_set.antiA = (int)Mathf.Pow(2f, antiADropdown.value);
    }

    public void OnVsyncChange(){
        QualitySettings.vSyncCount = game_set.vSync = vSyncDropdown.value;
    }

    public void OnApplyButtonClick(){
        SaveSettings();
    }

    public void SaveSettings(){
        string jsondata = JsonUtility.ToJson(game_set, true);
        File.WriteAllText(Application.persistentDataPath +"/DBsettings.json", jsondata);
    }

    public void LoasSettings(){
        game_set = JsonUtility.FromJson<game_set>(File.ReadAllText(Application.persistentDataPath + "/DBsettings.json"));
        antiADropdown.value = game_set.antiA;
        vSyncDropdown.value = game_set.vSync;
        textureQDrowdown.value = game_set.vSync;
        resolutionDropdown.value = game_set.resIndex;
        fullscreenToggle.isOn = game_set.fullscreen;
        Screen.fullScreen = game_set.fullscreen;

        resolutionDropdown.RefreshShownValue();

    }

}
