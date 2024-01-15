// BEGIN MIT LICENSE BLOCK //
//
// Copyright (c) 2017 dskjal
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php
//
// END MIT LICENSE BLOCK   //
/*
 * *����*
 * ���s�̏����͂��ĂȂ��D���r��K�v�Ƃ��镔�����r���ŉ��s����Ȃ��悤��������K�v������D
 * http://dskjal.com/unity/detect-unity-ugui-break-pos.html ���Q�ƁD
 */
/*
 * �ݒ���@
 * uGUI �� Text �ɂ��̃X�N���v�g������D
 * �e�L�X�g�̃Z���^�����O�ݒ������ uGUI �� Text �̃v���n�u����� TextPrefab �ɃZ�b�g
 * �v���n�u�̃t�H���g�T�C�Y���e�L�X�g�̃t�H���g�T�C�Y�� 1/2 ���炢�ɂ���
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
    public GameObject TextPrefab;  // �e�L�X�g�̓Z���^�����O���Ă�������
    private const float rubyHeight = 0.3f;

    class RubyPos
    {
        public int start;   // ���r�̊J�n�C���f�b�N�X
        public int end;     // ���r�̏I���C���f�b�N�X
        public string ruby; // ���r
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
        // �e�L�X�g�̃����_�����O�ʒu�̌v�Z
        var settings = text.GetGenerationSettings(rt.sizeDelta);
        settings.scaleFactor = 1;
        generator.Populate(text.text, settings);

        // �e�����̃����_�����O�ʒu���L�^���������z��̎擾
        var charArray = generator.GetCharactersArray();
        foreach (var ruby in rubyPos)
        {
            var start = charArray[ruby.start].cursorPos;
            var end = charArray[ruby.end].cursorPos;
            end.x += charArray[ruby.end].charWidth;

            PlaceRuby(start.x + (end.x - start.x) / 2f, start.y + charArray[ruby.start].charWidth / 2 * rubyHeight, ruby.ruby);
        }
    }

    // TextPrefab ���C���X�^���X�����Ĕz�u����
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