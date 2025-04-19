# 🔒 DoorLock — A Stardew Valley SMAPI Mod

**DoorLock** is a simple SMAPI mod that restricts entry to cabins and the farmhouse based on each player's in-game house assignment. Only the assigned player can enter their designated home — everyone else will be politely (or not-so-politely) warped away.

## Features

- Automatically assigns cabins to players based on in-game save data
- Prevents unassigned players from entering other houses
- Warps unauthorized players back to the farm entrance
- Works in both single-player and multiplayer games
- No config needed — fully automatic

## How It Works

- Uses the game's internal cabin assignments and farmhouse ownership
- Runs automatically after the save is loaded
- Intercepts player warps to house locations and checks access
- Displays an in-game message when a player is denied entry

## Installation

1. Install [SMAPI](https://smapi.io)
2. Download or clone this repository
3. Copy the `DoorLock` folder into your `Stardew Valley/Mods/` directory
4. Launch the game via `SMAPI`

## Nexus Mods

This mod will be published on [Nexus Mods](https://www.nexusmods.com/stardewvalley) soon!  
Once available, you'll be able to download it directly from there, receive update notifications, and leave feedback.

Stay tuned for the release!

## Contributing

Contributions are welcome! If you'd like to improve the mod, fix bugs, or add features:

1. Fork the repository
2. Create a new branch
3. Make your changes
4. Submit a pull request (PR) with a clear description

> Please note: All changes to the `main` branch must go through a pull request and be reviewed. Direct pushes to `main` are restricted.

For feature suggestions or bug reports, feel free to open an issue!

## 📝 License

This project is licensed under the [MIT License](LICENSE).  
Feel free to use, modify, or build upon it — just give credit where it's due!

## 👤 Author

Developed by [Kenet Ortiz](https://github.com/KOrtizLedezma)

---

*Built with love for the Stardew Valley modding community.*
