using HarmonyLib;
using UnityEngine;

namespace REPOUtility;

public static class ChatHelper
{
    public static void SendMessage(string message)
    {
        ChatManager.instance.ForceSendMessage(message);
    }

    public static bool IsChatActive()
    {
        return ChatManager.instance.StateIsActive();
    }

    public static bool IsChatPossessed()
    {
        return ChatManager.instance.StateIsPossessed();
    }

    public static void SpeakTTS(string text, bool crouch = false)
    {
        var tts = PlayerVoiceChat.instance?.ttsVoice;
        if (tts == null)
        {
            Plugin.Log.LogWarning("SpeakTTS: TTSVoice not available");
            return;
        }
        tts.TTSSpeakNow(text, crouch);
    }

    public static void StopTTS()
    {
        PlayerVoiceChat.instance?.ttsVoice?.StopAndClearVoice();
    }

    public static bool IsSpeaking()
    {
        var tts = PlayerVoiceChat.instance?.ttsVoice;
        if (tts == null) return false;
        var field = AccessTools.Field(typeof(TTSVoice), "isSpeaking");
        return (bool)field.GetValue(tts);
    }
}
