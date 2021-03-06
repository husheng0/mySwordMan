﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteItem : ReusingScrollItemBase 
{
    poemDataGenerate m_poemData;
    public override void OnInit()
    {
        AddOnClickListener("Button", OnClickCallBack);
    }

    public override void SetContent(int index, Dictionary<string, object> data)
    {
        m_poemData = (poemDataGenerate)data["poemData"];

        if(LanguageManager.s_currentLanguage == SystemLanguage.ChineseTraditional)
        {
            SetText("Text_poemName", ZhConverter.Convert(m_poemData.m_poemName, ZhConverter.To.Traditional));
            SetText("Text_author", ZhConverter.Convert(m_poemData.m_author, ZhConverter.To.Traditional));
        }
        else
        {
            SetText("Text_poemName", m_poemData.m_poemName);
            SetText("Text_author", m_poemData.m_author);
        }

    }

    void OnClickCallBack(InputUIOnClickEvent e)
    {
        ExaminePoemWindow.s_poemData = m_poemData;
        UIManager.OpenUIWindow<ExaminePoemWindow>();
    }
}
