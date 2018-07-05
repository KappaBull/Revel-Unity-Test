# Revel+Unity Test
## Start the web server:
$ revel run myapp  
Go to http://localhost:9000/  
## Code Layout

The directory structure of a generated Revel application:

    conf/             Configuration directory
        app.conf      Main app configuration file
        routes        Routes definition file

    app/              App sources
        init.go       Interceptor registration
        controllers/  App controllers go here
        views/        Templates directory

    messages/         Message files

    public/           Public static assets
        css/          CSS files
        js/           Javascript files
        images/       Image files
        unity3d/      Unity Builded WebGL files
    wallbg/           Unity Project

    tests/            Test suites