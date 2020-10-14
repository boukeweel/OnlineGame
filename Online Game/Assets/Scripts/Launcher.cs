using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace Com.MyCompany.MyGame{


    public class Launcher : MonoBehaviourPunCallbacks
    {

        // max player what can join a room before making a new room
        [SerializeField]
        private byte maxPlayersPerRoom = 10;

        [SerializeField]
        private GameObject controlPanal;

        [SerializeField]
        private GameObject proceslabel;


        string GameVersion = "1";


        bool isConnected;




        private void Awake()
        {

            // this makes sure when you call photonnetwork.loadlevel() on the master client and all clients in the same room is sync their levels
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        private void Start()
        {
            proceslabel.SetActive(false);
            controlPanal.SetActive(true);
        }


        /// <summary>
        /// start connection process.
        /// - if already connect, attempt to join room
        /// - if not connect, connect to a photon cloud network
        /// </summary>
        public void Connect()
        {
            proceslabel.SetActive(true);
            controlPanal.SetActive(false);

            if (PhotonNetwork.IsConnected == true)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                isConnected = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = GameVersion;
            }
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN basic Turorial/launcher: OnConnectedToMaster() Was Called by PUN");

            // we joind a random room if it is not there it calls onjoinRandomfailed()

            if (isConnected)
            {
                PhotonNetwork.JoinRandomRoom();
                isConnected = false;
            }
            


        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            proceslabel.SetActive(false);
            controlPanal.SetActive(true);
            isConnected = false;

            Debug.Log("Disconected Because" + cause);   
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // this makes it own room
            PhotonNetwork.CreateRoom(null, new RoomOptions());
        }

        public override void OnJoinedRoom()
        {
            if(PhotonNetwork.CurrentRoom.PlayerCount ==1)
            {
                Debug.Log("we load the room for 1");

                PhotonNetwork.LoadLevel("Room for 1");
            }
        }

    }
}
