using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuEndGame : MonoBehaviour
{
    public Text scoreText;
    
    public int score = 0;
    
    public void Start()
    {
        score = PlayerPrefs.GetInt("Score");
    }
    
    public void Update()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "You score: " + score +  " Pts";
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
