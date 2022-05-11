using UnityEngine ;
using EasyUI.PickerWheelUI ;
using UnityEngine.UI ;

public class Demo : MonoBehaviour {

   [SerializeField] private Button uiSpinButton ;
   [SerializeField] private Text uiSpinButtonText ;
   [SerializeField] private PickerWheel pickerWheel ;
   [SerializeField] private GameObject CanvasWheel;
   [SerializeField] private Button CloseBtn;


   private void Start () {
      Initialize ();

      uiSpinButton.onClick.AddListener (() => {

         uiSpinButton.interactable = false ;
         uiSpinButtonText.text = "Spinning" ;

         pickerWheel.OnSpinEnd (wheelPiece => {
            Debug.Log (
               @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label
               + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
            ) ;

            uiSpinButton.interactable = true ;
            uiSpinButtonText.text = "Spin" ;
         }) ;

         pickerWheel.Spin () ;

      }) ;

   }

   public void Button(){
       CanvasWheel.SetActive(true);
   }

   void Initialize ( ) {
		CloseBtn.onClick.RemoveAllListeners ( );
		CloseBtn.onClick.AddListener ( OnCloseButtonClick );
    }
    //open canvas timer build 1:
	void OnCloseButtonClick ( ) {
		CanvasWheel.SetActive ( false );
	}

}