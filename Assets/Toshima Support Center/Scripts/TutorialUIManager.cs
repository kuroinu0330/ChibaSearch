using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIManager : MonoBehaviour
{
    // プラットフォームが「PC」か「スマホ」かを設定するbool型変数
    [SerializeField]
    private Platform _isPlatform = Platform.PC;

    // チュートリアルで表示させる「GameObject」を格納する変数
    [SerializeField]
    private List<GameObject> _tutorialStep;

    // プラットフォームによって見た目が変わる「RawImage」コンポーネントをもつオブジェクトを格納する変数
    [SerializeField]
    private List<RawImage> _tutorialUIRawImage;

    // プラットフォームによって文言が変わる「Text」コンポーネントを持つオブジェクトを格納する変数
    [SerializeField]
    private List<Text> _tutorialUIText;

    // 「_tutorialUIRawImage」に適応させる差し替え予定の画像群を保持するリList型配列
    [SerializeField]
    private List<Texture> _texture;

    // 「次に進む」や「前へ戻る」ボタン、チュートリアル終了用のボタンを格納するList型配列
    [SerializeField]
    private List<GameObject> _subObj;

    // チュートリアルの進行フラグ(Animationにて変更を加える)
    private bool _progressFlag = false;

    // チュートリアルの進行度を表すint型変数
    private int _progressFaze = 0;

    /// <summary>
    /// プラットフォームを列挙する配列
    /// </summary>
    private enum Platform
    {
        PC,
        Smartphone
    }

    /// <summary>
    /// キーワードを列挙する配列
    /// </summary>
    private enum KeyWord
    {
        タッチ,
        二本指,
        左クリック,
        右クリック
    }

    private void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// 各種UIの再調整を行う関数
    /// </summary>
    private void Initialize()
    {
        // 実行予定のプラットフォームによって以下の処理を分岐
        switch (_isPlatform)
        {
            // 「PC」ベースの場合以下の処理を実行する
            case Platform.PC:

                // 「_tutorialUIText」の要素数だけ以下の処理を繰り返す
                for (int i = 0; i < _tutorialUIText.Count; i++)
                {
                    // 「タッチ」という文字を「左クリック」に置き換える
                    _tutorialUIText[i].text =
                        _tutorialUIText[i].text.Replace(KeyWord.タッチ.ToString(), KeyWord.左クリック.ToString());
                }

                for (int i = 0; i < _tutorialUIRawImage.Count(); i++)
                {
                    _tutorialUIRawImage[i].texture = _texture[0];
                }

                break;
            // 「スマートフォン」ベースの場合以下の処理を実行する(iPadも含む)
            case Platform.Smartphone:

                // 「_tutorialUIText」の要素数だけ以下の処理を繰り返す
                for (int i = 0; i < _tutorialUIText.Count; i++)
                {
                    // 「左クリック」という文字を「タッチ」に置き換える
                    _tutorialUIText[i].text =
                        _tutorialUIText[i].text.Replace(KeyWord.左クリック.ToString(), KeyWord.タッチ.ToString());
                }

                for (int i = 0; i < _tutorialUIRawImage.Count(); i++)
                {
                    _tutorialUIRawImage[i].texture = _texture[1];
                }

                break;
        }

    }
    /// <summary>
    /// 次に進むためのボタンが押された時に実行する関数
    /// </summary>
    public void OnClickNextArrow()
    {
        // 次のチュートリアルを表示
        TutorialUIUpdate(true);

        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 3);
    }

    /// <summary>
    /// 前に戻るためのボタンが押された時に実行する関数
    /// </summary>
    public void OnClickPrevArrow()
    {
        // 前のチュートリアルを表示
        TutorialUIUpdate(false);
        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 3);
    }

    /// <summary>
    /// チュートリアルを終了するボタンが押された時に実行する関数
    /// </summary>
    public void EndOfTutorial()
    {
        // 自身を非表示にする
        this.gameObject.SetActive(false);
        SoundManager.instance.PlayAudioSorce(SoundManager.AudioOfType.SYSTEMSE, 0);
        // 移動可能フラグを有効化
        TrackingMousePosition.Instance.UIButtomExit();
    }

    /// <summary>
    /// チュートリアルのUIを更新する
    /// </summary>
    /// <param name="add">チュートリアルの作業工程を進めることを示す</param>
    private void TutorialUIUpdate(bool add)
    {
        // 現在表示中のチュートリアルを非活性化
        _tutorialStep[_progressFaze].SetActive(false);

        // チュートリアルの工程を進める場合以下の処理を実行
        if (add)
        {
            // 「チュートリアルフェーズ」を一段階上昇
            _progressFaze++;
        }
        else
        {
            // 「チュートリアルフェーズ」を一段階下降
            _progressFaze--;
        }

        //  次回表示予定のチュートリアルを活性化
        _tutorialStep[_progressFaze].SetActive(true);

        // 現在の工数が「0」の時以下の処理を実行
        if (_progressFaze == 0)
        {
            // 「前へ戻るボタン」を非活性化
            _subObj[0].SetActive(false);
        }
        // 現在の工数が「0」ではなく、かつ「前へ戻るボタン」が非活性状態に以下の処理を実行
        else if (_progressFaze != 0 && !_subObj[0].activeSelf)
        {
            // 「前へ戻るボタン」を活性化
            _subObj[0].SetActive(true);
        }

        // 現在の工数が「最終工程」ではなく、かつ「次へ進むボタン」が活性状態時に以下の処理を実行
        if (_progressFaze != _tutorialStep.Count() - 1 && _subObj[2].activeSelf)
        {
            // 「次へ進むボタン」を非活性化
            _subObj[1].SetActive(true);

            //　「チュートリアルを終了するボタン」を活性化
            _subObj[2].SetActive(false);
        }
        // 現在の工程が「最終工程」である場合、以下の処理を実行
        else if (_progressFaze == _tutorialStep.Count() - 1)
        {
            // 「次へ進むボタン」を非活性化させる
            _subObj[1].SetActive(false);

            //　「チュートリアルを終了するボタン」を活性化させる
            _subObj[2].SetActive(true);
        }
    }
}
