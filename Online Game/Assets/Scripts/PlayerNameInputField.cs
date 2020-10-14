using System.Collections;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;


[RequireComponent(typeof(TMP_InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    const string playerNamePrefKey = "PlayerName";


    private void Start()
    {
        string defaultName = string.Empty;

        TMP_InputField inputField = this.GetComponent<TMP_InputField>();

        inputField.text = "";

        if(inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName(string valeu)
    {
        if (string.IsNullOrEmpty(valeu))
        {
            Debug.LogError("Player name Is null or empty");
            return;
        }
        PhotonNetwork.NickName = valeu;

        PlayerPrefs.SetString(playerNamePrefKey, valeu);
    }
}


