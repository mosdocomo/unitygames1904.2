using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Util : MonoBehaviour
{
    /// ツイート画面を開きます。
    /// msgPlain ツイートする文字列
    public static void Tweet(string msgPlain)
    {
        string url = "http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(msgPlain);
        Application.OpenURL(url);
        return;
    }
}

public class GameOverPanel : MonoBehaviour
{
    [System.Serializable]
    public class MedalInfo
    {
        /// 表示するメダルの画像です。アセットから設定してください。
        public Sprite spriteMedal_;
        /// メダルを表示するための条件となるスコアの下限です。この値以上の場合に表示します。
        public int scoreBorder_;
    }

    /// ツイートのフォーマット文です。
    /// {0} は現在のスコア、 {1} はベストスコアに置き換わります。
    public string tweetFormat_ = "#FlappyDaruma フラッピーだるま Score {0} BestScore {1}";

    /// メダルの情報です。
    /// scoreBorder_ の『大きい』順に設定してください。
    public List<MedalInfo> medalInfoList_;

    /// メダルを表示する UI.Image を設定します。
    /// メダル画像の差し替えで使います。
    public Image medal;

    public GameObject GameManager;

    public Text Score;
    public Text Best;
    public int score;
    public int bestscore;
    float speed;
    Vector2 v;
    // Start is called before the first frame update

    void Start()
    {
        speed = 500;
        v = new Vector2(0.0f, speed);
        GetComponent<Rigidbody2D>().velocity = v;
        score = GameManager.GetComponent<GameManager>().score;
        ChangePhaseGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        SetPanel();
        Score.text = "" + GameManager.GetComponent<GameManager>().score;
        Best.text = "" + GameManager.GetComponent<GameManager>().score;
    }

    void SetPanel()
    {
        if (GetComponent<Transform>().position.y > 160.0f)
        {// パネルの位置移動
            speed = 0.0f;
            v.y = speed;
            GetComponent<Rigidbody2D>().velocity = v;
        }
    }
    /// ゲームオーバーの段階に遷移します。
    public void ChangePhaseGameOver()
    {
        // スコアに応じたメダルの画像を表示するように設定します。(関数内の他の処理は省略)
        {
            foreach (MedalInfo _medalInfo in medalInfoList_)
            {
                if (_medalInfo.scoreBorder_ <= score)
                {
                    medal.overrideSprite = _medalInfo.spriteMedal_;
                    break;
                }
            }
        }
    }
    public void ButtonShare()
    {
        // ボタンの効果音を再生します。
        // Util.PlayAudioClip(acButton_, Vector3.zero, 1f);

        // ベストスコアと現在のスコアを含んだツイート用の文字列を作成し、ツイート用の画面を開きます。
        bestscore = score;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        string _msg = string.Format(tweetFormat_, score, bestScore);
        Util.Tweet(_msg);

    }
    public void ButtonTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}
