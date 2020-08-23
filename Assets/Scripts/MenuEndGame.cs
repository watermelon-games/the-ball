using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEndGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
