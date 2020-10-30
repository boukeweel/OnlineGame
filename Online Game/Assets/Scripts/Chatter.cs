using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Chatter : MonoBehaviourPunCallbacks, IPunObservable
{
    //ik heb dit gedeelte een deel van kelvin en van lance
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("doe je dit");
            if(ChatManger.instace.inputField.text.Length > 0)
            {
                photonView.RPC("SendChat", RpcTarget.Others, ChatManger.instace.inputField.text);
                SendChat(ChatManger.instace.inputField.text);
                ChatManger.instace.inputField.text = "";
                ChatManger.instace.inputField.ActivateInputField();
            }
        }
    }

    //ontvangt de rest van de spelers
    [PunRPC]
    public void SendChat(string _chatmessage, PhotonMessageInfo _info)
    {
        ChatManger.instace.chatBox.text += string.Format("{0}<color=red>{1}</color>: {2}\n", _info.Sender.IsMasterClient ? ":)" : "", _info.Sender.NickName, _chatmessage);
        if (_info.Sender.NickName == ":")
        {
            _info.Sender.NickName = "Player:" + Random.Range(0, 20);
        }
    }

    //dit ontvang jij aleen
    public void SendChat(string _chatmessage)
    {
        ChatManger.instace.chatBox.text += string.Format("{0}<color=red>{1}</color>: {2}\n", PhotonNetwork.IsMasterClient ? ":)" : "", PhotonNetwork.NickName, _chatmessage);
        if (PhotonNetwork.NickName == ":")
        {
            PhotonNetwork.NickName = "Player:" + Random.Range(0, 20);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //throw new System.NotImplementedException();
    }
}
