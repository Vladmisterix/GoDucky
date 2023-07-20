using UnityEngine.Advertisements;
using UnityEngine;

public class ShowAdds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener, IUnityAdsLoadListener
{
    private string _androidGameId = "5332896";
    private string _iosGameId = "5332897";
    private bool _isTestMode = true;
    private string _gameId;

    private string _androidAdUnitId = "Interstitial_Android";
    private string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    private void Awake()
    {
        InitializeAds();
    }
    private void InitializeAds()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _gameId = _iosGameId;
            _adUnitId = _iOsAdUnitId;
        }
        else
        {
            _gameId = _androidGameId;
            _adUnitId = _androidAdUnitId;
        }


        Advertisement.Initialize(_gameId, _isTestMode, this);
    }

    public void OnInitializationComplete()
    {
        Advertisement.Load(_adUnitId);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Advertisement.Show(adUnitId);
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }
    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}
