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
            
            // 연결이 완료되었으면 로비에 참가합니다.
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
                else// 룸의 정보가 변경되는 경우 == 방에 사람 빠져나가거나, 들어올때
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
                    //    Debug.Log("컴포넌트 없음");
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
