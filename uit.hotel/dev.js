const ngrok = require("ngrok");
const fs = require("fs");
const json = require("./appsettings.Development.json");
const { spawn } = require("child_process");

(async function() {
    switch (process.argv[2]) {
        case undefined:
            await host();
            runCommand("dev:dotnet");
            break;
        case "watch":
            await host();
            runCommand("dev:dotnet:watch");
            break;
        case "host":
            await host();
            break;
        default:
            throw new Error("Phải truyền vào host/watch/undefined");
    }
})();

function runCommand(command) {
    spawn("npm.cmd", ["run", command], { stdio: "inherit" })
        .on("error", error => console.log(error))
        .on("close", code =>
            console.log(`child process exited with code ${code}`)
        );
}

async function host() {
    const url = await ngrok.connect({
        log_format: "json",
        proto: "http",
        addr: 3000
    });

    json.MOMO.NOTIFY_URL = `${url}/api/payment/momo`;

    fs.writeFileSync(
        "appsettings.Development.json",
        JSON.stringify(json, null, 4)
    );

    console.log("[Start]:", url);
    console.log("[Setting]:\n", json);
}
