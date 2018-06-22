using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



    public class PlayerNameInput : MonoBehaviour
    {
        public InputField nameField;
        public Toggle rememberMe;
        public Text errorText;
    GameObject lobby;
        public string pName;

        private void Awake()
        {

            errorText.text = "";
            gameObject.SetActive(true);
            pName = PlayerPrefs.GetString("name");
            nameField.text = pName;

        lobby = GameObject.Find("LobbyManager");
        if(lobby == null)
        {
            return;
        }
        if(lobby != null)
        {
            lobby.SetActive(false);
        }
        if(PlayerPrefs.GetInt("remember") == 1)
        {
            rememberMe.isOn = true;
        }
        else if(PlayerPrefs.GetInt("remember") == 0)
        {
            rememberMe.isOn = false;
        }
       
        }

    private void Start()
    {
        if (rememberMe.isOn)
        {
            if(pName.Length > 0)
            {
                PlayerPrefs.SetString("name", pName);
                PlayerPrefs.Save();
                SceneManager.LoadScene("NetworkLobby");
                Debug.Log("loading lobby");
            }
           else if(pName.Length <= 0)
            {
                errorText.text = "Please Insert a Player Name";
                Debug.LogWarning("Please insert a user name");
            }
        }
        else if(!rememberMe.isOn)
        {
            
            Debug.Log("Dont load");
        }
    }
    public void changeName()
        {
        pName = nameField.text;
        if (pName.Length <= 0)
        {
            errorText.text = "Please Insert a Player Name";
        }
        else
        {
            if(lobby != null)
            {
                lobby.SetActive(true);
            }
            PlayerPrefs.SetString("name", pName);
            PlayerPrefs.Save();
            SceneManager.LoadScene("NetworkLobby");
        }
            
        }

    public void rememberPlayer(bool toggle)
    {
        if (toggle)
            PlayerPrefs.SetInt("remember", 1);
        if (!toggle)
            PlayerPrefs.SetInt("remember", 0);
        PlayerPrefs.Save();
    }
    
       
    }
