using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Instructions : MonoBehaviour
{
    [SerializeField]
    TMP_Text instructionText;
    [SerializeField]
    TMP_Text ScoreText;

    [SerializeField]
    TMP_Text timerText;

    [SerializeField]
    TMP_Text highestScore;

    [SerializeField]
    GameObject btnPlayAgain;

    [SerializeField]
    GameObject highScoreObj;

    [SerializeField]
    GameObject scoreObj;

    [SerializeField]
    GameObject timerObj;

    [SerializeField]
    GameObject pushBtn;

    [SerializeField]
    GameObject pullBtn;

    [SerializeField]
    GameObject instructionObj;

    [SerializeField]
    Animator gameDoorAnim;
    int score = 0;

    string[] doorState = new string[] {"PUSH", "PULL"};

    public static bool isInputGiven = false;
    public static string currentState;

    public float timeRemaining = 5;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        int state = Random.Range(0, 2);
        instructionText.text = doorState[state]; 
        currentState = doorState[state];
        timerIsRunning = true;
    }

    void Update()
    {
    if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                if(timeRemaining >= 0)
                timerText.text = "Time : " + Mathf.FloorToInt(timeRemaining);
                 
            } 
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                btnPlayAgain.SetActive(true);
                timerObj.SetActive(false);
                instructionObj.SetActive(false);
                pushBtn.SetActive(false);
                pullBtn.SetActive(false);
                gameDoorAnim.SetBool("doorPush",false);
                gameDoorAnim.SetBool("doorPull",false);

            }
        }
        else
        {
        int highscore = 0;  
            if(PlayerPrefs.HasKey("highscore"))
            {
                if(score > PlayerPrefs.GetInt("highscore"))
                {
                    highScoreObj.SetActive(true);
                    highscore = score;
                    highestScore.text = "Highest Score : " + highscore.ToString();
                    PlayerPrefs.SetInt("highscore",highscore);
                    PlayerPrefs.Save(); 
                }
                else
                {
                    highScoreObj.SetActive(true);
                    highestScore.text = "Highest Score : " + PlayerPrefs.GetInt("highscore").ToString();
                }
            }
            else
            {
                if(score > highscore)
                {
                    highScoreObj.SetActive(true);
                    highscore = score;
                    highestScore.text = "Highest Score : " + highscore.ToString();
                    PlayerPrefs.SetInt("highscore",highscore);
                    PlayerPrefs.Save();
                }
            }
        }
        }
        



    public void ChangeState()
    {
        Debug.Log("Change State called");
        int state = Random.Range(0, 2);
        instructionText.text = doorState[state]; 
        currentState = doorState[state];
        score++;
        ScoreText.text = "Score : " + score; 
    }

    public void PlayAgain()
    {
        Debug.Log("PlayAgain Called");
        highScoreObj.SetActive(false);
        btnPlayAgain.SetActive(false);
        SceneManager.LoadScene("GameScene");

        timeRemaining = 10;
    }
}
