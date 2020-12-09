//　CameraSample.cs 自機を追従するカメラ処理 2020/11/11

using UnityEngine;
 
public class CameraSample : MonoBehaviour {
 
    private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
 
	
	void Start () {
        
        // Playerの情報を取得
        this.player = GameObject.Find("Player");
 
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
 
	}
	
	void Update () {
        if (player != null)
        {
            // 新しいトランスフォームの値を代入する
            transform.position = player.transform.position + offset;
        }
	}
}