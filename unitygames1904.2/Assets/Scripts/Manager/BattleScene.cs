using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// スコアに応じたメダルを表示するためのリストの要素です。
[System.Serializable]
public class MedalInfo_
{
    /// 表示するメダルの画像です。アセットから設定してください。
    public Sprite spriteMedal_;
    /// メダルを表示するための条件となるスコアの下限です。この値以上の場合に表示します。
    public int scoreBorder_;
}

public class BattleScene : MonoBehaviour
{
    /// スコアに応じたメダルを表示するためのリストの要素です。
    [System.Serializable]
    public class MedalInfo_
    {
        /// 表示するメダルの画像です。アセットから設定してください。
        public Sprite spriteMedal_;
        /// メダルを表示するための条件となるスコアの下限です。この値以上の場合に表示します。
        public int scoreBorder_;
    }

    /// メダルの情報です。
    /// scoreBorder_ の『大きい』順に設定してください。
    public List<MedalInfo_> medalInfoList_;

    /// メダルを表示する UI.Image を設定します。
    /// メダル画像の差し替えで使います。
    public UnityEngine.UI.Image uiMedal_;

    /// 現在のスコアです。
    public int score_ = 0;

    /// ゲームオーバーの段階に遷移します。
    public void ChangePhaseGameOver()
    {
        // スコアに応じたメダルの画像を表示するように設定します。(関数内の他の処理は省略)
        {
            foreach (MedalInfo_ _medalInfo in medalInfoList_)
            {
                if (_medalInfo.scoreBorder_ <= score_)
                {
                    uiMedal_.sprite = _medalInfo.spriteMedal_;
                    break;
                }
            }
        }
    }
}
