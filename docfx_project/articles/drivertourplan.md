# Driver Tour Plan
Im Vorfeld muss die Person als Fahrer registriert sein, siehe hier [Registrieren als Fahrer](register.md)
## Schritt 1 : Einen TourPlan erstellen
### `POST /TourPlans`
### Model
An die Url wird folgendes Model gesendet, wichtig ist, dass das Feld `idDriver` zwar mitgesendet werden muss, aber nicht die aktuelle Id sein muss, das System erkennt selbst�ndig wechler Fahrer den Request stellt
```json
 {
  "idDriver": "id_not_needed",
  "departure": "2023-09-26T17:52:12.257Z",
  "stopRequests": 0,
  "eta": "00:15:00",
  "start": "string",
  "destination": "string",
  "message": "string",
  "currentLatitude": 50.08513701910111,
  "currentLongitude": 8.452825469725695
 }
```
### Response
```json
{
    "id": "id",
    "idDriver": "idDriver",
    "departure": "2023-09-26T17:52:12.257Z",
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
        "tourPlans": [
            null
        ]
    },
    "passengers": [],
    "passengerRequests": []
}
```

## Schritt 2 : Passenger Requests
### Schritt 2.1 : Anfragen erhalten
W�hrend der Laufzeit, kann der Fahrer jederzeit erfragen, ob sich Personen f�r seine Tour gemeldet haben und eine Mitfahrgelegenheit suchen
#### `GET /PassengerRequests/GetPassengerRequests`
Es m�ssen keine weiteren Parameter mitgeliefert werden, der Fahrer erh�lt dann folgenden Response, wenn es interessenten gibt
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
 Sollte das nicht der Fall sein, erh�lt er `Status404NotFound` zur�ck
### Schritt 2.2 : Anfragen Accepten oder Denien
Nachdem eine Person (Passagier) sich f�r eine Tour gemeldet hat, hat der Fahrer zwei M�glichkeiten, entweder er Aktzeptiert oder Verweigert die Mitfahrm�glichkeit
In beiden F�llen muss er das `PassengerRequest` Model zur�ck senden
<br/>
Die Api Calls w�ren `PUT AcceptRequest` und `PUT DenyRequest`
#### Model
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

