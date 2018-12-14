# Campus.Net

# API Server

`./APIServer`
数据库 API 服务器 采用`ASP.NET Core` Web API
并采用 `Swagger` 作为 API 的文档页面 (项目在 VS 运行起来后) [https://localhost:5001/swagger/](https://localhost:5001/swagger/)

- 依赖项

  - `.NET Core SDK / Runtime >= 2.2`

    - SDK 安装包 `dotnet-sdk-2.2.101-win-x64`
    - Runtime 安装包 `dotnet-hosting-2.2.0-win`
    - [下载地址](https://dotnet.microsoft.com/download)

  - `MongoDB Server >= 4.0` MongoDB 数据库服务

    - 安装包 `mongodb-win32-x86_64-2008plus_xxx.msi`
    - [下载地址](https://fastdl.mongodb.org/win32/mongodb-win32-x86_64-2008plus-ssl-4.0.4-signed.msi)

  - `MongoDB Compass Community Edition` MongoDB GUI
    - 安装包 `mongodb-compass-community.exe`
    - [下载地址](https://downloads.mongodb.com/compass/mongodb-compass-community-1.16.3-win32-x64.exe)

- 环境部署

  - 上述依赖安装后
  - 打开 VisualStudio 并运行 APIServer 项目
  - 如果 VisualStudio 因版本问题，不能运行 `asp.net core` 的项目的话

    请在确保安装 `dotnet core 2.2 sdk` 的前提下做如下尝试

    ```
    cd ./APIServer/
    // 复原依赖，并尝试build项目
    dotnet restore && dotnet build
    // 运行项目
    dotnet run --project ./APIServer
    ```

  - 如控制台报错与 MongoDB 相关

    请检查 `./APIServer/APIServer/appsettings.json`以及 `/APIServer/APIServer/appsettings.Development.json` 中 MongoDB 连接字符串

    ```json
    "ConnectionStrings": {
      "Campus_Net": "mongodb://127.0.0.1:27017"
    }
    ```

  - 同时由于新安装的 MongoDB 没有需要的数据库的和集合

        可能需要使用 MongoDB Compass 进行手动创建，结构如下

    - campus_net (Database)
      - users (Collection)
      - questions (Collection)
      - articles (Collection)

# UI

`./campus_net/`
UI 采用`Vue`全家桶，`Vue.js` `Vuex` `vue-router` etc.
运行后的页面地址 [http://localhost:8080](http://localhost:8080)

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
