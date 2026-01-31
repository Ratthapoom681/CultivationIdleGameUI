# Cultivation Idle Game

A Windows Forms-based idle cultivation game inspired by Eastern fantasy novels. Embark on a journey from mortal to immortal through meditation, alchemy, and sect management.

## 🎮 Game Features

### Core Gameplay
- **Real-time Cultivation System**: Passive and active Qi gathering with meditation mechanics
- **Multi-tiered Progression**: 9 cultivation realms from Mortal to Immortal, each with 10 levels
- **Dynamic UI Updates**: Real-time display of cultivation progress, resources, and status effects

### Advanced Systems
- **Sect Management**: Join 6 unique sects with different cultivation bonuses and requirements
- **Alchemy System**: Craft powerful pills using gathered herbs with recipe-based crafting
- **Mission System**: Complete sect missions for rewards and rare resources
- **Inventory Management**: Collect and manage herbs and pills with dynamic item tracking

## 🚀 Getting Started

### Prerequisites
- Windows 10/11 (x64)
- No additional runtime required (self-contained executable)

### Installation
1. Download the latest release from the Releases section
2. Extract the ZIP file to your desired location
3. Run `CultivationIdleGameUI.exe`

### Quick Start
1. Launch the game to begin your journey as a Mortal cultivator
2. Use **Cultivate** button for active cultivation (+10 Qi per click)
3. Enable **Meditation** for 50% cultivation rate bonus (30 seconds)
4. Join a sect when you meet the requirements
5. Complete missions and craft pills to accelerate your progress

## 🎯 Game Mechanics

### Cultivation Realms
1. **Mortal** → **Qi Condensation** → **Foundation Establishment**
2. **Core Formation** → **Nascent Soul** → **Golden Core**
3. **Nascent Divinity** → **Spirit Sovereign** → **Immortal**

### Breakthrough System
- Reach Level 10 in current realm
- Spend 1000 Spirit Stones
- Success rate: 60% + 5% per level above 10
- Failed breakthroughs reduce level by 2

### Available Sects
| Sect | Requirement | Bonus |
|------|-------------|--------|
| White Lotus Sect | Level 10, 500 stones | 1.2x cultivation |
| Black Demon Sect | Level 5, 1000 stones | 1.5x cultivation |
| Heavenly Sword Sect | Level 8, 750 stones | 1.3x cultivation |
| Mystic Alchemy Sect | Level 12, 600 stones | 1.1x cultivation |
| Thunder Bolt Sect | Level 7, 800 stones | 1.4x cultivation |

### Alchemy Recipes
- **Qi Gathering Pill**: 2x Ginseng + 1x Spirit Grass (Level 1, 80% success)
- **Breakthrough Pill**: 1x Blood Lotus + 2x Spirit Grass (Level 5, 60% success)
- **Divine Cultivation Pill**: 1x Void Flower + 1x Dragon Fruit + 2x Blood Lotus (Level 10, 40% success)

## 🛠️ Technical Details

### Built With
- **C#** - Programming language
- **.NET 10.0** - Framework
- **Windows Forms** - UI framework
- **Visual Studio 2022** - Development environment

### Architecture
- **Modular System Design**: Separate classes for Player, SectSystem, and AlchemySystem
- **Event-Driven UI**: Timer-based updates and responsive controls
- **Object-Oriented Patterns**: Encapsulated game logic with clear separation of concerns
- **Mathematical Modeling**: Balanced progression curves and probability calculations

### Project Structure
```
CultivationIdleGameUI/
├── Program.cs                 # Application entry point
├── MainForm.cs                # Main game interface
├── Player.cs                  # Player data and cultivation logic
├── SectSystem.cs              # Sect management and missions
├── AlchemySystem.cs           # Alchemy and recipe system
├── SectManagementForm.cs      # Sect selection interface
├── AlchemyForm.cs             # Alchemy crafting interface
└── CultivationIdleGameUI.csproj # Project configuration
```

## 📦 Build Instructions

### Development Setup
```bash
git clone <repository-url>
cd CultivationIdleGameUI
dotnet restore
dotnet build
```

### Creating Release Build
```bash
dotnet build -c Release
```

### Creating Self-Contained Executable
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

The resulting executable will be in: `bin\Release\net10.0-windows\win-x64\publish\CultivationIdleGameUI.exe`

## 🎮 Controls

### Main Interface
- **Cultivate**: Perform active cultivation (+10 Qi)
- **Meditate**: Enter meditation state for 50% rate bonus
- **Breakthrough**: Attempt realm advancement (requires Level 10, 1000 stones)
- **Sect Management**: Open sect selection menu
- **Alchemy**: Open alchemy crafting interface
- **Mission**: Complete sect mission for rewards

### Keyboard Shortcuts
- No keyboard shortcuts currently implemented (Windows Forms mouse interface)

## 🐛 Known Issues & Future Improvements

### Planned Features
- [ ] Auto-cultivation toggle
- [ ] Save/load game system
- [ ] More sects and recipes
- [ ] Sound effects and background music
- [ ] Achievements and statistics tracking
- [ ] Multi-language support

### Bug Reports
Please report any issues through the GitHub Issues page with:
- Description of the bug
- Steps to reproduce
- System information (Windows version)
- Screenshot if applicable

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

### Development Guidelines
- Follow existing code style and naming conventions
- Add comments for complex logic
- Test thoroughly before submitting
- Update documentation as needed

## 📞 Contact

Developed by: Ratthapoom681
- GitHub: github.com/Ratthapoom681
- Email: ratthapoom681@gmail.com

---

**Enjoy your cultivation journey! 🧘‍♂️✨**
