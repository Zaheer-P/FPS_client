using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //store player infro on client side
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();


    public GameObject localPlayerPrefab;
    public GameObject PlayerPrefab;

    private void Awake()
    {
        //singleton instance
        if (instance == null)
        {
            instance = this;
            Debug.Log("inst = hrioa thisoe one");
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Debug.Log("inst exists, destroy!");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(PlayerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().Initialize(_id, _username);
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }
}
