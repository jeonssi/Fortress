using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class Watch : MonoBehaviourPun
{
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        double time = PhotonNetwork.Time;

        int totalMilliseconds = (int)(time * 1000);

        int hours = totalMilliseconds / (1000 * 60 * 60);
        int minutes = (totalMilliseconds / (1000 * 60)) % 60;
        int seconds = (totalMilliseconds / 1000) % 60;
        int milliseconds = totalMilliseconds % 1000;

        text.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", hours, minutes, seconds, milliseconds);
    }
}
