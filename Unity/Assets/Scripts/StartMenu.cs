using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public float scaleMultipluyer = 1.5f;
    public UnityEngine.UI.Dropdown dropHead;

    [HideInInspector]
    public int wheelSelected;
    [HideInInspector]
    public int bodySelected;
    [HideInInspector]
    public int headSelected;

    private GameObject visibleCar = null;


	// Use this for initialization
	void Start () {
        ReinitCarPreview();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnWheelSelected(int v) {
        wheelSelected = v;
        ReinitCarPreview();
    }
    public void OnBodySelected(int v) {
        bodySelected = v;
        ReinitCarPreview();
    }
    public void OnHeadSelected(int v) {
        headSelected = dropHead.value;
        ReinitCarPreview();
    }

    public void OnStartGame() {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Fight");
    }

    public void OnExitGame() {
        Application.Quit();
    }

    private void ReinitCarPreview() {
        if (visibleCar != null)
            Destroy(visibleCar);

        visibleCar = GetComponent<GameLoader>().LoadCar(bodySelected, wheelSelected, headSelected, false, Vector3.zero);
        visibleCar.GetComponent<Rigidbody2D>().isKinematic = true;
        visibleCar.transform.localScale *= scaleMultipluyer;
    }
}
