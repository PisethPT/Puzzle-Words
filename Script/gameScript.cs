
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
    public Text time_text;
    float _time = 0f;
    bool _enabled = false;
    bool _active = false;
    public Slider _slider;
    public List<int> index_key;
    public List<Text> key_text = new List<Text>();
    public List<char> key_char = new List<char>(3);
    public char[] key_charSwaps;
    char swap;
    string true_word;
    int word;
    public Button start;
    string true_words;
    public bool click1, click2, click3;
    public GameObject[] check;
    string[] key_words = { "ASK", "YES", "YES","CAT","OUT","AND","BUY","YEP","HEY","FOR","NOR","BUT","ADD","HER","SHE","ARM","ART","ACE","OIL"
                          ,"YEA","NAW","USE","NEW","WAY","SUN","SAY","RUN","FUN","WAR","SEE","PRO"};
    void Start()
    {
        FindObjectOfType<music>().music_on();
        for (int i = 0; i < key_charSwaps.Length; i++)
            key_charSwaps[i] = ' ';
    }

    // Update is called once per frame
    void Update()
    {
        if (_enabled)
        {
            _time += Time.deltaTime;
            time_text.text = Mathf.Round(_time).ToString();
            _slider.value = _time;
            swap_character();
            compare_result();
            if (_time >= 10)
            {
                utils();
            }
        }
    }

    void utils()
    {
        start.enabled = true;
        _enabled = false;
        _time = 0f;
        key_char.Clear();
        key_text[0].text = "";
        key_text[1].text = "";
        key_text[2].text = "";
        _slider.value = 0;
        time_text.text = 0.ToString();
        true_word = "";
        check[0].SetActive(false);
        check[1].SetActive(false);
    }
    void compare_result()
    {
        for (int j = 0; j < key_char.Count; j++)
        {
            true_words += key_char[j];
        }

        for (int i = 0;i < key_words.Length; i++)
        {
            if (string.Equals(key_words[i], true_words))
            {
                FindObjectOfType<music>().win();
                check[1].SetActive(false);
                check[0].SetActive(true);
                
                print("True: " + key_words[i] + " ,like: " + true_words);
                StartCoroutine(wait());
                IEnumerator wait()
                {          
                    yield return new WaitForSeconds(1f);
                    utils();
                }

            }

        }
    }

    public void button_click(int n)
    {
        for (int i = 0; i < key_char.Count; i++)
        {
            if (i==n)
            {
               // key_charSwaps[n] = ' ';
                key_charSwaps[n] = key_char[i];
                click1 = true;
            }      
        }
    }
    public void button_click1(int n)
    {

        for (int i = 0; i < key_char.Count; i++)
        {
            if (i==n)
            {
               // key_charSwaps[n] = ' ';
                key_charSwaps[n] = key_char[i];
                click2 = true;
            }      
        }
    } 
    public void button_click2(int n)
    {
        for (int i = 0; i < key_char.Count; i++)
        {
            if (i==n)
            {
               // key_charSwaps[n] = ' ';
                key_charSwaps[n] = key_char[i];
                click3 = true;
            }   
        }

    }
    void swap_character()
    {
        if ((click1 && click2) || (click2 && click1))
        {
            swap = key_charSwaps[0];
            key_charSwaps[0] = key_charSwaps[1];
            key_charSwaps[1] = swap;
            key_char[0]= key_charSwaps[0];
            key_char[1]= key_charSwaps[1];
            
            click1 = click2 = false;
            key_text[0].text = key_charSwaps[0].ToString();
            key_text[1].text = key_charSwaps[1].ToString();
            swap = ' ';
            true_words = "";

        }        
        if ((click2 && click3) || (click3 && click2))
        {
            swap = key_charSwaps[1];
            key_charSwaps[1] = key_charSwaps[2];
            key_charSwaps[2] = swap;

            key_char[1] = key_charSwaps[1];
            key_char[2] = key_charSwaps[2];

            click2 = click3 = false;
            key_text[1].text = key_charSwaps[1].ToString();
            key_text[2].text = key_charSwaps[2].ToString();
            swap = ' ';
            true_words = "";
        }        
        if ((click1 && click3) ||(click3 && click1))
        {
            swap = key_charSwaps[0];
            key_charSwaps[0] = key_charSwaps[2];
            key_charSwaps[2] = swap;

            key_char[0] = key_charSwaps[0];
            key_char[2] = key_charSwaps[2];


            click1 = click3 = false;
            key_text[0].text = key_charSwaps[0].ToString();
            key_text[2].text = key_charSwaps[2].ToString();
            swap = ' ';
            true_words = "";
        }

       // compare_result(true_words);
    }

    public void start_button()
    {
        for(int i = 0; i < key_charSwaps.Length; i++)
            key_charSwaps[i] = ' ';
        _active = false;
        index_key.Clear();
        random_keyWord();
        _slider.value = 0f;
        _enabled = true;
        start.enabled = false;
    }

    void random_keyWord()
    {

            int d = 0;
            word = UnityEngine.Random.Range(0, key_words.Length - 1);
            for (int i = 0; i < key_words.Length; i++)
            {
                if (word.Equals(i))
                {
                do
                {
                    print("word: " + key_words[word]);
                    foreach (char c in key_words[word])
                    {
                        int key = UnityEngine.Random.Range(0, key_words[word].Length);
                        while (index_key.Contains(key)) key = UnityEngine.Random.Range(0, key_words[word].Length);
                        index_key.Add(key);
                       // print(key + " " + c);
                        key_char.Add(key_words[word][key]);
                      // key_text[d].text = key_char[d].ToString();
                        d++;

                    }
                    // compare_words();

                    for (int k = 0; k < key_char.Count; k++)
                    {
                        true_word += key_char[k];
                    }
                    for (int m = 0; m < key_words.Length; m++)
                    {
                        if (string.Equals(key_words[m], true_word))
                        {
                            print("word like");
                            _active = false;
                            print(_active);
                        }
                        else
                        {
                            print("word not like");
                            _active = true;
                            for (int l = 0; l < key_char.Count; l++)
                            {
                                key_text[l].text = key_char[l].ToString();
                            }

                        }
                    }
                    print(_active);
                } while (!_active);
                       
                }
            }
    }

    void compare_words()
    {

        for (int i = 0; i < key_char.Count; i++)
        {
            true_word += key_char[i];
        }
        for (int i = 0; i < key_words.Length; i++)
        {
            if (string.Equals(key_words[i],true_word))
            {
                print("word like");
                _active = true;
                print(_active);
            }
            else 
            {
                print("word not like");
                _active = false;
                for(int j = 0; j < key_char.Count; j++)
                {
                    key_text[j].text = key_char[j].ToString();
                }
                
            } 
        }
    }

    public void home_scenc()
    {
        SceneManager.LoadScene("Home");
    } 

}
