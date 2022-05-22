using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Branching : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Button[] _button_etapes;
    [SerializeField]
    private List<GameObject> _filtrage_etapes;
    [SerializeField]
    private List<GameObject> _liste_etapes;
    private int _randomGenerator;
    private int _randomBranch;
    private int _mapLenght = 4;
    private bool _mapGenerated = false;
    private bool _pathGenerated = false;
    private int _activeNodes = 0;

    [SerializeField]
    private GameObject _start;
    [SerializeField]
    private GameObject _end;

    [SerializeField]
    private GameObject[] _trailMakers;

    [SerializeField]
    private Text _text;
    private string[] _etape0Texts = { "Il était une fois, Nicolas Loth", "Il était une fois, Louis Celeyron", "Il était une fois, Nathalie Riès", "Il était une fois, Axel Domenger", "Il était une fois, Thibault Jaouen" };
    private string[] _etape1Texts = { "Sur un dragon", "Dans un carton", "Sous une cape d'invisibilité", "Face à un dinosaure", "Portant un gilet jaune" };
    private string[] _etape2Texts = { "En train de miner de la cryptomonnaie", "Prit en flagrant délit de tendresse", "En train de tondre des moutons", "Venant tout juste de se découvrir un amour incontrôlable envers les JV2B", "En direction de la lune pour défoncer des extra-terrestres" };
    private string[] _etape3Texts = { "Quand soudainement, une poule géante débarque de nulle part et l'écrase. RIP petit ange parti trop tôt", "C'est alors qu'une équipe de pompier arrive et l'arrosent.", "Quand soudain, tout le monde se mit à courir comme Naruto.", "Se dit qu'iel devrait ajouter 30 points sur la moyenne générale de Kévin, parce que why not" };
    void Start()
    {
        _liste_etapes = _filtrage_etapes;
        StartCoroutine(GenerateMap());
        for (int i = 4; i <= 15; i++)
        {
            _button_etapes[i].GetComponent<Image>().color = Color.grey;
            _button_etapes[i].GetComponent<Button>().enabled = false;
            
        }
        _end.GetComponent<Image>().color = Color.grey;
        _end.GetComponent<Button>().enabled = false;
        _start.GetComponent<Image>().color = Color.grey;
        _start.GetComponent<Button>().enabled = false;
    }

    private IEnumerator GenerateMap()
    {
        while (_pathGenerated == false)
        {
            if (_mapGenerated == false)
            {
                for (int i = 0; i < _mapLenght; i++)
                {
                    _randomGenerator = Random.Range(2, 5);
                    _filtrage_etapes[0].SetActive(true);
                    _filtrage_etapes[3].SetActive(true);
                    _activeNodes += 2;
                    if (_randomGenerator == 3)
                    {
                        _filtrage_etapes[1].SetActive(true);
                        _activeNodes += 1;
                    }
                    if (_randomGenerator == 4)
                    {
                        _filtrage_etapes[1].SetActive(true);
                        _filtrage_etapes[2].SetActive(true);
                        _activeNodes += 2;
                    }
                    _randomBranch = Random.Range(0, 2);
                    if (_activeNodes == 3)
                    {
                        _trailMakers[0].transform.position = new Vector3(_filtrage_etapes[0].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[1].transform.position = new Vector3(_filtrage_etapes[0].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[2].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[1].transform.position.y, 19.0f);
                        _trailMakers[3].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[1].transform.position.y, 19.0f);
                        _trailMakers[4].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                        _trailMakers[5].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                        _trailMakers[6].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                        _trailMakers[7].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                    }
                    else if (_activeNodes == 4)
                    {
                        _trailMakers[0].transform.position = new Vector3(_filtrage_etapes[0].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[1].transform.position = new Vector3(_filtrage_etapes[0].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[2].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[1].transform.position.y, 19.0f);
                        _trailMakers[3].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[1].transform.position.y, 19.0f);
                        _trailMakers[4].transform.position = new Vector3(_filtrage_etapes[2].transform.position.x, _filtrage_etapes[2].transform.position.y, 19.0f);
                        _trailMakers[5].transform.position = new Vector3(_filtrage_etapes[2].transform.position.x, _filtrage_etapes[2].transform.position.y, 19.0f);
                        _trailMakers[6].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                        _trailMakers[7].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                    }
                    else
                    {
                        _trailMakers[0].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[1].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[2].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[3].transform.position = new Vector3(_filtrage_etapes[1].transform.position.x, _filtrage_etapes[0].transform.position.y, 19.0f);
                        _trailMakers[4].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                        _trailMakers[5].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                        _trailMakers[6].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                        _trailMakers[7].transform.position = new Vector3(_filtrage_etapes[3].transform.position.x, _filtrage_etapes[3].transform.position.y, 19.0f);
                    }

                    _activeNodes = 0;

                    for (int x = 0; x < 4; x++)
                    {
                        _filtrage_etapes.RemoveAt(0);
                    }


                    if (i == 3)
                    {
                        _mapGenerated = true;
                    }
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                _trailMakers[0].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _trailMakers[1].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _trailMakers[2].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _trailMakers[3].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _trailMakers[4].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _trailMakers[5].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _trailMakers[6].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _trailMakers[7].transform.position = new Vector3(_end.transform.position.x - 3, _end.transform.position.y, 19.0f);
                _pathGenerated = true;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    public void griseEtape(int _etapeActuelle)
    {
        if (_etapeActuelle == 0)
        {
            for (int i = 0; i <= 3; i++)
            {
                _button_etapes[i].GetComponent<Image>().color = Color.grey;
                _button_etapes[i].GetComponent<Button>().enabled = false;
            }
            for (int i = 4; i <= 7; i++)
            {
                _button_etapes[i].GetComponent<Image>().color = Color.white;
                _button_etapes[i].GetComponent<Button>().enabled = true;
            }
        }
        if (_etapeActuelle == 1)
        {
            for (int i = 4; i <= 7; i++)
            {
                _button_etapes[i].GetComponent<Image>().color = Color.grey;
                _button_etapes[i].GetComponent<Button>().enabled = false;
            }
            for (int x = 8; x <= 11; x++)
            {
                _button_etapes[x].GetComponent<Image>().color = Color.white;
                _button_etapes[x].GetComponent<Button>().enabled = true;
            }
        }
        else if (_etapeActuelle == 2)
        {
            for (int i = 8; i <= 11; i++)
            {
                _button_etapes[i].GetComponent<Image>().color = Color.grey;
                _button_etapes[i].GetComponent<Button>().enabled = false;
            }
            for (int x = 12; x <= 15; x++)
            {
                _button_etapes[x].GetComponent<Image>().color = Color.white;
                _button_etapes[x].GetComponent<Button>().enabled = true;
            }
        }
        else if (_etapeActuelle == 3)
        {
            for (int x = 12; x <= 15; x++)
            {
                _button_etapes[x].GetComponent<Image>().color = Color.grey;
                _button_etapes[x].GetComponent<Button>().enabled = false;
            }
            _end.GetComponent<Image>().color = Color.white;
            _end.GetComponent<Button>().enabled = true;
        }
    }
    
    public void griseBoutons(Button currentButton)
    {
        
        int etape = 0;
        int tabLenght = 0;
        for (int x = 0; x <= 3; x++)
        {
            if (currentButton == _button_etapes[x])
            {
                etape = 0;
            }
        }
        for (int x = 4; x <= 7; x++)
        {
            if (currentButton == _button_etapes[x])
            {
                etape = 1;
            }
        }
        for (int x = 8; x <= 11; x++)
        {
            if (currentButton == _button_etapes[x])
            {
                etape = 2;
            }
        }
        for (int x = 12; x <= 15; x++)
        {
            if (currentButton == _button_etapes[x])
            {
                etape = 3;
            }
        }
        if (etape == 0) 
        {
            tabLenght = _etape0Texts.Length;
        }
        else if (etape == 1)
        {
            tabLenght = _etape1Texts.Length;
        }
        else if (etape == 2)
        {
            tabLenght = _etape2Texts.Length;
        }
        else
        {
            tabLenght = _etape3Texts.Length;
        }

        int randomText = Random.Range(0, tabLenght);

        if (etape == 0)
        {
            _text.text = _etape0Texts[randomText];
            _start.GetComponent<Image>().color = Color.grey;
            for (int i = 0; i <= 3; i++)
            {
                if (_button_etapes[i] != currentButton)
                {
                    Image imageComponent = _button_etapes[i].GetComponent<Image>();
                    imageComponent.color = Color.grey;
                    Button buttonComponent = _button_etapes[i].GetComponent<Button>();
                    buttonComponent.enabled = false;
                }
            }
        }
        else if (etape == 1)
        {
            _text.text = _etape1Texts[randomText];
            for (int i = 4; i <= 7; i++)
            {
                if (_button_etapes[i] != currentButton)
                {
                    Image imageComponent = _button_etapes[i].GetComponent<Image>();
                    imageComponent.color = Color.grey;
                    Button buttonComponent = _button_etapes[i].GetComponent<Button>();
                    buttonComponent.enabled = false;
                }
            }
        }
        else if (etape == 2)
        {
            _text.text = _etape2Texts[randomText];
            for (int i = 8; i <= 11; i++)
            {
                if (_button_etapes[i] != currentButton)
                {
                    Image imageComponent = _button_etapes[i].GetComponent<Image>();
                    imageComponent.color = Color.grey;
                    Button buttonComponent = _button_etapes[i].GetComponent<Button>();
                    buttonComponent.enabled = false;
                }
            }
        }
        else
        {
            _text.text = _etape3Texts[randomText];
            for (int i = 12; i <= 15; i++)
            {
                if (_button_etapes[i] != currentButton)
                {
                    Image imageComponent = _button_etapes[i].GetComponent<Image>();
                    imageComponent.color = Color.grey;
                    Button buttonComponent = _button_etapes[i].GetComponent<Button>();
                    buttonComponent.enabled = false;
                }
            }
        }
    }

    public void griseMauvaisChemin(Button currentButton)
    {
        if (currentButton == _button_etapes[0] || currentButton == _button_etapes[1])
        {
            _button_etapes[7].GetComponent<Image>().color = Color.grey;
            _button_etapes[7].GetComponent<Button>().enabled = false;
            _button_etapes[6].GetComponent<Image>().color = Color.grey;
            _button_etapes[6].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[2] || currentButton == _button_etapes[3])
        {
            _button_etapes[4].GetComponent<Image>().color = Color.grey;
            _button_etapes[4].GetComponent<Button>().enabled = false;
            _button_etapes[5].GetComponent<Image>().color = Color.grey;
            _button_etapes[5].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[4] || currentButton == _button_etapes[5])
        {
            _button_etapes[10].GetComponent<Image>().color = Color.grey;
            _button_etapes[10].GetComponent<Button>().enabled = false;
            _button_etapes[11].GetComponent<Image>().color = Color.grey;
            _button_etapes[11].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[6] || currentButton == _button_etapes[7])
        {
            _button_etapes[8].GetComponent<Image>().color = Color.grey;
            _button_etapes[8].GetComponent<Button>().enabled = false;
            _button_etapes[9].GetComponent<Image>().color = Color.grey;
            _button_etapes[9].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[8] || currentButton == _button_etapes[9])
        {
            _button_etapes[14].GetComponent<Image>().color = Color.grey;
            _button_etapes[14].GetComponent<Button>().enabled = false;
            _button_etapes[15].GetComponent<Image>().color = Color.grey;
            _button_etapes[15].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[10] || currentButton == _button_etapes[11])
        {
            _button_etapes[12].GetComponent<Image>().color = Color.grey;
            _button_etapes[12].GetComponent<Button>().enabled = false;
            _button_etapes[13].GetComponent<Image>().color = Color.grey;
            _button_etapes[13].GetComponent<Button>().enabled = false;
        }

        if (currentButton == _button_etapes[0] && _button_etapes[4].gameObject.activeInHierarchy == true && _button_etapes[1].gameObject.activeInHierarchy == true)
        {
            _button_etapes[5].GetComponent<Image>().color = Color.grey;
            _button_etapes[5].GetComponent<Button>().enabled = false;
            _button_etapes[6].GetComponent<Image>().color = Color.grey;
            _button_etapes[6].GetComponent<Button>().enabled = false;
            _button_etapes[7].GetComponent<Image>().color = Color.grey;
            _button_etapes[7].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[1] && _button_etapes[5].gameObject.activeInHierarchy == true && _button_etapes[0].gameObject.activeInHierarchy == true)
        {
            _button_etapes[4].GetComponent<Image>().color = Color.grey;
            _button_etapes[4].GetComponent<Button>().enabled = false;
            _button_etapes[6].GetComponent<Image>().color = Color.grey;
            _button_etapes[6].GetComponent<Button>().enabled = false;
            _button_etapes[7].GetComponent<Image>().color = Color.grey;
            _button_etapes[7].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[2] && _button_etapes[6].gameObject.activeInHierarchy == true && _button_etapes[3].gameObject.activeInHierarchy == true)
        {
            _button_etapes[7].GetComponent<Image>().color = Color.grey;
            _button_etapes[7].GetComponent<Button>().enabled = false;
            _button_etapes[4].GetComponent<Image>().color = Color.grey;
            _button_etapes[4].GetComponent<Button>().enabled = false;
            _button_etapes[5].GetComponent<Image>().color = Color.grey;
            _button_etapes[5].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[3] && _button_etapes[7].gameObject.activeInHierarchy == true && _button_etapes[2].gameObject.activeInHierarchy == true)
        {
            _button_etapes[6].GetComponent<Image>().color = Color.grey;
            _button_etapes[6].GetComponent<Button>().enabled = false;
            _button_etapes[4].GetComponent<Image>().color = Color.grey;
            _button_etapes[4].GetComponent<Button>().enabled = false;
            _button_etapes[5].GetComponent<Image>().color = Color.grey;
            _button_etapes[5].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[4] && _button_etapes[8].gameObject.activeInHierarchy == true && _button_etapes[5].gameObject.activeInHierarchy == true)
        {
            _button_etapes[9].GetComponent<Image>().color = Color.grey;
            _button_etapes[9].GetComponent<Button>().enabled = false;
            _button_etapes[10].GetComponent<Image>().color = Color.grey;
            _button_etapes[10].GetComponent<Button>().enabled = false;
            _button_etapes[11].GetComponent<Image>().color = Color.grey;
            _button_etapes[11].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[5] && _button_etapes[9].gameObject.activeInHierarchy == true && _button_etapes[4].gameObject.activeInHierarchy == true)
        {
            _button_etapes[8].GetComponent<Image>().color = Color.grey;
            _button_etapes[8].GetComponent<Button>().enabled = false;
            _button_etapes[10].GetComponent<Image>().color = Color.grey;
            _button_etapes[10].GetComponent<Button>().enabled = false;
            _button_etapes[11].GetComponent<Image>().color = Color.grey;
            _button_etapes[11].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[6] && _button_etapes[10].gameObject.activeInHierarchy == true && _button_etapes[7].gameObject.activeInHierarchy == true)
        {
            _button_etapes[9].GetComponent<Image>().color = Color.grey;
            _button_etapes[9].GetComponent<Button>().enabled = false;
            _button_etapes[8].GetComponent<Image>().color = Color.grey;
            _button_etapes[8].GetComponent<Button>().enabled = false;
            _button_etapes[11].GetComponent<Image>().color = Color.grey;
            _button_etapes[11].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[7] && _button_etapes[11].gameObject.activeInHierarchy == true && _button_etapes[6].gameObject.activeInHierarchy == true)
        {
            _button_etapes[9].GetComponent<Image>().color = Color.grey;
            _button_etapes[9].GetComponent<Button>().enabled = false;
            _button_etapes[10].GetComponent<Image>().color = Color.grey;
            _button_etapes[10].GetComponent<Button>().enabled = false;
            _button_etapes[8].GetComponent<Image>().color = Color.grey;
            _button_etapes[8].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[8] && _button_etapes[12].gameObject.activeInHierarchy == true && _button_etapes[9].gameObject.activeInHierarchy == true)
        {
            _button_etapes[13].GetComponent<Image>().color = Color.grey;
            _button_etapes[13].GetComponent<Button>().enabled = false;
            _button_etapes[14].GetComponent<Image>().color = Color.grey;
            _button_etapes[14].GetComponent<Button>().enabled = false;
            _button_etapes[15].GetComponent<Image>().color = Color.grey;
            _button_etapes[15].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[9] && _button_etapes[13].gameObject.activeInHierarchy == true && _button_etapes[8].gameObject.activeInHierarchy == true)
        {
            _button_etapes[12].GetComponent<Image>().color = Color.grey;
            _button_etapes[12].GetComponent<Button>().enabled = false;
            _button_etapes[14].GetComponent<Image>().color = Color.grey;
            _button_etapes[14].GetComponent<Button>().enabled = false;
            _button_etapes[15].GetComponent<Image>().color = Color.grey;
            _button_etapes[15].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[10] && _button_etapes[14].gameObject.activeInHierarchy == true && _button_etapes[11].gameObject.activeInHierarchy == true)
        {
            _button_etapes[12].GetComponent<Image>().color = Color.grey;
            _button_etapes[12].GetComponent<Button>().enabled = false;
            _button_etapes[13].GetComponent<Image>().color = Color.grey;
            _button_etapes[13].GetComponent<Button>().enabled = false;
            _button_etapes[15].GetComponent<Image>().color = Color.grey;
            _button_etapes[15].GetComponent<Button>().enabled = false;
        }
        else if (currentButton == _button_etapes[11] && _button_etapes[15].gameObject.activeInHierarchy == true && _button_etapes[10].gameObject.activeInHierarchy == true)
        {
            _button_etapes[12].GetComponent<Image>().color = Color.grey;
            _button_etapes[12].GetComponent<Button>().enabled = false;
            _button_etapes[13].GetComponent<Image>().color = Color.grey;
            _button_etapes[13].GetComponent<Button>().enabled = false;
            _button_etapes[14].GetComponent<Image>().color = Color.grey;
            _button_etapes[14].GetComponent<Button>().enabled = false;
        }
    }

}
