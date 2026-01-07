# Nightlight Nightmares - Installation Guide

A 2D Unity game where you play as Rosa with a flashlight, protecting her family's RV from creepy enemies in a dark park.
## Controls

- **WASD** or **Arrow Keys** - Move Rosa
- **Left Mouse Button** - Turn on flashlight (drains battery)

## Requirements

- **Unity Hub** (free)
- **Unity Editor version 2022.3.26f1** (specifically this version is required!)
- Windows or Mac

---

## Installation Steps

### 1. Install Unity Hub

Download and install Unity Hub:
- Go to: https://unity.com/download
- Click "Download Unity Hub"
- Install and open Unity Hub

### 2. Install Unity Editor 2022.3.26f1

In Unity Hub:
1. Click **"Installs"** tab on the left
2. Click **"Install Editor"**
3. Find and select **"2022.3.26f1"** from the list
    - If you don't see it, click "Archive" and search for it
4. Click **"Next"**
5. When asked to select modules, if you don't plan to export this game (or just want it to download faster), don't select any modules. If you don't have VS, download it too, but you can use JetBrains Rider too (What I'm using)
6. Click **"Install"** and wait (this takes 10-15 minutes)

**Direct link to 2022.3.26f1:**
https://unity.com/releases/editor/whats-new/2022.3.26

### 3. Download the Project

**Option A (Easier): Download ZIP**
1. Go to the GitHub repository: https://github.com/soppi24/NightlightNightmares.git
2. Click the green **"Code"** button
3. Click **"Download ZIP"**
4. Extract the ZIP file to a folder (e.g., `Documents/Unity Projects/`)


**Option B: Clone with Git, with your IDE of choice**
```bash
git clone https://github.com/soppi24/NightlightNightmares.git
```

### 4. Open Project in Unity

1. Open **Unity Hub**
2. Click the **"Projects"** tab
3. Click **"Add"** dropdown → **"Add project from disk"**
4. Navigate to the folder you just downloaded
5. Select the folder and click **"Add Project"**
6. The project should now appear in your Projects list
7. Click on it to open!

**First time opening takes 5-10 minutes** while Unity imports everything.

### 5. Run the Game

Once Unity Editor opens:
1. In the **Project** window (bottom), navigate to `Assets/Scenes/`
2. Double-click the main scene to open it (It's the ONLY scene there)
3. Click the **Play button** at the top center
4. The game should start!

## Troubleshooting

**"Version mismatch" warning?**
- The project was made in 2022.3.26f1
- You can try opening in a newer 2022.3.x version, but 2022.3.26f1 is recommended

**Unity crashes on first import?**
- Close Unity
- Delete the `Library` folder in the project directory
- Reopen the project in Unity Hub

**Can't find the scene?**
- Make sure you opened the correct folder (should contain `Assets`, `ProjectSettings`)
- Check `Assets/Scenes/` for scene files

**Project won't open?**
- Make sure you extracted the full ZIP (not just opened it!!)
- The folder should contain `Assets`, not another folder inside

## Credits

Created by:
 - Sophie Eruokwu - Technical Director
 - Rachael Eruokwu - Art Director