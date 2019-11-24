using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.TextCore;
using TMPro;
using UnityEngine.UI;
public class Post : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_InputField t;
    public Image c1;
    public Image c2;
    public delegate void Callback(string s);
    public Callback scoreCallback;

    public GameObject li;
    public Transform liParent;

    bool state1 = true;
    public Button b1;

    private void Start()
    {
        scoreText.text = "Score: " + ScoreContainer.instance.score.ToString();
    }

    public void PostScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", t.text);
        form.AddField("score", ScoreContainer.instance.score);
        StartCoroutine(PostRequest(form, "https://oscarlundberg.com/FiveCityGameJam/posthighscore.php", PostScore));
        print(t.text);
        c1.gameObject.SetActive(false);
        state1 = false;
    }

    IEnumerator PostRequest(WWWForm data, string url, Callback call = null)
    {
        using (UnityWebRequest req = UnityWebRequest.Post(url, data))
        {
            yield return req.SendWebRequest();

            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log(req.error);
            }
            else
            {
                call?.Invoke(req.downloadHandler.text);
            }
        }
    }

    void PostScore(string x)
    {
        GetScore();
    }

    public void GetScore()
    {
        StartCoroutine(PostRequest(null, "https://oscarlundberg.com/FiveCityGameJam/dumphighscore.php", DisplayScore));
    }

    void DisplayScore(string s)
    {
        c2.gameObject.SetActive(true);
        print(s);
        Response r = JsonUtility.FromJson<Response>("{\"posts\":" + s + "}");

        int i = 1;
        foreach(Scorepost sp in r.posts)
        {
            GameObject listItem = Instantiate(li, liParent) as GameObject;
            ScoreListItem sli = listItem.GetComponent<ScoreListItem>();
            sli.score = sp.score;
            sli.name = sp.name;
            sli.index = i;
            i++;
        }

    }

    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetKey(KeyCode.P))
            {
                print(t.text);
                ScoreContainer.instance.score = 12;
            }
        }

        if(!state1)
            return;

        if(t.text.Length > 2)
        {
            b1.interactable = true;
        }
        else
        {
            b1.interactable = false;
        }
    }
}