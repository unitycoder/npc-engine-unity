using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPCEngine;
using NPCEngine.API;
using NPCEngine.Utility;

public class SpeechToTextCaller : MonoBehaviour
{
    public Text resultUI;
    ResultFuture<string> result;
    public Button listenButton;

    private void Start()
    {
        listenButton.interactable = false;
        StartCoroutine(InitializationCoroutine());
    }

    IEnumerator InitializationCoroutine()
    {
        yield return SpeechToText.InitializeMicrophoneInput();
        listenButton.interactable = true;
    }

    private void Update()
    {
        if (result != null && result.ResultReady)
        {
            if (result.Result != "")
            {
                resultUI.text = result.Result;
                listenButton.interactable = true;
                result = null;
            }
            else
            {
                CallSpeechToText();
            }
        }
    }

    public void CallSpeechToText()
    {
        result = SpeechToText.Listen("_");
        listenButton.interactable = false;
    }


}
