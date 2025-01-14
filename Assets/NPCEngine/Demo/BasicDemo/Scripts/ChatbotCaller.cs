using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPCEngine;
using NPCEngine.API;
using NPCEngine.Utility;
using NPCEngine.Components;

public class ChatbotCaller : MonoBehaviour
{
    public InputField Temperature;
    public InputField TopK;
    public InputField LocationName;
    public InputField Location;
    public InputField Name;
    public InputField Persona;
    public InputField OtherName;
    public InputField OtherPersona;

    public Text ChatWindow;

    public InputField ChatInput;

    public Button SendButton;

    ResultFuture<string> result;

    public List<ChatLine> history;

    private void Start()
    {
        this.history = new List<ChatLine>();
    }

    public void RunChatbot()
    {
        this.history.Add(new ChatLine { speaker = OtherName.text, line = ChatInput.text });
        ChatInput.text = "";
        var context = new FantasyChatbotContext
        {
            location = Location.text,
            location_name = LocationName.text,
            name = Name.text,
            persona = Persona.text,
            other_name = OtherName.text,
            other_persona = OtherPersona.text,
            history = this.history
        };
        result = Chatbot<FantasyChatbotContext>.GenerateReply(context, float.Parse(Temperature.text), Int32.Parse(TopK.text));
        SendButton.interactable = false;
    }

    public void ClearHistory()
    {
        history = new List<ChatLine>();
        RenderChat();
    }

    public void RenderChat()
    {
        ChatWindow.text = "";
        foreach (var chatLine in history)
        {
            ChatWindow.text += String.Format("{0}: {1}\n", chatLine.speaker, chatLine.line);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (result != null && result.ResultReady)
        {
            history.Add(new ChatLine { speaker = Name.text, line = result.Result });
            RenderChat();
            SendButton.interactable = true;
            result = null;
        }
    }
}
