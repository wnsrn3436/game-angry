using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 //게임 씬 매니저 클래스
public class GameMgr : MonoBehaviour
{
    public static GameMgr instance;

    public float score;
    public Text scoreText;
    string scoreFormat;

    public GameObject gameEndImage;
    public Text gameStateText;

    public AudioSource audioSource;
    public AudioClip enemyDead;
    public AudioClip bulletShoot;
    public AudioClip bigBulletShoot;

    void Awake()
    {
        instance = this;

        Screen.SetResolution(1920, 1080, true);

        scoreFormat = scoreText.text;
        score = 0.0f;
    }

    void Update()
    {
        scoreText.text = string.Format(scoreFormat, score);

        if (score >= 200)
            LoadGameEnd(true);
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameEnd(bool isWin)
    {
        if (!gameEndImage.activeSelf)
        {
            if (isWin)
                gameStateText.text = "게임 승리!";
            else
                gameStateText.text = "게임 패배!";

            gameEndImage.SetActive(true);
            StartCoroutine(LoadGameAnime());
        }
    }

    IEnumerator LoadGameAnime()
    {
        for (float i = 0.0f; i < 1.0f; i += 0.05f)
        {
            yield return null;
            gameEndImage.transform.localScale = new Vector3(i, i, 1.0f);
        }
    }
}