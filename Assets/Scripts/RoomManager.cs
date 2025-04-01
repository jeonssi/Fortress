using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleInputFiled;
    [SerializeField] InputField capacityInputField;
    [SerializeField] GameObject roomPrefab;
    [SerializeField] InputField PlayerCount;

    [SerializeField] Transform parentTransform;

    [SerializeField] Dictionary<string ,GameObject> dictionary = new Dictionary<string, GameObject> ();

    void Start()
    {
        if(PhotonNetwork.InLobby == false)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    
    public override void OnConnectedToMaster()
    {
        if(PhotonNetwork.InLobby == false)
        {
            PhotonNetwork.JoinLobby();
            
            // ������ �Ϸ�Ǿ����� �κ� �����մϴ�.
            Debug.Log("Connected to Master Server!");

        }
      
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();    

        roomOptions.MaxPlayers = byte.Parse(capacityInputField.text);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(titleInputFiled.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject prefab = null;

        foreach (RoomInfo room in roomList)
        {
            if(room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out prefab);

                Destroy(prefab);

                dictionary.Remove(room.Name);
            }
            else
            {
                if(dictionary.ContainsKey(room.Name) == false)
                {
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"),parentTransform);

                    clone.GetComponent<Information>().View(room.Name, room.PlayerCount, room.MaxPlayers);

                    dictionary.Add(room.Name, clone);
                }
                else// ���� ������ ����Ǵ� ��� == �濡 ��� ���������ų�, ���ö�
                {
                    dictionary.TryGetValue(room.Name, out prefab);

                    prefab.GetComponent<Information>().View(room.Name, room.PlayerCount, room.MaxPlayers);
                    //Information info = dictionary[room.Name].GetComponent<Information>();   

                    //if(info != null)
                    //{
                    //    info.View(room.Name, room.PlayerCount, room.MaxPlayers);
                    //}
                    //else
                    //{
                    //    Debug.Log("������Ʈ ����");
                    //}
                }

                //GameObject roomObject = Instantiate(roomPrefab, parentTransform);
                //Information info = roomObject.GetComponent<Information>();

                //string roomName = titleInputFiled.text;
                //int currentStaff = 1;
                //int maxPlayer = int.Parse(capacityInputField.text);
                //info.View(roomName, currentStaff, maxPlayer);

                //dictionary[roomName] = gameObject;

            }
        }

        
    }


}
