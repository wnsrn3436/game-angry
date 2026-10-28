# Angry

[한국어](README.ko.md)

A 2D shooting game where a red bird on the left of the screen moves up and down and uses charge shots to hit flocks of birds flying in from the right. As the score rises, enemies appear more often and the player grows bigger. Reaching 200 points wins the game.

<img src="docs/screenshots/screenshot-1.png" width="480" alt="In game">


## How to play

Open `source/` in Unity 2018.1.9f2 and run it from `Assets/01.Scene/MainMenu.unity`. Press the start button on the main menu to begin.

Some of the original graphics and sounds, listed below, were made by other people and are not included, because it has not been settled whether they can be redistributed in a public repo. The scenes and prefabs reference these files, so to get the original look and sound, place them at the paths in the table.

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

In a mobile build, you move with the on-screen joystick and fire by pressing and releasing the fire button.

The bullet grows with the charge bar, and a fully charged shot fires with a particle effect and passes through enemies. A partly charged bullet disappears when it hits an enemy. Each enemy hit is worth 0.5 points, and running into an enemy loses the game.


## How it works

**Difficulty and reward both come from the score.** Each enemy spawn interval is `Random.Range(0.3f, 1.0f) - GameMgr.instance.score / 150` seconds, so it gets shorter as the score rises. The player's size is reset every frame to `0.5 + score / 100`. A bigger body is also easier to hit, so the difficulty rises along with the score.

```csharp
transform.localScale = new Vector3(0.5f + (GameMgr.instance.score / 100), 0.5f + (GameMgr.instance.score / 100), 1.0f);
```

Player and enemy positions are handled in viewport coordinates. Every time the player moves, its viewport x is fixed at 0.1 and its y is clamped between 0 and 1, then converted back to world coordinates, which keeps it on screen. Enemies appear at viewport x 1 with a random y and fly left from an impulse.


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

CC BY-NC-ND 4.0. Unmodified copies may be shared for noncommercial purposes with attribution. Distributing modified versions and commercial use are not allowed. Bundled libraries, graphics, sounds, and maps made by other people keep their own rights. See [LICENSE](LICENSE).
