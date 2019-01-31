Zombie Architect
====
> Global Game Jam 2019

Zombie Architect is a game developed during Global Game Jam 2019 by Changbai Li & Jan Dornig.
In this game, two players train their own horde of zombies to push boxes, by demonstrating the activity themselves. The first player who pushed 20 boxes into goal area wins.
The zombies are trained via Imitation Learning, a functionality provided by Unity's ml-agent library.

## Installation

Because the gameplay requires running the training process, (and because it's a game jam and we only have 48 hours), Zombie Architect is not packaged as an executable, but rather played directly from the Unity editor.

To run Zombie Architect, you need to first install and set up ml-agent. Learn more about it at [README-ml-agent.md](README-ml-agent.md). Installation process documented at [docs/Installation.md](docs/Installation.md).

### Running the game

0. Make sure ml-agent is properly set up
1. First open `UnitySDK/Assets/Game/Scenes/Prototype 1.unity` in Unity. We will come back to this in a bit
2. Open an Anaconda Prompt
3. In the prompt, navigate to the root directory of this repo
4. Activate the ml-agent environment by running `activate ml-agents`
5. Launch the training process with `mlagents-learn config/online_bc_config.yaml --train --slow`
6. Press the :arrow_forward: button in Unity when the message _"Start training by pressing the Play button in the Unity Editor"_ is displayed on the screen