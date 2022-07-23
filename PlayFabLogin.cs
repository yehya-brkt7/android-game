using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

//This script is to manage all online data behaviours of the game

public class PlayFabLogin : MonoBehaviour
{
	
	public GameObject rowPrefab; //position of the leaderboard to be shown
	public Transform rowsParent; //LeaderBoard header  
	
    public void Start()
    {
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId)){
            PlayFabSettings.TitleId = "DEF86"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true}; //Anonymous Login according to the deviceUniqueIdentifier
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure); 
    }
	

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
	
	public void SendLeaderBoard(int startTimeconverted) { //Send time recorded to database when finish line is crossed
		
		var request = new UpdatePlayerStatisticsRequest {
			Statistics = new List<StatisticUpdate> {
				new StatisticUpdate {
					StatisticName = "TimeScores", Value = startTimeconverted
				}
			}
		};
		PlayFabClientAPI.UpdatePlayerStatistics(request ,OnLeaderboardUpdate, OnLoginFailure);
	}
	
	void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
		
		Debug.Log("Successful LeaderBoard Sent");
	}
	
	public void GetLeaderboard() { //Get leaderboard data from database
		
		var request = new GetLeaderboardRequest {
			
			StatisticName = "TimeScores", StartPosition = 0, MaxResultsCount = 6
		};
		PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnLoginFailure);
	}
	
	void OnLeaderboardGet(GetLeaderboardResult result) { //Show leaderboard data in game
		
		foreach (Transform item in rowsParent) {
			
			Destroy(item.gameObject);
		}
		
		foreach (var item in result.Leaderboard) {
			
			
			GameObject newGo = Instantiate(rowPrefab, rowsParent);
			Text[] texts = newGo.GetComponentsInChildren<Text>();
			texts[0].text = (item.Position + 1).ToString();
			texts[1].text = item.DisplayName;
			texts[2].text = item.StatValue.ToString();
			

		Debug.Log(string.Format("Place: {0} | ID: {1} | Value: {2}",
			item.Position, item.DisplayName, item.StatValue));
			
		}
	}
	
	public InputField nameInput; //input player's name to show on leaderboard
	public void SubmitNameButton() {
		
		var request = new UpdateUserTitleDisplayNameRequest {
			DisplayName = nameInput.text,
		};
		PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnLoginFailure);	
		
	}
	
	void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result) {
		Debug.Log("Updated Display Name!");
		
	}
}





