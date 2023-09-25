# Passagier Anfragen
Um als Passagier bei jemanden mitzufahren, muss die Person zuerst registriert sein, danach können folgende Anfragen gestellt werden.
## `GET /PassengerRequests/FilterDriversBy5kmRadius`
Mit dieser Anfrage, können Passagiere eine Liste erhalten, welche alle Fahrer innerhalb von 5 Kilometern ausgibt
### Send Model
```json
{
  "currentLatitude": 50.08486509467797, 
  "currentLongitude": 8.458661956343363
}
```
### Response 
```json
[
    {
        "distance": 0.26,
        "person": {
            "firstname": "Driver_Firstname_Test3",
            "lastname": "Lastname_Test2",
            "phoneNumber": "number",
            "email": "TestDriver3@udrive.de",
           ...
        },
        "driver": {
            "id": "id",
            "idDrivinglicense": "idDrivinglicense",
            "idPerson": "idPerson",
            "seats": 0,
            "idDrivinglicenseNavigation": null,
            "idPersonNavigation": null,
            "tourPlans": []
        },
        "tourPlan": {
            "id": "id",
            "idDriver": "idDriver",
            "departure": "2023-09-25T17:52:12.257",
            "stopRequests": 0,
            "eta": "00:15:00",
            "start": "string",
            "destination": "string",
            "message": "string",
            "currentLatitude": 50.08513701910111,
            "currentLongitude": 8.452825469725695,
            "driver": {
               ...
            },
            "passengers": [],
            "passengerRequests": []
        }
    }
]
```

## `GET /PassengerRequests/GetScheduledDrivers`
Mit dieser Anfrage, werden alle aktuellen Fahrer mit ihren geplanten Touren ausgegeben
### Response
```json
[
    {
        "id": "id",
        "idDrivinglicense": "idDrivinglicense",
        "idPerson": "idPerson",
        "seats": 0,
        "idDrivinglicenseNavigation": null,
        "idPersonNavigation": null,
        "tourPlans": [
            {
                "id": "id",
                "idDriver": "idDriver",
                "departure": "2023-09-25T17:52:12.257",
                "stopRequests": 0,
                "eta": "00:15:00",
                "start": "string",
                "destination": "string",
                "message": "string",
                "currentLatitude": 50.08513701910111,
                "currentLongitude": 8.452825469725695,
                "driver": null,
                "passengers": [],
                "passengerRequests": []
            },
            {
                "id": "id",
                "idDriver": "idDriver",
                "departure": "2023-09-26T17:52:12.257",
                "stopRequests": 0,
                "eta": "00:15:00",
                "start": "string",
                "destination": "string",
                "message": "string",
                "currentLatitude": 50.08513701910111,
                "currentLongitude": 8.452825469725695,
                "driver": null,
                "passengers": [],
                "passengerRequests": []
            }
        ]
    }
]
```

## `POST /PassengerRequests`
Um sich für eine Tour zu melden, wird ein `POST` an den Controller `PassengerRequets` gesendet. Die `ìdPerson` muss hierbei nicht korrekt sei, das System erkennt welche Person den Request stellt.

### Send Model
```json
{"idPerson": "idPerson",
  "idTourPlan": "idTourPlan",
  "message": "Stehe an der Ecke",
  "currentLatitude": 0,
  "currentLongitude": 0
}
```
### Response
```json
[
    {
        "id": "id",
        "idPerson": "idPerson",
        "idTourPlan": "idTourPlan",
        "message": "Stehe an der Ecke",
        "currentLatitude": 0,
        "currentLongitude": 0,
        "isPending": true,
        "isDenied": false,
        "person": {
            "firstname": "Passenger1_Firstname",
            "lastname": "Lastname_Passenger1",
            "email": "Passenger1@udrive.de",
            "phoneNumber": "number",

            ...
        },
        "tourPlan": null
    }
]
 ```
### Weitere 
Um die Anfrage zu ändern, können einfach die Endpunkte `PUT`, `PATCH`,`DELETE` und `GET` benutzt werden.
