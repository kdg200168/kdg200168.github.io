// AfterbunerController.cs エフェクトがオフからオンにする処理 2020/11/11

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AfterburnerController : MonoBehaviour
{
    // defaultを入れないと警告が出るので注意
    [SerializeField]
    ParticleSystem pObject = default;

    // ここでパーティクルが停止される時間を指定
    float particleDelayTime = .2f;

    void Awake()
    {
        pObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && pObject.isStopped)
        {
            pObject.gameObject.SetActive(true);
            pObject.Simulate(4.0f, true, false); 
            pObject.Play(); 
            StartCoroutine(delay(particleDelayTime, () => {
                pObject.gameObject.SetActive(false);
            }));
        }
    }

    IEnumerator delay(float waitTime, UnityAction action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}