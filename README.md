<p align="center">
  <a href="https://github.com/phamhongphuc/uit.hotel" target="_blank" rel="noopener noreferrer">
    <img width="100" src="https://raw.githubusercontent.com/phamhongphuc/uit.hotel/master/logo.png" alt="Logo">
  </a>
</p>

<p align="center">
  <a href="https://travis-ci.com/phamhongphuc/uit.hotel"><img src="https://travis-ci.com/phamhongphuc/uit.hotel.svg?branch=dev" alt="Build Status"></a>
  <a href="https://dev.azure.com/uit-team/hotel/_build"><img src="https://dev.azure.com/uit-team/hotel/_apis/build/status/Azure%20Devops%20Hotel?branchName=dev" alt="Build Status"></a>
  <a href="https://www.codefactor.io/repository/github/phamhongphuc/uit.hotel"><img src="https://www.codefactor.io/repository/github/phamhongphuc/uit.hotel/badge" alt="Codefactor"></a>
  <a href="https://culur.net"><img src="https://img.shields.io/website.svg?label=demo&url=https://culur.net" alt="culur.net"></a>
</p>
<p align="center">
  <a href="https://github.com/phamhongphuc/uit.hotel/issues"><img src="https://img.shields.io/github/issues/phamhongphuc/uit.hotel.svg" alt="Issues Status"></a>
  <a href="https://github.com/phamhongphuc/uit.hotel/network/members"><img src="https://img.shields.io/github/forks/phamhongphuc/uit.hotel.svg" alt="Forks Status"></a>
  <a href="https://github.com/phamhongphuc/uit.hotel/stargazers"><img src="https://img.shields.io/github/stars/phamhongphuc/uit.hotel.svg" alt="Issues Status"></a>
  <a href="https://github.com/phamhongphuc/uit.hotel/blob/master/LICENSE"><img src="https://img.shields.io/github/license/phamhongphuc/uit.hotel.svg" alt="License Status"></a>
  <a href="https://github.com/phamhongphuc/uit.hotel/releases"><img src="https://img.shields.io/github/languages/code-size/phamhongphuc/uit.hotel.svg" alt="Code Size"></a>
  <a href="https://github.com/phamhongphuc/uit.hotel/releases"><img src="https://img.shields.io/github/repo-size/phamhongphuc/uit.hotel.svg" alt="Repo Size"></a>

  <h1 align="center"><a href="https://github.com/phamhongphuc/uit.hotel">Hotel Management System</a></h1>
</p>

Hotel Management System (HMS) is an open-source web-based hotel management software, designed and built for guesthouses and small hotels.

<p align="center">
    <img width="1000" src="https://raw.githubusercontent.com/phamhongphuc/uit.hotel/dev/.github/img/login.png" alt="Login Screen">
    <img width="1000" src="https://raw.githubusercontent.com/phamhongphuc/uit.hotel/dev/.github/img/booking-detail.png" alt="Booking Detail Screen">
</p>

## Roadmap

- Visit [phamhongphuc/uit.hotel#339](https://github.com/phamhongphuc/uit.hotel/issues/339)

## Features

- The system features include:
  - Revenue Management.
  - Yield Management.
  - Booking management.
  - Day rate management.
  - Booking calendar.
  - Check ins & check outs management.
  - Invoices and receipts.
  - Accounting document reports.

_**Note**: Some features are currently in development._

## Getting Started

### Prerequisites

To build this application from source, you need to have many other requirements and take additional steps:

- **.NET Core SDKs** 2.2.203 (.NET Core 3.0 will not work due to the breaking change).
- **Node.JS** 10.16.0 or later.
- **Yarn** 1.19.2 or later.
- **Ngrok** account to public URLs for building webhook integrations.
- *Additions:* **Realm Studio** to open the database file.

### Setup

#### 1. Clone

Clone this repo to your local machine using

```bash
git clone https://github.com/phamhongphuc/uit.hotel
```

#### 2. Setup secret key

##### a. On your local

In `uit.hotel` folder, Create a file named `appsettings.Development.json` and update the content like below:

```json
{
    "MOMO": {
        "SECRET_KEY": "12345678123456781234567812345678",
        "ACCESS_KEY": "1234567812345678",
        "PARTNER_CODE": "MOMO123456123456",
        "NOTIFY_URL": "null"
    }
}
```

_**Note**: `SECRET_KEY`, `ACCESS_KEY` and `PARTNER_CODE` will come from [https://business.momo.vn/](https://business.momo.vn/). And `NOTIFY_URL` will automatically generate by script._

##### b. On any server

This system will start 2 servers, once for front-end (NodeJS), once for the back-end (DotNET Core).

You can create a file named `appsettings.Development.json` like section **2.a** for the back-end server but the best practice is setting up the environment variables like:

```text
MOMO_SECRET_KEY = 12345678123456781234567812345678
MOMO_ACCESS_KEY = 1234567812345678
MOMO_PARTNER_CODE = MOMO123456123456
MOMO_NOTIFY_URL = <your backend server url>/api/payment/momo
TIMEZONE = 7
```

With the `TIMEZONE` is your hotel location's timezone.

#### 3. Setup ngrok

_**Note:** This step is only necessary if you want to run it on your local machine._

Open any terminal and type:

```bash
ngrok authtoken 123456789123456789123456789_12345123451234512345
```

Running this command will add your account's auth token to your ngrok.yml file. You can get your auth token from [https://dashboard.ngrok.com/](https://dashboard.ngrok.com/)

#### 4. Install/Update dependencies

Run `yarn` command in both `uit.hotel` and `uit.hotel.client` folders.

### III. Running on your local

#### 1. Back-end

```bash
cd uit.hotel

# run ngrok & dotnet
yarn dev

# run ngrok & dotnet watch
yarn dev watch

# run ngrok only
yarn dev host

# run dotnet only
dotnet run

# run dotnet watch only
dotnet watch
```

#### 2. Unit test for back-end

_**Note:** Make sure that dotnet isn't running at the same time you run the unit test._

```bash
cd uit.hotel.test
dotnet test
```

#### 3. Front-end

```bash
cd uit.hotel.client

# build your application with webpack and minify the JS & CSS (for production)
yarn build

# start the server in production mode
yarn start

# launch a development server on localhost:8080 with hot-reloading
yarn dev

# run linter: eslint, stylelint
yarn lint

# run format code with eslint, stylelint & prettier
yarn type:fix

# generate graphql schema (start the back-end server first)
yarn gql
```

## Contributors

This project exists thanks to all the people who contribute.

<p>
  <a href="https://github.com/phamhongphuc"><img src="https://github.com/phamhongphuc.png?size=40" alt="phamhongphuc"></a>
  <a href="https://github.com/thaotram"><img src="https://github.com/thaotram.png?size=40" alt="thaotram"></a>
  <a href="https://github.com/Fijetso"><img src="https://github.com/Fijetso.png?size=40" alt="Fijetso"></a>
  <a href="https://github.com/nhutkhanhng"><img src="https://github.com/nhutkhanhng.png?size=40" alt="nhutkhanhng"></a>
</p>

## License

This project is licensed under the MIT License - see the [MIT licensed](./LICENSE) file for details.
