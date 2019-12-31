
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public bool isEscapeToExit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
               BackHome();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void BackHome()
    {
        SceneManager.LoadScene("Home");
    }
}
