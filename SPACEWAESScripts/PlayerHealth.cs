// PlayerHealth.cs  自機のHP,残機,無敵時間などの処理 2020/11/11

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private AudioSource sound01; //サウンド1

    public GameObject effectPrefab; //エフェクト１
    public GameObject effectPrefab2; //エフェクト2
    public static int playerHP = 10; //プレイヤーHP
    private Slider hpSlider;         //プレイヤーHPを可視化させるスライダー
    public GameObject[] playerIcons;　//残機アイコン
    public static int destroyCount = 0; //やられた回数
    public bool isMuteki = false; //リトライ後の無敵時間
    private ScoreManager scoreManager;　//スコアマネージャー参照


    private void Start()
    {
        sound01 = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
        hpSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();
        hpSlider.maxValue = playerHP;
        hpSlider.value = playerHP;
        UpdatePlayerIcons();
    }
    private void OnParticleCollision(GameObject other)
    {
        //　敵の弾に当たったら
        if (other.gameObject.CompareTag("EnemyBullet") && isMuteki == false)
        {
            playerHP -= 1;
            sound01.PlayOneShot(sound01.clip);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(effect, 1.0f);
            //スライダーの数値を自機HPと同期させる
            hpSlider.value = playerHP;
            //HPが0になったら
            if (playerHP == 0)
            {
                destroyCount += 1;
                UpdatePlayerIcons();
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // プレーヤーを破壊するのではなく、非アクティブ状態にする
                this.gameObject.SetActive(false);

                if (destroyCount < 3) 
                {
                    // リトライ
                    Invoke("Retry", 2.0f);
                }
                else
                {
                    // ゲームオーバー
                    Invoke("GoToGameOver", 5.0f);

                    // destroyCountをリセット
                    destroyCount = 0;
                }
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    //残機アイコンの表示と非表示の処理
    void UpdatePlayerIcons()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
            {
                playerIcons[i].SetActive(true);
            }
            else
            {
                playerIcons[i].SetActive(false);
            }
        }
    }
    //自機が再表示時の処理
    void Retry()
    {
        this.gameObject.SetActive(true);
        playerHP = 10;
        hpSlider.value = playerHP;
        isMuteki = true;
        Invoke("MutekiOff", 2.0f);
    }
    //無敵時間をfalseにしておく処理
    void MutekiOff()
    {
        isMuteki = false;
    }
    // HPが増えすぎない様にする処理
    public void AddHP(int amount)
    {
        playerHP += amount;

        if (playerHP > 10)
        {
            playerHP = 10;
        }

        hpSlider.value = playerHP;
    }

}