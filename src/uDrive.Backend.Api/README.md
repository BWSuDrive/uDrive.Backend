# uDrive.Backend.Api

## Zugang via Bearer Token, bsp. an Postman
`https://bwsudriverestapi.azurewebsites.net/api/RESTLogin` als `POST` eingeben. 
Bei **Body** als raw json folgendes :
```json
{
  "userName": "Secretary@udrive.de",
  "password": "SecretarySTrongPassword!2345",
  "email": "Secretary@udrive.de"
}
```
als response m�sste dann etwas in der Art rauskommen:
```json
{
    "success": true,
    "data": {
        "id": "userid",
        "userName": "Secretary@udrive.de",
        "firstname": "Secretary",
        "lastname": "Secretary",
        "email": "Secretary@udrive.de",
        "token": "genratedtokenextralong"
    },
    "message": "Login Successfull!"
}
```

Der Wert in Token wird kopiert und ein neuer Request erstellt. Zu testzwecken ist `https://bwsudriverestapi.azurewebsites.net/api/Weekdays` erreichbar, welches die Secretary brauch um angesprochen zu werden.
Bei Postman `Get` als Request Type ausw�hlen, bei `Authorization`, `Bearer Token` ausw�hlen und dort den vorher kopierten Token einf�gen.
Als Ergebniss sollte eine *(noch)* **leere** liste und der Response Code 200 kommen, da keine Wochentage in der Datenbank eingetragen sind. 

## Data migrations 
`dotnet ef migrations remove --project ..\..\uDrive.Backend.Model\` 
`dotnet ef migrations add NewMigration --project ..\..\uDrive.Backend.Model`