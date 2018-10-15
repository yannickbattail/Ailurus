# Ailurus

## installation
### requirement

- git (of course)
- build tool for c# .net core 2.1 (msbuild)

### get the source

```console
git clone https://github.com/yannickbattail/Ailurus.git
cd Ailurus/Ailurus/wwwroot/
rm ./.empty
git clone https://github.com/yannickbattail/fulgens-js.git .
```

### start

```console
cd ..
dotnet run
```

Wait a bit and then you should have (or an other port)

    Now listening on: http://localhost:61218
    Application started. Press Ctrl+C to shut down.

and now open you web browser to http://localhost:61218/index.html

adapt the port if needed

finaly in the login box, use the URL http://localhost:61218
