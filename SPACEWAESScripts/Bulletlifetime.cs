// Bulletlifetime.cs 自機弾を生成後指定時間で削除する処理 2020/11/11

using UnityEngine;


public class Bulletlifetime : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        // 指定時間後にオブジェクト破壊
        Destroy(gameObject, lifetime);
      
    }
}