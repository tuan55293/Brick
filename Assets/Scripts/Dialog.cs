using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text titleText;
    public Text contentText;
    public Button btn;

    public void ShowDialog(bool isShow)
    {
        gameObject.SetActive(isShow);
        if (btn)
        {
            btn.gameObject.SetActive(!isShow);
        }
        GameManager.Ins.player.gameObject.SetActive(!isShow);
        GameManager.Ins.player.ShowViewFinder(!isShow);
    }
    public void UpdateDialog(string title, string content)
    {
        if (titleText != null)
        {
            titleText.text = title;
        }
        if (contentText != null)
        {
            contentText.text = content;
        }
    }
    public void UpdateDialogLevel(string title)
    {
        if (titleText != null)
        {
            titleText.text = title;
        }
    }
}
