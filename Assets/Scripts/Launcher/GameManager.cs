using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {

        public GameObject playerPrefab;

        void Start()
        {

            if (playerPrefab != null)
            {
                float xoffset = (PhotonNetwork.CountOfPlayers == 1) ? -5 : 5;
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(xoffset, -1f, 0f), Quaternion.identity);
            }
        }

        #region Photon Callbacks


        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }


        #endregion


        #region Public Methods


        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }


        #endregion
    }
}