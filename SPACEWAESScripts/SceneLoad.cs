// SceneLoad.cs プレイシーンに戻るボタンを押した時の処理 2020/11/11

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    public void OnClickStartButton()
    {
     // ゲームオーバーになったら数値をリセットする。
        SceneManager.LoadScene("PlayScene");
        ScoreManager.score = 0;
        PlayerHealth.destroyCount = 0;
        PlayerHealth.playerHP = 10;
    }
}
