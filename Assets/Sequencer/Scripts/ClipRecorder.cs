using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// IPointerDownHandler, IPointerUpHandler
public class ClipRecorder : MonoBehaviour
{
    AudioClip recording;
    AudioSource audioSource;
    private int minFreq;
    private int maxFreq;


    private float startRecordingTime;

    private void Start()
    {
        foreach (string s in Microphone.devices)
        {
            print(s);
        }
        Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

        //According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...
        if (minFreq == 0 || maxFreq == 0)
        {
            //...meaning 44100 Hz can be used as the recording sampling rate
            maxFreq = 44100;
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", false,300, maxFreq);
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
    }

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    //End the recording when the mouse comes back up, then play it
    //    Microphone.End("");

    //    //Trim the audioclip by the length of the recording
    //    AudioClip recordingNew = AudioClip.Create(recording.name, (int)((Time.time - startRecordingTime) * recording.frequency), recording.channels, recording.frequency, false);
    //    float[] data = new float[(int)((Time.time - startRecordingTime) * recording.frequency)];
    //    recording.GetData(data, 0);
    //    recordingNew.SetData(data, 0);
    //    this.recording = recordingNew;

    //    //Play recording
    //    audioSource.clip = recording;
    //    audioSource.Play();

    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    //Get the max frequency of a microphone, if it's less than 44100 record at the max frequency, else record at 44100
    //    int minFreq;
    //    int maxFreq;
    //    int freq = 44100;
    //    Microphone.GetDeviceCaps("", out minFreq, out maxFreq);
    //    if (maxFreq < 44100)
    //        freq = maxFreq;

    //    //Start the recording, the length of 300 gives it a cap of 5 minutes
    //    recording = Microphone.Start("", false, 300, 44100);
    //    startRecordingTime = Time.time;
    //}





}
