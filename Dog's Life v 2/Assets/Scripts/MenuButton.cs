using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
	[SerializeField] public MenuButtonController menuButtonController;
	[SerializeField] public Animator animator;
	[SerializeField] public AnimatorFunctions animatorFunctions;
	[SerializeField] public int thisIndex;

    
    // Update is called once per frame
    void Update()
    {

        #region Button Animation
        if (menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1)
            {
				animator.SetBool ("pressed", true);
			}
            else if (animator.GetBool ("pressed"))
            {
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;

                //Redirect to next scene
                MainMenu menu = new MainMenu(menuButtonController.index);
			}
		}
        else
        {
			animator.SetBool ("selected", false);
		}
        #endregion
    }
}
