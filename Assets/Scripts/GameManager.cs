 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// ���� ���� ��Ģ ���� �Ŵ���
// ���� ���� ����
// ���� ���� ���..
public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    static public bool isGamePause = false;
    static public bool isEnding = false;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake(){
        if(instance != null){
            Debug.LogError("systemManager error");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [SerializeField]
    Player player;

    [SerializeField]
    Player[] players;


    public Player Player
    {
        get { return player; }
    }

    public Player[] Players
    {
        get { return players; }
    }

    [SerializeField]
    CameraMove camera;

    public CameraMove Camera
    {
        get { return camera; }
    }

    // ���� ���۹�ư ������ ��
    public void OnClickStartButton()
    {
        // 0�� �� Ȱ��ȭ
        // �÷��̾ 0���� ������
        // ������ 0���� ������
        // ���ӳ� UI Ȱ��ȭ
        // ���丮 �������
    }

    public void EndGame()
    {
        isEnding = true;
        Debug.Log("****** Game Cleer! ******");
        SceneManager.LoadScene("Ending");
    }
}
