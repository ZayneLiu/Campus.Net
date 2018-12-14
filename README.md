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
    - 打开 VisualStudio 并运行APIServer项目
    - 如果 VisualStudio 因版本问题，不能运行 `asp.net core` 的项目的话，请在确保安装 `dotnet core 2.2 sdk` 的前提下做如下尝试
      ```
      cd ./APIServer/
      // 复原依赖，并尝试build项目
      dotnet restore && dotnet build
      // 运行项目
      dotnet run --project ./APIServer
      ```
    - 如控制台报错与MongoDB相关，请检查 `./APIServer/APIServer/appsetting.json`以及 `/APIServer/APIServer/appsettings.Development` 中MongoDB连接字符串
      ```json
      "ConnectionStrings": {
        "Campus_Net": "mongodb://127.0.0.1:27017"
      }
      ```
    - 同时由于新安装的MongoDB没有需要的数据库的和集合，可能需要使用 MongoDB Compass 进行手动创建，结构如下
      - campus_net  (Database)
        - users     (Collection)
        - questions (Collection)
        - articles  (Collection)

# UI
  `./campus_net/`
  UI 采用`Vue`全家桶，`Vue.js` `Vuex` `vue-router` etc.
  运行后的页面地址 (http://localhost:8080)[http://localhost:8080]
  - 依赖项
  - 部署环境
    ```
    // cd 到UI项目根目录
    cd ./UI/campus_net/

    // 安装项目依赖
    npm install

    // 运行项目
    npm run serve
    ```
