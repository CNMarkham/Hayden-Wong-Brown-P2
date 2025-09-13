using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (ButtonPlayerPrefs button in buttons)
        {
            int score = PlayerPrefs.GetInt(button.playerPrefKey, 0);
            button.starsImage.sprite = stars[score];
        }
    }
    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public Image starsImage;
        public string playerPrefKey;
    }
    public ButtonPlayerPrefs[] buttons;
    public Sprite[] stars;
    public void LevelSelectButtonPressed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
