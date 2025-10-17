using UnityEngine;

public class Rotador : MonoBehaviour {
    void Update () {
        // Rota el objeto cada frame
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}