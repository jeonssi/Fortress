using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using UnityEngine.UI;
using Unity.VisualScripting;
using PlayFab.EconomyModels;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0) return;

            //inputField �� �ִ� �ؽ�Ʈ�� �����ɴϴ�.
            string talk = PhotonNetwork.LocalPlayer.NickName + " : " + inputField.text;

            //RPC Target.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk() �Լ��� �����϶�� ����� ����
            photonView.RPC("Talk", RpcTarget.All, talk);
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        //Prefab�� �ϳ� ������ ���� text ���� ����
        GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"));


        //prefab �����Ʈ�� Text ������Ʈ�� �����ؼ� text.�� ���� ����
        talk.GetComponent<Text>().text = message;

        //��ũ�� �� = contetn ������Ʈ�� �ڽ����� ���
        talk.transform.SetParent(parentTransform);

        //ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����մϴ�.
        inputField.ActivateInputField();

        Canvas.ForceUpdateCanvases();

        //��ũ���� ��ġ�� �ʱ�ȭ
        scrollRect.verticalNormalizedPosition = 0.0f;

        //inputField�� �ؽ�Ʈ�� �ʱ�ȭ
        inputField.text = "";
    }

}