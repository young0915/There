using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
    public GameObject PausePanel;
    public Button RepauseButton;
    public Button RePlayButton;
    public Button BackButton;
    public GameObject MusicImage;

    // Start is called before the first frame update
   

    // Update is called once per frame
  

    public void PausedButton() //정지 버튼을 눌렀으면
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }
    public void Pausing()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }
    public void Playing() //리셋 버튼
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

      public void BackGame() //아직 백버튼 만들지 않은 상황이라 시작화면 받으면 할 것
      {
        SceneManager.LoadScene("01");
    }
    public void Music()
    {
        MusicImage.SetActive(true);
    }
    public void GetDownMusicButton()
    {
        MusicImage.SetActive(false);
    }
    public void QuitGame()//시작화면 나가기 버튼
    {
        Application.Quit();
    }
}
