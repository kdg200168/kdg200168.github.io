// TitleSceneLoad.cs タイトルシーンに戻るボタンを押した時の処理 2020/11/11

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoad : MonoBehaviour
{
        public void OnClickStartButton()
    {
        // 画面遷移をする際に数値をリセットする
        SceneManager.LoadScene("TitleScene");
        ScoreManager.score = 0;
        PlayerHealth.destroyCount = 0;
        PlayerHealth.playerHP = 10;
    }
}

