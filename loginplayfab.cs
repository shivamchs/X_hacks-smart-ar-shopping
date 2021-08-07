using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loginplayfab : MonoBehaviour
{
    private string userEmail;
    private string userPassword;
    private string username;
    public Text message;
    public InputField email;
    public InputField password;
    public InputField user;

    //This is public GameObject loginPanel;

    public void Start()
    {
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "B0A1C"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        // var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

        if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");

        }
    }

    private void OnLoginSuccess(LoginResult result)
    {
        message.text = "logIn successfully!!";
        Debug.Log("Congratulations, you made your first successful API call!");
       // PlayerPrefs.SetString("EMAIL", userEmail);
        //PlayerPrefs.SetString("PASSWORD", userPassword);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        message.text = error.ErrorMessage;
    }
   /* public void GetUserEmail(string email)
    {
        userEmail = email;
    }
    public void GetUserPassword(string password)
    {
        userPassword = password;
    }
    public void GetUsername(string uname)
    {
        username= uname;
    }*/
    public void onclicklogin()
    {//if (userEmail != null)
        var request = new LoginWithEmailAddressRequest {Email = email.text, Password = password.text};
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
       // PlayerPrefs.SetString("EMAIL", userEmail);
        //PlayerPrefs.SetString("PASSWORD", userPassword);

    }
    public void onclickregister()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = email.text, Password = password.text, Username = user.text};
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, Onregistersuccess, Onregisterfailure);
       /* PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayerPrefs.SetString("USERNAME", username);*/

    }
    private void Onregistersuccess(RegisterPlayFabUserResult result)
    {
        //var request = new LoginWithEmailAddressRequest { Email = email.text, Password = password.text };
        //PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        message.text = "registered successfully!!";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Onregisterfailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        message.text = error.ErrorMessage;
    }
    
}
