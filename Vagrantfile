Vagrant.configure("2") do |config|
  # Вказуємо базовий образ Ubuntu 20.04
  config.vm.box = "ubuntu/focal64"
  config.vm.network "forwarded_port", guest: 5000, host: 5001  # Проксіювання порту для BaGet на хості
  config.vm.hostname = "ubuntu-vm"
  config.vm.synced_folder ".", "/home/vagrant/CrossPlatformDevelopment-6"
  
  # Налаштування провіжнінгу
  config.vm.provision "shell", inline: <<-SHELL
    # Оновлення пакетів
    sudo apt update && sudo apt upgrade -y
    
    # Завантаження та установка репозиторію Microsoft для .NET
    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    sudo apt update
    
    # Установка .NET SDK 8.0
    sudo apt-get install -y dotnet-sdk-8.0
    
    # Додавання приватного NuGet репозиторію
    dotnet nuget add source http://192.168.56.1:5000s/v3/index.json -n PrivateRepo

    # Інсталяція вашого пакету як `dotnet tool`
    dotnet tool install --global ssofia --version 1.0.0 --add-source http://192.168.56.1:5000/v3/index.json
  SHELL
end
