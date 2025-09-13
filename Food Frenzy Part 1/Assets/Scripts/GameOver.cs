using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;

public class GameOver : MonoBehaviour
{
    public Image starsImage;
    public TMP_Text scoreText;
    public TMP_Text loseText;

    public Button replayButton;
    public Button doneButton;
    public static GameOver instance;
    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
            gameObject.SetActive(false);
            starsImage.enabled = false;
            scoreText.enabled = false;
            loseText.enabled = false;
            replayButton.gameObject.SetActive(false);
            doneButton.gameObject.SetActive(false);
            replayButton.onClick.AddListener(OnReplayClicked);
            doneButton.onClick.AddListener(OnDoneClicked);
        } 
    }
    public void ShowLose()
    {
        gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        doneButton.gameObject.SetActive(true);
        loseText.enabled = true;
        loseText.enabled = true;
    }
    public void ShowWin(int score, int starCount)
    {
        gameObject.SetActive(true);
        starsImage.enabled = true;
        scoreText.text = score.ToString();

        StartCoroutine(ShowWinCoroutine(starCount));
    }
    private IEnumerator ShowWinCoroutine(int starCount)
    {
        for (int i = 0; i <= starCount; i++)
        {
            yield return new WaitForSeconds(0.5f);
            starsImage.sprite = HUD.instance.stars[i];
        }
        scoreText.enabled = true;
        replayButton.gameObject.SetActive(true);
        doneButton.gameObject.SetActive(true);
    }
    public void OnReplayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnDoneClicked()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
