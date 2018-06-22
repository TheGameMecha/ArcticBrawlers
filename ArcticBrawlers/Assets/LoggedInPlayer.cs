using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoggedInPlayer : MonoBehaviour {

    public Text curUser;
   
	

    private void FixedUpdate()
    {
        curUser.text = PlayerPrefs.GetString("name");

    }
    public void logout()
    {
        PlayerPrefs.SetInt("remember", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Login");
       
        
    }

   

}
