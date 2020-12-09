// BossHealth.cs ボスのHP関連の処理 2020/11/11

using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    public GameObject effectPrefab2;
    public int BossHP = 200;
    public static int scoreValue = 5000;  
    private ScoreManager sm;

    void Start()
    {
        // ScoreManagerオブジェクトに付いているScoreManagerスクリプトの情報を取得してsmに入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    
    private void OnParticleCollision(GameObject other)
    {
        // 自機弾に当たったら
        if (other.gameObject.CompareTag("Bullet"))
        {
            // オブジェクトのHPを１ずつ減少させる。
            BossHP -= 1;
         
            
            // HPが0よりも大きい場合は
            if (BossHP > 0)
            {
                Destroy(other.gameObject);

            }
            else
            { // HPが0以下になった場合はsetActiveをfalseにして画面遷移
                Destroy(other.gameObject);

                // 爆発エフェクト再生
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                this.gameObject.SetActive(false);
                Invoke("GoToGameClear", 3.0f);
                // スコア付与
                sm.AddScore(scoreValue);
            }
        }
    }
    void GoToGameClear()
    {
        SceneManager.LoadScene("GameClearScene");
    }
}