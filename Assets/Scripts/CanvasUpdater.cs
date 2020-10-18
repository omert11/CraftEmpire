using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdater : MonoBehaviour
{
    public bool onCanvasUpdate;
    public int canvasState;
    float timer = 60;
    public CanvasGroup SelectCanvas;
    public CanvasGroup MainCanvas;
    public CanvasGroup GameCanvas;
    public CanvasGroup SkillTreeCanvas;
    public CanvasGroup WorkCanvas;
    public CanvasGroup WorldCanvas;

    private void Start()
    {
    }
    void Update()
    {
        if (onCanvasUpdate)
        {

            switch (canvasState)
            {
                case 0:
                    SelectCanvas.gameObject.SetActive(true);
                    MainCanvas.alpha = (timer - 30) / 30;
                    SelectCanvas.alpha = 1 - (timer - 30) / 30;
                    if (timer < 0) MainCanvas.gameObject.SetActive(false);
                    break;
                case 1:
                    MainCanvas.gameObject.SetActive(true);
                    MainCanvas.alpha = 1 - (timer - 30) / 30;
                    SelectCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) SelectCanvas.gameObject.SetActive(false);
                    break;
                case 2:
                    GameCanvas.gameObject.SetActive(true);
                    GameCanvas.alpha = 1 - (timer - 30) / 30;
                    SelectCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) SelectCanvas.gameObject.SetActive(false);
                    break;
                case 3:
                    SkillTreeCanvas.gameObject.SetActive(true);
                    SkillTreeCanvas.alpha = 1 - (timer - 30) / 30;
                    GameCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) GameCanvas.gameObject.SetActive(false);
                    break;
                case 4:
                    GameCanvas.gameObject.SetActive(true);
                    GameCanvas.alpha = 1 - (timer - 30) / 30;
                    SkillTreeCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) SkillTreeCanvas.gameObject.SetActive(false);
                    break;
                case 5:
                    WorkCanvas.gameObject.SetActive(true);
                    WorkCanvas.alpha = 1 - (timer - 30) / 30;
                    GameCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) GameCanvas.gameObject.SetActive(false);
                    break;
                case 6:
                    GameCanvas.gameObject.SetActive(true);
                    GameCanvas.alpha = 1 - (timer - 30) / 30;
                    WorkCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) WorkCanvas.gameObject.SetActive(false);
                    break;
                case 7:
                    WorldCanvas.gameObject.SetActive(true);
                    WorldCanvas.alpha = 1 - (timer - 30) / 30;
                    GameCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) GameCanvas.gameObject.SetActive(false);
                    break;
                case 8:
                    GameCanvas.gameObject.SetActive(true);
                    GameCanvas.alpha = 1 - (timer - 30) / 30;
                    WorldCanvas.alpha = (timer - 30) / 30;
                    if (timer < 0) WorldCanvas.gameObject.SetActive(false);
                    break;
            }
            if (timer < 0)
            {
                onCanvasUpdate = false;
                timer = 60;
            }
            else
            {

                timer--;
            }
        }
    }
}
