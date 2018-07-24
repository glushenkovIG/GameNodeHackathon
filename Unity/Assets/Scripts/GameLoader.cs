using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using Com.Expload.Program;

public class GameLoader : MonoBehaviour {

    public Text text;
    public GameObject[] bodies;
    public GameObject[] wheels;
    public GameObject[] heads;

    public string leftPlayerAddress, rightPlayerAddress;
    public Vector3[] spawn = new Vector3[2];

    public void StopGame(CarController looser) {
        foreach (Rigidbody2D rb in FindObjectsOfType<Rigidbody2D>()) {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
        }

        text.text = !looser.isSecondPlayer ? "Left player won!" : "Right player won!";
        FightRequest leftPlayer = new FightRequest(ConvertHexStringToByteArray(leftPlayerAddress));
        FightRequest rightPlayer = new FightRequest(ConvertHexStringToByteArray(rightPlayerAddress));
        StartCoroutine(leftPlayer.Fight(!looser.isSecondPlayer ? leftPlayerAddress : rightPlayerAddress,
            looser.isSecondPlayer ? leftPlayerAddress : rightPlayerAddress));
        StartCoroutine(rightPlayer.Fight(!looser.isSecondPlayer ? leftPlayerAddress : rightPlayerAddress,
            looser.isSecondPlayer ? leftPlayerAddress : rightPlayerAddress));
    }

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name != "Fight")
            return;

        StartMenu menu = FindObjectOfType<StartMenu>();
        if (menu) {
            LoadCar(menu.bodySelected, menu.wheelSelected, menu.headSelected, false, spawn[0]);
            Destroy(menu.gameObject);
        }

        LoadRandomOpponent();
	}

    private void LoadRandomOpponent() {
        int body = UnityEngine.Random.Range(0, bodies.Length);
        int wheel = UnityEngine.Random.Range(0, wheels.Length);
        int head = UnityEngine.Random.Range(0, heads.Length);
        LoadCar(body, wheel, head, true, spawn[1]);
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name != "Fight")
            return;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Start");
        }
	}

    public GameObject LoadCar(int bodyId, int wheelId, int headId, bool isSecondPlayer, Vector3 pos) {
        GameObject car = Instantiate(bodies[bodyId]);
        car.transform.position = pos;
        CarController carController = car.GetComponent<CarController>();

        GameObject wheel1 = Instantiate(wheels[wheelId], car.transform);
        GameObject wheel2 = Instantiate(wheels[wheelId], car.transform);
        GameObject head = Instantiate(heads[headId], car.transform);
        carController.isSecondPlayer = isSecondPlayer;
        carController.wheel1.connectedBody = wheel1.GetComponent<Rigidbody2D>();
        carController.wheel2.connectedBody = wheel2.GetComponent<Rigidbody2D>();
        carController.head.connectedBody = head.GetComponent<Rigidbody2D>();

        return car;
    }

    private static byte[] ConvertHexStringToByteArray(string hexString) {
        if (hexString.Length % 2 != 0) {
            throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
        }

        byte[] HexAsBytes = new byte[hexString.Length / 2];
        for (int index = 0; index < HexAsBytes.Length; index++) {
            string byteValue = hexString.Substring(index * 2, 2);
            HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        return HexAsBytes;
    }
}
