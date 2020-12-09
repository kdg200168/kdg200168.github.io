// Bossmove.cs ボスを動かす処理 2020/11/11

using UnityEngine;

public class Bossmove : MonoBehaviour
{
    public float movespeed = 10F;

    // ボスを動かす
    void Update()
    {
        this.transform.position += transform.forward * movespeed * Time.deltaTime;
    }
}
