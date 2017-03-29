# Unity SDK for Nether

## Work in Progress 
There is currently a beta SDK of Unity SDK for Nether that you can find in the src folder.

## Downloading the Unity SDK for Nether
Nether Unity SDK is open source and freely downloadable from Unity Asset Store. Current code is built with 5.5.2 but should work on all 5.x editions of Unity. Nether SDK for Unity has no dependencies on other packages, apart from potential libraries from authentication providers (e.g. Facebook).

### Installing the Unity SDK for Nether
Installation is simple. You download the package from the Unity Asset Store and extract all files to your project. You can find a scene named "test" and a "UIScript" script that contain some example code that you can borrow.

### Making Unity SDK for Nether work with your project

1. drag the prefab called "NetherClient" into the scene. This contains a singleton class for easy and reliable access
2. set your Nether deployment endpoint URL on the prefab's properties. Also set clientID, clientSecret and scope
3. configure authentication in your game (e.g. Facebook). You may need to download external library for this purpose, e.g. you can find the Facebook SDK for Unity [here](https://developers.facebook.com/docs/unity/)
4. You're done! Now you can call Nether methods

### Usage

Generally, Nether access methods have the signature **NetherSDK.Instance.DoSomething(instanceForPutOrPost, callbackWithResultOrError)**. 

#### Get Nether token

After you get the token from the authentication provider of your choice, you need to get a Nether token. For example, if you are using Facebok authentication, you could do the following

```csharp
if (FB.IsLoggedIn)
        {
            //get access token
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            //token is automatically saved in NetherClient.Instance
            NetherClient.Instance.GetAccessToken(aToken.TokenString, s =>
            {
                Debug.Log("Got token " + s); 
            });

        }
```

Token is saved in the **NetherClient.Instance** instance, and you can then safely call implemented class methods.

#### Post a score

You can use the NetherClient.Instance.PostScore method to post a Score to Nether

```csharp
public void PostScoreAction()
    {
        NetherClient.Instance.PostScore(new Score() { country = "Greece", score = 50 }, result =>
        {
            if (result.Status == CallBackResult.Success)
            {
                Debug.Log("SUCCESS posting score");
            }
            else
            {
                StatusText.text = result.Exception.Message;
                if (result.NetherError != null)
                    Debug.Log(result.NetherError.ToString());
            }
        });
    }
```

#### Get Player

You can use the NetherClient.Instance.GetPlayer method to get player's details

```csharp
NetherClient.Instance.GetPlayer (result => {
			if (result.Status == CallBackResult.Success) {
				Debug.Log (result.Result.gamertag.ToString ());
				StatusText.text = result.Result.gamertag.ToString ();
			} else {
				Debug.Log (result.Exception.Message);
				StatusText.text = result.Exception.Message;
			}
		});
```

#### Put Player

You can use the NetherClient.Instance.PutPlayer method to update player's details

```csharp
NetherClient.Instance.PutPlayer (new Player () {
			gamertag = "dgkanatsios",
			country = "Greece",
			customTag = "myCustomTag"
		}, result => {
			if (result.Status == CallBackResult.Success) {
				Debug.Log ("SUCCESS putting player");
				StatusText.text = "SUCCESS putting player";
			} else {
				Debug.Log (result.Exception.Message);
				StatusText.text = result.Exception.Message;
				if (result.NetherError != null)
					Debug.Log (result.NetherError.ToString ());
			}
		});
```

#### Get Leaderboards action

You can use the NetherClient.Instance.GetLeaderboards method to get leaderboards

```csharp
NetherClient.Instance.GetLeaderboards (result => {
			if (result.Result != null && result.Result.Length > 0) {
				foreach (var item in result.Result) {
					Debug.Log (item.name + " " + item._link);
				}
			} else
				Debug.Log ("no leaderboards available");
		});
```

#### Post Data

You can use the NetherClient.Instance.PostData method to post custom data. This posts the data to Nether deployment's Event Hub instance.

```csharp
NetherClient.Instance.PostData(new DeviceCapabilities() { cpu = "ARM", ram = "2 GB" }, result => {
            if (result.Status == CallBackResult.Success)
            {
                Debug.Log("SUCCESS posting to event hub");
                StatusText.text = "SUCCESS posting to event hub";
            }
            else
            {
                Debug.Log(result.Exception.Message);
                StatusText.text = result.Exception.Message;
                if (result.NetherError != null)
                    Debug.Log(result.NetherError.ToString());
            }
        });
```
