using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// オーディオソースを再生するためのコンポーネントを入れる
	AudioSource audioSource;

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	// Use this for initialization
	void Start(){

		//接触時の効果音再生用のために宣言
		audioSource =  GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}

	//トリガーモードで他のオブジェクトと接触した場合の処理（課題）
	void OnCollisionEnter2D(Collision2D other) {

		//キューブまたは地面に接触した場合（課題）
	if (other.gameObject.tag == "BoxTag" || other.gameObject.tag == "GroundTag") {
//			Debug.Log("True");
			audioSource.Play();
		}

		//ユニティちゃんに接触した場合（課題）
		if (other.gameObject.tag == "UnitychanTag") {
//			Debug.Log("False");
			audioSource.Stop();
		}                
	}
}
