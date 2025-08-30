using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Level level;

    public TMP_Text remainingText;
    public TMP_Text remainingLabel;
    public TMP_Text targetText;
    public TMP_Text targetLabel;
    public TMP_Text scoreText;
    public Image starsImage;
    public Sprite[] stars;
    public static HUD instance;
    private int starIndex;
    private bool isGameOver;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            UpdateStars();
        }
    }
    private void Start()
    {
        
    }
    public void UpdateStars()
    {
        starsImage.sprite = stars[starIndex];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
        if (score >= level.score3Star)
        {
            starIndex = 3;
        }
        else if (score >= level.score2Star)
        {
            starIndex = 2;
        }
        else if (score >= level.score1Star)
        {
            starIndex = 1;
        }
        UpdateStars();
    }
    public void SetTarget(int target) 
        {
            targetText.text = target.ToString();
        } 
    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }
    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }
    public void SetLevelType(Level.LevelType type)
    {
        switch (type)
        {
            case Level.LevelType.MOVES:
                remainingLabel.text = "moves remaining";
                targetLabel.text = "target score";
                break;
            case Level.LevelType.OBSTACLE:
                remainingLabel.text = "moves remaining";
                targetLabel.text = "dishes remaining";
                break;
            case Level.LevelType.TIMER:
                remainingLabel.text = "time remaining";
                targetLabel.text = "target score";
                break;
        }
    }
    public void OnGameWin(int score)
    {
        isGameOver = true;
    }
    public void OnGameLose()
    {
        isGameOver = false;
    }
}
