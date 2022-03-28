using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int speed;
    [SerializeField] GameObject AncientRadiant;
    [SerializeField] GameObject AncientDire;
    private static GameObject player;
    private void Start()
    {
        Time.timeScale = speed;
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Heroes/Void Spirit"), new Vector3(-35, -35, 0), Quaternion.identity);
    }
    public static void GameEnd(bool isRadiant)
    {
        if (isRadiant)
        {
            Text text;
            text = player.GetComponent<PlayerScript>().text;
            text.gameObject.SetActive(true);
            text.color = Color.green;
            text.text = "Radiant Victory";
        }
        else if (!isRadiant)
        {
            Text text;
            text = player.GetComponent<PlayerScript>().text;
            text.gameObject.SetActive(true);
            text.color = Color.red;
            text.text = "Dire Victory";
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("SampleScene");
    }
}
