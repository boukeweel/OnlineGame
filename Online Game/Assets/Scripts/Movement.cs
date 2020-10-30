using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Movement : MonoBehaviourPunCallbacks
{
    private Vector2 M_move;
    private SpriteRenderer sp;
    public TMP_Text Name;

    private void Start()
    {
        //sprite render
        //animator
        sp = GetComponent<SpriteRenderer>();
        name = PhotonNetwork.NickName;
        M_move = Vector3.zero;
    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                M_move.y = 3;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                M_move.y = -3;
            }
            else
            {
                M_move.y = 0;
            }


            if (Input.GetKey(KeyCode.D))
            {
                M_move.x = 3;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                M_move.x = -3;
            }
            else
            {
                M_move.x = 0;
            }

            transform.Translate(M_move * Time.deltaTime);
        }
    }
}
