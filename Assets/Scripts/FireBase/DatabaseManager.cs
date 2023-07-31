using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    public InputField Name;
    public InputField Gold;

    public Text _nameText;
    public Text _goldText;

    string _userID;
    DatabaseReference _databaseReference;
    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()
    {
        User newUser = new User(Name.text, int.Parse(Gold.text));
        if (newUser == null)
            Debug.Log("New user is null");

        string json = JsonUtility.ToJson(newUser);

        _databaseReference.Child("users").Child(_userID).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetName(Action<string> onCallback)
    {
        var userNameData = _databaseReference.Child("users").Child(_userID).Child("_name").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapShot = userNameData.Result;
            onCallback.Invoke(snapShot.Value.ToString());            
        }
    }

    public IEnumerator GetGold(Action<int> onCallback)
    {
        var userGoldData = _databaseReference.Child("users").Child(_userID).Child("_gold").GetValueAsync();

        yield return new WaitUntil(predicate: () => userGoldData.IsCompleted);

        if (userGoldData != null)
        {
            DataSnapshot snapShot = userGoldData.Result;
            onCallback.Invoke(int.Parse(snapShot.Value.ToString()));
        }
    }

    public void GetUserInfo()
    {
        StartCoroutine(GetName((string name) => {
            _nameText.text = "Name: " + name;
        }));

        StartCoroutine(GetGold((int gold) => {
            _goldText.text = "Gold:" + gold.ToString();
        }));
    }

    public void UpdateName()
    {
        _databaseReference.Child("users").Child(_userID).Child("_name").SetValueAsync(Name.text);
    }

    public void UpdateGold()
    {
        _databaseReference.Child("users").Child(_userID).Child("_gold").SetValueAsync(Gold.text);
    }

}



