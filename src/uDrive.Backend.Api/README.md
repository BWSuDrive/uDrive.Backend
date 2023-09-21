# uDrive.Backend.Api

## Zugang via Bearer Token, bsp. an Postman

### Login
`https://https://bws-udriveapi.azurewebsites.net/Login` als `POST` eingeben. 
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
        "roles": [
            "Person", 
            etc.
        ],
        "token": "genratedtokenextralong"
    },
    "message": "Login Successfull!"
}
```
### Registrierung
`https://https://bws-udriveapi.azurewebsites.net/Register` als `POST` eingeben. 
Bei **Body** als raw json folgendes :
```json
{
  "userName": "Secretary@udrive.de",
  "password": "SecretarySTrongPassword!2345",
  "email": "Secretary@udrive.de",
  "Firstname":"Super",
  "Lastname":"Secretary"
}
```
als response müsste dann etwas in der Art rauskommen:
```json
{
    "success": true,
    "data": {
        "id": "userid",
        "userName": "Secretary@udrive.de",
        "firstname": "Super",
        "lastname": "Secretary",
        "email": "Secretary@udrive.de",
        "token": "genratedtokenextralong",
        "roles": [
            "Person"
        ]
    },
    "message": "User created successfully!"
}
```
Hierbei wird neu registrierten direkt die Rolle **Person** zugewiesen


Der Wert in Token wird kopiert und ein neuer Request erstellt. Zu testzwecken ist `https://bwsudriverestapi.azurewebsites.net/api/Weekdays` erreichbar, welches die Secretary brauch um angesprochen zu werden.
Bei Postman `Get` als Request Type auswählen, bei `Authorization`, `Bearer Token` auswählen und dort den vorher kopierten Token einfügen.
Als Ergebniss sollte eine *(noch)* **leere** liste und der Response Code 200 kommen, da keine Wochentage in der Datenbank eingetragen sind. 

## Data migrations 
`dotnet ef migrations remove --project ..\uDrive.Backend.Model\` 
`dotnet ef migrations add NewMigration --project ..\uDrive.Backend.Model`
`dotnet ef database update --project ..\uDrive.Backend.Model --connection "CONNECTION_STRING_IN_MARKS"`