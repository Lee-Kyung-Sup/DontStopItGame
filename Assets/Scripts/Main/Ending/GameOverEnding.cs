using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverEnding : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void RePlayBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StageChoiceBtn()
    {
        //�̱���
    }
}
