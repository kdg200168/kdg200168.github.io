// ChangeBossScene.cs ボスシーン遷移の処理 2020/11/11

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBossScene : MonoBehaviour
{
    private GameObject Player;
   
    void Start()
    {
        //プレイヤーの情報を取得する
       Player = GameObject.Find("Player");
    }
   
    void Update()
    {
        // プレイヤーの座標が指定の地点まで到達するとボスシーンに遷移
        if (Player.transform.position.z >= 20000)
        {
            Invoke("GoToBOSS", 1.5f);
        }
    }
 
    void GoToBOSS()
    {
        SceneManager.LoadScene("BossScene");
    }
}

