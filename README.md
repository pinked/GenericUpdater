# Generic Application Updater
The Generic Application Updater is a project that provides a simple and generic solution for updating applications on Windows. This updater ensures that the installer remains the same file, allowing it to download the latest version of the application and perform the installation at startup. Additionally, the updater checks for updates each time Windows logs in, ensuring that users always have access to the latest software updates.

## Features
- Automatically downloads and installs the latest version of the application.
- Maintains a consistent installer file, reducing the need for manual updates.
- Performs the installation process during system startup, minimizing disruption to users.
- Checks for updates on each Windows log in, ensuring users have the latest software version.

## Installation
To use the Generic Application Updater, follow these steps:

- Clone the repository or download the source code.
- Keep a text file online that has the URL for latest file.
- Update the install URL (to fetch the latest setup) in the main file.
- Add the application updater to the startup items on Windows.
- Ensure that the necessary permissions are set for the updater to download and install files.

## Configuration
Sample config text file that should be uploaded and kept updated.

```
>APP.exe;300;https://example.com/setup-v300.exe;
>App2.msi;102;https://example.com/app2-setup-v102.exe;
```
APP is the name of application, 300 is a sample version number, and third value is the URL for the latest install file.

## Usage
Once the Generic Application Updater is properly installed and configured, it will automatically check for updates and perform the installation process during system startup. Users will have the latest version of the application without the need for manual updates.

## Contributing
Contributions to the Generic Application Updater project are welcome! If you find any bugs, have feature requests, or would like to contribute code, please open an issue or submit a pull request to the GitHub repository.

## License
This project is licensed under the MIT License. Feel free to use, modify, and distribute the code within the terms of the license.

## Disclaimer
The Generic Application Updater is provided as-is without any warranty. The developers are not responsible for any damages or issues caused by the use of this updater. Use it at your own risk.

