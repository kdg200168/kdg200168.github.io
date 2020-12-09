// AfterbunerController.cs エフェクトがオンからオフにする処理 2020/11/11

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AfterburnerController2 : MonoBehaviour
{
    // defaultを入れないと警告が出るので注意
    [SerializeField]
    ParticleSystem pObject = default;

    // ここでパーティクルが停止される時間を指定
    float particleDelayTime = .2f;

    void Awake()
    {
        pObject.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && pObject.isPlaying)
        {
            pObject.gameObject.SetActive(false);
            pObject.Simulate(4.0f, true, false); 
            pObject.Stop(); 
            StartCoroutine(delay(particleDelayTime, () => {
                pObject.gameObject.SetActive(true);
            }));
        }
    }

    IEnumerator delay(float waitTime, UnityAction action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}