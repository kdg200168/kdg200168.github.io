// GameEnd.cs アプリケーション終了させる処理 2020/11/11

using UnityEngine;

public class GameEnd : MonoBehaviour
{
    //　ボタンを押すとアプリケーション終了
    public void OnClickEndButton()
    {
        Application.Quit();
    }
}
