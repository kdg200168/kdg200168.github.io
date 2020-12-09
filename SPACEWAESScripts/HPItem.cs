// HPItem.cs 回復アイテムが自機に当たった時の処理 2020/11/11
 
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    private PlayerHealth ph;
    private int reward = 2; // 回復値

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤータグが付いてるオブジェクトに当たると
        if (other.gameObject.tag == "Player")
        {
            //playerにあるplayerhealthスクリプトを参照
            ph = GameObject.Find("Player").GetComponent<PlayerHealth>();

            // AddHP()メソッドを呼び出して「引数」にrewardを与えている。
            ph.AddHP(reward);

            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);
        }
    }
}