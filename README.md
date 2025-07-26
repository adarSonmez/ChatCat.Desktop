# ChatCat

A modern desktop chat application built with WPF and .NET 8, featuring a clean architecture with MVVM pattern and dependency injection.

## 🏗️ Architecture

ChatCat follows a clean architecture pattern with clear separation of concerns:

- **ChatCat.Desktop** - WPF presentation layer with custom controls and pages
- **ChatCat.Core** - Business logic, view models, and shared services

### Key Features

- **MVVM Pattern** - Full implementation with data binding and commands
- **Dependency Injection** - Microsoft.Extensions.DependencyInjection for IoC
- **Custom Controls** - Reusable WPF controls for chat interface
- **Modern UI** - Custom fonts (Lato) and FontAwesome icons
- **Service Locator** - Centralized dependency resolution

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 8 SDK
- Windows OS (WPF requirement)

## 🏛️ Project Structure
```
ChatCat/
├── ChatCat.Core/                      # Core business logic
│   ├── Commands/                      # ICommand implementations
│   ├── Constants/Enums/               # Application enumerations
│   ├── Extensions/                    # Service registration extensions
│   ├── Utils/
│   │   ├── IoC/                       # Dependency injection utilities
│   │   └── Locator/                   # Service locator pattern
│   └── ViewModels/
│       ├── Abstract/                  # Base view model classes
│       └── Concrete/                  # Feature-specific view models
│           ├── Auth/                  # Authentication view models
│           ├── Chat/                  # Chat-related view models
│           └── Message/               # Message handling view models
└── ChatCat.Desktop/                   # WPF presentation layer
    ├── Controls/                      # Custom WPF controls
    │   ├── Base/                      # Base control classes
    │   ├── AttachmentMenuControl      # File attachment interface
    │   ├── ChatInputControl           # Message input control
    │   ├── ChatTitleBarControl        # Chat header control
    │   ├── MessageListControl         # Message display control
    │   └── MessageListItemControl     # Individual message control
    ├── Extensions/                    # Desktop service registration
    ├── Fonts/                         # Custom fonts (Lato, FontAwesome)
    ├── Images/                        # Application assets
    └── Pages/                         # Application pages
        ├── ChatPage                   # Main chat interface
        └── RegisterPage               # User registration
```

## 🎨 UI Components

### Custom Controls

- **ChatInputControl** - Message composition with attachment support
- **MessageListControl** - Scrollable message history
- **MessageListItemControl** - Individual message rendering
- **ChatTitleBarControl** - Chat header with participant info
- **AttachmentMenuControl** - File attachment options

### Pages

- **LoginPage** - User authentication
![Login View](Images/login_view.png)
- **RegisterPage** - New user registration  
- **ChatPage** - Main chat interface
![Chat View](Images/chat_view.png)

## 🔧 Configuration

The application uses `appsettings.json` for configuration: { "Logging": { "LogLevel": { "Default": "Information" } } }


## 🏗️ Development

### Adding New Features

1. **View Models** - Add to `ChatCat.Core/ViewModels/Concrete/`
2. **Controls** - Add to `ChatCat.Desktop/Controls/`
3. **Pages** - Add to `ChatCat.Desktop/Pages/`
4. **Services** - Register in respective `Extensions/` folders

### Service Registration

Services are registered in:
- `ChatCat.Core/Extensions/` - Core services
- `ChatCat.Desktop/Extensions/` - Desktop-specific services

### Dependency Resolution

Use the `CoreLocator` class for accessing view models: var loginVM = CoreLocator.LoginPageVM; var applicationVM = CoreLocator.ApplicationVM;


## 🎯 Current Features

- ✅ User authentication (Login/Register)
- ✅ Navigation system
- ✅ Message display with timestamps
- ✅ Custom styling and fonts
- ✅ MVVM data binding
- ✅ Dependency injection setup

## 🔮 Planned Features

- [ ] Real-time messaging
- [ ] File attachments
- [ ] User profiles
- [ ] Group chats
- [ ] Message encryption
- [ ] Notifications

## 🛠️ Technologies Used

- **.NET 8** - Target framework
- **WPF** - Windows Presentation Foundation
- **Microsoft.Extensions.DependencyInjection** - IoC container
- **Microsoft.Extensions.Hosting** - Application hosting
- **Microsoft.Extensions.Logging** - Logging framework

## 📝 Code Style

The project follows standard C# conventions:
- XML documentation for public APIs
- Async/await for asynchronous operations
- MVVM pattern with INotifyPropertyChanged
- Dependency injection for loose coupling

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 🏢 Support

For support and questions, please open an issue in the repository.
