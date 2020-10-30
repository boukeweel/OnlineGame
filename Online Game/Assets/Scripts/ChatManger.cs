using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class ChatManger : MonoBehaviourPunCallbacks
{
    // ik heb hier een deel van kelvin gehad omdat ik het in de les had gemist en hem had gevraagt hoe ik het moest doen

    public TMP_Text chatBox;
    public TMP_InputField inputField;

    

    public static ChatManger instace;

    

    private void Awake()
    {
        instace = this;
    }
    private void Start()
    {
        chatBox.text = "";
        inputField.text = "";
        PhotonNetwork.Instantiate("Chatter", Vector3.zero, Quaternion.identity);
        
    }
    public override void OnLeftRoom()
    {
        
        SceneManager.LoadScene(0);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        chatBox.text += string.Format("<color=grey>{0} is erbij gekomen!</color>\n", newPlayer.NickName);
        
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        chatBox.text += string.Format("<color=grey>{0} is weg gegaan</color>\n", otherPlayer.NickName);
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
    }

    public void start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(2);
        }
    }

}
