// DestroyObject.cs 敵のHP関連,確率でアイテムドロップをする処理 2020/11/11

using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab2;
    public int objectHP = 6;
    public static int scoreValue = 100;
    private ScoreManager sm;
    public GameObject items;

    void Start()
    {
        // ScoreManagerオブジェクトに付いているScoreManagerスクリプトの情報を取得してsmに入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnParticleCollision(GameObject other)
    {
        // Bulletタグが付与されているオブジェクトにぶつかると
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;

            // HPが0よりも大きい場合は
            if (objectHP > 0)
            {
                Destroy(other.gameObject);
            }
            else
            {
                // HPが0以下になった場合は
                Destroy(other.gameObject);

                // エフェクトを発生させる。
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                Destroy(this.gameObject);

                
                sm.AddScore(scoreValue);
                // 1/2の確率でアイテムドロップ
                if (Random.Range(0, 2) == 0)
                {
                    Instantiate(items, transform.position, transform.rotation);
                }
            }
        }
    }
}