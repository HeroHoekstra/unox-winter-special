using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< HEAD
    public void StartGame()
=======
    public void PlayGame()
>>>>>>> d8214157f194165629cbeb9cc40ac5fecdaf3f48
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
