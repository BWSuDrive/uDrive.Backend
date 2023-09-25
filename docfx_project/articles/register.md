# Register as User
Für die Regestrierung muss ein `POST` request an `/Register` gehen
## Post Model
```json
{
  "userName": "Passenger1@udrive.de",
  "password": "pw",
  "email": "Passenger1@udrive.de",
  "firstname": "Passenger1_Firstname",
  "lastname": "Lastname_Passenger1",
  "phonenumber" : "number"
}
```
## Response
Der Response sieht ähnlich aus wie beim Login :
```json
{
    "success": true,
    "data": {
        "id": "id",
        "userName": "Passenger1@udrive.de",
        "firstname": "Passenger1_Firstname",
        "lastname": "Lastname_Passenger1",
        "email": "Passenger1@udrive.de",
        "token": "",
        "roles": [
            "Person"
        ]
    },
    "message": "Login Successfull!"
}
```

# Register as Driver 
Für die Registrierung als Fahrer, wird mindestens ein Account mit Secretary Role benötigt, dieser kann dann eine Person als Fahrer via Api registrieren
## Post Model `POST /AddDrivingLicenceWithNewDriver/personID`
Wichtig hierbei ist, in der URL die Id der Person anzugeben.
```json
{
  "expireDate": "2030-09-21T13:11:15.018Z",
  "licenceClass": "B",
  "seats" : 2
}
```
## Response
Als Response kommt nur die neue generierte Id des Fahrer(Drivers) raus
```json
"fa57449d-731c-47ed-a0cc-6d22155924f4"
```
