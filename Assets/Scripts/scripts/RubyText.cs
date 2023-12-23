// BEGIN MIT LICENSE BLOCK //
//
// Copyright (c) 2017 dskjal
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php
//
// END MIT LICENSE BLOCK   //
/*
 * *注意*
 * 改行の処理はしてない．ルビを必要とする部分が途中で改行されないよう処理する必要がある．
 * http://dskjal.com/unity/detect-unity-ugui-break-pos.html を参照．
 */
/*
 * 設定方法
 * uGUI の Text にこのスクリプトをつける．
 * テキストのセンタリング設定をした uGUI の Text のプレハブを作り TextPrefab にセット
 * プレハブのフォントサイズをテキストのフォントサイズの 1/2 ぐらいにする
 */
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(Text), typeof(RectTransform))]
public class RubyText : MonoBehaviour
{

    Text text;
    RectTransform rt;
    public GameObject TextPrefab;  // テキストはセンタリングしておくこと
    private const float rubyHeight = 0.3f;

    class RubyPos
    {
        public int start;   // ルビの開始インデックス
        public int end;     // ルビの終了インデックス
        public string ruby; // ルビ
        public RubyPos(int start, int end, string ruby)
        {
            this.start = start;
            this.end = end;
            this.ruby = ruby;
        }
    }
    void Start()
    {
        text = GetComponent<Text>();
        rt = GetComponent<RectTransform>();

        var rubyPos = new List<RubyPos>();
        var matches = Regex.Matches(text.text, @"\[(.*?)\]<(.*?)>");
        // removed text count
        var rmtxt = 0;
        foreach (Match match in matches)
        {
            var match1 = match.Groups[1];
            var match2 = match.Groups[2];
            // remove markdown texts and insert match1
            text.text = text.text.Remove(match.Index - rmtxt, match.Length);
            text.text = text.text.Insert(match.Index - rmtxt, match1.Value);
            // remove text count 1([)
            rmtxt += 1;
            rubyPos.Add(new RubyPos(match1.Index - rmtxt, match1.Index - rmtxt + match1.Length - 1, match2.Value));
            // removed text count is 2(]) + 2(<>) + (ruby count)
            rmtxt += 1 + 2 + match2.Length;
        }

        var generator = new TextGenerator();
        // テキストのレンダリング位置の計算
        var settings = text.GetGenerationSettings(rt.sizeDelta);
        settings.scaleFactor = 1;
        generator.Populate(text.text, settings);

        // 各文字のレンダリング位置を記録した文字配列の取得
        var charArray = generator.GetCharactersArray();
        foreach (var ruby in rubyPos)
        {
            var start = charArray[ruby.start].cursorPos;
            var end = charArray[ruby.end].cursorPos;
            end.x += charArray[ruby.end].charWidth;

            PlaceRuby(start.x + (end.x - start.x) / 2f, start.y + charArray[ruby.start].charWidth / 2 * rubyHeight, ruby.ruby);
        }
    }

    // TextPrefab をインスタンス化して配置する
    void PlaceRuby(float x, float y, string text)
    {
        var o = GameObject.Instantiate(TextPrefab);
        o.name = text;
        o.transform.SetParent(this.transform);
        var prt = o.GetComponent<RectTransform>();
        prt.localPosition = new Vector3(x, y, 0f);
        prt.localScale = new Vector3(1, 1, 1);

        o.GetComponent<Text>().text = text;
    }
}