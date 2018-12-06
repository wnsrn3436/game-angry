using UnityEngine;
using UnityEngine.SceneManagement;

//메인메뉴 씬 매니저 클래스
public class MainMenuMgr : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void OnGameStartClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnGameEndClick()
    {
        Application.Quit();
    }
}