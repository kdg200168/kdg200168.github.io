// EnemyShotShell.cs 雑魚の弾の発射とクールダウンの処理 2020/11/11

using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
   
    public GameObject enemyShellPrefab;
    public float shotSpeed;
    private int shotIntarval;
    private Vector3 PEnemy_pos;
    public Transform target;
    public float speed = 2F;

    private void OnTriggerStay(Collider other)
        {
        shotIntarval += 1;
        // Playerタグが付いているオブジェクトがトリガーコライダーの範囲内に入ったら
        if (other.CompareTag("Player"))
            {
                // LookAt()メソッドは指定した方向にオブジェクトの向きを回転させることができる
                transform.LookAt(target);
    
            }
        // 弾発射のクールタイム
        if (shotIntarval % 2500 == 0 )
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, new Vector3(transform.position.x , transform.position.y, transform.position.z　), this.transform.rotation);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            Destroy(enemyShell, 5.0f);
        }
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}