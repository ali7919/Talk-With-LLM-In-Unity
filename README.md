# Speech Recognition and LLM Inference for Unity

![image](https://github.com/user-attachments/assets/2aaaa26c-2dc7-4b9d-a261-0c792c0142a6)


This project combines speech recognition using the Whisper model and [Sentis](https://unity.com/products/sentis) with LLM inference using [LLMUnity](https://github.com/undreamai/LLMUnity) and the Google Gemma2 2b model, all running on-device in Unity.

## Project Setup

### Prerequisites

- Unity 2022.3.39 (recommended, but not required)
- [Git LFS](https://git-lfs.com/)

### Installation

1. **Do not download as a ZIP file**. Instead, use Git to clone the repository:

   ```
   git clone https://github.com/ali7919/Talk-With-LLM-In-Unity.git
   ```

2. Open the project in Unity (preferably version 2022.3.39).

3. Open the `Scenes/scene` file.

4. Click on "Import TMP Essentials" if prompted.

### Configuration

1. Download the Gemma 2 2b-it (8-bit quantized version) or any other LLM with .gguf format.
2. Place the downloaded LLM file in the `StreamingAssets` folder.
3. In the Unity scene, select the `LLM` GameObject and ensure the correct model is selected.

![image](https://github.com/user-attachments/assets/86855eb3-7e9e-45f0-adb2-0e0aca8798cf)


5. Download LogMelSepctro.onnx , AudioEncoder_Tiny.onnx and AudioDecoder_Tiny.onnx from [here](https://huggingface.co/unity/sentis-whisper-tiny/tree/main/ONNX) and vocab.json from [here](https://huggingface.co/unity/sentis-whisper-tiny/tree/main)
7. Place `vocab.json` in the `StreamingAssets` folder.
8. Place the ONNX models in the `SentisModels` folder.
9. In the Unity scene, select the `Sentis-Whisper` GameObject and assign each model as required.

![image](https://github.com/user-attachments/assets/d54d7ca9-110e-45a5-a477-cc855f89e9f0)


## Running the Project

Run the game
You have two options for input:
### Text Input:

Type your message in the input field.
Press Enter to send the message.

### Voice Input:
Click on the microphone icon to start recording.
Speak your message.
Click the microphone icon again when you're done speaking to send the message.


The application will process your input (either text or speech) and generate a response using the LLM.



