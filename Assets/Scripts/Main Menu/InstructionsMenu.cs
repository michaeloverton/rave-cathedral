using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    private int currentInstruction = 0;
    public List<GameObject> instructions;
    public GameObject nextButton;
    public GameObject prevButton;

    public void Confirm() {
        // Reset the instructions back to 0.
        instructions[currentInstruction].SetActive(false);

        currentInstruction = 0;
        instructions[currentInstruction].SetActive(true);
        nextButton.SetActive(true);
        prevButton.SetActive(false);

        // Deactivate the menu and go back to main.
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Next() {
        // Deactivate the current instruction.
        instructions[currentInstruction].SetActive(false);

        // Activate the next instruction.
        currentInstruction++;
        instructions[currentInstruction].SetActive(true);

        // If no more instructions, deactivate next button.
        if(currentInstruction == instructions.Count-1) {
            nextButton.SetActive(false);
        }

        if(currentInstruction != 0) {
            prevButton.SetActive(true);
        }
    }

    public void Prev() {
        // Deactivate the current instruction.
        instructions[currentInstruction].SetActive(false);

        // Activate the prev instruction.
        currentInstruction--;
        instructions[currentInstruction].SetActive(true);

        // If first instruction, deactivate prev button.
        if(currentInstruction == 0) {
            prevButton.SetActive(false);
            nextButton.SetActive(true);
        }
    }
}
