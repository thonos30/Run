using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public playerController player;
    public Text teksGame;
    public Camera gameCamera;
    public GameObject[] blockPrefabs;
    private float blockPointer = 20;
    private float safeMargin = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(player != null && blockPointer < player.transform.position.x + safeMargin)
        {
            int blockIndex = Random.Range(0, blockPrefabs.Length);
            if(blockPointer < 20)
            {
                blockIndex = 0;
            }
            GameObject objekBlok = GameObject.Instantiate<GameObject>(blockPrefabs[blockIndex]);
            objekBlok.transform.SetParent(this.transform);
            blockController block  = objekBlok.GetComponent<blockController>();
            objekBlok.transform.position = new Vector3(blockPointer / block.size / 2, 0, 0);
            blockPointer += block.size;
        }
        if(player != null)
        {
            gameCamera.transform.position = new Vector3
            (player.transform.position.x, 
            gameCamera.transform.position.y, 
            gameCamera.transform.position.z);
            teksGame.text = "Score : " + Mathf.Floor(player.transform.position.x);
        }
        else
        {
            teksGame.text += "\nTekan R untuk Restart";
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
