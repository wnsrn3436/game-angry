# Angry

A 2D shooting game where a red bird on the left of the screen moves up and down and hits flocks of birds flying in from the right with charge shots. As the score rises enemies come more often and the player grows bigger, and reaching 200 points wins the game.

<img src="docs/screenshots/screenshot-1.png" width="480" alt="In game">


## How to play

Open `source/` in Unity 2018.1.9f2 and play from `Assets/01.Scene/MainMenu.unity`. Press the start button on the main menu to begin.

The assets below from the original graphics and sounds were made by other people and are not included, since their redistribution in a public repo is not clearly allowed. The scenes and prefabs refer to these files, so place them at the listed paths to see and hear the game as in the original.

| Asset | Publisher | Path | Used in the original |
|---|---|---|---|
| Graphics asset `2DGamesAssets` (source to be confirmed) | To be confirmed | `Assets/04.Sprite/2DGamesAssets/` | Player, enemy, bullet, and background graphics and the player's flapping animation |
| `MainMenu.png`, `GameEnd.png`, `Button.png` (source to be confirmed) | To be confirmed | `Assets/04.Sprite/` | Main menu background, game end panel, and buttons |
| 8 Bit Retro Rampage: Free Edition | Red Button Audio | `Assets/07.Sound/8BitRetroRampage/` | Shot and enemy kill sounds |
| `MainBgm.mp3`, `GameBgm.mp3` (source to be confirmed) | To be confirmed | `Assets/07.Sound/` | Background music of the main menu and game scenes |

| Key | Action |
|---|---|
| Up and down arrow keys, W and S | Move up and down |
| Space | Hold to fill the charge bar, release to fire |

In a mobile build you move with the on-screen joystick and fire by pressing and releasing the fire button.

The bullet grows with the charge bar, and a fully charged shot fires with a particle effect and passes through enemies. A partly charged bullet disappears when it hits an enemy. Each enemy hit is worth 0.5 points, and running into an enemy loses the game.


## How it works

**Difficulty and reward both come from the score.** The enemy spawn interval is `Random.Range(0.3f, 1.0f) - GameMgr.instance.score / 150` seconds each time, so it gets shorter as the score rises, and the player's size is set again every frame to `0.5 + score / 100`. A bigger body is also easier to hit, so the score itself becomes the difficulty.

```csharp
transform.localScale = new Vector3(0.5f + (GameMgr.instance.score / 100), 0.5f + (GameMgr.instance.score / 100), 1.0f);
```

Player and enemy positions are handled in viewport coordinates. Every time the player moves, its viewport x is fixed to 0.1 and y is clamped between 0 and 1 before converting back to world coordinates, so it stays on screen. Enemies appear at viewport x 1 and a random y, and fly left from an impulse.


## Files

| Path | Content |
|---|---|
| `source/Assets/01.Scene/` | Main menu and game scenes |
| `source/Assets/02.Script/` | Player, bullet, enemy, enemy spawn, and game manager scripts |
| `source/Assets/03.Prefab/` | Player, bullet, enemy, and background prefabs |
| `source/Assets/04.Sprite/Bar.png` | Charge bar graphic |
| `source/Assets/05.Animation/`, `06.Material/` | Player animation and enemy material |
| `source/Assets/Standard Assets/` | CrossPlatformInput from Unity Standard Assets |
| `source/ProjectSettings/` | Unity 2018.1.9f2 project settings |
| `docs/screenshots/` | Screenshot |


## Credits

- Standard Assets (CrossPlatformInput): Unity Technologies. Used for the mobile joystick and input handling.


## License

CC BY-NC-ND 4.0. Unmodified copies may be shared for noncommercial purposes with attribution. Modified versions and commercial use are not allowed. Bundled libraries, graphics, sounds, and maps made by other people keep their own rights. See [LICENSE](LICENSE).
