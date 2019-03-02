using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _Instance;
    public static GameManager Instance { get { return _Instance; } }

    // UI
    public GameObject GameOverText
        , SuccessText
        , StartBtn
        , ContinueBtn
        , PauseBtn
        , JoyStickBtn
        , RestartBtn
        , ArchiveBtn;

    public JoyStick JoyStick;
    public GameObject Player;
    private GameObject frontArchivePoint = null;



    private void Awake() {
        _Instance = this;
        Time.timeScale = 0f;
    }

    void Update () {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.R)) {
            GameRestart();
        }
	}

    // 存档
    public void NewArchivePoint(GameObject newPoint) {
        if (frontArchivePoint != null
            && newPoint.transform.position.z > frontArchivePoint.transform.position.z) {
            frontArchivePoint = newPoint;
        }
        else if (frontArchivePoint == null) {
            frontArchivePoint = newPoint;
        }
    }

    // 读档
    public void Archive() {
        if (frontArchivePoint != null) {
            Player.transform.position = frontArchivePoint.transform.position;
            GameContinue();
            this.JoyStick.Reset();
        }
    }

    // 游戏的几种状态
    public void Success() {
        Time.timeScale = 0f;
        RestartBtn.SetActive(true);
        PauseBtn.SetActive(false);
        JoyStickBtn.SetActive(false);
        SuccessText.SetActive(true);
    }

    public void GameOver() {
        Time.timeScale = 0f;
        GameOverText.SetActive(true);
        RestartBtn.SetActive(true);
        ArchiveBtn.SetActive(true);
        PauseBtn.SetActive(false);
        JoyStickBtn.SetActive(false);
    }

    public void GamePause() {
        Time.timeScale = 0f;
        PauseBtn.SetActive(false);
        ContinueBtn.SetActive(true);
        RestartBtn.SetActive(true);
        JoyStickBtn.SetActive(false);
        ArchiveBtn.SetActive(false);
    }

    public void GameContinue() {
        Time.timeScale = 1f;
        PauseBtn.SetActive(true);
        ContinueBtn.SetActive(false);
        JoyStickBtn.SetActive(true);
        RestartBtn.SetActive(false);
        ArchiveBtn.SetActive(false);
        GameOverText.SetActive(false);
        StartBtn.SetActive(false);
    }

    public void GameRestart() {
        SceneManager.LoadScene("2");
        Time.timeScale = 1f;
    }



}
