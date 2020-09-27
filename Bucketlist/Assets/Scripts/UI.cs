using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField] public GameObject UIElement;
    [SerializeField] public GameObject Options;
    [SerializeField] public List<string> Listitems;
    [SerializeField] public List<GameObject> Textitems;
    [SerializeField] public List<bool> HaveBeenHere;
    [SerializeField] public GameObject Number;
    public int N = 1;
    public RectTransform pos;
    public bool Active;

    // Start is called before the first frame update
    void Start()
    {
        UIElement.SetActive(false);
        pos = Options.GetComponent<RectTransform>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit")){
            if (!Active){
                GetComponent<AudioSource>().Play(0);
                UIElement.SetActive(false);
                pos.localPosition = new Vector2(372, 26);
                Active = true;
            }
            else
            {
                GetComponent<AudioSource>().Play(0);
                UIElement.SetActive(true);
                pos.localPosition = new Vector2(195, 26);
                Active = false;

            }
        }
    }
    public void UpdateUI(GameObject door){
        for (int i = 0; i < 10;i++){
            if (door.tag == i.ToString()){
                if (!HaveBeenHere[i]){
                    HaveBeenHere[i] = true;
                    Text TT = Textitems[i].GetComponent<Text>();
                    TT.text = Listitems[i];
                    TT.color = Color.white;
                    TT.fontSize = 10;
                    Number.GetComponent<Text>().text = N.ToString() + "/10";
                    N = N + 1;
                }


            }
        }
    }

}
