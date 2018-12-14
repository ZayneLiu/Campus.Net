# Campus.Net

# API Server
  `./APIServer`
  数据库 API 服务器 采用`ASP.NET Core` Web API
  并采用 `Swagger` 作为API的文档页面 (项目在VS运行起来后) (https://localhost:5001/swagger/)[https://localhost:5001/swagger/]
  - 依赖项
    - `.NET Core SDK / Runtime >= 2.2`
      SDK安装包 `../Enviroment/dotnet-sdk-2.2.101-win-x64`
      Runtime安装包 `../Enviroment/dotnet-hosting-2.2.0-win`
    - `MongoDB Server >= 4.0` MongoDB 数据库服务
      安装包 `../Enviroment/mongodb-win32-x86_64-2008plus-signed.msi`
    - `MongoDB Compass Community Edition` MongoDB GUI
      安装包 `../Enviroment/mongodb-compass-community.exe`
  - 环境部署
    - 上述依赖安装后
    - 打开 VisualStudio 并
    

    将 `/APIServer/APIServer/appsetting.json`以及 `/APIServer/APIServer/appsettings.Development` 中MongoDB连接字符串
      ```json
      "ConnectionStrings": {
        "Campus_Net": "mongodb://127.0.0.1:27017"
      }
      ```

# UI
  `./campus_net/`
  UI 采用`Vue`全家桶，`Vue.js` `Vuex` `vue-router` etc.
  - 依赖项
  - 部署环境
    ```
    // cd 到UI项目根目录
    cd ./UI/campus_net/

    // xiangm

    ```
