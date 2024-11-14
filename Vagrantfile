Vagrant.configure("2") do |config|
  # Ubuntu VM
  config.vm.define "ubuntu-vm" do |ubuntu|
    ubuntu.vm.box = "ubuntu/focal64"
    ubuntu.vm.network "forwarded_port", guest: 5000, host: 5001
    ubuntu.vm.hostname = "ubuntu-vm"
    ubuntu.vm.synced_folder ".", "/home/vagrant/CrossPlatformDevelopment-6"
    
    ubuntu.vm.provision "shell", inline: <<-SHELL
      # Оновлення пакетів
      sudo apt update && sudo apt upgrade -y
      
      # Завантаження та установка репозиторію Microsoft для .NET
      wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      sudo dpkg -i packages-microsoft-prod.deb
      sudo apt update
      
      # Установка .NET SDK 8.0
      sudo apt-get install -y dotnet-sdk-8.0
      
      # Додавання приватного NuGet репозиторію
      dotnet nuget add source http://192.168.56.1:5000/v3/index.json -n PrivateRepo

      # Інсталяція вашого пакету як `dotnet tool`
      dotnet tool install --global ssofia --version 1.0.0 --add-source http://192.168.56.1:5000/v3/index.json
    SHELL
  end

  # Windows VM
  config.vm.define "windows-vm" do |windows|
    windows.vm.box = "peru/windows-10-enterprise-x64-eval"
    windows.vm.network "forwarded_port", guest: 5000, host: 5002
    windows.vm.hostname = "windows-vm"
    windows.vm.synced_folder ".", "C:/vagrant/CrossPlatformDevelopment-6"
    
    windows.vm.provision "shell", inline: <<-SHELL
      # Установка Chocolatey для керування пакетами
      Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
      
      # Установка .NET SDK через Chocolatey
      choco install dotnet-sdk --version 8.0 -y

      # Додавання приватного NuGet репозиторію
      dotnet nuget add source http://192.168.56.1:5000/v3/index.json -n PrivateRepo

      # Інсталяція вашого пакету як `dotnet tool`
      dotnet tool install --global ssofia --version 1.0.0 --add-source http://192.168.56.1:5000/v3/index.json
    SHELL
  end

  # macOS VM (емуляція)
  config.vm.define "macos-vm" do |macos|
    macos.vm.box = "generic/macos11"
    macos.vm.network "forwarded_port", guest: 5000, host: 5003
    macos.vm.hostname = "macos-vm"
    macos.vm.synced_folder ".", "/Users/vagrant/CrossPlatformDevelopment-6"
    
    macos.vm.provision "shell", inline: <<-SHELL
      # Оновлення Homebrew і установка .NET SDK
      /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
      brew install --cask dotnet-sdk

      # Додавання приватного NuGet репозиторію
      dotnet nuget add source http://192.168.56.1:5000/v3/index.json -n PrivateRepo

      # Інсталяція вашого пакету як `dotnet tool`
      dotnet tool install --global ssofia --version 1.0.0 --add-source http://192.168.56.1:5000/v3/index.json
    SHELL
  end
end
