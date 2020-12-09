// ScoreManager.cs スコアの表示と加算処理 2020/11/11

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    private static Text scoreLabel;

    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCORE：" + score;
    }
    // スコアの初期化.
    public void ScoreReset()
    {
        score = 0;
    }
    // スコアを増加させるメソッド
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE：" + score;
    }
}
