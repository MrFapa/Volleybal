using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject progessLabel;

    [SerializeField] private byte maxPlayerPerRoom = 4;
    string gameVersion = "1";


    Button playButton;
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        progessLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    public void Connect()
    {
        progessLabel.SetActive(true);
        controlPanel.SetActive(true);

        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("passier");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = this.gameVersion;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("trying to connect to Master");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Disconnect");
        progessLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join, creating new one");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayerPerRoom });
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
        Debug.Log("Joined room");
    }
}
