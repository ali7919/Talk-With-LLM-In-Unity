using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class SpeechRecognitionController : MonoBehaviour {
    [SerializeField] private UnityEvent onStartRecording;
    [SerializeField] private UnityEvent onSendRecording;
    [SerializeField] public UnityEvent<string> onResponse;
    [SerializeField] private TMP_Dropdown m_deviceDropdown;
    [SerializeField] private Image m_progress;

    public RunWhisper runWhisper; // This is the reference to the RunWhisper script

    private string m_deviceName;
    private AudioClip m_clip;
    private byte[] m_bytes;
    private bool m_recording;

    private void Awake() {
        // Select the microphone device (by default the first one) but
        // also populate the dropdown with all available devices
        m_deviceName = Microphone.devices[0];
        foreach (var device in Microphone.devices) {
            m_deviceDropdown.options.Add(new TMP_Dropdown.OptionData(device));
        }
        m_deviceDropdown.value = 0;
        m_deviceDropdown.onValueChanged.AddListener(OnDeviceChanged);
    }

    /// <summary>
    /// This method is called when the user selects a different device from the dropdown
    /// </summary>
    /// <param name="index"></param>
    private void OnDeviceChanged(int index) {
        m_deviceName = Microphone.devices[index];
    }

    /// <summary>
    /// This method is called when the user clicks the button
    /// </summary>
    public void Click() {
        if (!m_recording) {
            StartRecording();
        } else {
            StopRecording();
        }
    }

    /// <summary>
    /// Start recording the user's voice
    /// </summary>
    private void StartRecording() {
        m_clip = Microphone.Start(m_deviceName, false, 10, 16000);
        m_recording = true;
        onStartRecording.Invoke();
    }

    /// <summary>
    /// Stop recording the user's voice and send the audio to the Whisper Model
    /// </summary>
    private void StopRecording() {
        var position = Microphone.GetPosition(m_deviceName);
        Microphone.End(m_deviceName);
        m_recording = false;
        SendRecording();
    }

    /// <summary>
    /// Run the Whisper Model with the audio clip to transcribe the user's voice
    /// </summary>
    private void SendRecording() {
        onSendRecording.Invoke();
        runWhisper.audioClip = m_clip;
        runWhisper.Transcribe();
    }

    private void Update() {
        if (!m_recording) {
            return;
        }

        m_progress.fillAmount = (float)Microphone.GetPosition(m_deviceName) / m_clip.samples;

        if (Microphone.GetPosition(m_deviceName) >= m_clip.samples) {
            StopRecording();
        }
    }
}
